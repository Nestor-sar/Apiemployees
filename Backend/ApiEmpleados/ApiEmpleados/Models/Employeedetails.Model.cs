using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ApiEmpleados.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; } // AI y PK en la base de datos
        public string Nombre { get; set; } // varchar(100)
        public string Apellido { get; set; } // varchar(100)
        public string Cargo { get; set; } // varchar(50)
        public DateTime FechaIngreso { get; set; } // datetime

    }
}
