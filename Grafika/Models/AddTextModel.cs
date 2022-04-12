using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Grafika.Models
{
    public class AddTextModel
    {
        private string text;
        private Brush foregorund;
        private Brush background;
        private double size;

        public AddTextModel(string text, Brush foregorund, Brush background, double size)
        {
            this.text = text;
            this.Foregorund = foregorund;
            this.background = background;
            this.size = size;
        }

        public string Text { get => text; set => text = value; }
        public Brush Background { get => background; set => background = value; }
        public double Size { get => size; set => size = value; }
        public Brush Foregorund { get => foregorund; set => foregorund = value; }
    }
}
