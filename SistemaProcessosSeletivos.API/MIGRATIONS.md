# Migrations (EF Core)

Execute os comandos a partir da raiz da solução.

## Criar uma migration

```bash
	dotnet ef migrations add <NomeDaMigration> --project SistemaProcessosSeletivos.Infrastructure\SistemaProcessosSeletivos.Infrastructure.csproj --startup-project SistemaProcessosSeletivos.API\SistemaProcessosSeletivos.API.csproj --output-dir Data/Migrations --context AppDbContext
```

## Aplicar no banco

```bash
	dotnet ef database update --project SistemaProcessosSeletivos.Infrastructure\SistemaProcessosSeletivos.Infrastructure.csproj --startup-project SistemaProcessosSeletivos.API\SistemaProcessosSeletivos.API.csproj --context AppDbContext
```

## Remover a última migration (se necessário)

```bash
dotnet ef migrations remove \
  --project SistemaProcessosSeletivos.Infrastructure\SistemaProcessosSeletivos.Infrastructure.csproj \
  --startup-project SistemaProcessosSeletivos.API\SistemaProcessosSeletivos.API.csproj \
  --context AppDbContext
```
