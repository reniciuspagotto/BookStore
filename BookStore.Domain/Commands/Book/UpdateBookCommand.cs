using Flunt.Validations;

namespace BookStore.Domain.Commands.Book
{
    public class UpdateBookCommand : CreateBookCommand
    {
        public string Id { get; set; }

        public new void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsNotNullOrEmpty(Id, "Identificador", "Identificador não encontrado")
                    .IsNotNullOrEmpty(Title, "Nome", "Informe o nome do livro")
                    .IsNotNullOrEmpty(Code, "Código", "Informe o código do livro")
            );
        }
    }
}