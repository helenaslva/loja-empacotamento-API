using LojaEmpacotamentoApi.Entities;
using LojaEmpacotamentoApi.Models.Pedidos;
using LojaEmpacotamentoApi.Repository.Pedidos;
using LojaEmpacotamentoApi.Result.Caixas;
using LojaEmpacotamentoApi.Result.Pedidos;
using LojaEmpacotamentoApi.Result.Produtos;

namespace LojaEmpacotamentoApi.Handler.Pedidos
{
    public class PedidoHandler : IPedidoHandler
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<List<SalvarPedidoResult>> ProcessarPedidos(List<SalvarPedidoModel> pedidosModel)
        {
            var resultados = new List<SalvarPedidoResult>();

            foreach (var model in pedidosModel)
            {
                var pedidoId = Guid.NewGuid();
                var produtos = new List<Produto>();
                var pedidoProdutos = new List<PedidoProduto>();

                foreach (var produtoModel in model.Produtos)
                {
                    var produto = new Produto
                    {
                        Id = Guid.NewGuid(),
                        Nome = produtoModel.Nome,
                        AlturaCm = produtoModel.AlturaCm,
                        LarguraCm = produtoModel.LarguraCm,
                        ComprimentoCm = produtoModel.ComprimentoCm,
                        PesoKg = 0 
                    };

                    produtos.Add(produto);

                    pedidoProdutos.Add(new PedidoProduto
                    {
                        Id = Guid.NewGuid(),
                        PedidoId = pedidoId,
                        ProdutoId = produto.Id,
                        Quantidade = 1
                    });
                }

                // Aloca os produtos nas caixas disponíveis
                var caixasEmpacotadas = AlocarProdutos(produtos, pedidoId);

                // Cria o pedido
                var pedido = new Pedido
                {
                    Id = pedidoId,
                    DataPedido = model.DataPedido,
                    Status = model.Status
                };
                try
                {
                    await _pedidoRepository.SalvarPedido(pedido, pedidoProdutos, caixasEmpacotadas);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar pedido:");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException?.Message);
                    throw; // repropaga o erro se quiser manter o fluxo
                }

                

        
                var resultado = new SalvarPedidoResult
                {
                    PedidoId = pedido.Id,
                    CaixasUsadas = caixasEmpacotadas.Select(cx => new CaixaUsadaResult
                    {
                        NomeCaixa = cx.Caixa.Nome,
                        AlturaCm = cx.Caixa.AlturaCm,
                        LarguraCm = cx.Caixa.LarguraCm,
                        ComprimentoCm = cx.Caixa.ComprimentoCm,
                        Produtos = cx.Produtos.Select(p => new ProdutoEmpacotadoResult
                        {
                            Nome = p.Produto.Nome,
                            AlturaCm = p.Produto.AlturaCm,
                            LarguraCm = p.Produto.LarguraCm,
                            ComprimentoCm = p.Produto.ComprimentoCm
                        }).ToList()
                    }).ToList()
                };

                resultados.Add(resultado);
            }

            return resultados;
        }

        private List<PedidoCaixa> AlocarProdutos(List<Produto> produtos, Guid pedidoId)
        {
            var caixasDisponiveis = new List<Caixa>
            {
                new Caixa { Id = Guid.NewGuid(), Nome = "Caixa 1", AlturaCm = 30, LarguraCm = 40, ComprimentoCm = 80 },
                new Caixa { Id = Guid.NewGuid(), Nome = "Caixa 2", AlturaCm = 80, LarguraCm = 50, ComprimentoCm = 40 },
                new Caixa { Id = Guid.NewGuid(), Nome = "Caixa 3", AlturaCm = 50, LarguraCm = 80, ComprimentoCm = 60 },
            };

            var caixasEmpacotadas = caixasDisponiveis
                .Select(c => new PedidoCaixa
                {
                    Id = Guid.NewGuid(),
                    PedidoId = pedidoId,
                    CaixaId = c.Id,
                    Caixa = c,
                    Produtos = new List<CaixaProduto>()
                }).ToList();

            foreach (var produto in produtos)
            {
                var alocado = false;

                foreach (var caixa in caixasEmpacotadas)
                {
                    if (ProdutoCabeNaCaixa(produto, caixa.Caixa))
                    {
                        caixa.Produtos.Add(new CaixaProduto
                        {
                            Id = Guid.NewGuid(),
                            ProdutoId = produto.Id,
                            PedidoCaixaId = caixa.Id,
                            Produto = produto,
                            Quantidade = 1
                        });

                        alocado = true;
                        break;
                    }
                }

                if (!alocado)
                    throw new Exception($"Produto '{produto.Nome}' não cabe em nenhuma caixa disponível.");
            }

            return caixasEmpacotadas.Where(c => c.Produtos.Any()).ToList();
        }

        private bool ProdutoCabeNaCaixa(Produto produto, Caixa caixa)
        {
            var p = new[] { produto.AlturaCm, produto.LarguraCm, produto.ComprimentoCm }.OrderBy(x => x).ToArray();
            var c = new[] { caixa.AlturaCm, caixa.LarguraCm, caixa.ComprimentoCm }.OrderBy(x => x).ToArray();

            return p[0] <= c[0] && p[1] <= c[1] && p[2] <= c[2];
        }
    }
}
