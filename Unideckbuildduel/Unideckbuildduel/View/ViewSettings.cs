using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unideckbuildduel
{
    /// <summary>
    /// A static class for settings (preferences) for the view
    /// </summary>
    public static class ViewSettings
    {
        /// <summary>
        /// The width of the border for cards
        /// </summary>
        public static int CardWidth { get; set; } = 1;
        /// <summary>
        /// The size of cards
        /// </summary>
        public static Size CardSize { get; set; } = new Size(160, 80);
        /// <summary>
        /// The withd of the border of buildings
        /// </summary>
        public static int BuildWidth { get; set; } = 2;
        /// <summary>
        /// The size of buildings
        /// </summary>
        public static Size BuildSize { get; set; } = new Size(100, 20);
        /// <summary>
        /// The color used for buildings
        /// </summary>
        public static Color BuildColour { get; set; } = Color.DarkSlateBlue;
        /// <summary>
        /// The font used for displays
        /// </summary>
        public static Font BaseFont { get; set; } = new Font("Arial", 12, FontStyle.Regular);
        /// <summary>
        /// The colour of the text
        /// </summary>
        public static Color TextColour { get; set; } = Color.DarkOrchid;
        /// <summary>
        /// The margin between objects on the screen
        /// </summary>
        public static Size Margin { get; set; } = new Size(16, 16);
        /// <summary>
        /// Do not display anything on the right of this
        /// </summary>
        public static int Rightmost { get; set; }
    }
}
