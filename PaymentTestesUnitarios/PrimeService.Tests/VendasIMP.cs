using PaymentApi.Entities;
using PaymentApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestesUnitarios.PrimeService.Tests
{
    internal class VendasIMP
    {
        public Venda VendasTeste1()
        {
            return new Venda
            {
                Id = 0,
                Data = new DateTime(2023, 01, 23, 10, 23, 00),
                ItensVendidos = new ProdutoIMP().CincoProdutos(),
                StatusVenda = EnumStatusVenda.AguardandoPagamento,
                Vendedor = new VendedorIMP().VendedoraJessica(),
            };
        }

        public Venda VendasTeste2()
        {
            return new Venda
            {
                Id = 0,
                Data = new DateTime(2023, 01, 05, 11, 47, 00),
                ItensVendidos = new ProdutoIMP().DoisProdutos(),
                StatusVenda = EnumStatusVenda.AguardandoPagamento,
                Vendedor = new VendedorIMP().VendedorRoberto(),
            };
        }
        
        public Venda VendasTeste3()
        {
            return new Venda
            {
                Id = 0,
                Data = new DateTime(2023, 01, 05, 11, 47, 00),
                ItensVendidos = new ProdutoIMP().QuatroProdutos(),
                StatusVenda = EnumStatusVenda.AguardandoPagamento,
                Vendedor = new VendedorIMP().VendedoraTatiane(),
            };
        }
     }
  }


    


