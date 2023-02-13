using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Context;
using PaymentApi.Entities;
using PaymentApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
        public class VendaController : ControllerBase
    {
        private readonly PaymentContext _context;

        public VendaController(PaymentContext context)
        {
            _context = context;
        }


[HttpPost("RegistrarVenda")]
        public IActionResult RegistrarVenda([Required] int IdVendedor, [Required] DateTime Data, [Required] List<Produto> ProdutosVendidos)
        {
            Venda venda = new Venda();
            var vendedor = _context.Vendedores.Find(IdVendedor);

            if (vendedor is null)
                return NotFound("Vendedor não encontrado");

            if (ProdutosVendidos is null)
                return BadRequest("É preciso adicionar ao menos 1 produto");

            if (ProdutosVendidos.Count() == 0)
                return BadRequest("É preciso adicionar ao menos 1 produto");

            venda.StatusVenda = EnumStatusVenda.AguardandoPagamento;            
            venda.Vendedor = vendedor;
            venda.ItensVendidos = ProdutosVendidos;
            venda.Data = Data;
                       
            _context.Add(venda);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarVenda), new { id = venda.Id }, venda);
        }

        [HttpPut("AtualizarStatusPedido/{id}")]
        public IActionResult AtualizarVenda(int id, EnumStatusVenda status)
        {
            var venda = _context.Vendas.Find(id);

            if (venda is null)
                return NotFound();

            if(StatusTeste(venda.StatusVenda, status))
            {
                venda.StatusVenda = status;

                _context.Vendas.Update(venda);
                _context.SaveChanges();

                return Ok(venda);
            }
            else 
            {
                return BadRequest("Transição de Status Inválida!");
            }  
        }   


        [HttpGet("ConsultarVenda/{id}")]
        public IActionResult BuscarVenda(int id)
        {
            var vendaTest = _context.Vendas.Find(id);

            if (vendaTest is null)
                return NotFound();

            var venda = _context.Vendas.Where(x => x.Id == id)
                .Include(v => v.Vendedor).Include(i => i.ItensVendidos);

            return Ok(venda);
        }
         
            private bool StatusTeste(EnumStatusVenda StatusAnterior, EnumStatusVenda StatusNovo)
        {
            //De: Aguardando pagamento Para: Pagamento Aprovado
            //De: Aguardando pagamento Para: Cancelado
            if (StatusAnterior == EnumStatusVenda.AguardandoPagamento
                && (StatusNovo == EnumStatusVenda.PagamentoAprovado || StatusNovo == EnumStatusVenda.Cancelado))
            {
                return true;
            }
            //De: Pagamento Aprovado Para: Enviado para Transportadora
            //De: Pagamento Aprovado Para: Cancelado
            else if (StatusAnterior == EnumStatusVenda.PagamentoAprovado &&
                (StatusNovo == EnumStatusVenda.EnviadoParaTransportadora || StatusNovo == EnumStatusVenda.Cancelado))
            {
                return true;
            } 
            //De: Enviado para Transportador Para: Entregue
            else if (StatusAnterior == EnumStatusVenda.EnviadoParaTransportadora &&
               StatusNovo == EnumStatusVenda.Entregue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
 
