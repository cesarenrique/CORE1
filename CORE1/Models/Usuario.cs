using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE1.Models
{
    [Table("Usuarios",Schema ="tallercore2")]
    public class Usuario
    {

        [Key]
        [Column("id",Order =0)]
        public int id { get; set; }

        [Column("fechaalta",Order=1)]
        public DateTime fechaalta { get; set; }

        [Display(Description = "Nombre de usuario",
            Name ="Nombre: ",
            Prompt ="Nombre del usuario",
            ShortName = "Nombre")]
        [Required(ErrorMessage ="El nombre es obligatorio")]
        [Column("nombre",Order=2,TypeName ="varchar(50)")]
        public string nombre { get; set; }

        [Display(Description = "Apellidos de usuario",
            Name = "Apellidos: ",
            Prompt = "Apellidos del usuario",
            ShortName = "Apellidos")]
        [Column("apellidos", Order = 3, TypeName = "varchar(100)")]
        public string apellidos { get; set; }

        [Display(Description = "Correo electrónico de usuario",
            Name = "Correo electrónico : ",
            Prompt = "Correo electrónico del usuario",
            ShortName = "Correo electrónico")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [Column("email", Order = 4, TypeName = "varchar(100)")]
        public string email { get; set; }


        [Display(Description = "Clave de acceso",
            Name = "Clave: ",
            Prompt = "Clave de acceso",
            ShortName = "Clave")]
        [Required(ErrorMessage = "La clave es obligatoria")]
        [Column("clave", Order = 5, TypeName = "varchar(50)")]
        public string password { get; set; }

        [Display(Description = "Rol dell usuario",
            Name = "Rol: ",
            Prompt ="Rol del usuario",
            ShortName ="Rol")]
        [Required(ErrorMessage = "El rol es obligatorio")]
        [Column("rol", Order = 6, TypeName = "varchar(20)")]
        public string rol { get; set; }


        [Display(Description = "Usuario activo?",
            Name = "Activo: ",
            Prompt = "Usuario activo",
            ShortName = "Activo")]
        [Required(ErrorMessage = "El estado activo es obligatorio")]

        [Column("activo", Order = 7,TypeName = "varchar(1)")]
        public string activo { get; set; }

        public Usuario(int id=0, DateTime? fechaalta=null, string nombre="", string apellidos="", string email="", string password="", string rol="", string activo="S")
        {
            this.id = id;
            this.fechaalta = fechaalta ?? DateTime.Now;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.password = password;
            this.rol = rol;
            this.activo = activo;
        }
        
        public Usuario(int id,DateTime fechaalta, string nombre, string email, string password, string rol, string activo)
        {
            this.id = id;
            this.fechaalta =fechaalta;
            this.nombre = nombre;
            this.apellidos = "";
            this.email = email;
            this.password = password;
            this.rol = rol;
            this.activo = activo;
        }
    }
}
