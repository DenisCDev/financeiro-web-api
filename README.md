# API Web para Cadastro de Receitas e Despesas
Esta é uma API Web desenvolvida em C# utilizando o framework .NET, Entity Framework Core e PostgreSQL para cadastro e gerenciamento de valores de receita e despesas. Além disso, a API inclui funcionalidades para visualização de dados por meio de gráficos utilizando a biblioteca Chart.js.

## Funcionalidades
- Cadastro de Receitas e Despesas: Permite adicionar novos registros de receita e despesa, incluindo nome, valor e data.
- [Em desenvolvimento] Visualização de Dados: Apresenta gráficos com a distribuição dos valores de receita e despesa ao longo do tempo.
- [Em desenvolvimento] Gerar relatório por mês da receita/despesa do período

## Conceitos de Código
- POO
- SOLID
  
## Tecnologias Utilizadas
- Linguagem de Programação: C#
- Framework: .NET
- Banco de Dados: PostgreSQL
- ORM (Object-Relational Mapping): Entity Framework Core
- Biblioteca de Gráficos: Chart.js

## Requisitos
Visual Studio 2022
PostgreSQL4
(Recomendando rodar no edge ao executar código)

## Configuração
Clone o repositório para sua máquina local;
Certifique-se de ter o PostgreSQL instalado e configurado;
Configure a conexão com o banco de dados no arquivo appsettings.json;
Execute o comando dotnet ef database update para aplicar as migrações e criar o esquema do banco de dados;
Execute a aplicação.
