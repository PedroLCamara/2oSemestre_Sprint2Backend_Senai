using Microsoft.EntityFrameworkCore;
using senai.InLock.webAPI.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.InLock.webAPI.CodeFirst.Contexts
{
    public class InLockCodeFirstContext : DbContext
    {
        DbSet<Estudios> Estudios { get; set; }
        DbSet<Jogos> Jogos { get; set; }
        DbSet<TiposUsuario> TiposUsuario { get; set; }
        DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder OptsBuilder)
        {
            OptsBuilder.UseSqlServer("Server= PEDRO-PC\\SQLExpress; DataBase=InLockCodeFirst; user ID=sa; pwd= senai@123");
            base.OnConfiguring(OptsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder MdlBuilder)
        {
            MdlBuilder.Entity<Estudios>(entity => entity.HasIndex(e => e.NomeEstudio).IsUnique());
            MdlBuilder.Entity<Estudios>().HasData(
                new Estudios
                {
                    IdEstudio = 1,
                    NomeEstudio = "Blizzard"
                },
                new Estudios
                {
                    IdEstudio = 2,
                    NomeEstudio = "Rockstar Studios"
                },
                new Estudios
                {
                    IdEstudio = 3,
                    NomeEstudio = "Santa Monica Studios"
                }
                );

            MdlBuilder.Entity<Jogos>().HasData(
                new Jogos
                {
                    IdJogo = 1,
                    IdEstudio = 1,
                    Nome = "Hearthstone",
                    Descricao = "Um jogo de cartas virtual com foco principal em pvp",
                    DataLancamento = Convert.ToDateTime("11/03/2014"),
                    Valor = Convert.ToDecimal(59.99),
                },
                new Jogos
                {
                    IdJogo = 2,
                    IdEstudio = 2,
                    Nome = "GTA V",
                    Descricao = "Grand Theft Auto V é um jogo eletrônico de ação-aventura",
                    DataLancamento = Convert.ToDateTime("17/09/2013"),
                    Valor = Convert.ToDecimal(159.99),
                },
                new Jogos
                {
                    IdJogo = 3,
                    IdEstudio = 3,
                    Nome = "God Of War IV",
                    Descricao = "Sua vingança contra os deuses do Olimpo agora é passado, e Kratos vive como um homem comum nas terras dos monstros e deuses nórdicos. E é nesse mundo inóspito e implacável que ele precisa lutar para sobreviver... e ensinar seu filho a fazer o mesmo.",
                    DataLancamento = Convert.ToDateTime("20/04/2018"),
                    Valor = Convert.ToDecimal(159.99),
                }
                );

            MdlBuilder.Entity<TiposUsuario>(entity => entity.HasIndex(TpU => TpU.Titulo).IsUnique());
            MdlBuilder.Entity<TiposUsuario>().HasData(
                new TiposUsuario
                {
                    IdTipoUsuario = 1,
                    Titulo = "Administrador"
                },
                new TiposUsuario {
                    IdTipoUsuario = 2,
                    Titulo = "Comum"
                }
                );

            MdlBuilder.Entity<Usuarios>(entity => entity.HasIndex(u => u.Email).IsUnique());
            MdlBuilder.Entity<Usuarios>().HasData(
                new Usuarios
                {
                    IdUsuario = 1,
                    Email = "comum@comum.com",
                    Senha = "comum",
                    IdTipoUsuario = 2
                },
                new Usuarios
                {
                    IdUsuario = 2,
                    Email = "admin@admin.com",
                    Senha = "admin",
                    IdTipoUsuario = 1
                }
                );
        }
    }
}
