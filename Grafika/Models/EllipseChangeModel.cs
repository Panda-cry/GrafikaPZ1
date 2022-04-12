using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Grafika.Models
{
    public class EllipseChangeModel
    {
        private Brush fill;
        private Brush strokeFill;
        private int strokeThickess;

        public EllipseChangeModel()
        {
            strokeThickess = -1;
        }

        public EllipseChangeModel(Brush fill, Brush strokeFill, int strokeThickess)
        {
            this.fill = fill;
            this.strokeFill = strokeFill;
            this.strokeThickess = strokeThickess;
        }

        public Brush Fill { get => fill; set => fill = value; }
        public Brush StrokeFill { get => strokeFill; set => strokeFill = value; }
        public int StrokeThickess { get => strokeThickess; set => strokeThickess = value; }
    }
}
