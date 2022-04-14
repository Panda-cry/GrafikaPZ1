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
            AddTextModel model = new AddTextModel() { Text = "Neki Text",Size = 400, Background = Brushes.Red, Foregorund = Brushes.BlueViolet };

            if(text.Text.Length != 0)
            {
                model.Text = text.Text;
            }
            if(size.Value != null)
            {
                model.Size = size.Value.Value;
            }
            if(foreground.SelectedColor != null)
            {
                model.Foregorund = new SolidColorBrush(foreground.SelectedColor.Value);
            }
            if(background.SelectedColor != null)
            {
                model.Background = new SolidColorBrush(background.SelectedColor.Value);
            }

            MainWindow.addTextModel = model;
            this.Close();
        }
    }
}
