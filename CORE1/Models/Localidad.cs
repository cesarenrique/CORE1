namespace CORE1.Models
{
    public class Localidad
    {
        public decimal id { get; set; }
        public string Nombre { get; set; }
        public Localidad(int id=0, string nombre="")
        {
            this.id = id;
            this.Nombre = nombre;
        }
    }
}
