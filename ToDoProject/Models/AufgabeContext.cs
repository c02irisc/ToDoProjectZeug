using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
    class AufgabeContext : DbContext
    {
        public DbSet<Aufgabe> Aufgaben { get; set; }
        // danach geht es in die View-Modell-Klasse
    }

}
