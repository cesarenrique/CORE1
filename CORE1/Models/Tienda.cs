namespace CORE1.Models
{
    public class Tienda
    {
        public decimal id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string email { get; set; }
        public string telefonos { get; set; }


        public Tienda(decimal i=0,string nombre="", string direccion="", string localidad="", string email="", string telefonos = "")
        {
            this.id = i;
            this.nombre = nombre;
            this.direccion = direccion;
            this.localidad = localidad;
            
            this.email = email;
            this.telefonos = telefonos;
        }
    }
}
