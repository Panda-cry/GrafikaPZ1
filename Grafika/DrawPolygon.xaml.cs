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
    /// Interaction logic for DrawPolygon.xaml
    /// </summary>
    public partial class DrawPolygon : Window
    {
        public DrawPolygon()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PolygonModel model = null;
            if (textColour.SelectedColor == null || polygonText.Text == "")
            {
                model = new PolygonModel()
                {
                    StrokThic = strokeThickness.Value.Value,
                    Fill = new SolidColorBrush(polygonColourPicker.SelectedColor.Value),
                    StrokeFill = new SolidColorBrush(strokeColorPicker.SelectedColor.Value)

                };
            }
            else
            {
                model = new PolygonModel()
                {
                    Text = polygonText.Text,
                    TextColour = new SolidColorBrush(textColour.SelectedColor.Value),
                    StrokThic = strokeThickness.Value.Value,
                    Fill = new SolidColorBrush(polygonColourPicker.SelectedColor.Value),
                    StrokeFill = new SolidColorBrush(strokeColorPicker.SelectedColor.Value)

                };
            }
           
            MainWindow.polygonModel = model;
            this.Close();
        }
    }
}
