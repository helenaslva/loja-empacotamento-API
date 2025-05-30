using LojaEmpacotamentoApi.Data;
using LojaEmpacotamentoApi.Entities;
using LojaEmpacotamentoApi.Handler.Caixas;
using LojaEmpacotamentoApi.Handler.Pedidos;
using LojaEmpacotamentoApi.Handler.Produtos;
using LojaEmpacotamentoApi.Repository.Caixas;
using LojaEmpacotamentoApi.Repository.Pedidos;
using LojaEmpacotamentoApi.Repository.Produto;
using LojaEmpacotamentoApi.Repository.Produtos;
using Microsoft.EntityFrameworkCore;

namespace LojaEmpacotamentoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ? Switches devem vir antes de tudo
            AppContext.SetSwitch("Switch.Microsoft.Data.SqlClient.DisableLogging", true);
            AppContext.SetSwitch("Switch.Microsoft.Data.SqlClient.UseLegacyExtendedTypes", false);
            AppContext.SetSwitch("Switch.Microsoft.Data.SqlClient.DisableConnectionPoolPerformanceCounters", true);

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IProdutoHandler, ProdutoHandler>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
            builder.Services.AddScoped<IPedidoHandler, PedidoHandler>();
            builder.Services.AddScoped<ICaixaRepository, CaixaRepository>();
            builder.Services.AddScoped<ICaixaHandler, CaixaHandler>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
