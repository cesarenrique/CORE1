using CORE1.Models;

namespace CORE1.Services
{
    public class Service
    {
        public List<Tienda> GetTiendas()
        {
            List<Tienda> tiendas = new List<Tienda>()
            {
                new Tienda(1,"Tienda A", "Calle 123", 1, "usuario@gmail.com ","123456789"),
                new Tienda(2,"Tienda B", "Avenida 456", 2, "usuario2@gmail.com ","1234590"),
                new Tienda(4,"Tienda C", "Boulevard 789", 3, "usuario3@gmail.com","987654321"),
                new Tienda(5,"Tienda D", "Boulevard 789",  3, "usuario3@gmail.com","987654321"),
                new Tienda(6,"Tienda E", "Boulevard 789",  3, "usuario3@gmail.com","987654321"),
                new Tienda(7,"Tienda F", "Boulevard 789",  3, "usuario3@gmail.com","987654321"),
            };

            return tiendas;

        }
        public List<Localidad> GetLocalidades()
        {
            List<Localidad> localidades = new List<Localidad>()
            {
                new Localidad(1,"Ciudad X"),
                new Localidad(2,"Ciudad Y"),
                new Localidad(3,"Ciudad Z")
            };
            return localidades;
        }
    }
}
