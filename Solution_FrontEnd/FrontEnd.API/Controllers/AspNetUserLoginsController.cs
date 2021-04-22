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
    public class AspNetRoleClaimsController : Controller
    {
        string baseurl = "https://localhost:61265/";


        // GET: AspNetRoleClaims
        public async Task<IActionResult> Index()
        {
            List<data.AspNetRoleClaims> aux = new List<data.AspNetRoleClaims>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/AspNetRoleClaims");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.AspNetRoleClaims>>(auxres);
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

            var aspNetRoleClaims = GetById(id);


            if (aspNetRoleClaims == null)
            {
                return NotFound();
            }

            return View(aspNetRoleClaims);
        }

        // GET: AspNetRoleClaims/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(getAllAspNetRoles(), "Id", "Id");
            return View();
        }

        //POST: AspNetRoleClaims/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleId,ClaimType,ClaimValue")] data.AspNetRoleClaims aspNetRoleClaims)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(aspNetRoleClaims);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/AspNetRoleClaims", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }

            ViewData["RoleId"] = new SelectList(getAllAspNetRoles(), "Id", "AspNetRoles", aspNetRoleClaims.RoleId);

            return View(aspNetRoleClaims);
        }

        // GET: AspNetRoleClaims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var aspNetRoleClaims = GetById(id);
            if (aspNetRoleClaims == null)
            {
                return NotFound();
            }


            ViewData["RoleId"] = new SelectList(getAllAspNetRoles(), "Id", "AspNetRoles", aspNetRoleClaims.RoleId);
            return View(aspNetRoleClaims);
        }

        //// POST: AspNetRoleClaims/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoleId,ClaimType,ClaimValue")] data.AspNetRoleClaims aspNetRoleClaims)
        {
            if (id != aspNetRoleClaims.Id)
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
                        var content = JsonConvert.SerializeObject(aspNetRoleClaims);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/AspNetRoleClaims/" + id, byteContent).Result;

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
            ViewData["RoleId"] = new SelectList(getAllAspNetRoles(), "Id", "AspNetRoles", aspNetRoleClaims.RoleId);

            return View(aspNetRoleClaims);
        }

        //// GET: AspNetUserRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetRoleClaims = GetById(id);
            if (aspNetRoleClaims == null)
            {
                return NotFound();
            }

            return View(aspNetRoleClaims);
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
                HttpResponseMessage res = await cl.DeleteAsync("api/AspNetRoleClaims/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }


        private bool AspNetUserRolesExists(int id)
        {
            return (GetById(id) != null);
        }
        private data.AspNetRoleClaims GetById(int? id)
        {
            data.AspNetRoleClaims aux = new data.AspNetRoleClaims();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/AspNetRoleClaims/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.AspNetRoleClaims>(auxres);
                }
            }
            return aux;
        }

        private List<data.AspNetRoles> getAllAspNetRoles()
        {

            List<data.AspNetRoles> aux = new List<data.AspNetRoles>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/AspNetRoles").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.AspNetRoles>>(auxres);
                }
            }
            return aux;
        }

    }
}
