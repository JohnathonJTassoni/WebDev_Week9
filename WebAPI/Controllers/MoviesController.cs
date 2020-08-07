using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Models.DataManager;

namespace MvcMovie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly MovieManager _repo;

        public MoviesController(MovieManager repo)
        {
            _repo = repo;
        }

        // GET: api/movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _repo.GetAll();
        }

        // GET api/movies/1
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return _repo.Get(id);
        }

        // POST api/movies
        [HttpPost]
        public void Post([FromBody] Movie movie)
        {
            _repo.Add(movie);
        }

        // PUT api/movies
        [HttpPut]
        public void Put([FromBody] Movie movie)
        {
            _repo.Update(movie.ID, movie);
        }

        // DELETE api/movies/1
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
