namespace CORE1.Models
{
    public class Tienda
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string email { get; set; }
        public string telefonos { get; set; }


        public Tienda(string nombre="", string direccion="", string localidad="", string email="", string telefonos = "")
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.localidad = localidad;
            
            this.email = email;
            this.telefonos = telefonos;
        }
    }
}
