using BookStore.Shared.EntityBase;
using System;

namespace BookStore.Domain.Entities
{
    public class Book : Entity
    {
        public Book(Guid id, string name, string code, bool ativo)
        {
            NewOrSetIdEntity(id);

            Name = name;
            Code = code;
            Ativo = ativo;
        }

        public string Name { get; private set; }
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