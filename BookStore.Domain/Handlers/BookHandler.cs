using BookStore.Domain.Commands.Book;
using BookStore.Domain.Entities;
using BookStore.Domain.Repository;
using BookStore.Shared.CommandHandler;
using BookStore.Shared.RequestResponse;
using System;

namespace BookStore.Domain.Handlers
{
    public class BookHandler :
        IHandler<CreateBookCommand>,
        IHandler<UpdateBookCommand>,
        IHandler<DeleteBookCommand>
    {
        public readonly IBookRepository _bookRepository;
        public readonly IUnitOfWork _unitOfWork;

        public BookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public ResponseResult Handle(CreateBookCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResponseResult("Erro ao inserir novo livro", false, null, command.Notifications);

            var book = new Book(Guid.Empty, command.Name, command.Code, command.Ativo);

            _bookRepository.Save(book);
            _unitOfWork.Commit();

            return new ResponseResult("Livro cadastrado com sucesso", true, book);
        }

        public ResponseResult Handle(UpdateBookCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResponseResult("Erro ao atualizar livro", false, null, command.Notifications);

            var book = new Book(Guid.Parse(command.Id), command.Name, command.Code, command.Ativo);

            _bookRepository.Update(book);
            _unitOfWork.Commit();

            return new ResponseResult("Livro atualizado com sucesso", true, book);
        }

        public ResponseResult Handle(DeleteBookCommand command)
        {
            var book = _bookRepository.Get(command.Id);
            book.Desativar();
            _unitOfWork.Commit();

            return new ResponseResult("Livro excluído com sucesso", true, book);
        }
    }
}