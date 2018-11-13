using BookStore.Domain.Commands.Book;
using BookStore.Domain.Handlers;
using BookStore.Domain.Repository;
using BookStore.Shared.RequestResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookHandler _bookHandler;
        private readonly IBookRepository _bookRepository;
        private IMemoryCache _cache;

        public BookController(BookHandler bookHandler, IBookRepository bookRepository, IMemoryCache cache)
        {
            _bookHandler = bookHandler;
            _bookRepository = bookRepository;
            _cache = cache;
        }

        [HttpPost]
        public ActionResult<ResponseResult> Save(CreateBookCommand command)
        {
            return _bookHandler.Handle(command);
        }

        [HttpPut]
        public ActionResult<ResponseResult> Update(UpdateBookCommand command)
        {
            return _bookHandler.Handle(command);
        }

        [HttpDelete("{id}")]
        public ActionResult<ResponseResult> Delete(Guid id)
        {
            return _bookHandler.Handle(new DeleteBookCommand { Id = id });
        }

        [HttpGet("{id}")]
        public ActionResult<ResponseResult> Get(Guid id)
        {
            var data = _cache.Get(id);

            if (data is null)
            {
                data = _bookRepository.GetNoTracking(id);
                _cache.Set(id, data, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(10)));
            }
            
            return new ResponseResult("Operação realizada com sucesso", true, data);
        }

        [HttpGet]
        public ActionResult<ResponseResult> GetAll()
        {
            var data = _cache.Get("Cache");

            if (data is null)
            {
                data = _bookRepository.GetAll();
                _cache.Set("Cache", data, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(20)));
            }

            return new ResponseResult("Operação realizada com sucesso", true, data);
        }
    }
}