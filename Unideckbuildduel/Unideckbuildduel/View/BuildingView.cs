using System.Drawing;
using Unideckbuildduel.Logic;

namespace Unideckbuildduel.View
{
    /// <summary>
    /// A class allowing to display a building.
    /// </summary>
    public class BuildingView
    {
        private CardType cardType;
        /// <summary>
        /// The location, relative to the window.
        /// </summary>
        public Point Location { get; set; }
        private BuildingView() { }
        /// <summary>
        /// A factory method used to create a new building with a location, null if not possible.
        /// </summary>
        /// <param name="cardType">The card type used to construct the building</param>
        /// <param name="point">The first location of the building</param>
        /// <returns>The new building or null</returns>
        public static BuildingView MakeBuildingOrNull(CardType cardType, Point point)
        {
            if (cardType == null || cardType.Kind != Kind.Building) { return null; }
            if (cardType.Name == null) { return null; }
            BuildingView building = new BuildingView
            {
                cardType = cardType,
                Location = point
            };
            return building;
        }
        /// <summary>
        /// The draw method.
        /// </summary>
        /// <param name="g">The graphic context to display the building in</param>
        public void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(ViewSettings.BuildColour, ViewSettings.BuildWidth), new Rectangle(Location, ViewSettings.BuildSize));
            g.DrawString(cardType.Name, ViewSettings.BaseFont, new SolidBrush(ViewSettings.BuildColour), new Point(Location.X + 2, Location.Y + 5));
        }
    }
}