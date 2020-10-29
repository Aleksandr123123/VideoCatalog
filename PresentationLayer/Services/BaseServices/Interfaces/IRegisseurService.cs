using Persist.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services.BaseServices.Interfaces
{
    public interface IRegisseurService
    {
        Task<Regisseur> CreateRegisseurAsync(RegisseurViewModel customer);
    }
}
