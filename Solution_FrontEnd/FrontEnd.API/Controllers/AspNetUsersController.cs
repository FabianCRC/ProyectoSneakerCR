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
    public class AspNetUsersController : Controller
    {
        string baseurl = "http://localhost:61265/";


        // GET: AspNetUsers
        public async Task<IActionResult> Index()
            {

                List<data.AspNetUsers> aux = new List<data.AspNetUsers>();
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = await cl.GetAsync("api/AspNetUsers");

                    if (res.IsSuccessStatusCode)
                    {
                        var auxres = res.Content.ReadAsStringAsync().Result;
                        aux = JsonConvert.DeserializeObject<List<data.AspNetUsers>>(auxres);
                    }
                }
                return View(aux);
            }

        // GET: AspNetUsers/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var aspNetUsers = GetById(id);


                if (aspNetUsers == null)
                {
                    return NotFound();
                }

                return View(aspNetUsers);
            }

        // GET: AspNetUsers/Create
        public IActionResult Create()
            {
                return View();
            }

        // POST: AspNetUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount")] data.AspNetUsers aspNetUsers)
            {
                if (ModelState.IsValid)
                {
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(baseurl);
                        var content = JsonConvert.SerializeObject(aspNetUsers);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PostAsync("api/AspNetUsers", byteContent).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                return View(aspNetUsers);
            }

        // GET: AspNetUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var aspNetUsers = GetById(id);
                if (aspNetUsers == null)
                {
                    return NotFound();
                }
                return View(aspNetUsers);
            }

        // POST: AspNetUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] data.AspNetUsers aspNetUsers)
            {
                if (id != Convert.ToInt32(aspNetUsers.Id))
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
                            var content = JsonConvert.SerializeObject(aspNetUsers);
                            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                            var byteContent = new ByteArrayContent(buffer);
                            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                            var postTask = cl.PutAsync("api/AspNetUsers/" + id, byteContent).Result;

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
                return View(aspNetUsers);
            }

        // GET: AspNetUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var aspNetUsers = GetById(id);
                if (aspNetUsers == null)
                {
                    return NotFound();
                }

                return View(aspNetUsers);
            }

        // POST: AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = await cl.DeleteAsync("api/AspNetUsers/" + id);

                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            private bool AspNetUsersExists(int id)
            {
                return (GetById(id) != null);
            }

            private data.AspNetUsers GetById(int? id)
            {
                data.AspNetUsers aux = new data.AspNetUsers();
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = cl.GetAsync("api/AspNetUsers/" + id).Result;

                    if (res.IsSuccessStatusCode)
                    {
                        var auxres = res.Content.ReadAsStringAsync().Result;
                        aux = JsonConvert.DeserializeObject<data.AspNetUsers>(auxres);
                    }
                }
                return aux;
            }
        }
}
