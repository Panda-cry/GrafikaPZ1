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
    /// Interaction logic for DrawElipse.xaml
    /// </summary>
    public partial class DrawElipse : Window
    {
        public DrawElipse()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EllipseModel models = null;
            if (textColour.SelectedColor==null && ellipseText.Text == "")
            {
            models = new EllipseModel(width.Value.Value, height.Value.Value, strokeThickness.Value.Value,new SolidColorBrush(ellipseColourPicker.SelectedColor.Value), new SolidColorBrush(strokeColorPicker.SelectedColor.Value));
               
            }
            else
            {
             models= new EllipseModel(width.Value.Value, height.Value.Value, strokeThickness.Value.Value,new SolidColorBrush(ellipseColourPicker.SelectedColor.Value), new SolidColorBrush(strokeColorPicker.SelectedColor.Value),new SolidColorBrush(textColour.SelectedColor.Value),ellipseText.Text);
              
            }
            MainWindow.model = models;
            this.Close();
        }
    }
}
