namespace CORE1.Models
{
    public class Localidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Localidad(int id=0, string nombre="")
        {
            this.Id = id;
            this.Nombre = nombre;
        }
    }
}
