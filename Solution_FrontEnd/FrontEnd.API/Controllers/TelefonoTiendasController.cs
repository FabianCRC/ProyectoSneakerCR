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
    public class TelefonoTiendasController : Controller
    {
        string baseurl = "http://localhost:61265/";



        // GET: TelefonoTienda
        public async Task<IActionResult> Index()
        {
            List<data.TelefonoTienda> aux = new List<data.TelefonoTienda>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/TelefonoTienda");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.TelefonoTienda>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: TelefonoTienda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonotienda = GetById(id);


            if (telefonotienda == null)
            {
                return NotFound();
            }

            return View(telefonotienda);
        }

        // GET: TelefonoTienda/Create
        public IActionResult Create()
        {
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda");
            return View();
        }

        //POST: TelefonoTienda/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTelefono,Descripcion,Numero,IdTienda")] data.TelefonoTienda telefonotienda)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(telefonotienda);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/TelefonoTienda", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda", telefonotienda.IdTienda);

            return View(telefonotienda);
        }

        // GET: TelefonoTienda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var telefonotienda = GetById(id);
            if (telefonotienda == null)
            {
                return NotFound();
            }

            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda", telefonotienda.IdTienda);
            return View(telefonotienda);
        }

        //// POST: TelefonoTienda/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTelefono,Descripcion,Numero,IdTienda")] data.TelefonoTienda telefonotienda)
        {
            if (id != telefonotienda.IdTelefono)
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
                        var content = JsonConvert.SerializeObject(telefonotienda);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/TelefonoTienda/" + id, byteContent).Result;

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
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "NombreTienda", telefonotienda.IdTienda);

            return View(telefonotienda);
        }

        //// GET: TelefonoTienda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonotienda = GetById(id);
            if (telefonotienda == null)
            {
                return NotFound();
            }

            return View(telefonotienda);
        }

        //// POST: TelefonoTienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/TelefonoTienda/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }


        private bool TelefonoTiendaExists(int id)
        {
            return (GetById(id) != null);
        }
        private data.TelefonoTienda GetById(int? id)
        {
            data.TelefonoTienda aux = new data.TelefonoTienda();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/TelefonoTienda/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.TelefonoTienda>(auxres);
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
