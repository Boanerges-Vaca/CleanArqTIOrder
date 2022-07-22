using NorthWind.Entities.Interfaces;
using NorthWind.Repository.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repository.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly NorthWindContext context;

        public UnitOfWork(NorthWindContext context) =>
            this.context = context;

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();  
        }
    }
}
