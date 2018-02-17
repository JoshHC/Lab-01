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

                Data.Instance.JugadoresCSharp.AddLast(jugadorNuevo);

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
                Jugador jugadorExistente = Data.Instance.JugadoresCSharp.ElementAt(id - 1);

                // Aqui se Edita el Jugador
                var jugadorNuevo = new Jugador
                {
                    Nombre = jugadorExistente.Nombre,
                    Apellido = jugadorExistente.Apellido,
                    Posición = jugadorExistente.Posición,
                    Salario = Convert.ToDecimal(collection["Salario"]),
                    Club = collection["Club"]
                };

                foreach (Jugador persona in Data.Instance.JugadoresArtesanal)
                {
                    if (persona.ID == id)
                    {
                        int cont = 0;
                        bool listo = false;

                        while (listo != true)
                        {
                            //if (Data.Instance.JugadoresArtesanal.) Aqui estaba modificando
                            if (Data.Instance.JugadoresCSharp.ElementAt(cont).ID != persona.ID)
                                cont++;
                            else
                            {

                                Data.Instance.JugadoresCSharp.AddBefore(Data.Instance.JugadoresCSharp.Find(persona), jugadorNuevo);
                                Data.Instance.JugadoresCSharp.Remove(persona);
                                listo = true;
                            }
                        }

                        if (listo == true)
                            break;
                    }
                }

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
                foreach (Jugador persona in Data.Instance.JugadoresCSharp)
                {
                    if (persona.ID == id)
                    {
                        int cont = 0;
                        bool listo = false;

                        while (listo != true)
                        {
                            if (Data.Instance.JugadoresCSharp.ElementAt(cont).ID != persona.ID)
                                cont++;
                            else
                            {
                                Data.Instance.JugadoresCSharp.Remove(persona);
                                listo = true;
                            }
                        }

                        if (listo == true)
                            break;
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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

            //Se crea un Jugador Momentaneo para pasar los datos

            string Dato = Lector.ReadLine();
            Dato = Lector.ReadLine();
            string[] Linea = Dato.Split(',');

            while (Dato != null)
            {
                var jugadornuevo = new Jugador
                {
                    ID = Data.Instance.JugadoresCSharp.Count() + 1,
                    Club = Linea[0],
                    Apellido = Linea[1],
                    Nombre = Linea[2],
                    Posición = Linea[3],
                    Salario = Convert.ToDecimal(Linea[4])
                };

                Data.Instance.JugadoresCSharp.AddLast(jugadornuevo);

                Dato = Lector.ReadLine();

                if (Dato != null)
                {
                    Linea = Dato.Split(',');
                }

            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Aca se hace el Ingreso por medio de Archivo de Texto, ya que el Boton de Result esta Linkeado.
        public ActionResult DeleteFile(HttpPostedFileBase file)
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

            //Se crea un Jugador Momentaneo para pasar los datos

            string Dato = Lector.ReadLine();
            Dato = Lector.ReadLine();
            string[] Linea = Dato.Split(',');

            while (Dato != null)
            {
                var jugadorEliminar = new Jugador
                {
                    ID = Data.Instance.JugadoresCSharp.Count() + 1,
                    Club = Linea[0],
                    Apellido = Linea[1],
                    Nombre = Linea[2],
                    Posición = Linea[3],
                    Salario = Convert.ToDecimal(Linea[4])
                };

                foreach (Jugador persona in Data.Instance.JugadoresCSharp)
                {
                    if (persona.Nombre == jugadorEliminar.Nombre && persona.Apellido == jugadorEliminar.Apellido && persona.Posición == jugadorEliminar.Posición &&
                        persona.Salario == jugadorEliminar.Salario && persona.Club == jugadorEliminar.Club)
                    {
                        int cont = 0;
                        bool listo = false;

                        while (listo != true)
                        {
                            if (Data.Instance.JugadoresCSharp.ElementAt(cont).ID != persona.ID)
                                cont++;
                            else
                            {
                                Data.Instance.JugadoresCSharp.Remove(persona);
                                listo = true;
                            }
                        }

                        if (listo == true)
                            break;
                    }
                }

                Dato = Lector.ReadLine();

                if (Dato != null)
                {
                    Linea = Dato.Split(',');
                }

            }

            return RedirectToAction("Index");

        }

    }
}
