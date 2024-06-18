# API de Cadastro de Usuários com C#
### Objetivo
O objetivo deste projeto é criar uma API de cadastro de usuários utilizando a linguagem de programação C#.

### Funcionalidades
- Cadastro de novos usuários com nome, email e senha.
- Validação de dados de entrada.
- Armazenamento seguro dos dados utilizando um banco de dados SQL Server.

### Tecnologias Utilizadas
- ASP.NET Core
- Entity Framework Core
- SQL Server

### Como Utilizar
#### 1. Pré-requisitos

- Visual Studio 2019 ou superior
- SQL Server Management Studio (SSMS) para verificar o banco de dados
  
#### 2. Configuração do Projeto

- Clone este repositório para sua máquina local

``` git clone https://github.com/seu-usuario/nome-do-repositorio.git ```

### 3. Configuração do Banco de Dados

- Abra o SQL Server Management Studio (SSMS).
- Execute o script de criação do banco de dados (script.sql) disponível na pasta Database/.

### 4. Configuração do Projeto no Visual Studio

- Abra o projeto UserRegistrationAPI.sln no Visual Studio.
- Verifique e ajuste a string de conexão com o banco de dados em appsettings.json.

### 5. Executar o Projeto

- Pressione F5 para compilar e executar a aplicação no Visual Studio.
- A API estará disponível em https://localhost:44368 por padrão.

### 6. Testar a API
- Utilize o Postman ou qualquer outra ferramenta de API para testar as operações de cadastro de usuários.

## Contribuições
Contribuições são super bem-vindas! Sintam-se à vontade para enviar pull requests com melhorias, correções de bugs ou novas funcionalidades.
