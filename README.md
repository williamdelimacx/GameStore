# 🎮 GameStore API

🚀 **GameStore** é uma API backend desenvolvida em **ASP.NET (.NET 8)** para gerenciar um sistema de loja de jogos — com funcionalidades para gerenciar jogos, categorias, usuários e operações relacionadas ao catálogo.

---

## 📌 Funcionalidades

- 📋 **CRUD de jogos**
- 🗂️ **Gestão de categorias**
- 🧑‍💻 **Endpoints para listagem e manipulação de dados**
- 🚀 Estrutura modular e organizada para fácil extensão

---

## 🛠️ Tecnologias

Este projeto foi desenvolvido com:

- 🧑‍💻 **C#**
- 🔧 **ASP.NET Web API**
- 📦 **.NET 8**
- 🗄️ **SQL Server**
- 🐳 **Docker**
- ☁️ **Azure Storage**
- 📁 **Arquitetura orientada a camadas**

---

## 📥 Pré-requisitos

Antes de rodar o projeto, você precisa ter instalado:

✔️ .NET SDK 8 ou superior  
✔️ Docker  
✔️ Um editor/IDE (VSCode, Visual Studio, Rider, etc.)

---

## ▶️ Como executar a aplicação

```bash
# Clone o repositório
git clone https://github.com/williamdelimacx/GameStore.git

# Entre na pasta da API
cd GameStore/GameStore.Api

# Restaurar dependências
dotnet restore

# Build
dotnet build

# Executar a aplicação
dotnet run
```

🐳 Infraestrutura (Docker)
Subindo o SQL Server
$sa_password = "[SA PASSWORD HERE]"

```bash
docker run `
  -e "ACCEPT_EULA=Y" `
  -e "MSSQL_SA_PASSWORD=$sa_password" `
  -p 1433:1433 `
  -v sqlvolume:/var/opt/mssql `
  -d --rm `
  --name mssql `
  mcr.microsoft.com/mssql/server:2022-latest
```

🔐 Configuração de Secrets
Connection String do SQL Server
```bash
$sa_password = "[SA PASSWORD HERE]"

dotnet user-secrets set "ConnectionStrings:GameStoreContext" `
"Server=localhost;Database=GameStore;User Id=sa;Password=$sa_password;TrustServerCertificate=True"
```
Connection String do Azure Storage
```bash
$storage_connstring = "[STORAGE CONN STRING HERE]"

dotnet user-secrets set "ConnectionStrings:AzureStorage" $storage_connstring
```
