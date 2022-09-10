using MP.ApiDotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; private set; }

        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp, price);
        }

        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(id < 0, "Id precisa ser maior que 0");
            Id = id;
            Validation(name, codErp, price);
        }

        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome do produto deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Código do produto deve ser informado");
            DomainValidationException.When(price < 0, "Preço do produto deve ser informado");

            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
