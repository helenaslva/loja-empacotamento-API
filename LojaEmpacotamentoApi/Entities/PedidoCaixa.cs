using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaEmpacotamentoApi.Entities
{
    public class PedidoCaixa
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Pedido")]
        public Guid PedidoId { get; set; }

        [ForeignKey("Caixa")]
        public Guid CaixaId { get; set; }

        public Pedido Pedido { get; set; }
        public Caixa Caixa { get; set; }

        public ICollection<CaixaProduto> Produtos { get; set; }
    }

}
