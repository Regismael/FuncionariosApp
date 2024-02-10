# FuncionariosApp API

Bem-vindo ao FuncionariosApp API! Este projeto é uma API ASP.NET que realiza operações CRUD de funcionários utilizando as bibliotecas Dapper e SqlData.Client.

## Configuração do Ambiente

Certifique-se de ter o [Visual Studio](https://visualstudio.microsoft.com/) instalado para abrir e executar o projeto. O projeto utiliza o ASP.NET Core.

## Configuração do Banco de Dados

O projeto utiliza o Dapper para interagir com o banco de dados SQL Server. Antes de executar o projeto, siga as etapas abaixo:

1. Crie um banco de dados no SQL Server chamado "BDFuncionariosApp".

2. Configure a string de conexão no arquivo `appsettings.json` com as informações do seu servidor SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=seu-servidor;Database=BDFuncionariosApp;Integrated Security=True;"
  },
  // ... outras configurações ...
}
