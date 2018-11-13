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

            var books = _bookRepository.GetByTitleAndCode(command.Title, command.Code);
            var code = _bookRepository.GetByCode(command.Code);

            if (books != null)
                command.AddNotification("Titulo", "Título já cadastrado");

            if (code != null)
                command.AddNotification("Código", "Código já cadastrado");

            if(command.Invalid)
                return new ResponseResult("Erro ao inserir novo livro", false, null, command.Notifications);

            var book = new Book(Guid.Empty, command.Title, command.Code, command.Ativo);

            _bookRepository.Save(book);
            _unitOfWork.Commit();

            return new ResponseResult("Livro cadastrado com sucesso", true, book);
        }

        public ResponseResult Handle(UpdateBookCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResponseResult("Erro ao atualizar livro", false, null, command.Notifications);

            command.Validate();

            if (command.Invalid)
                return new ResponseResult("Erro ao inserir novo livro", false, null, command.Notifications);

            var books = _bookRepository.GetByTitleAndCode(command.Title, command.Code);
            var code = _bookRepository.GetByCode(command.Code);

            if (books != null && Guid.Parse(command.Id) != books.Id)
                command.AddNotification("Titulo", "Título já cadastrado");

            if (code != null && Guid.Parse(command.Id) != code.Id)
                command.AddNotification("Código", "Código já cadastrado");

            if (command.Invalid)
                return new ResponseResult("Erro ao inserir novo livro", false, null, command.Notifications);

            var book = new Book(Guid.Parse(command.Id), command.Title, command.Code, command.Ativo);

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