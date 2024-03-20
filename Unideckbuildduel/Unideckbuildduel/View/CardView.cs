using System.Drawing;
using Unideckbuildduel.Logic;

namespace Unideckbuildduel.View
{
    /// <summary>
    /// A class allowing to display a not-yet-played card.
    /// </summary>
    public class CardView
    {
        private readonly Card card;
        private readonly Color colour;
        /// <summary>
        /// The location, relative to the window.
        /// </summary>
        public Point Location { get; set; }
        /// <summary>
        /// The number of the card in the player's hand. Read only.
        /// </summary>
        public int CardNum { get; private set; }
        private Rectangle Rect {  get { return new Rectangle(Location, ViewSettings.CardSize); } }

        /// <summary>
        /// Parametered constructor.
        /// </summary>
        /// <param name="card">The card to view</param>
        /// <param name="location">The initial location of the card</param>
        public CardView(Card card, Point location, int cardNum)
        {
            this.card = card;
            Location = location;
            switch (card.CardType.Kind)
            {
                case Kind.Building: colour = Color.SkyBlue; break;
                case Kind.Ressource: colour = Color.ForestGreen; break;
                case Kind.Action: colour = Color.Magenta; break;
                default: colour = Color.Black; break;
            }
            CardNum = cardNum;
        }
        /// <summary>
        /// The draw method.
        /// </summary>
        /// <param name="g">The graphic context to display the building in</param>
        public void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(colour, ViewSettings.CardWidth), Rect);
            Point baseLine = Location;
            baseLine.Offset(5, 10);
            g.DrawString(card.CardType.Kind.ToString(), ViewSettings.BaseFont, new SolidBrush(ViewSettings.TextColour), baseLine);
            baseLine.Offset(5, 10);
            g.DrawString(card.CardType.Name, ViewSettings.BaseFont, new SolidBrush(ViewSettings.TextColour), baseLine);
            //...
        }
    }
}