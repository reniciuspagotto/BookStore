using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Domain.Commands.Book
{
    public class CreateBookCommand : Notifiable, IValidatable
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Ativo { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsNotNullOrEmpty(Name, "Nome", "Informe o nome do livro")
                    .IsNotNullOrEmpty(Code, "Código", "Informe o código do livro")
            );
        }
    }
}