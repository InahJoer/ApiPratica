using ApiPratica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPratica.Data
{
    public class ApiPraticaContext :DbContext
    {
        public ApiPraticaContext(DbContextOptions<ApiPraticaContext> options) : base(options) 
        {


        }

        public DbSet<Mascotas> Mascotas { get; set; }

        public DbSet<Raza> Raza { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Mascotas>().HasData(
                new Mascotas()
                {
                      MascotaId = 1,
                      MascotaName = "Juan",
                      MascotaDescription = "Pequeño",
                      Fecha = new DateTime(2018, 09 , 12),
                      RazaId = 1
                },
                new Mascotas()
                {
                    MascotaId = 2,
                    MascotaName = "Oswaldo",
                    MascotaDescription = "Gorda",
                    Fecha = new DateTime(2018, 09, 12),
                    RazaId = 2
                }
                );
            model.Entity<Raza>().HasData(
                new Raza()
                {
                    RazaId = 1,
                    RazaName = "Chihuahua",
                    RazaColor = "Negrote"
                },
                new Raza()
                {
                    RazaId = 2,
                    RazaName = "Pitbull",
                    RazaColor = "Verde"
                });
            model.Entity<Usuario>().HasData(
            new Usuario()
            {
                Id = 1,
                NombreUsuario = "Chejudos",
                Contraseña = "holaquepasa",
                Rol = "Administrador"
            },
            new Usuario()
            {
                Id = 2,
                NombreUsuario = "Mrpimiento",
                Contraseña = "megustanmenores",
                Rol = "Vendedor"
            });
        }
    }
}
