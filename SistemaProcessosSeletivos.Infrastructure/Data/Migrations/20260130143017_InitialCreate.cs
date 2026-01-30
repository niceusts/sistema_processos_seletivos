using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaProcessosSeletivos.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AVALIACAO");

            migrationBuilder.EnsureSchema(
                name: "CONFIG");

            migrationBuilder.EnsureSchema(
                name: "EXECUCAO");

            migrationBuilder.EnsureSchema(
                name: "ACESSO");

            migrationBuilder.EnsureSchema(
                name: "JURIDICO");

            migrationBuilder.CreateTable(
                name: "InscricaoStatus",
                schema: "EXECUCAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TipoProcessoId = table.Column<int>(type: "int", nullable: false),
                    NumeroEdital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoHtml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicioInscricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFimInscricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusEdital = table.Column<int>(type: "int", nullable: false),
                    ConfiguracoesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscricaoStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                schema: "ACESSO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                schema: "ACESSO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                schema: "ACESSO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoProcesso",
                schema: "CONFIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    RequerVagaReserva = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RequerIntegracaoSalarial = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProcesso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "ACESSO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    SenhaHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UltimoLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfilPermissao",
                schema: "ACESSO",
                columns: table => new
                {
                    PerfilId = table.Column<long>(type: "bigint", nullable: false),
                    PermissaoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilPermissao", x => new { x.PerfilId, x.PermissaoId });
                    table.ForeignKey(
                        name: "FK_PerfilPermissao_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "ACESSO",
                        principalTable: "Perfil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PerfilPermissao_Permissao_PermissaoId",
                        column: x => x.PermissaoId,
                        principalSchema: "ACESSO",
                        principalTable: "Permissao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Secretaria",
                schema: "ACESSO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Sigla = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secretaria_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "ACESSO",
                        principalTable: "Tenant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Candidato",
                schema: "EXECUCAO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    NomeSocial = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Pcd = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PossuiCadUnico = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidato_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "ACESSO",
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Edital",
                schema: "CONFIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecretariaId = table.Column<long>(type: "bigint", nullable: false),
                    TipoProcessoId = table.Column<long>(type: "bigint", nullable: false),
                    NumeroEdital = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Titulo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    StatusEdital = table.Column<int>(type: "int", nullable: false),
                    DataInicioInscricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFimInscricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edital_Secretaria_SecretariaId",
                        column: x => x.SecretariaId,
                        principalSchema: "ACESSO",
                        principalTable: "Secretaria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Edital_TipoProcesso_TipoProcessoId",
                        column: x => x.TipoProcessoId,
                        principalSchema: "CONFIG",
                        principalTable: "TipoProcesso",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioLotacao",
                schema: "ACESSO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    SecretariaId = table.Column<long>(type: "bigint", nullable: false),
                    PerfilId = table.Column<long>(type: "bigint", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioLotacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioLotacao_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "ACESSO",
                        principalTable: "Perfil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuarioLotacao_Secretaria_SecretariaId",
                        column: x => x.SecretariaId,
                        principalSchema: "ACESSO",
                        principalTable: "Secretaria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuarioLotacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "ACESSO",
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EditalEtapa",
                schema: "CONFIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditalId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    TipoAvaliacao = table.Column<int>(type: "int", nullable: false),
                    EhEliminatoria = table.Column<bool>(type: "bit", nullable: false),
                    PesoPonderado = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditalEtapa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditalEtapa_Edital_EditalId",
                        column: x => x.EditalId,
                        principalSchema: "CONFIG",
                        principalTable: "Edital",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormularioSecao",
                schema: "CONFIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditalId = table.Column<long>(type: "bigint", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioSecao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormularioSecao_Edital_EditalId",
                        column: x => x.EditalId,
                        principalSchema: "CONFIG",
                        principalTable: "Edital",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inscricao",
                schema: "EXECUCAO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditalId = table.Column<long>(type: "bigint", nullable: false),
                    CandidatoId = table.Column<long>(type: "bigint", nullable: false),
                    ProtocoloGerado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StatusInscricao = table.Column<int>(type: "int", nullable: false),
                    NotaFinal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    ClassificacaoAtual = table.Column<int>(type: "int", nullable: true),
                    RowVer = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscricao_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalSchema: "EXECUCAO",
                        principalTable: "Candidato",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inscricao_Edital_EditalId",
                        column: x => x.EditalId,
                        principalSchema: "CONFIG",
                        principalTable: "Edital",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BancaExaminadora",
                schema: "AVALIACAO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditalEtapaId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancaExaminadora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BancaExaminadora_EditalEtapa_EditalEtapaId",
                        column: x => x.EditalEtapaId,
                        principalSchema: "CONFIG",
                        principalTable: "EditalEtapa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegraPontuacao",
                schema: "CONFIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditalEtapaId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TipoResultado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegraPontuacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegraPontuacao_EditalEtapa_EditalEtapaId",
                        column: x => x.EditalEtapaId,
                        principalSchema: "CONFIG",
                        principalTable: "EditalEtapa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CampoConfig",
                schema: "CONFIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormularioSecaoId = table.Column<long>(type: "bigint", nullable: false),
                    Label = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    VariavelCodigo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TipoDado = table.Column<int>(type: "int", nullable: false),
                    Obrigatorio = table.Column<bool>(type: "bit", nullable: false),
                    EhDadoSensivel = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Ordem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampoConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampoConfig_FormularioSecao_FormularioSecaoId",
                        column: x => x.FormularioSecaoId,
                        principalSchema: "CONFIG",
                        principalTable: "FormularioSecao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "inscricao_historico_status",
                schema: "EXECUCAO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InscricaoId = table.Column<long>(type: "bigint", nullable: false),
                    StatusAnteriorId = table.Column<int>(type: "int", nullable: false),
                    StatusNovoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    Justificativa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscricao_historico_status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inscricao_historico_status_InscricaoStatus_StatusAnteriorId",
                        column: x => x.StatusAnteriorId,
                        principalSchema: "EXECUCAO",
                        principalTable: "InscricaoStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inscricao_historico_status_InscricaoStatus_StatusNovoId",
                        column: x => x.StatusNovoId,
                        principalSchema: "EXECUCAO",
                        principalTable: "InscricaoStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inscricao_historico_status_Inscricao_InscricaoId",
                        column: x => x.InscricaoId,
                        principalSchema: "EXECUCAO",
                        principalTable: "Inscricao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recurso",
                schema: "JURIDICO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InscricaoId = table.Column<long>(type: "bigint", nullable: false),
                    EditalEtapaId = table.Column<long>(type: "bigint", nullable: false),
                    TipoRecurso = table.Column<int>(type: "int", nullable: false),
                    StatusRecurso = table.Column<int>(type: "int", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recurso_EditalEtapa_EditalEtapaId",
                        column: x => x.EditalEtapaId,
                        principalSchema: "CONFIG",
                        principalTable: "EditalEtapa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recurso_Inscricao_InscricaoId",
                        column: x => x.InscricaoId,
                        principalSchema: "EXECUCAO",
                        principalTable: "Inscricao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BancaMembro",
                schema: "AVALIACAO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BancaExaminadoraId = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    EhPresidente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancaMembro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BancaMembro_BancaExaminadora_BancaExaminadoraId",
                        column: x => x.BancaExaminadoraId,
                        principalSchema: "AVALIACAO",
                        principalTable: "BancaExaminadora",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BancaMembro_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "ACESSO",
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegraResultado",
                schema: "CONFIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegraPontuacaoId = table.Column<long>(type: "bigint", nullable: false),
                    Pontos = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    PontosMaximos = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegraResultado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegraResultado_RegraPontuacao_RegraPontuacaoId",
                        column: x => x.RegraPontuacaoId,
                        principalSchema: "CONFIG",
                        principalTable: "RegraPontuacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CampoOpcao",
                schema: "CONFIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampoConfigId = table.Column<long>(type: "bigint", nullable: false),
                    TextoVisivel = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ValorArmazenado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampoOpcao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampoOpcao_CampoConfig_CampoConfigId",
                        column: x => x.CampoConfigId,
                        principalSchema: "CONFIG",
                        principalTable: "CampoConfig",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegraCondicao",
                schema: "CONFIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegraPontuacaoId = table.Column<long>(type: "bigint", nullable: false),
                    CampoConfigId = table.Column<long>(type: "bigint", nullable: false),
                    Operador = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ValorReferencia = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegraCondicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegraCondicao_CampoConfig_CampoConfigId",
                        column: x => x.CampoConfigId,
                        principalSchema: "CONFIG",
                        principalTable: "CampoConfig",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegraCondicao_RegraPontuacao_RegraPontuacaoId",
                        column: x => x.RegraPontuacaoId,
                        principalSchema: "CONFIG",
                        principalTable: "RegraPontuacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Resposta",
                schema: "EXECUCAO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InscricaoId = table.Column<long>(type: "bigint", nullable: false),
                    CampoConfigId = table.Column<long>(type: "bigint", nullable: false),
                    TipoDado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resposta_CampoConfig_CampoConfigId",
                        column: x => x.CampoConfigId,
                        principalSchema: "CONFIG",
                        principalTable: "CampoConfig",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Resposta_Inscricao_InscricaoId",
                        column: x => x.InscricaoId,
                        principalSchema: "EXECUCAO",
                        principalTable: "Inscricao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecursoAnalise",
                schema: "JURIDICO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecursoId = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioAvaliadorId = table.Column<long>(type: "bigint", nullable: false),
                    ParecerTecnico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecisaoFinal = table.Column<bool>(type: "bit", nullable: false),
                    DataAnalise = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursoAnalise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecursoAnalise_Recurso_RecursoId",
                        column: x => x.RecursoId,
                        principalSchema: "JURIDICO",
                        principalTable: "Recurso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecursoAnalise_Usuario_UsuarioAvaliadorId",
                        column: x => x.UsuarioAvaliadorId,
                        principalSchema: "ACESSO",
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DistribuicaoAvaliacao",
                schema: "AVALIACAO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InscricaoId = table.Column<long>(type: "bigint", nullable: false),
                    BancaMembroId = table.Column<long>(type: "bigint", nullable: false),
                    StatusAvaliacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribuicaoAvaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistribuicaoAvaliacao_BancaMembro_BancaMembroId",
                        column: x => x.BancaMembroId,
                        principalSchema: "AVALIACAO",
                        principalTable: "BancaMembro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DistribuicaoAvaliacao_Inscricao_InscricaoId",
                        column: x => x.InscricaoId,
                        principalSchema: "EXECUCAO",
                        principalTable: "Inscricao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RespostaArquivo",
                schema: "EXECUCAO",
                columns: table => new
                {
                    RespostaId = table.Column<long>(type: "bigint", nullable: false),
                    Caminho = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Hash = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaArquivo", x => x.RespostaId);
                    table.ForeignKey(
                        name: "FK_RespostaArquivo_Resposta_RespostaId",
                        column: x => x.RespostaId,
                        principalSchema: "EXECUCAO",
                        principalTable: "Resposta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RespostaData",
                schema: "EXECUCAO",
                columns: table => new
                {
                    RespostaId = table.Column<long>(type: "bigint", nullable: false),
                    Valor = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaData", x => x.RespostaId);
                    table.ForeignKey(
                        name: "FK_RespostaData_Resposta_RespostaId",
                        column: x => x.RespostaId,
                        principalSchema: "EXECUCAO",
                        principalTable: "Resposta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RespostaNumero",
                schema: "EXECUCAO",
                columns: table => new
                {
                    RespostaId = table.Column<long>(type: "bigint", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaNumero", x => x.RespostaId);
                    table.ForeignKey(
                        name: "FK_RespostaNumero_Resposta_RespostaId",
                        column: x => x.RespostaId,
                        principalSchema: "EXECUCAO",
                        principalTable: "Resposta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RespostaTexto",
                schema: "EXECUCAO",
                columns: table => new
                {
                    RespostaId = table.Column<long>(type: "bigint", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaTexto", x => x.RespostaId);
                    table.ForeignKey(
                        name: "FK_RespostaTexto_Resposta_RespostaId",
                        column: x => x.RespostaId,
                        principalSchema: "EXECUCAO",
                        principalTable: "Resposta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotaItem",
                schema: "AVALIACAO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistribuicaoAvaliacaoId = table.Column<long>(type: "bigint", nullable: false),
                    RegraPontuacaoId = table.Column<long>(type: "bigint", nullable: false),
                    NotaAtribuida = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    JustificativaTexto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaItem_DistribuicaoAvaliacao_DistribuicaoAvaliacaoId",
                        column: x => x.DistribuicaoAvaliacaoId,
                        principalSchema: "AVALIACAO",
                        principalTable: "DistribuicaoAvaliacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotaItem_RegraPontuacao_RegraPontuacaoId",
                        column: x => x.RegraPontuacaoId,
                        principalSchema: "CONFIG",
                        principalTable: "RegraPontuacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BancaExaminadora_EditalEtapaId",
                schema: "AVALIACAO",
                table: "BancaExaminadora",
                column: "EditalEtapaId");

            migrationBuilder.CreateIndex(
                name: "IX_BancaMembro_BancaExaminadoraId",
                schema: "AVALIACAO",
                table: "BancaMembro",
                column: "BancaExaminadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_BancaMembro_UsuarioId",
                schema: "AVALIACAO",
                table: "BancaMembro",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CampoConfig_FormularioSecaoId_VariavelCodigo",
                schema: "CONFIG",
                table: "CampoConfig",
                columns: new[] { "FormularioSecaoId", "VariavelCodigo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampoOpcao_CampoConfigId",
                schema: "CONFIG",
                table: "CampoOpcao",
                column: "CampoConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_UsuarioId",
                schema: "EXECUCAO",
                table: "Candidato",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoAvaliacao_BancaMembroId",
                schema: "AVALIACAO",
                table: "DistribuicaoAvaliacao",
                column: "BancaMembroId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoAvaliacao_InscricaoId",
                schema: "AVALIACAO",
                table: "DistribuicaoAvaliacao",
                column: "InscricaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Edital_SecretariaId",
                schema: "CONFIG",
                table: "Edital",
                column: "SecretariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Edital_TipoProcessoId",
                schema: "CONFIG",
                table: "Edital",
                column: "TipoProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_EditalEtapa_EditalId",
                schema: "CONFIG",
                table: "EditalEtapa",
                column: "EditalId");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioSecao_EditalId",
                schema: "CONFIG",
                table: "FormularioSecao",
                column: "EditalId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_CandidatoId",
                schema: "EXECUCAO",
                table: "Inscricao",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_EditalId",
                schema: "EXECUCAO",
                table: "Inscricao",
                column: "EditalId");

            migrationBuilder.CreateIndex(
                name: "IX_inscricao_historico_status_InscricaoId",
                schema: "EXECUCAO",
                table: "inscricao_historico_status",
                column: "InscricaoId");

            migrationBuilder.CreateIndex(
                name: "IX_inscricao_historico_status_StatusAnteriorId",
                schema: "EXECUCAO",
                table: "inscricao_historico_status",
                column: "StatusAnteriorId");

            migrationBuilder.CreateIndex(
                name: "IX_inscricao_historico_status_StatusNovoId",
                schema: "EXECUCAO",
                table: "inscricao_historico_status",
                column: "StatusNovoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaItem_DistribuicaoAvaliacaoId",
                schema: "AVALIACAO",
                table: "NotaItem",
                column: "DistribuicaoAvaliacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaItem_RegraPontuacaoId",
                schema: "AVALIACAO",
                table: "NotaItem",
                column: "RegraPontuacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_Codigo",
                schema: "ACESSO",
                table: "Perfil",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilPermissao_PermissaoId",
                schema: "ACESSO",
                table: "PerfilPermissao",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissao_Codigo",
                schema: "ACESSO",
                table: "Permissao",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_EditalEtapaId",
                schema: "JURIDICO",
                table: "Recurso",
                column: "EditalEtapaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_InscricaoId",
                schema: "JURIDICO",
                table: "Recurso",
                column: "InscricaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecursoAnalise_RecursoId",
                schema: "JURIDICO",
                table: "RecursoAnalise",
                column: "RecursoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecursoAnalise_UsuarioAvaliadorId",
                schema: "JURIDICO",
                table: "RecursoAnalise",
                column: "UsuarioAvaliadorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegraCondicao_CampoConfigId",
                schema: "CONFIG",
                table: "RegraCondicao",
                column: "CampoConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_RegraCondicao_RegraPontuacaoId",
                schema: "CONFIG",
                table: "RegraCondicao",
                column: "RegraPontuacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegraPontuacao_EditalEtapaId",
                schema: "CONFIG",
                table: "RegraPontuacao",
                column: "EditalEtapaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegraResultado_RegraPontuacaoId",
                schema: "CONFIG",
                table: "RegraResultado",
                column: "RegraPontuacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_CampoConfigId",
                schema: "EXECUCAO",
                table: "Resposta",
                column: "CampoConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_InscricaoId_CampoConfigId",
                schema: "EXECUCAO",
                table: "Resposta",
                columns: new[] { "InscricaoId", "CampoConfigId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Secretaria_TenantId",
                schema: "ACESSO",
                table: "Secretaria",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Cpf",
                schema: "ACESSO",
                table: "Usuario",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLotacao_PerfilId",
                schema: "ACESSO",
                table: "UsuarioLotacao",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLotacao_SecretariaId",
                schema: "ACESSO",
                table: "UsuarioLotacao",
                column: "SecretariaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLotacao_UsuarioId",
                schema: "ACESSO",
                table: "UsuarioLotacao",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampoOpcao",
                schema: "CONFIG");

            migrationBuilder.DropTable(
                name: "inscricao_historico_status",
                schema: "EXECUCAO");

            migrationBuilder.DropTable(
                name: "NotaItem",
                schema: "AVALIACAO");

            migrationBuilder.DropTable(
                name: "PerfilPermissao",
                schema: "ACESSO");

            migrationBuilder.DropTable(
                name: "RecursoAnalise",
                schema: "JURIDICO");

            migrationBuilder.DropTable(
                name: "RegraCondicao",
                schema: "CONFIG");

            migrationBuilder.DropTable(
                name: "RegraResultado",
                schema: "CONFIG");

            migrationBuilder.DropTable(
                name: "RespostaArquivo",
                schema: "EXECUCAO");

            migrationBuilder.DropTable(
                name: "RespostaData",
                schema: "EXECUCAO");

            migrationBuilder.DropTable(
                name: "RespostaNumero",
                schema: "EXECUCAO");

            migrationBuilder.DropTable(
                name: "RespostaTexto",
                schema: "EXECUCAO");

            migrationBuilder.DropTable(
                name: "UsuarioLotacao",
                schema: "ACESSO");

            migrationBuilder.DropTable(
                name: "InscricaoStatus",
                schema: "EXECUCAO");

            migrationBuilder.DropTable(
                name: "DistribuicaoAvaliacao",
                schema: "AVALIACAO");

            migrationBuilder.DropTable(
                name: "Permissao",
                schema: "ACESSO");

            migrationBuilder.DropTable(
                name: "Recurso",
                schema: "JURIDICO");

            migrationBuilder.DropTable(
                name: "RegraPontuacao",
                schema: "CONFIG");

            migrationBuilder.DropTable(
                name: "Resposta",
                schema: "EXECUCAO");

            migrationBuilder.DropTable(
                name: "Perfil",
                schema: "ACESSO");

            migrationBuilder.DropTable(
                name: "BancaMembro",
                schema: "AVALIACAO");

            migrationBuilder.DropTable(
                name: "CampoConfig",
                schema: "CONFIG");

            migrationBuilder.DropTable(
                name: "Inscricao",
                schema: "EXECUCAO");

            migrationBuilder.DropTable(
                name: "BancaExaminadora",
                schema: "AVALIACAO");

            migrationBuilder.DropTable(
                name: "FormularioSecao",
                schema: "CONFIG");

            migrationBuilder.DropTable(
                name: "Candidato",
                schema: "EXECUCAO");

            migrationBuilder.DropTable(
                name: "EditalEtapa",
                schema: "CONFIG");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "ACESSO");

            migrationBuilder.DropTable(
                name: "Edital",
                schema: "CONFIG");

            migrationBuilder.DropTable(
                name: "Secretaria",
                schema: "ACESSO");

            migrationBuilder.DropTable(
                name: "TipoProcesso",
                schema: "CONFIG");

            migrationBuilder.DropTable(
                name: "Tenant",
                schema: "ACESSO");
        }
    }
}
