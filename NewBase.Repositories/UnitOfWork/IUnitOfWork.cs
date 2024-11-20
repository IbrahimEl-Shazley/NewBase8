using Microsoft.EntityFrameworkCore.Storage;
using NewBase.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        TRepo Repository<TRepo>() where TRepo : IBaseRepository;
        bool SaveChange();
        Task<bool> SaveChangeAsync();
        Task<IDbContextTransaction> Transaction();

    }
}
