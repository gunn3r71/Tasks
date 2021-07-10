namespace API.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}