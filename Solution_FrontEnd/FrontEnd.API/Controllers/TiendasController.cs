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
    public class TiendasController : Controller
    {
        string baseurl = "http://localhost:61265/";


        // GET: Tiendas 
        public async Task<IActionResult> Index()
            {

                List<data.Tiendas> aux = new List<data.Tiendas>();
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = await cl.GetAsync("api/Tiendas");

                    if (res.IsSuccessStatusCode)
                    {
                        var auxres = res.Content.ReadAsStringAsync().Result;
                        aux = JsonConvert.DeserializeObject<List<data.Tiendas>>(auxres);
                    }
                }

                return View(aux);
        }

            // GET: Tiendas/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tiendas = GetById(id);


                if (tiendas == null)
                {
                    return NotFound();
                }
            ViewData["Valoraciones"] = new List<data.ValoracionTienda>(getAllValoracionesTienda());
            ViewData["telefonos"] = new List<data.TelefonoTienda>(getAllTelefonoTienda());
            ViewData["correos"] = new List<data.CorreoTienda>(getAllCorreoTienda());
            ViewData["productos"] = new List<data.Productos>(getAllProductos());
            ViewData["idTienda"] = id;
            return View(tiendas);
            }

            // GET: Tiendas/Create
            public IActionResult Create()
            {

            return View();
            }

            // POST: Tiendas/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("IdTienda,NombreTienda,DescripcionTienda")] data.Tiendas tiendas)
            {


            if (ModelState.IsValid)
                {

                using (var cl = new HttpClient())
                    {

                    if (tiendas.IdTienda != null) { 

                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(tiendas);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/Tiendas", byteContent).Result;
                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }

                    }            

            }

            return View(tiendas);
            }

            // GET: Tiendas/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tiendas = GetById(id);
                if (tiendas == null)
                {
                    return NotFound();
                }
                return View(tiendas);
            }

            // POST: Tiendas/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("IdTienda,NombreTienda,DescripcionTienda")] data.Tiendas tiendas)
            {
                if (id != tiendas.IdTienda)
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
                            var content = JsonConvert.SerializeObject(tiendas);
                            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                            var byteContent = new ByteArrayContent(buffer);
                            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                            var postTask = cl.PutAsync("api/Tiendas/" + id, byteContent).Result;

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
                return View(tiendas);
            }

            // GET: Tiendas/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tiendas = GetById(id);
                if (tiendas == null)
                {
                    return NotFound();
                }

                return View(tiendas);
            }

            // POST: Tiendas/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = await cl.DeleteAsync("api/Tiendas/" + id);

                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            private bool TiendasExists(int id)
            {
                return (GetById(id) != null);
            }

            private data.Tiendas GetById(int? id)
            {
                data.Tiendas aux = new data.Tiendas();
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = cl.GetAsync("api/Tiendas/" + id).Result;

                    if (res.IsSuccessStatusCode)
                    {
                        var auxres = res.Content.ReadAsStringAsync().Result;
                        aux = JsonConvert.DeserializeObject<data.Tiendas>(auxres);
                    }
                }
                return aux;
            }
        private List<data.ValoracionTienda> getAllValoracionesTienda()
        {

            List<data.ValoracionTienda> aux = new List<data.ValoracionTienda>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/ValoracionTienda").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.ValoracionTienda>>(auxres);
                }
            }
            return aux;
        }

        private List<data.TelefonoTienda> getAllTelefonoTienda()
        {

            List<data.TelefonoTienda> aux = new List<data.TelefonoTienda>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/TelefonoTienda").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.TelefonoTienda>>(auxres);
                }
            }
            return aux;
        }

        private List<data.CorreoTienda> getAllCorreoTienda()
        {

            List<data.CorreoTienda> aux = new List<data.CorreoTienda>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/CorreoTienda").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.CorreoTienda>>(auxres);
                }
            }
            return aux;
        }

        private List<data.Productos> getAllProductos()
        {

            List<data.Productos> aux = new List<data.Productos>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Productos").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Productos>>(auxres);
                }
            }
            return aux;
        }


    }
}
