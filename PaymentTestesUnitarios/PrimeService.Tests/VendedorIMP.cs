using PaymentApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace PaymentTestesUnitarios.PrimeService.Tests
{
   internal class VendedorIMP
    {
        public Vendedor VendedoraJessica()
        {
            return new Vendedor
            {
                Id = 0,
                Nome = "Jessica",
                Cpf = "234.678.987-55",
                Email = "jessica@email.com",
                Telefone = "(81) 2345-7890"
            };               
        }

        public Vendedor VendedorRoberto()
        {
            return new Vendedor
            {
                Id = 0,
                Nome = "Roberto",
                Cpf = "987.098.543-23",
                Email = "robert@email.com",
                Telefone = "(31) 7890-9876"
            };
        }

            public Vendedor VendedoraTatiane()
        {
            return new Vendedor
            {
                Id = 0,
                Nome = "Tatiane",
                Cpf = "279.543.256-67",
                Email = "Tatiane@email.com",
                Telefone = "(19) 99142-9870"
            };
        }       
     }
  }    


    