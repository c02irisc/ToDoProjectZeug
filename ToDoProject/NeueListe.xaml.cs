using System;
using System.Collections.Generic;
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
    /// Interaktionslogik für NeueListe.xaml
    /// </summary>
    public partial class NeueListe : Window
    {
        public NeueListe()
        {
            InitializeComponent();
            NeueListeViewModel vm = new NeueListeViewModel();

            this.DataContext = vm;
        }

        private void Button_BildLaden(object sender, RoutedEventArgs e)
        {
            ChooseBild fenster = new ChooseBild();

            // An dieser Stelle die Bilderliste mitgeben?
            // an anderer stelle das gewählt bild zurückgeben.

            fenster.ShowDialog();
        }


        private void Button_LoadListeNeu(object sender, RoutedEventArgs e)
        {
            ListenAnsicht fenster = new ListenAnsicht();

            var vm = (NeueListeViewModel)this.DataContext; // takes the Info from vwmodel

            ToDoList erstellteListe  = new ToDoList();
            erstellteListe.Name = vm.neueListe.Name;
            erstellteListe.Bild = vm.neueListe.Bild;
            erstellteListe.Aufgaben = vm.neueListe.Aufgaben;



            // vm.AddAufgabe(erstellteAufgabe);

            vm.AddListe(erstellteListe);


            this.Close();

            // Take info from Todolist and give it to new vm in aktuelle Liste in neuerTask
            fenster.ShowDialog();


        }




    }
}
