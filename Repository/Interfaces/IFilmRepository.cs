using Persist.Entityes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository.Interfaces
{
    public interface IFilmRepository 
    {
        IEnumerable<Film> GetAll();
        Film Get(Guid id);
        void Create(Film item);
        void Update(Film item);
        void Delete(int id);
    }
}
