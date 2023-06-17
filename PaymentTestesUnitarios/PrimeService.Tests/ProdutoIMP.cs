using PaymentApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PaymentTestesUnitarios.PrimeService.Tests

{
    internal class ProdutoIMP
    
    {
                public List<Produto> CincoProdutos()
        {
            return new List<Produto>
            {
                new Produto
                {
                    Id = 0,
                    Descricao = "Cafeteira",
                    Quantidade = 1,
                    Valor = 300.00M
                },
                new Produto
                {
                    Id = 0,
                    Descricao = "Tenis",
                    Quantidade = 1,
                    Valor = 800.00M
                },
                new Produto
                {
                    Id = 0,
                    Descricao = "Air Fryer",
                    Quantidade = 1,
                    Valor = 700.00M
                },
                new Produto
                {
                    Id = 0,
                    Descricao = "Guarda roupa",
                    Quantidade = 1,
                    Valor = 2000.00M
                },
                new Produto
                {
                    Id = 0,
                    Descricao = "Secador de cabelo",
                    Quantidade = 1,
                    Valor = 250.00M
                }  
            };
        }
        public List<Produto> QuatroProdutos()
        {
            return new List<Produto>
            {
                new Produto
                {
                    Id = 0,
                    Descricao = "Sofá",
                    Quantidade = 1,
                    Valor = 3000.00M
                },
                new Produto
                {
                    Id = 0,
                    Descricao = "Notebook",
                    Quantidade = 1,
                    Valor = 5000.00M
                },
                new Produto
                {
                    Id = 0,
                    Descricao = "Ferro de passar",
                    Quantidade = 1,
                    Valor = 450.00M
                },
                new Produto
                {
                    Id = 0,
                    Descricao = "Aspirador de pó",
                    Quantidade = 1,
                    Valor = 500.00M
                }
            };
        }




        public List<Produto> TresProdutos()
        {
            return new List<Produto>
            {
                new Produto
                {
                    Id = 0,
                    Descricao = "Mesa de Centro",
                    Quantidade = 1,
                    Valor = 350.00M
                },
                new Produto
                {
                    Id = 0,
                    Descricao = "Cômoda",
                    Quantidade = 1,
                    Valor = 500.00M
                },
                new Produto
                {
                    Id = 0,
                    Descricao = "Máquina de Lavar Louças",
                    Quantidade = 1,
                    Valor = 2000.00M
                },
            };
        }

        public List<Produto> DoisProdutos()
        {
            return new List<Produto>
            {
                new Produto
                {
                    Id = 0,
                    Descricao = "Mesa de jantar",
                    Quantidade = 1,
                    Valor = 1500.00M
                },
                new Produto
                {
                    Id = 0,
                    Descricao = "Notebook",
                    Quantidade = 1,
                    Valor = 5000.00M
                } 
            };
        }
    }
}
