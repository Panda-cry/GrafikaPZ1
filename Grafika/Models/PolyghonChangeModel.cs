using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Grafika.Models
{
    public class PolyghonChangeModel
    {
      
        private int strokThic;
        private Brush fill;
        private Brush strokeFill;

        public PolyghonChangeModel()
        {
        }

        public PolyghonChangeModel(int strokThic, Brush fill, Brush strokeFill)
        {
    
            this.strokThic = strokThic;
            this.fill = fill;
            this.strokeFill = strokeFill;
        }

        public int StrokThic { get => strokThic; set => strokThic = value; }
        public Brush Fill { get => fill; set => fill = value; }
        public Brush StrokeFill { get => strokeFill; set => strokeFill = value; }
    }
}
