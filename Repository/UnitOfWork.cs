using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UnitOfWork
    {
        private readonly IFilmRepository filmRepository;

        public UnitOfWork(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }
        public IFilmRepository FilmRepository { get; set; }
    }
}
