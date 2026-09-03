using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace apiwebFestivos.dominio
{
    [Table("TipoFestivo")]
    public class TipoFestivo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo")]
        public  int Tipo { get; set; }
    }
}
