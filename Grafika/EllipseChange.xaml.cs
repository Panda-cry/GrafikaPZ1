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
    /// Interaction logic for EllipseChange.xaml
    /// </summary>
    public partial class EllipseChange : Window
    {
        public EllipseChange()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EllipseChangeModel change = new EllipseChangeModel();
            if(strokeColorPicker.SelectedColor != null)
            {
                change.StrokeFill = new SolidColorBrush(strokeColorPicker.SelectedColor.Value);
            }
            if(strokeThickness.Value != null)
            {
                change.StrokeThickess = strokeThickness.Value.Value;
            }
            if(ellipseColourPicker.SelectedColor != null)
            {
                change.Fill= new SolidColorBrush(ellipseColourPicker.SelectedColor.Value);
            }

            MainWindow.ellipseChangeModel = change;
            this.Close();
        }
    }
}
