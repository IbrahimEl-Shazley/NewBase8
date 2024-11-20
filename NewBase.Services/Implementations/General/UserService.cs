using NewBase.Core.Entities.UserTables;
using NewBase.Services.DTOs.Schema.SEC;
using NewBase.Services.Implementation;
using NewBase.Services.Interfaces.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Services.Implementations.General
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
