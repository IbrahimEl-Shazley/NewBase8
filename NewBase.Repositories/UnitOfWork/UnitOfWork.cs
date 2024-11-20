using Microsoft.EntityFrameworkCore.Storage;
using NewBase.Context;
using NewBase.Core.Entities.UserTables;
using NewBase.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        private Dictionary<Type, object> repositories;

        public UnitOfWork(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _context = dbContext;
            //_userRepository = userRepository;
        }

        ~UnitOfWork()
        {
            _context.Dispose();
        }

  
        public TRepository Repository<TRepository>() where TRepository : IBaseRepository
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TRepository);

            if (!repositories.ContainsKey(type))
            {
                repositories[type] = _serviceProvider.GetService(typeof(TRepository));
            }

            return (TRepository)repositories[type];
        }

        public bool SaveChange()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangeAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IDbContextTransaction> Transaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }

    }

}
