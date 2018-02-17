using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab01_1104017_1169317
{
    public class Jugador: IComparable
    {
        public int CompareTo(object obj)
        {
            var comparer = ((Jugador)obj).ID;
            return comparer < ID ? -1 : comparer == ID ? 0 : 1;
        }

        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La posicion es requerida")]
        public string Posición { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El salario es requerido")]
        public decimal Salario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El club es requerido")]
        public string Club { get; set; }
    }
}