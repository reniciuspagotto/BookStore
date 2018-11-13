using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace BookStore.Domain.Commands.Book
{
    public class DeleteBookCommand : Notifiable, IValidatable
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsNotNullOrEmpty(Id, "Identificador", "Identificador não encontrado")
            );
        }
    }
}
