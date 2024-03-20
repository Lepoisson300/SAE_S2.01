namespace Unideckbuildduel.Logic
{
    /// <summary>
    /// A class modeling one actual card; cards may have duplicates, card types may not.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// This card's type.
        /// </summary>
        public CardType CardType { get; set; }
    }
}