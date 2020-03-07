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
            NeuerTask fenster = new NeuerTask();
           
            fenster.ShowDialog();
            var vm = (ListenAnsichtViewModel)this.DataContext;
            vm.FillAufgabenliste();

        }
    }
}
