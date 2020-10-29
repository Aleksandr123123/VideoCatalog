using Persist;
using Persist.Entityes;
using PresentationLayer.Models;
using PresentationLayer.Services.BaseServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services.BaseServices.Implementation
{
    public class RegisseurService : IRegisseurService
    {
        private readonly EFDBContext _context;

        public RegisseurService(EFDBContext context)
        {
            _context = context;
        }

        public async Task<Regisseur> CreateRegisseurAsync(RegisseurViewModel regisseurView)
        {

            var regisseur = new Regisseur()
            {
                Id = Guid.NewGuid(),
                Name = regisseurView.Name
            };
            var result = await _context.AddAsync(regisseur);
            return result.Entity;
        }
    }
}
