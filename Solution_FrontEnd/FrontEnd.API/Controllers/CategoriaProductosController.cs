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
    public class CategoriaProductosController : Controller
    {
        string baseurl = "https://localhost:44359/";

        // GET: CategoriaProductos 
        public async Task<IActionResult> Index()
        {

            List<data.CategoriaProductos> aux = new List<data.CategoriaProductos>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/CategoriaProducto");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.CategoriaProductos>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: CategoriaProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaproductos = GetById(id);


            if (categoriaproductos == null)
            {
                return NotFound();
            }

            return View(categoriaproductos);
        }

        // GET: CategoriaProductos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Categoria")] data.CategoriaProductos categoriaproductos)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(categoriaproductos);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/CategoriaProducto", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(categoriaproductos);
        }

        // GET: CategoriaProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaproductos = GetById(id);
            if (categoriaproductos == null)
            {
                return NotFound();
            }
            return View(categoriaproductos);
        }

        // POST: CategoriaProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Categoria")] data.CategoriaProductos categoriaproductos)
        {
            if (id != categoriaproductos.IdCategoria)
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
                        var content = JsonConvert.SerializeObject(categoriaproductos);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/CategoriaProducto/" + id, byteContent).Result;

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
            return View(categoriaproductos);
        }

        // GET: CategoriaProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaproductos = GetById(id);
            if (categoriaproductos == null)
            {
                return NotFound();
            }

            return View(categoriaproductos);
        }

        // POST: CategoriaProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/CategoriaProducto/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProductosExists(int id)
        {
            return (GetById(id) != null);
        }

        private data.CategoriaProductos GetById(int? id)
        {
            data.CategoriaProductos aux = new data.CategoriaProductos();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = cl.GetAsync("api/CategoriaProducto/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.CategoriaProductos>(auxres);
                }
            }
            return aux;
        }
    }
}
