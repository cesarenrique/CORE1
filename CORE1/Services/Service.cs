using CORE1.Models;

namespace CORE1.Services
{
    public class Service
    {
        public List<Tienda> GetTiendas()
        {
            List<Tienda> tiendas = new List<Tienda>()
            {
                new Tienda(1,"Tienda A", "Calle 123", "Ciudad X", "usuario@gmail.com ","123456789"),
                new Tienda(2,"Tienda B", "Avenida 456", "Ciudad Y", "usuario2@gmail.com ","1234590"),
                new Tienda(4,"Tienda C", "Boulevard 789", "Ciudad Z", "usuario3@gmail.com","987654321")
            };

            return tiendas;

        }

    }
}
