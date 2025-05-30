using System.ComponentModel.DataAnnotations;

namespace LojaEmpacotamentoApi.Entities
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public float AlturaCm { get; set; }
        public float LarguraCm { get; set; }
        public float ComprimentoCm { get; set; }
        public float PesoKg { get; set; }

        public ICollection<PedidoProduto> Pedidos { get; set; }
        public ICollection<CaixaProduto> CaixaProdutos { get; set; }
    }

}
