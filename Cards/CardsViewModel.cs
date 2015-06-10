using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Documents;

namespace Cards
{
    /// <summary>
    /// Main class for View Model
    /// TODO: follow guidelines
    /// </summary>
    public class CardsViewModel : ICardsViewModel
    {
        private readonly IDispatcher _dispatcher;
        private System.Windows.Input.ICommand _calcCommand;
        private System.Windows.Input.ICommand _saveCommand;
        private System.Windows.Input.ICommand _showCommand;
        public CardsViewModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            _chosenRanks = new List<CardRank>();
            _chosenSuits = new List<CardSuit>();
            _evaluatedSets = new System.Collections.ObjectModel.ObservableCollection<ProbabilitySet>();
            _calcCommand = new MyCommand(() => CalculateProbability());
            _saveCommand = new MyCommand(() => SaveCalculations());
            _showCommand = new MyCommand(() => ShowHighest());

        }

        private System.Collections.ObjectModel.ObservableCollection<ProbabilitySet> _evaluatedSets;
        private List<CardRank> _chosenRanks;
        private List<CardSuit> _chosenSuits;
        private ProbabilitySet _highestProbability;

        public System.Collections.ObjectModel.ObservableCollection<ProbabilitySet> EvaluatedSets
        {
            get { return _evaluatedSets; }
        }

        public IList<CardRank> AvailableRanks
        {
            get { return (IList<CardRank>) Enum.GetValues(typeof(CardRank)).Cast<CardRank>(); }
        }

        public IList<CardRank> ChosenRanks
        {
            get
            {
                return _chosenRanks;
            }
            set
            {
                if (value != _chosenRanks)
                {
                    _chosenRanks =(List<CardRank>) value;
                    NotifyPropertyChanged();
                }
            }
        }

        public IList<CardSuit> AvailableSuits
        {
            get { return (IList<CardSuit>)Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>(); ; }
        }

        public IList<CardSuit> ChosenSuits
        {
            get
            {
                return _chosenSuits;
            }
            set
            {
                if (value != _chosenSuits)
                {
                    _chosenSuits = (List<CardSuit>)value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ProbabilitySet HighestProbability
        {
            get { return _highestProbability; }
        }

        public System.Windows.Input.ICommand SaveSearchesCommand
        {
            get { return _saveCommand; }
        }

        public System.Windows.Input.ICommand CalcCommand
        {
            get { return _calcCommand; }
        }

        public System.Windows.Input.ICommand ShowHighestCommand
        {
            get { return _showCommand; }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void CalculateProbability()
        {
            if(ChosenRanks.Count > 0 && ChosenSuits.Count > 0)
            {
                double result = 0;
                result = (double)((ChosenSuits.Count * AvailableRanks.Count) + (ChosenRanks.Count * AvailableSuits.Count) - (ChosenRanks.Count * ChosenSuits.Count)) / (double)(AvailableSuits.Count * AvailableRanks.Count);

                addToEvaluated(result);

            }
            else
            {
                MessageBox.Show("Cannot calculate probability");
            }
        }

        private void addToEvaluated(double input)
        {
            var probabSet = new ProbabilitySet();
            probabSet.Probability = input;
            probabSet.Ranks = this.ChosenRanks;
            probabSet.Suits = this.ChosenSuits;

            _evaluatedSets.Add(probabSet);
        }

        private void SaveCalculations()
        {
            using( var sw = new StreamWriter("temp.json"))
            {
                JavaScriptSerializer serial = new JavaScriptSerializer();

                sw.Write(serial.Serialize(EvaluatedSets));
            }
        }

        private void ShowHighest()
        {
           var tempEvals = new System.Collections.ObjectModel.ObservableCollection<ProbabilitySet>();
            tempEvals = EvaluatedSets;

            _highestProbability = tempEvals.OrderByDescending(item => item.Probability).First();

            MessageBox.Show("Highest probability is " + _highestProbability.Probability.ToString());
        }
    }
}
