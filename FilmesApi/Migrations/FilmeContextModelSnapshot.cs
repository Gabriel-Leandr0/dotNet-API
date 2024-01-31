﻿// <auto-generated />
using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilmesApi.Migrations;

[DbContext(typeof(FilmeContext))]
partial class FilmeContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.1")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("Models.Filme", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Genero")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Titulo")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("duracao")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Filmes");
            });
#pragma warning restore 612, 618
    }
}
