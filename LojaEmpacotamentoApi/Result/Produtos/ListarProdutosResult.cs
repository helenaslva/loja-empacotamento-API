namespace LojaEmpacotamentoApi.Result.Produtos
{
    public class ListarCaixasResult
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public float AlturaCm { get; set; }
        public float LarguraCm { get; set; }
        public float ComprimentoCm { get; set; }
        public float PesoKg { get; set; }

    }
}
