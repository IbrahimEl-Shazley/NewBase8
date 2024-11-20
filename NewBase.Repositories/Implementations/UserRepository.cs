using AAITHelper;
using Microsoft.EntityFrameworkCore;
using NewBase.Context;
using NewBase.Core.Entities.Shared;
using NewBase.Core.Entities.UserTables;
using NewBase.Core.Models.DTO;
using NewBase.Repositories.Interfaces;
using System;
using System.Linq.Expressions;

namespace NewBase.Repositories.Implementations
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> MailExistsEdit(string email, string userId)
         => await _context.Users.AnyAsync(u => (u.Email == email) && u.Id != userId);
        public async Task<bool> MailExistsRegister(string email)
          => await _context.Users.AnyAsync(u => u.Email == email);


        public async Task<bool> PhoneExistsBeforEdit(string phone, string userId)
         => await _context.Users.AnyAsync(u => u.PhoneNumber == phone && u.Id != userId);


        public async Task<bool> PhoneExistsBeforeRegister(string phone)
            => await _context.Users.AnyAsync(u => u.PhoneNumber == phone);

        public async Task<int> GenerateCode()
        {
            //try
            //{
            //    int code = HelperNumber.GetRandomNumber(currentCode);
            //    var GetInfoSms = await _context.Settings.FirstOrDefaultAsync();
            //    if (GetInfoSms != null)
            //    {
            //        if (GetInfoSms.SenderName != "test")
            //        {
            //            code = HelperNumber.GetRandomNumber();
            //        }
            //    }
            //    return code;
            //}
            //catch (Exception )
            //{
            //    return 0;
            //}
            return 0;

        }

        public IQueryable<T> GetUser<T>(Expression<Func<T, bool>> predicate, bool withTracking = true) where T : class
        {
            var query = _context.Set<T>().AsQueryable();
            if (withTracking)
                return query.Where(PreparePredicate(predicate));
            else
                return query.Where(PreparePredicate(predicate)).AsNoTracking();
        }   
        
        public Task<T> UserFirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, bool withTracking = true) where T : class
        {
            var query = _context.Set<T>().AsQueryable();
            if (withTracking)
                return query.FirstOrDefaultAsync(PreparePredicate(predicate));
            else
                return query.FirstOrDefaultAsync(PreparePredicate(predicate));
        }
        public void UpdateUser<T>(T entity) where T : class
        {
            _context.Update<T>(entity);
        }
    }
}
