using BookStore.Domain.Commands.Book;
using BookStore.Domain.Handlers;
using BookStore.Domain.Repository;
using BookStore.Shared.RequestResponse;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookHandler _bookHandler;
        private readonly IBookRepository _bookRepository;

        public BookController(BookHandler bookHandler, IBookRepository bookRepository)
        {
            _bookHandler = bookHandler;
            _bookRepository = bookRepository;
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

        [HttpDelete]
        public ActionResult<ResponseResult> Delete(Guid id)
        {
            return _bookHandler.Handle(new DeleteBookCommand { Id = id });
        }

        [HttpGet("{id}")]
        public ActionResult<ResponseResult> Get(Guid id)
        {
            var data = _bookRepository.GetNoTracking(id);
            return new ResponseResult("Operação realizada com sucesso", true, data);
        }

        [HttpGet]
        public ActionResult<ResponseResult> GetAll()
        {
            var data = _bookRepository.GetAll();
            return new ResponseResult("Operação realizada com sucesso", true, data);
        }
    }
}