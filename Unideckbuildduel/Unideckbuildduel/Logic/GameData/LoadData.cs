using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unideckbuildduel.Logic.GameData
{
    /// <summary>
    /// A static class only used to load the game data.
    /// </summary>
    public static class LoadData
    {
        private static bool generated = false;
        public static bool Generated { get { return generated; } }
        private static readonly Dictionary<string, CardType> cardTypes = new Dictionary<string, CardType>();
        /// <summary>
        /// A Dictionary countaining all of the possible card types indexed by their name
        /// </summary>
        public static Dictionary<string, CardType> CardTypes { get { if (generated) { return new Dictionary<string, CardType>(cardTypes); } else { return null; } } }
        private static void GenTypes()
        {
            cardTypes.Add("Classroom", new CardType
            {
                Name = "Classroom",
                Kind = Kind.Building,
                Description = "A simple classroom."
            });
            cardTypes.Add("Dorm", new CardType
            {
                Name = "Dorm",
                Kind = Kind.Building,
                Description = "Houses students.",
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Classroom"], 2 }
                },
                Points = 1
            }) ;
            cardTypes.Add("Cafeteria", new CardType
            {
                Name = "Cafeteria",
                Kind = Kind.Building,
                Description= "Feeds students.",
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Classroom"], 3 },
                    { cardTypes["Dorm"], 1 }
                },
                Points = 5
            });
            cardTypes.Add("Faculty Lounge", new CardType
            {
                Name = "Faculty Lounge",
                Kind = Kind.Building,
                Description= "Dwelling for academics.",
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Classroom"], 2 }
                },
                Points = 1,
                Effect = Effect.CanExchange,
                EffectCard = cardTypes["Classroom"]
            });
            cardTypes.Add("Funding", new CardType
            {
                Name = "Funding",
                Kind = Kind.Ressource,
                Description="Food consumed by academics."
            });
            cardTypes.Add("A-List Publication", new CardType
            {
                Name = "A-List Publication",
                Kind = Kind.Ressource,
                Description="Substance produced by academics."
            });
            cardTypes.Add("Research Lab", new CardType
            {
                Name = "Research Lab",
                Kind = Kind.Building,
                Description = "Place favoured by academics for their production.",
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Classroom"], 1 },
                    { cardTypes["Faculty Lounge"], 1 }
                },
                RequiredRessources = new Dictionary<CardType, int>
                {
                    { cardTypes["Funding"], 2 }
                },
                Effect = Effect.CanExchange,
                EffectCard = cardTypes["A-List Publication"],
                Points = 7
            });
            cardTypes.Add("Library", new CardType
            {
                Name = "Library",
                Unique = true,
                Kind = Kind.Building,
                Description = "Collective memory.",
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Dorm"], 2 },
                    { cardTypes["Cafeteria"], 1 }
                },
                Effect = Effect.OneMoreCard,
                Points = 7,
            });
            cardTypes.Add("Grand Hall", new CardType
            {
                Name = "Grand Hall",
                Unique = true,
                Kind = Kind.Building,
                Description= "Funding lure.",
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Faculty Lounge"], 2 },
                    { cardTypes["Research Lab"], 2 }
                },
                RequiredRessources = new Dictionary<CardType, int>
                {
                    { cardTypes["Funding"], 3 }
                },
                Effect = Effect.DrawOncePerTurn,
                EffectCard = cardTypes["Funding"],
                Points = 13
            });
            cardTypes.Add("Server Farm", new CardType
            {
                Name = "Server Farm",
                Unique = true,
                Kind = Kind.Building,
                Description = "Room for consuming many ressources.",
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Classroom"], 5 },
                    { cardTypes["Research Lab"], 2 }
                },
                Effect = Effect.CanExchange,
                EffectCard = cardTypes["Funding"],
                Points = 7
            });
            cardTypes.Add("Archive", new CardType
            {
                Name = "Archive",
                Unique = true,
                Kind = Kind.Building,
                Description = "Long-term storage.",
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Library"], 1 }
                },
                RequiredRessources = new Dictionary<CardType, int>
                {
                    { cardTypes["Funding"], 1 }
                },
                Effect = Effect.DrawFromDiscardOncePerTurn,
                EffectCard = cardTypes["A-List Publication"],
                Points = 17
            });
            cardTypes.Add("Museum", new CardType
            {
                Name = "Museum",
                Unique = true,
                Kind = Kind.Building,
                Description= "Enables the public to go see complicated gizmos.",
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Archive"], 1 }
                },
                Effect = Effect.ProducesOne,
                EffectCard = cardTypes["A-List Publication"],
                Points = 19
            });
            cardTypes.Add("Aquarium", new CardType
            {
                Unique = true,
                Kind = Kind.Building,
                Description="Enables the public to spend their money.",
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Archive"], 1 }
                },
                Effect = Effect.ProducesOne,
                EffectCard = cardTypes["Funding"],
                Points = 19
            });
            cardTypes.Add("Fablab", new CardType
            {
                Name = "Fablab",
                Unique = true,
                Kind = Kind.Building,
                Description = "Enables funding embezzeling.",
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Research Lab"], 3 }
                },
                RequiredRessources = new Dictionary<CardType, int>
                {
                    { cardTypes["Funding"], 3 }
                },
                Effect = Effect.DrawOncePerTurn,
                EffectCard = cardTypes["Funding"],
                Points = 19
            });
            cardTypes.Add("Supercomputer", new CardType
            {
                Name = "Supercomputer",
                Kind = Kind.Building,
                Description="Mathematical spirit apotheosis.",
                Unique = true,
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Research Lab"], 5 },
                    { cardTypes["Server Farm"], 1 }
                },
                RequiredRessources = new Dictionary<CardType, int>
                {
                    { cardTypes["Funding"], 5 },
                    { cardTypes["A-List Publication"], 3 }
                },
                Points = 50
            });
            cardTypes.Add("Particle Collider", new CardType
            {
                Name = "Particle Collider",
                Kind = Kind.Building,
                Description = "Apocalypsis engine.",
                Unique = true,
                RequiredBuildings = new Dictionary<CardType, int>
                {
                    { cardTypes["Research Lab"], 3 },
                    { cardTypes["Archive"], 1 },
                    { cardTypes["Grand Hall"], 1 }
                },
                RequiredRessources = new Dictionary<CardType, int>
                {
                    { cardTypes["Funding"], 3 },
                    { cardTypes["A-List Publication"], 5 }
                },
                Points = 50
            });
            cardTypes.Add("Official Visit", new CardType
            {
                Name = "Official Visit",
                Kind = Kind.Action,
                Description = "Capture of a celebrity for hyperactivity ends.",
                Effect = Effect.PlayAgain,
                EffectRequiredCard = cardTypes["A-List Publication"]
            });
            cardTypes.Add("Over-hyped Keyword", new CardType
            {
                Name = "Over-hyped Keyword",
                Kind = Kind.Action,
                Description = "If fashionable, milk it all the way.",
                Effect = Effect.Substitute,
                EffectCard = cardTypes["Funding"]
            });
            cardTypes.Add("Prestigious Award", new CardType
            {
                Name = "Prestigious Award",
                Kind = Kind.Action,
                Effect = Effect.Substitute,
                Description = "Carpe diem.",
                EffectCard = cardTypes["A-List Publication"]
            });
        }
        /// <summary>
        /// Method used to generate a deck of cards.
        /// </summary>
        /// <returns>All cards, given as a stack</returns>
        public static Stack<Card> GenStack()
        {
            if (!Generated)
            {
                GenTypes();
                generated = true;
            }
            List<Card> list = new List<Card>();
            for (int i = 0; i < 30; i++) list.Add(new Card { CardType = cardTypes["Classroom"] });
            for (int i = 0; i < 10; i++) list.Add(new Card { CardType = cardTypes["Dorm"] });
            // for (int i = 0; i < 2; i++) list.Add(new Card { CardType = cardTypes["Cafeteria"] });
            Random random = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int r = random.Next(i + 1);
                (list[i], list[r]) = (list[r], list[i]);
            }
            Stack<Card> stack = new Stack<Card>();
            foreach (Card card in list)
            {
                stack.Push(card);
            }
            return stack;
        }
    }
}
