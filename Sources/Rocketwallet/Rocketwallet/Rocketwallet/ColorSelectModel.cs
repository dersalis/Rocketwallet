using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rocketwallet.Rocketwallet;
using System.Windows.Media;

namespace Rocketwallet.Rocketwallet
{
    public class ColorSelectModel
    {
        public ColorSelectModel(string text, Color color)
        {
            this.Text = text;
            this.Color = color;
            this.ColorBrush = new SolidColorBrush(color);
        }
        public string Text { get; set; }
        public Color Color { get; set; }
        public SolidColorBrush ColorBrush { get; set; }
    }
}
