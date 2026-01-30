using Microsoft.EntityFrameworkCore;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Secretaria> Secretarias => Set<Secretaria>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Perfil> Perfis => Set<Perfil>();
    public DbSet<Permissao> Permissoes => Set<Permissao>();
    public DbSet<PerfilPermissao> PerfisPermissoes => Set<PerfilPermissao>();
    public DbSet<UsuarioLotacao> UsuariosLotacoes => Set<UsuarioLotacao>();
    public DbSet<TipoProcesso> TiposProcesso => Set<TipoProcesso>();
    public DbSet<Edital> Editais => Set<Edital>();
    public DbSet<EditalEtapa> EditaisEtapas => Set<EditalEtapa>();
    public DbSet<FormularioSecao> FormulariosSecao => Set<FormularioSecao>();
    public DbSet<CampoConfig> CamposConfig => Set<CampoConfig>();
    public DbSet<CampoOpcao> CamposOpcao => Set<CampoOpcao>();
    public DbSet<RegraPontuacao> RegrasPontuacao => Set<RegraPontuacao>();
    public DbSet<RegraCondicao> RegrasCondicao => Set<RegraCondicao>();
    public DbSet<RegraResultado> RegrasResultado => Set<RegraResultado>();
    public DbSet<Candidato> Candidatos => Set<Candidato>();
    public DbSet<Inscricao> Inscricoes => Set<Inscricao>();
    public DbSet<Resposta> Respostas => Set<Resposta>();
    public DbSet<RespostaTexto> RespostasTexto => Set<RespostaTexto>();
    public DbSet<RespostaNumero> RespostasNumero => Set<RespostaNumero>();
    public DbSet<RespostaData> RespostasData => Set<RespostaData>();
    public DbSet<RespostaArquivo> RespostasArquivos => Set<RespostaArquivo>();
    public DbSet<InscricaoHistoricoStatus> InscricoesHistoricoStatus => Set<InscricaoHistoricoStatus>();
    public DbSet<BancaExaminadora> BancasExaminadoras => Set<BancaExaminadora>();
    public DbSet<BancaMembro> BancasMembros => Set<BancaMembro>();
    public DbSet<DistribuicaoAvaliacao> DistribuicoesAvaliacao => Set<DistribuicaoAvaliacao>();
    public DbSet<NotaItem> NotasItens => Set<NotaItem>();
    public DbSet<Recurso> Recursos => Set<Recurso>();
    public DbSet<RecursoAnalise> RecursosAnalise => Set<RecursoAnalise>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}
