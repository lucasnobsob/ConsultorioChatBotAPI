﻿// <auto-generated />
using System;
using ConsultorioChatBot.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsultorioChatBot.Data.Migrations
{
    [DbContext(typeof(ConsultorioDbContext))]
    partial class ConsultorioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsultorioChatBot.Business.Models.Agenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Confirmacao")
                        .HasColumnType("bit");

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MedicoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServicoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("Agenda", (string)null);
                });

            modelBuilder.Entity("ConsultorioChatBot.Business.Models.Medico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"));

                    b.HasKey("Id");

                    b.ToTable("Medicos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cc2d0a62-a230-42f7-8c06-4c4917f933d8"),
                            CRM = "101196/SP",
                            Especialidade = "Gastroenterologia",
                            Nome = "Alexandre Campos",
                            Numero = 0
                        });
                });

            modelBuilder.Entity("ConsultorioChatBot.Business.Models.Servico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"));

                    b.Property<string>("PreparoExame")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoServico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Servicos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ed2df1e-ae89-4c03-a554-fd1c66297455"),
                            Descricao = "# Consulta Ou Retorno  - Atendimento Presencial.",
                            Numero = 0,
                            TipoServico = 0
                        },
                        new
                        {
                            Id = new Guid("6dc5206b-f685-4879-88c5-850eefb35dd5"),
                            Descricao = "Endoscopia Digestiva Alta E Depois digite 60.",
                            Numero = 0,
                            TipoServico = 1
                        },
                        new
                        {
                            Id = new Guid("f61a1f4d-f2ff-4f38-b318-89768a29c21c"),
                            Descricao = "Exame Colonoscopia nº 60 Para Preparo.",
                            Numero = 0,
                            TipoServico = 1
                        },
                        new
                        {
                            Id = new Guid("d1b32085-6104-4abd-87ca-c4600cec5ca2"),
                            Descricao = "Virtual Atendimento Via Online.",
                            Numero = 0,
                            TipoServico = 0
                        },
                        new
                        {
                            Id = new Guid("c650a821-3ee1-4b7f-b90c-5a5b988e562f"),
                            Descricao = "§ Endoscopia + Colonoscopia nº60 Preparo",
                            Numero = 0,
                            TipoServico = 1
                        });
                });

            modelBuilder.Entity("MedicoServico", b =>
                {
                    b.Property<Guid>("MedicosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServicosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MedicosId", "ServicosId");

                    b.HasIndex("ServicosId");

                    b.ToTable("MedicoServico");
                });

            modelBuilder.Entity("ConsultorioChatBot.Business.Models.Agenda", b =>
                {
                    b.HasOne("ConsultorioChatBot.Business.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .IsRequired();

                    b.HasOne("ConsultorioChatBot.Business.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("MedicoServico", b =>
                {
                    b.HasOne("ConsultorioChatBot.Business.Models.Medico", null)
                        .WithMany()
                        .HasForeignKey("MedicosId")
                        .IsRequired();

                    b.HasOne("ConsultorioChatBot.Business.Models.Servico", null)
                        .WithMany()
                        .HasForeignKey("ServicosId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
