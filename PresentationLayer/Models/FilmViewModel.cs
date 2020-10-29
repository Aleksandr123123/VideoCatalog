using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class FilmViewModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset YearManufacture { get; set; }
        public string RegisseurName { get; set; } 
        public string Poster { get; set; }
        public string UserId { get; set; }
    }
    public class FilmViewModelEdit
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset YearManufacture { get; set; } 
        public IFormFile Poster { get; set; } 
    }
    public class FilmCreateModel
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset YearManufacture { get; set; }
        public IFormFile Poster { get; set; }
        public string Regisseur { get; set; }
        public string UserId { get; set; } 
    }
    public class FilmUpdateModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; } 
        public IFormFile Poster { get; set; } 
    }

    public class IndexFilmViewModel
    {
        public IEnumerable<FilmViewModel> Films { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
