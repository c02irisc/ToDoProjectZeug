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
    /// Interaktionslogik für ChooseBild.xaml
    /// </summary>
    public partial class ChooseBild : Window
    {

        
        public ChooseBild()
        {
            InitializeComponent();
        }

        private void Button_BildSpeichern(object sender, RoutedEventArgs e)
        {
            var cacheVM = (NeueListeViewModel)this.DataContext;
            cacheVM.neueListe.Bild = cacheVM.SelectedBild;

            this.Close();

        }
    }
}
