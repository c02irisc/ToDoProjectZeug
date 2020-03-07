using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
     class ToDoListContext : DbContext
    {
        public DbSet<ToDoList> ToDoListen { get; set; }

        public DbSet<Aufgabe> Aufgaben { get; set; }

        
    }
}
