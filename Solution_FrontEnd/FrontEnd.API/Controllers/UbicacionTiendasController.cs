using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using data = FrontEnd.API.Models;

namespace FrontEnd.W.Controllers
{
    public class UbicacionTiendasController : Controller
    {
        string baseurl = "https://localhost:44359/";


        // GET: UbicacionTienda
        public async Task<IActionResult> Index()
        {
            List<data.UbicacionTienda> aux = new List<data.UbicacionTienda>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/UbicacionTienda");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.UbicacionTienda>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: UbicacionTienda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicaciontienda = GetById(id);


            if (ubicaciontienda == null)
            {
                return NotFound();
            }

            return View(ubicaciontienda);
        }

        // GET: UbicacionTienda/Create
        public IActionResult Create()
        {
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda");
            return View();
        }

        //POST: UbicacionTienda/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Provincia,Canton,Direccion,IdTienda")] data.UbicacionTienda ubicaciontienda)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(ubicaciontienda);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/UbicacionTienda", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda", ubicaciontienda.IdTienda);

            return View(ubicaciontienda);
        }

        // GET: UbicacionTienda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var ubicaciontienda = GetById(id);
            if (ubicaciontienda == null)
            {
                return NotFound();
            }

            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda", ubicaciontienda.IdTienda);
            return View(ubicaciontienda);
        }

        //// POST: UbicacionTienda/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Provincia,Canton,Direccion,IdTienda")] data.UbicacionTienda ubicaciontienda)
        {
            if (id != ubicaciontienda.IdUbicacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(baseurl);
                        var content = JsonConvert.SerializeObject(ubicaciontienda);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/UbicacionTienda/" + id, byteContent).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception)
                {
                    var aux2 = GetById(id);
                    if (aux2 == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda", ubicaciontienda.IdTienda);

            return View(ubicaciontienda);
        }

        //// GET: UbicacionTienda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicaciontienda = GetById(id);
            if (ubicaciontienda == null)
            {
                return NotFound();
            }

            return View(ubicaciontienda);
        }

        //// POST: UbicacionTienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/UbicacionTienda/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }


        private bool UbicacionTiendaExists(int id)
        {
            return (GetById(id) != null);
        }
        private data.UbicacionTienda GetById(int? id)
        {
            data.UbicacionTienda aux = new data.UbicacionTienda();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/UbicacionTienda/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.UbicacionTienda>(auxres);
                }
            }
            return aux;
        }
        private List<data.Tiendas> getAllTiendas()
        {

            List<data.Tiendas> aux = new List<data.Tiendas>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Tiendas").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Tiendas>>(auxres);
                }
            }
            return aux;
        }
    }
}
