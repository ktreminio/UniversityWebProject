namespace Kevin.Treminio.University.Service.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Dispose();
        Task<bool> SaveAsync();
    }
}
