﻿using System.Collections.Generic;
using System.Linq;
using MvcMovie.Data;
using MvcMovie.Models.Repository;

namespace MvcMovie.Models.DataManager
{
    public class MovieManager : IDataRepository<Movie, int>
    {
        private readonly MvcMovieContext _context;

        public MovieManager(MvcMovieContext context)
        {
            _context = context;
        }

        public Movie Get(int id)
        {
            return _context.Movie.Find(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movie.ToList();
        }

        public int Add(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();

            return movie.ID;
        }

        public int Delete(int id)
        {
            _context.Movie.Remove(_context.Movie.Find(id));
            _context.SaveChanges();

            return id;
        }

        public int Update(int id, Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            
            return id;
        }
    }
}
