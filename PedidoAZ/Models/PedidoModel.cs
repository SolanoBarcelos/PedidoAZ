using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoAZ.Models
{
    [Table("Pedido") ]
    public class PedidoModel
    {
        [Column("Id")]
        [Display(Name="Codigo")]
        public int Id { get; set; }

        [Column("Produto")]
        [Display(Name = "Produto")]
        public string Produto { get; set; }

        [Column("NomeCliente")]
        [Display(Name = "NomeCliente")]
        public string NomeCliente { get; set; }

        [Column("Endereco")]
        [Display(Name = "Endereco")]
        public string Endereco { get; set; }

        [Column("DataPedido")]
        [Display(Name = "DataPedido")]
        public string DataPedido { get; set; }

        [Column("Recebido")]
        [Display(Name = "Recebido")]
        public string Recebido { get; set; }
    }
}
