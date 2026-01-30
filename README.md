# Sistema Processos Seletivos

## Requisitos

- .NET SDK 9
- SQL Server (local)

## Configuração

Atualize a string de conexão em `SistemaProcessosSeletivos.API/appsettings.json` se necessário.

## Restaurar e compilar

```bash
dotnet restore

dotnet build
```

## Rodar a API

```bash
dotnet run --project SistemaProcessosSeletivos.API/SistemaProcessosSeletivos.API.csproj
```

## Migrations (EF Core)

Execute a partir da raiz da solução.

### Criar migration

```bash
dotnet ef migrations add <NomeDaMigration> \
  --project SistemaProcessosSeletivos.Infrastructure/SistemaProcessosSeletivos.Infrastructure.csproj \
  --startup-project SistemaProcessosSeletivos.API/SistemaProcessosSeletivos.API.csproj \
  --output-dir Data/Migrations \
  --context AppDbContext
```

### Aplicar no banco

```bash
dotnet ef database update \
  --project SistemaProcessosSeletivos.Infrastructure/SistemaProcessosSeletivos.Infrastructure.csproj \
  --startup-project SistemaProcessosSeletivos.API/SistemaProcessosSeletivos.API.csproj \
  --context AppDbContext
```

### Remover última migration (se necessário)

```bash
dotnet ef migrations remove \
  --project SistemaProcessosSeletivos.Infrastructure/SistemaProcessosSeletivos.Infrastructure.csproj \
  --startup-project SistemaProcessosSeletivos.API/SistemaProcessosSeletivos.API.csproj \
  --context AppDbContext
```
