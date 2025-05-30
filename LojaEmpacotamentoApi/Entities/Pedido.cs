using System.ComponentModel.DataAnnotations;

namespace LojaEmpacotamentoApi.Entities
{
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DataPedido { get; set; }

        public string Status { get; set; }

        public ICollection<PedidoProduto> Produtos { get; set; }

        public ICollection<PedidoCaixa> Caixas { get; set; }
    }

}
