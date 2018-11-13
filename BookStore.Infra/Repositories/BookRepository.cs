using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Domain.Entities;
using BookStore.Domain.Repository;
using BookStore.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        protected readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public Book Get(Guid id)
        {
            return _context.Books.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.AsNoTracking().ToList().Where(p => p.Ativo == true).OrderBy(p => p.Title);
        }

        public Book GetByCode(string code)
        {
            return _context.Books.AsNoTracking().Where(p => p.Code.ToLower() == code.ToLower() && p.Ativo == true).FirstOrDefault();
        }

        public Book GetByTitle(string title)
        {
            return _context.Books.AsNoTracking().Where(p => p.Title.ToLower() == title.ToLower() && p.Ativo == true).FirstOrDefault();
        }

        public Book GetByTitleAndCode(string title, string code)
        {
            return _context.Books.AsNoTracking().Where(p => p.Title.ToLower() == title.ToLower() && p.Code.ToLower() == code.ToLower() && p.Ativo == true).FirstOrDefault();
        }

        public Book GetNoTracking(Guid id)
        {
            return _context.Books.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public void Save(Book entity)
        {
            _context.Add(entity);
        }

        public void Update(Book entity)
        {
            _context.Update(entity);
        }
    }
}