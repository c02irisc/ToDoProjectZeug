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
        public NeuerTask()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var neuerTaskvm = (NeuerTaskViewModel)this.DataContext;
            var vm = (MainWindowViewModel)Application.Current.MainWindow.DataContext;

            ToDoList cache = neuerTaskvm.ToDoList;

            Aufgabe erstellteAufgabe = new Aufgabe();
            erstellteAufgabe.Topic = neuerTaskvm.Aufgabe.Topic;
            erstellteAufgabe.Prio = neuerTaskvm.Aufgabe.Prio;
            erstellteAufgabe.Inhalt = neuerTaskvm.Aufgabe.Inhalt;
            erstellteAufgabe.Category = neuerTaskvm.SelectedCategory;
            if (neuerTaskvm.Aufgabe.Category != null)
            {
                Console.WriteLine(neuerTaskvm.Aufgabe.Category);

                erstellteAufgabe.Category = DefineCategoryIcon(neuerTaskvm.Aufgabe.Category);
            }
            erstellteAufgabe.Category = neuerTaskvm.Aufgabe.Category;

            erstellteAufgabe.Done = false;

           if (neuerTaskvm.ToDoList != null)
            {
                erstellteAufgabe.ParentToDoList = neuerTaskvm.ToDoList;
            }
            neuerTaskvm.ToDoList.Aufgaben.Add(erstellteAufgabe);
            vm.AddAufgabe(erstellteAufgabe);
            vm.AllAufgaben.Add(erstellteAufgabe);

            vm.Update();

            this.Close();
        }

        private String DefineCategoryIcon(String cat)
        {
            return "Test";
        }

        private void ComboBoxKategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var neuerTaskvm = (NeuerTaskViewModel)this.DataContext;
            neuerTaskvm.SelectedCategory = 
        }
    }
}
