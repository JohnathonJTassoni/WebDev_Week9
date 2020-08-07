using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Web.Helper;
using Newtonsoft.Json;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Index
        public async Task<IActionResult> Index()
        {
            var response = await MovieApi.InitializeClient().GetAsync("api/movies");

            if(!response.IsSuccessStatusCode)
                throw new Exception();

            // Storing the response details recieved from web api.
            var result = response.Content.ReadAsStringAsync().Result;

            // Deserializing the response recieved from web api and storing into a list.
            var movies = JsonConvert.DeserializeObject<List<MovieDto>>(result);

            return View(movies);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieDto movie)
        {
            if(ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
                var response = MovieApi.InitializeClient().PostAsync("api/movies", content).Result;

                if(response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            return View(movie);
        }
        
        // GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
                return NotFound();

            var response = await MovieApi.InitializeClient().GetAsync($"api/movies/{id}");

            if(!response.IsSuccessStatusCode)
                throw new Exception();

            var result = response.Content.ReadAsStringAsync().Result;
            var movie = JsonConvert.DeserializeObject<MovieDto>(result);

            return View(movie);
        }

        // POST: Movies/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MovieDto movie)
        {
            if(id != movie.ID)
                return NotFound();

            if(ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
                var response = MovieApi.InitializeClient().PutAsync("api/movies", content).Result;

                if(response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
                return NotFound();

            var response = await MovieApi.InitializeClient().GetAsync($"api/movies/{id}");

            if(!response.IsSuccessStatusCode)
                throw new Exception();

            var result = response.Content.ReadAsStringAsync().Result;
            var movie = JsonConvert.DeserializeObject<MovieDto>(result);

            return View(movie);
        }

        // POST: Movies/Delete/1
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var response = MovieApi.InitializeClient().DeleteAsync($"api/movies/{id}").Result;

            if(response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return NotFound();
        }
    }
}
