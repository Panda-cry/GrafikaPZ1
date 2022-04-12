using Grafika.Models;
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

namespace Grafika
{
    /// <summary>
    /// Interaction logic for TextChange.xaml
    /// </summary>
    public partial class TextChange : Window
    {
        public TextChange()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextChangeModel model = new TextChangeModel();
            if(foreground.SelectedColor != null)
            {
                model.Foregroung = new SolidColorBrush(foreground.SelectedColor.Value);
            }
            if(background.SelectedColor != null)
            {
                model.Background = new SolidColorBrush(background.SelectedColor.Value);
            }

            MainWindow.textChangeModel = model;
            this.Close();
        }
    }
}
