using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Grafika.Models
{
    public class TextChangeModel
    {
        private Brush foregroung;
        private Brush background;

        public TextChangeModel(Brush foregroung, Brush background)
        {
            this.foregroung = foregroung;
            this.background = background;
        }

        public TextChangeModel()
        {
        }

        public Brush Background { get => background; set => background = value; }
        public Brush Foregroung { get => foregroung; set => foregroung = value; }
    }
}
