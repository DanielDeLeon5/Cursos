namespace ExamenWebApi.Migrations
{
    using ExamenWebApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExamenWebApi.Data.ExamenWebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExamenWebApi.Data.ExamenWebApiContext context)
        {
            context.Catedraticoes.AddOrUpdate(new Catedratico[]
           {
                new Catedratico() { Id = 1,  Apellido = "Cajas", Nombre = "Armando", DPI = "3323123450901", Especialidad ="Informatica"},
                new Catedratico() { Id = 2,  Apellido = "Gonzales", Nombre = "Ana", DPI = "4533325420201", Especialidad ="Programacion"},
                new Catedratico() { Id = 3,  Apellido = "Alvarado", Nombre = "David", DPI = "24353133554401", Especialidad ="Redes"},
                new Catedratico() { Id = 4,  Apellido = "Calderon", Nombre = "Edvin", DPI = "2323153452921", Especialidad ="Base de datos"},
                new Catedratico() { Id = 5,  Apellido = "Santos", Nombre = "Andrea", DPI = "2323122462901", Especialidad ="Seguridad informatica"}
           });
        }
    }
}
