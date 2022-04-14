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
                    StrokThic = 33,
                    Fill = Brushes.Red,
                    StrokeFill = Brushes.Blue

                };

                if (polygonColourPicker.SelectedColor != null)
                {
                    model.Fill = new SolidColorBrush(polygonColourPicker.SelectedColor.Value);
                }
                if (strokeColorPicker.SelectedColor != null)
                {
                    model.StrokeFill = new SolidColorBrush(strokeColorPicker.SelectedColor.Value);
                }
                if(strokeThickness.Value != null)
                {
                    model.StrokThic = strokeThickness.Value.Value;
                }
            }
            else
            {
                model = new PolygonModel()
                {
                    Text = "Neki Text",
                    TextColour = Brushes.Blue,
                    StrokThic = 33,
                    Fill = Brushes.Red,
                    StrokeFill = Brushes.Gray

                };
                if(polygonText.Text.Length != 0)
                {
                    model.Text = polygonText.Text;
                }
                if(textColour.SelectedColor != null)
                {
                    model.TextColour = new SolidColorBrush(textColour.SelectedColor.Value);
                }
                if (polygonColourPicker.SelectedColor != null)
                {
                    model.Fill = new SolidColorBrush(polygonColourPicker.SelectedColor.Value);
                }
                if (strokeColorPicker.SelectedColor != null)
                {
                    model.StrokeFill = new SolidColorBrush(strokeColorPicker.SelectedColor.Value);
                }
                if (strokeThickness.Value != null)
                {
                    model.StrokThic = strokeThickness.Value.Value;
                }
            }
           
            MainWindow.polygonModel = model;
            this.Close();
        }
    }
}
