using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace BookStore.Domain.Commands.Book
{
    public class DeleteBookCommand : Notifiable
    {
        public Guid Id { get; set; }
    }
}
