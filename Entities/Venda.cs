using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentApi.Enums;

namespace PaymentApi.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusVenda StatusVenda { get; set; }
        public Vendedor? Vendedor { get; set; }
        public List<Produto>? ItensVendidos { get; set; }
    }
}
