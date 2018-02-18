using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab01_1104017_1169317
{
    public class Jugador: IComparable
    {
     

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

        public int CompareTo(Jugador other)
        {
            return other.ID < ID ? -1 : other.ID == ID ? 0 : 1;
        }

        public Comparison<Jugador> CompareById = delegate (Jugador i, Jugador j)
        {
            return i.CompareTo(j);
        };

        public Comparison<Jugador> CompareByName = delegate (Jugador i, Jugador j)
        {
            return i.Nombre.CompareTo(j.Nombre);
        };

        public Comparison<Jugador> CompareByLastName = delegate (Jugador i, Jugador j)
        {
            return i.Apellido.CompareTo(j.Apellido);
        };

        public Comparison<Jugador> CompareByClub = delegate (Jugador i, Jugador j)
        {
            return i.Club.CompareTo(j.Club);
        };

        public Comparison<Jugador> CompareBySalary = delegate (Jugador i, Jugador j)
        {
            return i.Salario.CompareTo(j.Salario);
        };

        public Comparison<Jugador> CompareByPosition = delegate (Jugador i, Jugador j)
        {
            return i.Posición.CompareTo(j.Posición);
        };

        public override string ToString()
        {
            return $"{ID}|{Nombre}|{Apellido}|{Club}|{Salario}|{Posición}";
        }

        public bool Equals(Jugador jugador)
        {
            bool igual = jugador.Nombre == Nombre;
            igual = igual && jugador.Apellido == Apellido;
            igual = igual && jugador.Club == Club;
            igual = igual && jugador.Salario == Salario;
            igual = igual && jugador.Posición == Posición;
            return igual;
        }

        public int CompareTo(object obj)
        {
            try
            {
                Jugador jugador = obj as Jugador;
                return jugador.ID < ID ? -1 : jugador.ID == ID ? 0 : 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}