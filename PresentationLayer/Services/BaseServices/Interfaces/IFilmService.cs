using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services.BaseServices.Interfaces
{
    public  interface IFilmService
    {
        Task<List<FilmViewModel>> GetFilmListAsync(); 
        Task<IndexFilmViewModel> GetFilmPageAsync(int page); 
        FilmViewModel GetFilmById(int filmId);
        Task<FilmViewModel> GetFilmByIdAsync(string filmId);

        Task CreateFilmAsync(FilmCreateModel customer);
        Task UpdateFilmAsync(FilmViewModelEdit filmViewModelEdit);   
    }
}
