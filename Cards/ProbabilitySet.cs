using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards
{
    /// <summary>
    /// Probability
    /// </summary>
    /// 
    public class ProbabilitySet
    {
        /// <summary>
        /// Chosen ranks
        /// </summary>
        public IList<CardRank> Ranks { get; set; }
        
        /// <summary>
        /// Chosen suits
        /// </summary>
        public IList<CardSuit> Suits { get; set; }

        /// <summary>
        /// Calculated probability
        /// </summary>
        public double Probability { get; set; }

        public ProbabilitySet()
        {
            Ranks = new List<CardRank>();
            Suits = new List<CardSuit>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Probability of {0:0.00} for", Probability);
            
            if (PrintCollection(sb, Ranks, "ranks") && Suits != null && Suits.Any())
            {
                sb.Append(" or");                
            }

            PrintCollection(sb, Suits, "suites");
            return sb.ToString();
        }

        private bool PrintCollection<T>(StringBuilder sb, IList<T> collection, string collectionName)
        {
            if (collection != null && collection.Count > 0)
            {
                sb.Append(" ");
                sb.Append(collectionName);
                sb.Append(": ");

                for (int i = 0; i < collection.Count; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(", ");
                    }

                    sb.Append(collection[i]);
                }

                return true;
            }

            return false;
        }
    }
}
