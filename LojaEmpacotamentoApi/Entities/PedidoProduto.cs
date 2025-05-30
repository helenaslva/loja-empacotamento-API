using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaEmpacotamentoApi.Entities
{
    public class PedidoProduto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Pedido")]
        public Guid PedidoId { get; set; }

        [ForeignKey("Produto")]
        public Guid ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }

}
