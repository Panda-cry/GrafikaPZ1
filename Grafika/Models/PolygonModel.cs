using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Grafika.Models
{
    public class PolygonModel
    {
        private string text;
        private Brush textColour;
        private int strokThic;
        private Brush fill;
        private Brush strokeFill;

        public PolygonModel()
        {
        }

        public PolygonModel(string text, Brush textColour, int strokThic, Brush fill, Brush strokeFill)
        {
            this.text = text;
            this.textColour = textColour;
            this.strokThic = strokThic;
            this.fill = fill;
            this.strokeFill = strokeFill;
        }

        public PolygonModel(int strokThic, Brush fill, Brush strokeFill)
        {
            this.strokThic = strokThic;
            this.fill = fill;
            this.strokeFill = strokeFill;
        }


        public string Text { get => text; set => text = value; }
        public Brush TextColour { get => textColour; set => textColour = value; }
        public int StrokThic { get => strokThic; set => strokThic = value; }
        public Brush Fill { get => fill; set => fill = value; }
        public Brush StrokeFill { get => strokeFill; set => strokeFill = value; }
    }
}
