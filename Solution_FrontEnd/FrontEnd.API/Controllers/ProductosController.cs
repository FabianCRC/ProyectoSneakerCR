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
    public class ProductosController : Controller
    {
        string baseurl = "http://localhost:61265/";



        // GET: Productos
        public async Task<IActionResult> Index()
        {
            List<data.Productos> aux = new List<data.Productos>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Productos");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Productos>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = GetById(id);


            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(getAllCategoriaProductos(), "IdCategoria", "Categoria");
            ViewData["IdMarcaProducto"] = new SelectList(getAllMarcaProductos(), "IdMarca", "MarcaProducto");
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "DescripcionTienda");
            return View();
        }

        //POST: Productos/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,NombreProducto,DescripcionPproducto,Anno,Valor,IdMarcaProducto,IdTienda,IdCategoria")] data.Productos productos)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(productos);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/Productos", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["IdCategoria"] = new SelectList(getAllCategoriaProductos(), "IdCategoria", "Categoria", productos.IdCategoria);
            ViewData["IdMarcaProducto"] = new SelectList(getAllMarcaProductos(), "IdMarca", "MarcaProducto", productos.IdMarcaProducto);
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "DescripcionTienda", productos.IdTienda);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var productos = GetById(id);
            if (productos == null)
            {
                return NotFound();
            }

            ViewData["IdCategoria"] = new SelectList(getAllCategoriaProductos(), "IdCategoria", "Categoria", productos.IdCategoria);
            ViewData["IdMarcaProducto"] = new SelectList(getAllMarcaProductos(), "IdMarca", "MarcaProducto", productos.IdMarcaProducto);
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "DescripcionTienda", productos.IdTienda);

            return View(productos);
        }

        //// POST: Productos/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,NombreProducto,DescripcionPproducto,Anno,Valor,IdMarcaProducto,IdTienda,IdCategoria")]  data.Productos productos)
        {
            if (id != productos.IdProducto)
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
                        var content = JsonConvert.SerializeObject(productos);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/Productos/" + id, byteContent).Result;

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
            ViewData["IdCategoria"] = new SelectList(getAllCategoriaProductos(), "IdCategoria", "Categoria", productos.IdCategoria);
            ViewData["IdMarcaProducto"] = new SelectList(getAllMarcaProductos(), "IdMarca", "MarcaProducto", productos.IdMarcaProducto);
            ViewData["IdTienda"] = new SelectList(getAllTiendas(), "IdTienda", "DescripcionTienda", productos.IdTienda);
            return View(productos);
        }

        //// GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = GetById(id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        //// POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/Productos/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }


        private bool ProductosExists(int id)
        {
            return (GetById(id) != null);
        }
        private data.Productos GetById(int? id)
        {
            data.Productos aux = new data.Productos();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Productos/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.Productos>(auxres);
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
        private List<data.MarcaProductos> getAllMarcaProductos()
        {

            List<data.MarcaProductos> aux = new List<data.MarcaProductos>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/MarcaProductos").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.MarcaProductos>>(auxres);
                }
            }
            return aux;
        }
        private List<data.CategoriaProductos> getAllCategoriaProductos()
        {

            List<data.CategoriaProductos> aux = new List<data.CategoriaProductos>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/CategoriaProducto").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.CategoriaProductos>>(auxres);
                }
            }
            return aux;
        }
    }
}
