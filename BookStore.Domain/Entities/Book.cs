using BookStore.Shared.EntityBase;
using System;

namespace BookStore.Domain.Entities
{
    public class Book : Entity
    {
        public Book(Guid id, string title, string code, bool ativo)
        {
            NewOrSetIdEntity(id);

            Title = title;
            Code = code;
            Ativo = ativo;
        }

        public string Title { get; private set; }
        public string Code { get; private set; }
        public bool Ativo { get; private set; }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Desativar()
        {
            Ativo = false;
        }
    }
}