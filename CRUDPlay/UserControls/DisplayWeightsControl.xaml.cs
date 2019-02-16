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

namespace CRUDPlay.UserControls
{
    /// <summary>
    /// Interaction logic for DisplayWeightsControl.xaml
    /// </summary>
    public partial class DisplayWeightsControl : UserControl
    {



        public Weight Weight
        {
            get { return (Weight)GetValue(WeightProperty); }
            set { SetValue(WeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Weight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.Register("Weight", typeof(Weight), typeof(DisplayWeightsControl), new PropertyMetadata(new Weight(), DisplayText));

        private static void DisplayText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as DisplayWeightsControl;
        }


        public DisplayWeightsControl()
        {
            InitializeComponent();
        }
    }
}
