using LojaEmpacotamentoApi.Models.ProdutoPedido;
using System.ComponentModel.DataAnnotations;

namespace LojaEmpacotamentoApi.Models.Pedidos
{
    public class SalvarPedidoModel
    {
        public Guid Id { get; set; }

        public DateTime DataPedido { get; set; }

        public string Status { get; set; }

        public List<ProdutoPedidoModel> Produtos { get; set; }

    }
}
