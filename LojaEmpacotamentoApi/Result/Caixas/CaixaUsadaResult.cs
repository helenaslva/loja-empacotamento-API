using LojaEmpacotamentoApi.Result.Produtos;

namespace LojaEmpacotamentoApi.Result.Caixas
{
    public class CaixaUsadaResult
    {
        public string NomeCaixa { get; set; } // Ex: "Caixa 1"
        public float AlturaCm { get; set; }
        public float LarguraCm { get; set; }
        public float ComprimentoCm { get; set; }

        public List<ProdutoEmpacotadoResult> Produtos { get; set; }
    }

}
