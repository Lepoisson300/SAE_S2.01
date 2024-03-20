using System.Collections.Generic;

namespace Unideckbuildduel.Logic
{
    /// <summary>
    /// A class modelling a type of card. No duplicates.
    /// </summary>
    public class CardType
    {
        /// <summary>
        /// The name of the type; identifies the cardtype.
        /// </summary>
        public string Name { get; internal set; }
        /// <summary>
        /// The kind of the card.
        /// </summary>
        public Kind Kind { get; internal set; }
        /// <summary>
        /// The description, for informative purposes.
        /// </summary>
        public string Description { get; internal set; }
        /// <summary>
        /// A set of card types required as placed buildings with the number of cards for each associated.
        /// </summary>
        public Dictionary<CardType, int> RequiredBuildings { get; internal set; } = null;
        /// <summary>
        /// The value, in score points, of this card as a placed building, 0 if irrelevant.
        /// </summary>
        public int Points { get; internal set; } = 0;
        /// <summary>
        /// The card's special effect, or null.
        /// </summary>
        public Effect? Effect { get; internal set; } = null;
        /// <summary>
        /// The card type associated to the effect, or null.
        /// </summary>
        public CardType EffectCard { get; internal set; } = null;
        /// <summary>
        /// A set of card types required as ressources with the number of cards for each associated.
        /// </summary>
        public Dictionary<CardType, int> RequiredRessources { get; internal set; } = null;
        /// <summary>
        /// The card type required for the effect, or null.
        /// </summary>
        public CardType EffectRequiredCard { get; internal set; } = null;
        /// <summary>
        /// True iff there can only be one building of that type placed for a player, false if irrelevant.
        /// </summary>
        public bool Unique { get; internal set; } = false;
        /// <summary>
        /// Equals override.
        /// </summary>
        /// <param name="obj">The object compared to.</param>
        /// <returns>True iff both non-null cardtypes have the same name.</returns>
        public override bool Equals(object obj)
        {
            if (obj == this) { return true; }
            if (obj == null) { return false; }
            if (!(obj is CardType)) { return false; }
            CardType other = (CardType)obj;
            if (ReferenceEquals(Name, other.Name)) { return true; }
            if (Name == null) { return false; }
            return Name.Equals(other.Name);
        }
        /// <summary>
        /// Companion override for GetHashCode.
        /// </summary>
        /// <returns>A name-based hash code.</returns>
        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}