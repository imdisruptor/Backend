using Backend.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModels
{
    public class DirectoryViewModel
    {
        List<Catalog> Catalogs { get; set; }
        List<Message> Messages { get; set; }
    }
}
