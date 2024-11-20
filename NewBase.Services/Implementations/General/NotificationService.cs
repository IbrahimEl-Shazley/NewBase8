using NewBase.Core.Entities.NOTIFIC;
using NewBase.Integration.DTOs;
using NewBase.Integration.Services.Abstraction;
using NewBase.Repositories.Interfaces;
using NewBase.Repositories.UnitOfWork;
using NewBase.Services.Interfaces.General;
using NewBase.Services.DTOs.General;
using NewBase.Services.ServiceHelpers;
using NewBase.Services.ServiceHelpers.EmailTemplates;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using NewBase.Core.Enums;
using NewBase.Service.Interfaces.General;
using NewBase.Service.Implementation.General;

namespace NewBase.Services.Implementation.General
{
    public class NotificationService : BaseService, INotificationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICurrentUserService _statlessSessionService;
        private readonly ISMSService _sMSService;
        private readonly IMailService _mailService;
        
        private readonly IBaseRepository _baseRepository;

        public NotificationService(IUnitOfWork uow, IConfiguration configuration, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _uow = uow;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _statlessSessionService = (ICurrentUserService)serviceProvider.GetService(typeof(ICurrentUserService));
            _sMSService = (ISMSService)serviceProvider.GetService(typeof(ISMSService));
            _mailService = (IMailService)serviceProvider.GetService(typeof(IMailService));
            _baseRepository = _uow.Repository<IBaseRepository>();
        }


        public async Task<bool> Send(Notification dto, NotificationTypeEnum notificationType)
        {
            Type type = typeof(ServicesAssembly).Assembly.GetType($"NewBase.Services.DTOs.General.{notificationType}");
            var inst = Activator.CreateInstance(type);
            if (inst.GetType().GetProperty(nameof(dto.To)) != null) inst.GetType().GetProperty(nameof(dto.To)).SetValue(inst, dto.To);
            if (inst.GetType().GetProperty(nameof(dto.Input)) != null) inst.GetType().GetProperty(nameof(dto.Input)).SetValue(inst, dto.Input);
            if (inst.GetType().GetProperty(nameof(dto.NotificationCategory)) != null) inst.GetType().GetProperty(nameof(dto.NotificationCategory)).SetValue(inst, dto.NotificationCategory);
            return await Send((Notification)inst);
        }

        public async Task<bool> Send(Notification dto)
        {
            switch (dto)
            {
                case SMS: return await SendSMS((SMS)dto);
                case Email: return await SendEmail((Email)dto);
                default: throw new NotImplementedException();
            }
        }


        #region private
        private async Task<bool> SendSMS(SMS dto)
        {
            return await _sMSService.Send(new SMSDTO
            {
                Message = dto.Input,
                Number = dto.To,
            });
        }

        private async Task<bool> SendEmail(Email dto)
        {
            INotificationTemplate templateLocator = _serviceProvider.GetService(NotificationTemplateLocator.Templates[dto.NotificationCategory]) as INotificationTemplate;
            NotificationTemplate template = await _baseRepository.FirstOrDefaultAsync<NotificationTemplate>(x => x.NotificationTypeId == (int)NotificationTypeEnum.Email && x.NotificationCategoryId == (int)dto.NotificationCategory);

            var mailMessage = new MailMessage(new MailAddress(NotificationHelper.FromEmail()), new MailAddress(dto.To))
            {
                Subject = NotificationHelper.LoadNotificationSubject(dto.NotificationCategory, _statlessSessionService.Language),
                Body = NotificationHelper.LoadNotificationBody(templateLocator, template, dto.Input, _statlessSessionService.Language),
                IsBodyHtml = true,
            };
            return await _mailService.Send(mailMessage);
        }
        #endregion
    }
}

