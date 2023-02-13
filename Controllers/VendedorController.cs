using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Context;
using PaymentApi.Entities;
using System.ComponentModel.DataAnnotations;


namespace PaymentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {

        private readonly PaymentContext _context;

        public VendedorController(PaymentContext context)
        {
            _context = context;
        }

         [HttpPost("AdicionarVendedor")]
        public IActionResult AdicionarVendedor([Required] string Nome, [Required] string Cpf, [Required][EmailAddress] string Email, [Required] string Telefone)
        {
            Vendedor vendedor = new Vendedor();

            vendedor.Nome = Nome;
            vendedor.Cpf = Cpf;
            vendedor.Email = Email;
            vendedor.Telefone = Telefone;

            _context.Add(vendedor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarVendedor), new { id = vendedor.Id }, vendedor);
        }

        [HttpGet("BuscarVendedor/{id}")]
        public IActionResult BuscarVendedor(int id)
        {
            var vendedor = _context.Vendedores.Find(id);

            if (vendedor is null)
                return NotFound();

            return Ok(vendedor);
        }

        [HttpDelete("DeletarVendedor/{id}")]
        public IActionResult DeletarVendedor(int id)
        {
            var vendedor = _context.Vendedores.Find(id);

            if (vendedor is null)
                return NotFound();

            _context.Vendedores.Remove(vendedor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}







