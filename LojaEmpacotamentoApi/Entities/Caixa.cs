using System.ComponentModel.DataAnnotations;

namespace LojaEmpacotamentoApi.Entities
{
    public class Caixa
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public float AlturaCm { get; set; }
        public float LarguraCm { get; set; }
        public float ComprimentoCm { get; set; }
        public float PesoMaxKg { get; set; }


        public float VolumeCm3 => AlturaCm * LarguraCm * ComprimentoCm;

        public ICollection<PedidoCaixa> Pedidos { get; set; }
    }

}
