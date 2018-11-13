namespace BookStore.Domain.Repository
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}