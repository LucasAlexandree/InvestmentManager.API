# Sistema de Gestão de Investimentos Pessoais

Este é um sistema para gestão e acompanhamento de investimentos, permitindo que os usuários visualizem o desempenho de suas carteiras, gerenciem ativos e registrem transações com eficiência.

## Funcionalidades

- **Autenticação e Cadastro**: Registro de usuários, login seguro com JWT e recuperação de senha.
- **Gerenciamento de Ativos**: Adição, edição e remoção de ativos (ações, fundos, etc.).
- **Transações**: Registro de compras e vendas de ativos com detalhes completos.
- **Dashboard**: Visão geral da carteira, gráficos de desempenho e alertas.
- **Análise de Desempenho**: Avaliação do retorno de cada ativo e comparação com benchmarks.
- **Rebalanceamento**: Sugestões de alocação de ativos e simulações de rebalanceamento.

## Tecnologias

- **Back-end**: .NET 8 (C#)
- **Arquitetura**: Domain-Driven Design (DDD)
- **API**: ASP.NET Core Web API
- **Autenticação**: JWT
- **Testes**: xUnit
- **Documentação**: Swagger/OpenAPI
- **Validação**: FluentValidation
- **Logging**: Serilog
- **Containerização**: Docker

## Instalação

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

### Configuração e Execução

1. Clone o repositório:
    ```bash
    git clone https://github.com/seu-usuario/nome-do-repositorio.git
    cd nome-do-repositorio
    ```

2. Configure a string de conexão no `appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=seu-servidor;Database=InvestmentManagerDB;User Id=seu-usuario;Password=sua-senha;"
    }
    ```

3. Execute as migrações e inicie o projeto:
    ```bash
    dotnet ef database update
    dotnet run --project InvestmentManager.API
    ```

4. Acesse a documentação da API: `http://localhost:5000/swagger`.

### Testes

Execute os testes unitários:
```bash
dotnet test
