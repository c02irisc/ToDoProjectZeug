using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoProject.Models;
using ToDoProject.ViewModels;

namespace ToDoProject
{
    /// <summary>
    /// Interaktionslogik für NeuerTask.xaml
    /// </summary>
    public partial class NeuerTask : Window
    {

        public ToDoList aktuelleListe { get; set; }

        public NeuerTask()
        {
            InitializeComponent();

            NeuerTaskViewModel vm = new NeuerTaskViewModel();

            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var vm = (NeuerTaskViewModel)this.DataContext;

            Aufgabe erstellteAufgabe = new Aufgabe();
                erstellteAufgabe.Topic = vm.Aufgabe.Topic;
                erstellteAufgabe.Prio = vm.Aufgabe.Prio;
                erstellteAufgabe.Inhalt = vm.Aufgabe.Inhalt;
                erstellteAufgabe.Category = vm.Aufgabe.Category;
                erstellteAufgabe.Done = false;
                erstellteAufgabe.ParentToDoList = aktuelleListe;
                 
            vm.AddAufgabe(erstellteAufgabe);
         

            this.Close();

        }
    }
}
