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

            modelBuilder.Entity("ConsultorioChatBot.Business.Models.Exame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<int>("DuracaoHoras")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Exame", (string)null);
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
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("ConsultorioChatBot.Business.Models.PreparoExame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExameId");

                    b.ToTable("PreparoExame", (string)null);
                });

            modelBuilder.Entity("ConsultorioChatBot.Business.Models.Servico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TipoServico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Servicos");
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

            modelBuilder.Entity("ConsultorioChatBot.Business.Models.PreparoExame", b =>
                {
                    b.HasOne("ConsultorioChatBot.Business.Models.Exame", "Exame")
                        .WithMany()
                        .HasForeignKey("ExameId")
                        .IsRequired();

                    b.Navigation("Exame");
                });
#pragma warning restore 612, 618
        }
    }
}
