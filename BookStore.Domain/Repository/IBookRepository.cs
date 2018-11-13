using BookStore.Domain.Entities;
using System.Collections.Generic;

namespace BookStore.Domain.Repository
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Book GetByTitleAndCode(string title, string code);
        Book GetByCode(string code);
        Book GetByTitle(string title);

    }
}