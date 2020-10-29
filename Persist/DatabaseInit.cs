using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persist.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persist
{
    public interface IDatabaseInit
    {
        Task SeedAsync();
    }

    public class DatabaseInit : IDatabaseInit
    {
        private readonly EFDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DatabaseInit(EFDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);
            if (!await _context.Users.AnyAsync())
            { 
                ApplicationUser user = new ApplicationUser (){Email = "user@mail.ru", UserName = "user@mail.ru", FullName = "user" };
                List<Regisseur> regisseurs = new List<Regisseur>()
                {
                    new Regisseur() {Id = Guid.NewGuid(), Name = "Ricardo Torell" },
                    new Regisseur() {Id = Guid.NewGuid(), Name = "Djon Skit" }
                };
                Film film = new Film()
                {
                    Id = Guid.NewGuid(),
                    Description = "Seme film",
                    Name = "Gachi",
                    Regisseur = regisseurs.FirstOrDefault(),
                    User = user
                };
                    
                await _userManager.CreateAsync(user, "1234"); 

                try
                {  
                    await _context.AddRangeAsync(regisseurs);
                    await _context.AddAsync(film);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    throw;
                } 
            }

        }
    }

}