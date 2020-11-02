using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persist.Entityes
{
    public class Film
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int YearManufacture { get; set; }
        public string Poster { get; set; }
        public Guid RegisseurId { get; set; }
        public string UserId { get; set; }
        public Regisseur Regisseur { get; set; }
        public ApplicationUser User { get; set; }

    }
}
