using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entityes;
using PresentationLayer.Models;
using PresentationLayer.Services.BaseServices.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services.BaseServices.Implementation
{
    public class FilmService : IFilmService
    {
        private readonly EFDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRegisseurService _regisseurService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FilmService(EFDBContext context, UserManager<ApplicationUser> userManager, IRegisseurService regisseurService, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _regisseurService = regisseurService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task CreateFilmAsync(FilmCreateModel createFilm)
        {
            string uniqueFileName = null;
            Guid guid = Guid.NewGuid();
            if (createFilm.Poster != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueFileName = guid.ToString() + "_" + Path.GetFileName(createFilm.Poster.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                await createFilm.Poster.CopyToAsync(new FileStream(filePath, FileMode.Create));
            }
            var film = new Film()
            {
                Name = createFilm.Name,
                Description = createFilm.Description,
                YearManufacture = createFilm.YearManufacture,
                Poster = uniqueFileName,
                User = await _userManager.FindByIdAsync(createFilm.UserId),
                Regisseur = await GetRegisseur(createFilm.Regisseur)
            };
            await _context.Films.AddAsync(film);
            await _context.SaveChangesAsync();
             
        }
        private async Task<Regisseur> GetRegisseur(string name)
        {
            var result = await _context.Regisseurs.FirstOrDefaultAsync(e => e.Name == name);
            if(result == null)
            {
                return new Regisseur()
                {
                    Id = Guid.NewGuid(),
                    Name = name
                };
            }
            return result;
        }
      
        public FilmViewModel GetFilmById(int filmId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FilmViewModel>> GetFilmListAsync()
        { 
            var data = await _context.Films.Include(u => u.Regisseur).ToListAsync();
            var resultList = data.Select(e => new FilmViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                YearManufacture = e.YearManufacture,
                RegisseurName = e.Regisseur.Name,
                Poster = e.Poster
            });
            return resultList.ToList();
        }

        public async Task UpdateFilmAsync(FilmViewModelEdit filmViewModelEdit)
        {
            string uniqueFileName = null;
            if(filmViewModelEdit.Poster != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueFileName = filmViewModelEdit.Id.ToString() + "_" + Path.GetFileName(filmViewModelEdit.Poster.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                await filmViewModelEdit.Poster.CopyToAsync(new FileStream(filePath, FileMode.Create));
            }
            Film film = await _context.Films.FindAsync(filmViewModelEdit.Id);

            film.Name = filmViewModelEdit.Name;
            film.Description = filmViewModelEdit.Description;
            film.Poster = uniqueFileName ?? film.Poster;
            film.YearManufacture = filmViewModelEdit.YearManufacture;
            await _context.SaveChangesAsync();
        }

        public async Task<IndexFilmViewModel> GetFilmPageAsync(int page)
        {
            int pageSize = 10;
            var data = await _context.Films.Skip((page - 1) * pageSize).Take(pageSize).Include(u => u.Regisseur).ToListAsync();
            var filmViewModels = data.Select(e => new FilmViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                YearManufacture = e.YearManufacture,
                RegisseurName = e.Regisseur.Name,
                Poster = e.Poster,
                UserId = e.UserId
            });
            var resultList = filmViewModels.ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = _context.Films.Count() };
            IndexFilmViewModel index = new IndexFilmViewModel { PageInfo = pageInfo, Films = resultList };
            return index;
        }

        public async Task<FilmViewModel> GetFilmByIdAsync(string filmId)
        {
            var film = await _context.Films.Include(e=> e.Regisseur).FirstOrDefaultAsync(e => e.Id.ToString().ToLower() ==  filmId.ToLower());
            var filmViewModels =  new FilmViewModel
            {
                Id = film.Id,
                Name = film.Name,
                Description = film.Description,
                YearManufacture = film.YearManufacture,
                RegisseurName = film.Regisseur.Name,
                Poster = film.Poster,
                UserId = film.UserId
            };
            return filmViewModels;
        }
    }
}
