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

        }

        private void Button_BildLaden(object sender, RoutedEventArgs e)
        {
            ChooseBild fenster = new ChooseBild();

            fenster.DataContext = (NeueListeViewModel)this.DataContext;

            fenster.ShowDialog();
        }


        private void Button_LoadListeNeu(object sender, RoutedEventArgs e)
        {
            // SAVE THE NEW GENERATED LIST

            var vm = (MainWindowViewModel)Application.Current.MainWindow.DataContext;
            var newListVM = (NeueListeViewModel)this.DataContext;

            ToDoList erstellteListe = new ToDoList();
            erstellteListe.Name = newListVM.neueListe.Name.Equals("") ? "Kein Name eingegeben" : newListVM.neueListe.Name;

            erstellteListe.Bild = newListVM.neueListe.Bild;
            erstellteListe.Aufgaben = newListVM.neueListe.Aufgaben;

            // DB Save
            vm.AddNewToDoList(erstellteListe);
            // Liste im Main wird upgedated
            vm.AllToDoLists.Add(erstellteListe);
            // Selected Element wird übergeben
            vm.SelectedToDoList = erstellteListe;


            // OPEN IN NEW WINDOW
            ListenAnsicht fenster = new ListenAnsicht();
            ListenAnsichtViewModel viewModel = new ListenAnsichtViewModel();

            // Ausgewählte Liste übergeben
            viewModel.aktuellesToDo = vm.SelectedToDoList;
            fenster.DataContext = viewModel;

            // TODO: Frage ob das hier notwendig ist?
            viewModel.FillAufgabenliste();

            this.Close();
            fenster.ShowDialog();
        }




    }
}
