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
    /// Interaction logic for AddText.xaml
    /// </summary>
    public partial class AddText : Window
    {
        public AddText()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTextModel model = new AddTextModel(text.Text, new SolidColorBrush(foreground.SelectedColor.Value), new SolidColorBrush(background.SelectedColor.Value), size.Value.Value);
            MainWindow.addTextModel = model;
            this.Close();
        }
    }
}
