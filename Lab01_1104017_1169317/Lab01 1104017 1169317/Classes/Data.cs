using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01_1104017_1169317.Classes
{
    public class Data
    {
        private static Data instance;
        public static Data Instance
        {
            get
            {
                if (instance == null)
                    instance = new Data();
                return instance;
            }
        }


        public LinkedList<Jugador> JugadoresCSharp;
        public ListaDoble<Jugador> JugadoresArtesanal;

        public Data()
        {
            JugadoresCSharp = new LinkedList<Jugador>();
            JugadoresArtesanal = new ListaDoble<Jugador>();
        }
    }
}