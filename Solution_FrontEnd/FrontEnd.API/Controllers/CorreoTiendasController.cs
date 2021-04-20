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

namespace FrontEnd.API.Controllers
{
    public class CorreoTiendasController : Controller
    {
        string baseurl = "https://localhost:44359/";


        // GET: CorreoTienda
        public async Task<IActionResult> Index()
        {
            List<data.CorreoTienda> aux = new List<data.CorreoTienda>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/CorreoTienda");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.CorreoTienda>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: CorreoTienda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correotienda = GetById(id);


            if (correotienda == null)
            {
                return NotFound();
            }

            return View(correotienda);
        }

        // GET: CorreoTienda/Create
        public IActionResult Create()
        {
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda");
            return View();
        }

        //POST: CorreoTienda/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Correo,Descripcion,IdTienda")] data.CorreoTienda correotienda)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(correotienda);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/CorreoTienda", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda", correotienda.IdTienda);

            return View(correotienda);
        }

        // GET: CorreoTienda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var correotienda = GetById(id);
            if (correotienda == null)
            {
                return NotFound();
            }

            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda", correotienda.IdTienda);
            return View(correotienda);
        }

        //// POST: CorreoTienda/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Correo,Descripcion,IdTienda")] data.CorreoTienda correotienda)
        {
            if (id != correotienda.IdCorreo)
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
                        var content = JsonConvert.SerializeObject(correotienda);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/CorreoTienda/" + id, byteContent).Result;

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
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda", correotienda.IdTienda);

            return View(correotienda);
        }

        //// GET: CorreoTienda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correotienda = GetById(id);
            if (correotienda == null)
            {
                return NotFound();
            }

            return View(correotienda);
        }

        //// POST: CorreoTienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/CorreoTienda/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }


        private bool CorreoTiendaExists(int id)
        {
            return (GetById(id) != null);
        }
        private data.CorreoTienda GetById(int? id)
        {
            data.CorreoTienda aux = new data.CorreoTienda();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/CorreoTienda/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.CorreoTienda>(auxres);
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
