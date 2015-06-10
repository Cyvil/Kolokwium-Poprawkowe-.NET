using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Cards
{
    /// <summary>
    /// Main viewmodel of application
    /// DO NOT MODIFY THIS FILE
    /// </summary>
    public interface ICardsViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the evaulated sets of probabilities
        /// </summary>
        ObservableCollection<ProbabilitySet> EvaluatedSets { get; }

        /// <summary>
        /// Gets all available ranks
        /// </summary>
        IList<CardRank> AvailableRanks { get; }

        /// <summary>
        /// Gets or sets chosen ranks
        /// </summary>
        IList<CardRank> ChosenRanks { get; set; }

        /// <summary>
        /// Gets all available suits
        /// </summary>
        IList<CardSuit> AvailableSuits { get; }

        /// <summary>
        /// Gets or sets chosen suits
        /// </summary>
        IList<CardSuit> ChosenSuits { get; set; }

        /// <summary>
        /// Gets the highest probability
        /// </summary>
        ProbabilitySet HighestProbability { get; }

        /// <summary>
        /// Save history of probabilities to a file
        /// </summary>
        ICommand SaveSearchesCommand { get; }

        /// <summary>
        /// Command to caculate probability
        /// </summary>
        ICommand CalcCommand { get; }

        /// <summary>
        /// Command to search for highest probability
        /// </summary>
        ICommand ShowHighestCommand { get; }
    }
}
