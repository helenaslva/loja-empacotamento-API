using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaEmpacotamentoApi.Entities
{
    public class CaixaProduto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("PedidoCaixa")]
        public Guid PedidoCaixaId { get; set; }

        [ForeignKey("Produto")]
        public Guid ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public PedidoCaixa PedidoCaixa { get; set; }
        public Produto Produto { get; set; }
    }

}
