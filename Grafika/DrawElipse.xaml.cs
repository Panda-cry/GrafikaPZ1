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
            models = new EllipseModel(333, 333, 33,Brushes.Red, Brushes.Blue);
                if(width.Value != null)
                {
                    models.Width = width.Value.Value;
                }
                if (height.Value != null)
                {
                    models.Height = height.Value.Value;
                }
                if (strokeThickness.Value != null)
                {
                    models.StrokeThic = strokeThickness.Value.Value;
                }
                if (ellipseColourPicker.SelectedColor != null)
                {
                    models.Fill = new SolidColorBrush(ellipseColourPicker.SelectedColor.Value);
                }
                if (strokeColorPicker.SelectedColor != null)
                {
                    models.StrokeFill = new SolidColorBrush(strokeColorPicker.SelectedColor.Value);
                }
            }
            else
            {
                models = new EllipseModel(333, 333, 33, Brushes.Red, Brushes.Blue,Brushes.Green , "Neki text");
                if (width.Value != null)
                {
                    models.Width = width.Value.Value;
                }
                if (height.Value != null)
                {
                    models.Height = height.Value.Value;
                }
                if (strokeThickness.Value != null)
                {
                    models.StrokeThic = strokeThickness.Value.Value;
                }
                if (ellipseColourPicker.SelectedColor != null)
                {
                    models.Fill = new SolidColorBrush(ellipseColourPicker.SelectedColor.Value);
                }
                if (strokeColorPicker.SelectedColor != null)
                {
                    models.StrokeFill = new SolidColorBrush(strokeColorPicker.SelectedColor.Value);
                }
                if (textColour.SelectedColor != null)
                {
                    models.TextColour = new SolidColorBrush(textColour.SelectedColor.Value);
                }
                if (ellipseColourPicker.SelectedColor != null)
                {
                    models.Text = ellipseText.Text;
                }
            }
            MainWindow.model = models;
            this.Close();
        }
    }
}
