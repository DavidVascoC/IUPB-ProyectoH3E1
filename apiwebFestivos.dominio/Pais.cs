using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiwebFestivos.dominio
{
    public class Pais
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre")]
        public required string Nombre { get; set; }
    }
}
