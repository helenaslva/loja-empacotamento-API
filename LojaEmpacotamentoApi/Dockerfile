FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Dependências necessárias para Microsoft.Data.SqlClient funcionar no Linux
RUN apt-get update && apt-get install -y libkrb5-dev libicu-dev libssl-dev

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia o projeto e o template de runtime
COPY ["LojaEmpacotamentoApi.csproj", "."]
COPY ["LojaEmpacotamentoApi.runtimeconfig.template.json", "."]
RUN dotnet restore "./LojaEmpacotamentoApi.csproj"

# Copia o restante do código
COPY . .
WORKDIR "/src/."

# Build do projeto
RUN dotnet build "LojaEmpacotamentoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaEmpacotamentoApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# Copia os arquivos publicados para o container final
COPY --from=publish /app/publish .

# Instala o debugger (opcional)
RUN apt-get update && apt-get install -y unzip curl \
    && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

# Inicia a aplicação
ENTRYPOINT ["dotnet", "LojaEmpacotamentoApi.dll"]
