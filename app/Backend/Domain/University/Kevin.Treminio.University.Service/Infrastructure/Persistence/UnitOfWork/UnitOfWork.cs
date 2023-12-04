using Kevin.Treminio.University.Service.Domain.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityContext _context;

        public UnitOfWork(UniversityContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
