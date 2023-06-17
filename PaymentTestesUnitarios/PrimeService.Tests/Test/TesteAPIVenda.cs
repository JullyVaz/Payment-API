using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentApi.Context;
using PaymentApi.Entities;
using PaymentApi.Controllers;
using PaymentApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PaymentTestesUnitarios.PrimeService.Tests;


namespace PaymentTestesUnitarios.PrimeService.Tests.Test
{
    public class TesteAPIVenda
    {
        private readonly PaymentContext _context;
        VendaController _vendaController;

        public TesteAPIVenda()
        {
          var options = new DbContextOptionsBuilder<PaymentContext>()
                .UseInMemoryDatabase(databaseName:"DbSstore")
                .options;

            _context = new PaymentContext(options);
                           
            _vendaController = new VendaController(_context);

            //Teste com 2 vendedores
            _context.Vendedores.Add(new VendedorIMP().VendedoraJessica());
            _context.Vendedores.Add(new VendedorIMP().VendedoraTatiane());

            // iniciando as vendas
            _context.Vendas.Add(new VendasIMP().VendasTeste1());
            _context.Vendas.Add(new VendasIMP().VendasTeste3());
            _context.SaveChanges();
        }

        // Testes
        [Theory(DisplayName = "Teste Registrar Venda Ok")]
        [MemberData(nameof(DataProdutos))]
        public void TesteRegistrarVenda201Created(int IdVendedor, DateTime Data, List<Produto> ListaProdutos)
        {
            var resultado = _vendaController.RegistrarVenda(IdVendedor,
                Data, ListaProdutos);

            Assert.IsAssignableFrom<CreatedAtActionResult>(resultado);
        }
        

        [Fact(DisplayName = "Teste Registrar Venda NotFound Vendedor")]
        public void TesteRegistrarVendaE404()
        {
            var resultado = _vendaController.RegistrarVenda(200,
                DateTime.Now, new ProdutoIMP().DoisProdutos());

            Assert.IsAssignableFrom<NotFoundObjectResult>(resultado);
        }

        [Fact(DisplayName = "Teste Registrar Venda Sem Produto")]
        public void TesteRegistrarVendaSemProdutoE400()
        {
            var resultado = _vendaController.RegistrarVenda(1,
                DateTime.Now, null);

            Assert.IsAssignableFrom<BadRequestObjectResult>(resultado);
        }


        [Fact(DisplayName = "Teste Buscar Venda")]
        public void TesteBuscarVenda200Ok()
        {
            var resultado = _vendaController.BuscarVenda(1);

            Assert.IsAssignableFrom<OkObjectResult>(resultado);          
        }

        [Fact(DisplayName = "Teste Atualizar Status de Aguardando Pagamento At Entregue")]
        public void TesteAtualizarStatusLinearAteEntregue200Ok()
        {
            _vendaController.AtualizarVenda(1, EnumStatusVenda.PagamentoAprovado);
            _vendaController.AtualizarVenda(1, EnumStatusVenda.EnviadoParaTransportadora);
            var resultado = _vendaController.AtualizarVenda(1, EnumStatusVenda.Entregue);

            Assert.IsAssignableFrom<OkObjectResult>(resultado);
        }

        [Fact(DisplayName = "Teste Atualizar Status de Aguardando Pagamento At Cancelado")]
        public void TesteAtualizarStatusLinearAteCancelado200Ok()
        {
            _vendaController.AtualizarVenda(2, EnumStatusVenda.PagamentoAprovado);
            var resultado = _vendaController.AtualizarVenda(2, EnumStatusVenda.Cancelado);

            Assert.IsAssignableFrom<OkObjectResult>(resultado);
        }

        [Theory(DisplayName = "Teste de Falha ao Atualizar Status")]
        [InlineData(EnumStatusVenda.EnviadoParaTransportadora)]
        [InlineData(EnumStatusVenda.Entregue)]
        public void TesteDeFalhaAoAtualizarStatusE400(EnumStatusVenda status)
        {
            _vendaController.AtualizarVenda(3, status);
            var resultado = _vendaController.AtualizarVenda(3, status);

            Assert.IsAssignableFrom<BadRequestObjectResult>(resultado);
        }

        //  mantendo o  theory do metodo registrar venda
        public static IEnumerable<object[]> DataProdutos()
        {
            yield return new object[]
            {
                1,
                new DateTime(2023, 01, 12),
                new ProdutoIMP().CincoProdutos()
            };
            yield return new object[]
            {
                2,
                new DateTime(2022, 12, 10),
                new ProdutoIMP().DoisProdutos()
            };
            yield return new object[]
            {
                1,
                new DateTime(2023, 01, 11),
                new ProdutoIMP().QuatroProdutos()
            };
            yield return new object[]
            {
                2,
                new DateTime(2022, 12, 02),
                new ProdutoIMP().TresProdutos()
            };

        }
    }

}


