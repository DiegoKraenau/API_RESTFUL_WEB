﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RapiSolver.Repository.context;

namespace RapiSolver.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RapiSolver.Entity.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellido");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("RapiSolver.Entity.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Age");

                    b.Property<string>("City");

                    b.Property<string>("Contraseña");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("Genger");

                    b.Property<string>("LastName");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("State");

                    b.Property<int>("UsuarioId");

                    b.HasKey("CustomerId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("RapiSolver.Entity.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("State");

                    b.HasKey("LocationId");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("RapiSolver.Entity.Recommendation", b =>
                {
                    b.Property<int>("RecommendationId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Mark");

                    b.Property<string>("Note");

                    b.Property<int>("SupplierId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("RecommendationId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("recommendations");
                });

            modelBuilder.Entity("RapiSolver.Entity.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fecha");

                    b.Property<string>("Note");

                    b.Property<int>("ServicioId");

                    b.Property<int>("SupplierId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("ReservationId");

                    b.HasIndex("ServicioId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("RapiSolver.Entity.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Publish");

                    b.Property<string>("RolDescription");

                    b.HasKey("RolId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("RapiSolver.Entity.ServiceCategory", b =>
                {
                    b.Property<int>("ServiceCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryDescription");

                    b.Property<string>("CategoryName");

                    b.HasKey("ServiceCategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("RapiSolver.Entity.ServiceDetails", b =>
                {
                    b.Property<int>("ServiceDetailsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ServicioId");

                    b.Property<int>("SupplierId");

                    b.HasKey("ServiceDetailsId");

                    b.HasIndex("ServicioId");

                    b.HasIndex("SupplierId");

                    b.ToTable("serviceDetails");
                });

            modelBuilder.Entity("RapiSolver.Entity.Servicio", b =>
                {
                    b.Property<int>("ServicioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("ServiceCategoryId");

                    b.HasKey("ServicioId");

                    b.HasIndex("ServiceCategoryId");

                    b.ToTable("servicios");
                });

            modelBuilder.Entity("RapiSolver.Entity.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Age");

                    b.Property<string>("City");

                    b.Property<string>("Contraseña");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("Genger");

                    b.Property<string>("LastName");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("State");

                    b.Property<int>("UsuarioId");

                    b.HasKey("SupplierId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("suppliers");
                });

            modelBuilder.Entity("RapiSolver.Entity.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RolId");

                    b.Property<string>("UserName");

                    b.Property<string>("UserPassword");

                    b.HasKey("UsuarioId");

                    b.HasIndex("RolId");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("RapiSolver.Entity.Customer", b =>
                {
                    b.HasOne("RapiSolver.Entity.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RapiSolver.Entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RapiSolver.Entity.Recommendation", b =>
                {
                    b.HasOne("RapiSolver.Entity.Supplier", "Supplier")
                        .WithMany("Recommendations")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RapiSolver.Entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RapiSolver.Entity.Reservation", b =>
                {
                    b.HasOne("RapiSolver.Entity.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RapiSolver.Entity.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RapiSolver.Entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RapiSolver.Entity.ServiceDetails", b =>
                {
                    b.HasOne("RapiSolver.Entity.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RapiSolver.Entity.Supplier", "Supplier")
                        .WithMany("ServiciosDetails")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RapiSolver.Entity.Servicio", b =>
                {
                    b.HasOne("RapiSolver.Entity.ServiceCategory", "ServiceCategory")
                        .WithMany("Servicios")
                        .HasForeignKey("ServiceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RapiSolver.Entity.Supplier", b =>
                {
                    b.HasOne("RapiSolver.Entity.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RapiSolver.Entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RapiSolver.Entity.Usuario", b =>
                {
                    b.HasOne("RapiSolver.Entity.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
