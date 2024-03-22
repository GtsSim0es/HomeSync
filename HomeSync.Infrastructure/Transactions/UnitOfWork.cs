using HomeSync.Application.Interfaces;
using HomeSync.Infrastructure.Data.ApplicationDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSync.Infrastructure.Transctions
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Roolback()
        {

        }
    }
}
