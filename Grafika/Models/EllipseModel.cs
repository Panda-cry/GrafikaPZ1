using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Grafika.Models
{
    public class EllipseModel
    {
        private int width;
        private int height;
        private int strokeThic;
        private Brush fill;
        private Brush strokeFill;
        private Brush textColour;
        private string text;

        public EllipseModel(int width, int height, int strokeThic, Brush fill, Brush strokeFill)
        {
            this.width = width;
            this.height = height;
            this.strokeThic = strokeThic;
            this.fill = fill;
            this.strokeFill = strokeFill;
        }


            public EllipseModel(int width, int height, int strokeThic, Brush fill, Brush strokeFill, Brush textColour, string text)
        {
            this.width = width;
            this.height = height;
            this.strokeThic = strokeThic;
            this.fill = fill;
            this.strokeFill = strokeFill;
            this.textColour = textColour;
            this.text = text;
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int StrokeThic { get => strokeThic; set => strokeThic = value; }
        public Brush Fill { get => fill; set => fill = value; }
        public Brush StrokeFill { get => strokeFill; set => strokeFill = value; }
        public string Text { get => text; set => text = value; }
        public Brush TextColour { get => textColour; set => textColour = value; }

        public override string ToString()
        {
            return this.width + " " + this.height + this.StrokeThic + " " + this.strokeFill  + this.fill + " " + this.text; 
        }
    }
}
