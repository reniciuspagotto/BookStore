using BookStore.Shared.EntityBase;
using BookStore.Shared.RequestResponse;

namespace BookStore.Shared.CommandHandler
{
    public interface IHandler<T>
    {
        ResponseResult Handle(T command);
    }
}
