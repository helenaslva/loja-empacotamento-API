using LojaEmpacotamentoApi.Entities;
using LojaEmpacotamentoApi.Models.Produtos;
using LojaEmpacotamentoApi.Repository.Produto;
using LojaEmpacotamentoApi.Shared;

namespace LojaEmpacotamentoApi.Handler.Produtos
{
    public class ProdutoHandler : IProdutoHandler
    {
        private readonly IProdutoRepository _repository;

        public ProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Output> SalvarProduto(SalvarProdutoModel produto)
        {
            var produtoOfc = new Produto()
            {
                Nome = produto.Nome,
                AlturaCm = produto.AlturaCm,
                LarguraCm = produto.LarguraCm,
                ComprimentoCm = produto.ComprimentoCm,
                PesoKg = produto.PesoKg
            };

            var salvo = _repository.SalvarProduto(produtoOfc);
            if (salvo != null)
            {
                return new Output() { IsSuccess = true, Message = "Produto salvo com sucesso!" };
            }
            else
            {
                return new Output() { IsSuccess = false, Message = "Algo deu errado no processo de salvamento do produto" };
            }
        }
    }
}
