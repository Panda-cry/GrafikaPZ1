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
    /// Interaction logic for PolyghonChange.xaml
    /// </summary>
    public partial class PolyghonChange : Window
    {
        public PolyghonChange()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PolyghonChangeModel model = new PolyghonChangeModel();
            if(strokeColorPicker.SelectedColor != null)
            {
                model.StrokeFill = new SolidColorBrush(strokeColorPicker.SelectedColor.Value);
            }
            if(strokeThickness.Value != null)
            {
                model.StrokThic = strokeThickness.Value.Value;
            }
            if(polygonColourPicker.SelectedColor != null)
            {
                model.Fill = new SolidColorBrush(polygonColourPicker.SelectedColor.Value);
            }

            MainWindow.polyghonChangeModle = model;
            this.Close();

        }
    }
}
