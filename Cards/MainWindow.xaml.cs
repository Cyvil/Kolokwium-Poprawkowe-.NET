using System.Windows;

namespace Cards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// DO NOT MODIFY THIS FILE
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ICardsViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
