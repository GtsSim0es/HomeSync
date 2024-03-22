using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSync.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        Task Rollback();
    }
}
