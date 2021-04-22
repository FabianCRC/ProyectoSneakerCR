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
    public class AspNetUserLoginsController : Controller
    {
        string baseurl = "https://localhost:61265/";


        // GET: AspNetUserLogins
        public async Task<IActionResult> Index()
        {
            List<data.AspNetUserLogins> aux = new List<data.AspNetUserLogins>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/AspNetUserLogins");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.AspNetUserLogins>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: AspNetRoleClaims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserLogins = GetById(id);


            if (aspNetUserLogins == null)
            {
                return NotFound();
            }

            return View(aspNetUserLogins);
        }

        // GET: AspNetUserLogins/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(getAllAspNetUsers(), "Id", "Id");
            return View();
        }

        //POST: AspNetUserLogins/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LoginProvider,ProviderKey,ProviderDisplayName,UserId")] data.AspNetUserLogins aspNetUserLogins)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(aspNetUserLogins);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/AspNetUserLogins", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }


            ViewData["UserId"] = new SelectList(getAllAspNetUsers(), "Id", "Id", aspNetUserLogins.UserId);

            return View(aspNetUserLogins);
        }

        // GET: aspNetUserLogins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var aspNetUserLogins = GetById(id);
            if (aspNetUserLogins == null)
            {
                return NotFound();
            }


            ViewData["UserId"] = new SelectList(getAllAspNetUsers(), "Id", "Id", aspNetUserLogins.UserId);
            return View(aspNetUserLogins);
        }

        //// POST: AspNetRoleClaims/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LoginProvider,ProviderKey,ProviderDisplayName,UserId")] data.AspNetUserLogins aspNetUserLogins)
        {
            if (id != aspNetUserLogins.Id)
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
                        var content = JsonConvert.SerializeObject(aspNetUserLogins);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/AspNetUserLogins/" + id, byteContent).Result;

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
            ViewData["UserId"] = new SelectList(getAllAspNetUsers(), "Id", "Id", aspNetUserLogins.UserId);

            return View(aspNetUserLogins);
        }

        //// GET: AspNetUserRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserLogins = GetById(id);
            if (aspNetUserLogins == null)
            {
                return NotFound();
            }

            return View(aspNetUserLogins);
        }

        //// POST: AspNetUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/AspNetUserLogins/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }


        private bool AspNetUserLoginsExists(int id)
        {
            return (GetById(id) != null);
        }
        private data.AspNetUserLogins GetById(int? id)
        {
            data.AspNetUserLogins aux = new data.AspNetUserLogins();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/AspNetUserLogins/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.AspNetUserLogins>(auxres);
                }
            }
            return aux;
        }

        private List<data.AspNetUsers> getAllAspNetUsers()
        {

            List<data.AspNetUsers> aux = new List<data.AspNetUsers>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/AspNetUsers").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.AspNetUsers>>(auxres);
                }
            }
            return aux;
        }

    }
}
