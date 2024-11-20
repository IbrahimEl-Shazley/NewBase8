using Microsoft.EntityFrameworkCore;
using NewBase.Context;
using NewBase.Core.Entities.SettingTables;
using NewBase.Integration.DTOs;
using NewBase.Integration.Services.Abstraction;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace NewBase.Integration.Services.Implementation
{
    public class SMSService : ISMSService
    {
        private readonly ApplicationDbContext _db;
        public SMSService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Send(SMSDTO dto)
        {
            Setting GetInfoSms = await _db.Settings.FirstOrDefaultAsync();
            if (GetInfoSms != null)
            {
                if (GetInfoSms.SenderName != "test")
                {
                    var resultSms = await SendMessageBy4jawaly(dto.Message.ToString(), dto.Number, GetInfoSms.SenderName, GetInfoSms.UserNameSms, GetInfoSms.PasswordSms);
                    return resultSms;
                }
            }
            return false;
        }

        public static async Task<bool> SendMessageBy4jawaly(string msg, string numbers, string senderName, string userName, string password)
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.4jawaly.net/");
            var res = (await client.GetAsync("api/sendsms.php?username=" + userName + "&password=" + password + "&numbers=" + numbers + "&sender=" + senderName + "&message=" + msg + "&&return=string"));

            return res.IsSuccessStatusCode;
        }
    }
}
