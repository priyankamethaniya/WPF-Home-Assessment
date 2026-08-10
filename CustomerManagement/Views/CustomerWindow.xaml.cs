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
using System.Windows.Shapes;

namespace CustomerManagement.Views
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
