using Lab01_1104017_1169317.Classes;
using System;
using System.Collections.Generic;
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

        // GET: JugadorArtesanal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JugadorArtesanal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JugadorArtesanal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var Jugador1 = new Jugador
                {
                    ID = Data.Instance.JugadoresCSharp.Count + 1,
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

        // GET: JugadorArtesanal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JugadorArtesanal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JugadorArtesanal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JugadorArtesanal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
