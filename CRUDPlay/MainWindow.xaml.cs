using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CRUDPlay.Models;
using SQLite;

namespace CRUDPlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void SaveNumberButton_OnClick(object sender, RoutedEventArgs e)
        {
             InsertWeight();
             ReadDatabase();
        }

        void InsertWeight()
        {
            var weight = new Weight()
            {
                Weights = double.Parse(NumberInputTextBox.Text),
                DateCreated = DateTime.Now
            };

            using (var conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Weight>();
                conn.Insert(weight);
                SaveNumberButton.Background = new SolidColorBrush(Colors.Chartreuse);
                SaveNumberButton.Foreground = new SolidColorBrush(Colors.Black);
            }

        }

        void ReadDatabase()
        {
            var weight = new Weight()
            {

            };
            List<Weight> weights;

            using (var conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Weight>();
                weights = conn.Table<Weight>().ToList();
            }

            if (weights != null)
                DNumListView.ItemsSource = weights;
        }

        private void NumberInputTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            double parsedValue;

            SaveNumberButton.IsEnabled = !string.IsNullOrEmpty(NumberInputTextBox.Text) && double.TryParse(NumberInputTextBox.Text, out parsedValue);

            if (SaveNumberButton.IsEnabled)
            {
                SaveNumberButton.Background = new SolidColorBrush(Colors.Green);
                SaveNumberButton.Foreground = new SolidColorBrush(Colors.White);
            }
        }
    }
}
