﻿// <auto-generated />
using System;
using Macro_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Macro_Model.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Macro_Model.Models.Cadastro", b =>
                {
                    b.Property<string>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Cpf");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Cadastro");
                });

            modelBuilder.Entity("Macro_Model.Models.Listadefavorito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CadastroCpf")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CadastroCpf");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Listadefavorito");
                });

            modelBuilder.Entity("Macro_Model.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ListadefavoritoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nutricional")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Restricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TipoConteudoImagem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListadefavoritoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Macro_Model.Models.Listadefavorito", b =>
                {
                    b.HasOne("Macro_Model.Models.Cadastro", "Cadastro")
                        .WithMany("Listadefavorito")
                        .HasForeignKey("CadastroCpf");

                    b.HasOne("Macro_Model.Models.Produto", "ProdutoFK")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cadastro");

                    b.Navigation("ProdutoFK");
                });

            modelBuilder.Entity("Macro_Model.Models.Produto", b =>
                {
                    b.HasOne("Macro_Model.Models.Listadefavorito", null)
                        .WithMany("Produtos")
                        .HasForeignKey("ListadefavoritoId");
                });

            modelBuilder.Entity("Macro_Model.Models.Cadastro", b =>
                {
                    b.Navigation("Listadefavorito");
                });

            modelBuilder.Entity("Macro_Model.Models.Listadefavorito", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
