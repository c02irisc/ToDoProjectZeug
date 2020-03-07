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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoProject.Models;
using ToDoProject.ViewModels;

namespace ToDoProject
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            vm.FillData();

            // vm.CreateSamples();

            this.DataContext = vm;

        }

        private void Button_ListeAnzeigen(object sender, RoutedEventArgs e)
        {
            ListenAnsicht fenster = new ListenAnsicht();

            ListenAnsichtViewModel viewModel = new ListenAnsichtViewModel();

            // Ausgewählte Liste übergeben
            viewModel.aktuellesToDo = vm.SelectedToDoList;

            fenster.DataContext = viewModel;

            // TODO: Frage ob das hier notwendig ist?
            viewModel.FillAufgabenliste();

            fenster.ShowDialog();
        }

        private void Button_AlleListenAnsehen(object sender, RoutedEventArgs e)
        {
            MainWindow fenster = new MainWindow();

            fenster.ShowDialog();
        }

        private void Button_NeueListeAnlegen(object sender, RoutedEventArgs e)
        {
            NeueListe fenster = new NeueListe();
            NeueListeViewModel viewModel = new NeueListeViewModel();

            ToDoList cache = new ToDoList()
            {
                Name = "",
                Bild = "Pics/011.png",
                Aufgaben = new List<Aufgabe>()
            };

            viewModel.neueListe = cache;

            fenster.DataContext = viewModel;
            fenster.ShowDialog();
        }

        private void Button_ListeLoeschen(object sender, RoutedEventArgs e)
        {
            if(vm.SelectedToDoList != null)
            {
                vm.RemoveToDoList(vm.SelectedToDoList);
                vm.AllToDoLists.Remove(vm.SelectedToDoList);
            }
        }


    }
}
