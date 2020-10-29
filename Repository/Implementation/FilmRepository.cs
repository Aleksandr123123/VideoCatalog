using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Persist;
using Persist.Entityes;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Implementation
{
    public class FilmRepository : IFilmRepository
    {
        private readonly EFDBContext _context;

        public FilmRepository(EFDBContext context)
        {
            _context = context;
        }

        public void Create(Film item)
        {
            var result = _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Film film = _context.Films.Find(id);
            if(film != null)
            {
                _context.Remove(film);
            }
        }

        public Film Get(Guid id)
        {
            return _context.Films.FirstOrDefault(c=> c.Id.Equals(id));
        }

        public IEnumerable<Film> GetAll()
        {
            return _context.Films;
        }

        public void Update(Film item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
