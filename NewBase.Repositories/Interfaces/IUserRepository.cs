using NewBase.Core.DTOs;
using NewBase.Core.Entities.Shared;
using NewBase.Core.Entities.UserTables;
using NewBase.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository
    {
        Task<bool> MailExistsRegister(string email);
        Task<bool> PhoneExistsBeforeRegister(string phone);
        Task<bool> MailExistsEdit(string email, string userId);
        Task<bool> PhoneExistsBeforEdit(string phone, string userId);
        Task<int>  GenerateCode();
        //Task<ApplicationDbUser> AddUser(UserAddDto userInfoAddDTO);
        IQueryable<T> GetUser<T>(Expression<Func<T, bool>> predicate, bool withTracking = true) where T : class;
        Task<T> UserFirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, bool withTracking = true) where T : class; //params Expression<Func<T, object>>[] includes
        void UpdateUser<T>(T entity) where T : class;


    }
}
