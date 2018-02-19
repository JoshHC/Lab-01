using Lab01_1104017_1169317.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01_1104017_1169317.Controllers
{
    public class JugadorArtesanalController : Controller
    {
        // GET: JugadorArtesanal
        public ActionResult Index()
        {
            return View(Data.Instance.JugadoresArtesanal);
        }

        public ActionResult BusquedaArtesanal(string Tipo, string Search)
        {
            if (Tipo == "Nombre")
            {

                List<Jugador> NombreBuscado = new List<Jugador>();
                NombreBuscado.Clear();
                foreach (var item in Data.Instance.JugadoresArtesanal)
                {
                    if (item.Nombre == Search)
                    {
                        NombreBuscado.Add(item);
                    }

                }
                return View("Index", NombreBuscado);


            }
            else if (Tipo == "Apellido")
            {
                List<Jugador> ApellidoBuscado = new List<Jugador>();
                ApellidoBuscado.Clear();
                foreach (var item in Data.Instance.JugadoresArtesanal)
                {
                    if (item.Apellido == Search)
                    {
                        ApellidoBuscado.Add(item);
                    }

                }
                return View("Index", ApellidoBuscado);

            }
            else if (Tipo == "Posicion")
            {
                List<Jugador> PosicionBuscada = new List<Jugador>();
                PosicionBuscada.Clear();
                foreach (var item in Data.Instance.JugadoresArtesanal)
                {
                    if (item.Posición == Search)
                    {
                        PosicionBuscada.Add(item);
                    }

                }
                return View("Index", PosicionBuscada);

            }
            else if (Tipo == "Salario")
            {
                List<Jugador> SalarioBuscado = new List<Jugador>();
                SalarioBuscado.Clear();
                foreach (var item in Data.Instance.JugadoresArtesanal)
                {
                    if (item.Salario == Convert.ToDecimal(Search))
                    {
                        SalarioBuscado.Add(item);
                    }

                }
                return View("Index", SalarioBuscado);


            }
            else if (Tipo == "Club")
            {
                List<Jugador> ClubBuscado = new List<Jugador>();
                ClubBuscado.Clear();
                foreach (var item in Data.Instance.JugadoresArtesanal)
                {
                    if (item.Club == Search)
                    {
                        ClubBuscado.Add(item);
                    }

                }
                return View("Index", ClubBuscado);

            }
            return View();
        }

        // GET: JugadorArtesanal/Details/5
        public ActionResult DetailsArtesanal(int id)
        {
            return View();
        }

        // GET: JugadorArtesanal/Create
        public ActionResult CreateArtesanal()
        {
            return View();
        }

        // POST: JugadorArtesanal/Create
        [HttpPost]
        public ActionResult CreateArtesanal(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var Jugador1 = new Jugador
                {
                    ID = Data.Instance.JugadoresArtesanal.Tamaño()+1,
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Posición = collection["Posición"],
                    Salario = Convert.ToDecimal(collection["Salario"]),
                    Club = collection["Club"]
                };

                NodoDoble<Jugador> jugadorNuevo = new NodoDoble<Jugador>(null, Jugador1, null);
                Data.Instance.JugadoresArtesanal.InsertarUltimo(jugadorNuevo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult UploadFileArtesanal()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Aca se hace el Ingreso por medio de Archivo de Texto, ya que el Boton de Result esta Linkeado.
        public ActionResult UploadFileArtesanal(HttpPostedFileBase file)
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
                var Jugador1 = new Jugador
                {
                    ID = Data.Instance.JugadoresArtesanal.Tamaño()+1,
                    Club = Linea[0],
                    Apellido = Linea[1],
                    Nombre = Linea[2],
                    Posición = Linea[3],
                    Salario = Convert.ToDecimal(Linea[4])
                };

                NodoDoble<Jugador> jugadorNuevo = new NodoDoble<Jugador>(null, Jugador1, null);
                Data.Instance.JugadoresArtesanal.InsertarUltimo(jugadorNuevo);

                Dato = Lector.ReadLine();

                if (Dato != null)
                {
                    Linea = Dato.Split(',');
                }

            }

            return RedirectToAction("Index");

        }


        // GET: JugadorArtesanal/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
        }

        // POST: JugadorArtesanal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Jugador jugadorExistente = Data.Instance.JugadoresArtesanal.ElementAt(id - 1);
                //NodoDoble nodoJugadorExistente;

                // Aqui se Edita el Jugador
                var personaNuevo = new Jugador
                {
                    ID = jugadorExistente.ID,
                    Nombre = jugadorExistente.Nombre,
                    Apellido = jugadorExistente.Apellido,
                    Posición = jugadorExistente.Posición,
                    Salario = Convert.ToDecimal(collection["Salario"]),
                    Club = collection["Club"]
                };

                NodoDoble<Jugador> jugadorNuevo = new NodoDoble<Jugador>(null, personaNuevo, null);

                foreach (Jugador persona in Data.Instance.JugadoresArtesanal)
                {

                    if (persona.ID == id)
                    {
                        int cont = 0;
                        bool listo = false;

                        while (listo != true)
                        {
                            if (Data.Instance.JugadoresArtesanal.ElementAt(cont).ID != persona.ID)
                                cont++;
                            else
                            {
                                NodoDoble<Jugador> personaElimnar = new NodoDoble<Jugador>(null, persona, null);
                                Data.Instance.JugadoresArtesanal.EliminarOrden(personaElimnar);
                                Data.Instance.JugadoresArtesanal.InsertarPorPosicion(cont, jugadorNuevo);
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

        // GET: JugadorArtesanal/Delete/5
        public ActionResult DeleteArtesanal(int id)
        {
            return View();
        }

        // POST: JugadorArtesanal/Delete/5
        [HttpPost]
        public ActionResult DeleteArtesanal(int id, FormCollection collection)
        {
            try
            {
                foreach (Jugador persona in Data.Instance.JugadoresArtesanal)
                {
                    if (persona.ID == id)
                    {
                        int cont = 0;
                        bool listo = false;

                        while (listo != true)
                        {
                            if (Data.Instance.JugadoresArtesanal.ElementAt(cont).ID != persona.ID)
                                cont++;
                            else
                            {
                                NodoDoble<Jugador> JugadorBorrar= new NodoDoble<Jugador>(null, persona, null);
                                Data.Instance.JugadoresArtesanal.EliminarOrden(JugadorBorrar);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Aca se hace el Ingreso por medio de Archivo de Texto, ya que el Boton de Result esta Linkeado.
        public ActionResult DeleteFileArtesanal(HttpPostedFileBase file)
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
                    ID = Data.Instance.JugadoresArtesanal.Count() + 1,
                    Club = Linea[0],
                    Apellido = Linea[1],
                    Nombre = Linea[2],
                    Posición = Linea[3],
                    Salario = Convert.ToDecimal(Linea[4])
                };

                foreach (Jugador persona in Data.Instance.JugadoresArtesanal)
                {
                    if (persona.Nombre == jugadorEliminar.Nombre && persona.Apellido == jugadorEliminar.Apellido && persona.Posición == jugadorEliminar.Posición &&
                        persona.Salario == jugadorEliminar.Salario && persona.Club == jugadorEliminar.Club)
                    {
                        int cont = 0;
                        bool listo = false;

                        while (listo != true)
                        {
                            if (Data.Instance.JugadoresArtesanal.ElementAt(cont).ID != persona.ID)
                                cont++;
                            else
                            {
                                NodoDoble<Jugador> JugadorBorrar = new NodoDoble<Jugador>(null, persona, null);
                                Data.Instance.JugadoresArtesanal.EliminarOrden(JugadorBorrar);
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
