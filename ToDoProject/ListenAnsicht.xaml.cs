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
    /// Interaktionslogik für ListenAnsicht.xaml
    /// </summary>
    public partial class ListenAnsicht : Window
    {
        public ListenAnsicht()
        {
            InitializeComponent();

            /*
            ListenAnsichtViewModel vm = new ListenAnsichtViewModel();
                        
            vm.FillAufgabenliste();

            this.DataContext = vm;
            */
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var thisViewModel = (ListenAnsichtViewModel)this.DataContext;
            NeuerTask fenster = new NeuerTask();
            NeuerTaskViewModel viewModel = new NeuerTaskViewModel();
            viewModel.ToDoList = thisViewModel.aktuellesToDo;

            fenster.DataContext = viewModel;

            fenster.ShowDialog();

        }
        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
            var vm = (MainWindowViewModel)Application.Current.MainWindow.DataContext;
            vm.Update();
            var thisViewModel = (ListenAnsichtViewModel)this.DataContext;
            thisViewModel.updateCount();
        }

        private void Filter_Name(object sender, RoutedEventArgs e)
        {
            var thisViewModel = (ListenAnsichtViewModel)this.DataContext;
            thisViewModel.FilterBy("Name");
        }
        private void Filter_Prio(object sender, RoutedEventArgs e)
        {
            var thisViewModel = (ListenAnsichtViewModel)this.DataContext;
            thisViewModel.FilterBy("Prio");
        }
        private void Filter_Kategorie(object sender, RoutedEventArgs e)
        {
            var thisViewModel = (ListenAnsichtViewModel)this.DataContext;
            thisViewModel.FilterBy("Kategorie");
        }
        private void Filter_Undone(object sender, RoutedEventArgs e)
        {
            var thisViewModel = (ListenAnsichtViewModel)this.DataContext;
            thisViewModel.FilterBy("Undone");
        }
        private void Filter_Done(object sender, RoutedEventArgs e)
        {
            var thisViewModel = (ListenAnsichtViewModel)this.DataContext;
            thisViewModel.FilterBy("Done");
        }

        private void Reload(object sender, RoutedEventArgs e)
        {
            var thisViewModel = (ListenAnsichtViewModel)this.DataContext;
            var vm = (MainWindowViewModel)Application.Current.MainWindow.DataContext;
            thisViewModel.AllAufgaben = vm.AllAufgaben;
            thisViewModel.FillAufgabenliste();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            /*
            var vm = (MainWindowViewModel)Application.Current.MainWindow.DataContext;

            var thisViewModel = (ListenAnsichtViewModel)this.DataContext;

            if(thisViewModel.SelectedAufgabe != null)
            {
                vm.RemoveAufgabe(thisViewModel.SelectedAufgabe);
                vm.AllAufgaben.Remove(thisViewModel.SelectedAufgabe);
            }
            */
        }

  
    }
}
