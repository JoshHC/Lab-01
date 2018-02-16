using Lab01_1104017_1169317.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01_1104017_1169317.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index()
        {
            return View(Data.Instance.JugadoresCSharp);
        }


        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Aca se hace el Ingreso por medio de Archivo de Texto, ya que el Boton de Result esta Linkeado.
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (Path.GetExtension(file.FileName) != ".csv")
            {
                //Aca se debe de Agregar una Vista de Error, o de Datos No Cargados
                //return RedirectToAction("Index");
            }

            Stream Direccion = file.InputStream;
        //Se lee el Archivo que se subio, por medio del Lector
            StreamReader Lector = new StreamReader(Direccion);
        //El Archivo se lee en una lista para luego ingresarlo
            List<Jugador> DatosJugadores = new List<Jugador>();
        //Se crea un Jugador Momentaneo para pasar los datos
            string Dato = Lector.ReadLine();
            string[] Linea = Dato.Split(',');

            while(Dato != null)
            {
                var jugadornuevo = new Jugador();
                jugadornuevo.ID = (DatosJugadores.Count() + 1);
                jugadornuevo.Club = Linea[0];
                jugadornuevo.Apellido = Linea[1];
                jugadornuevo.Nombre = Linea[2];
                jugadornuevo.Posición = Linea[3];
                jugadornuevo.Salario = Convert.ToDecimal(Linea[4]);
                Data.Instance.JugadoresCSharp.Add(jugadornuevo);

                Dato = Lector.ReadLine();

                if(Dato != null)
                {
                    Linea = Dato.Split(',');
                }
                
            }

            return RedirectToAction("Index");

        }
        // GET: Jugador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var jugadorNuevo = new Jugador
                {
                    ID = Data.Instance.JugadoresCSharp.Count + 1,
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Posición = collection["Posición"],
                    Salario = Convert.ToDecimal(collection["Salario"]),
                    Club = collection["Club"]
                };

                Data.Instance.JugadoresCSharp.Add(jugadorNuevo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int? id)
        {


            return View();
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // Aqui se Edita el Jugador
                var jugadorNuevo = new Jugador
                {
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Posición = collection["Posición"],
                    Salario = Convert.ToDecimal(collection["Salario"]),
                    Club = collection["Club"]
                };

                Data.Instance.JugadoresCSharp.RemoveAt((id-1));
                Data.Instance.JugadoresCSharp.Insert((id-1), jugadorNuevo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jugador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Data.Instance.JugadoresCSharp.RemoveAt((id-1));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
