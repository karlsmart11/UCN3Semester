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
using KarmaClient.OrderServiceRef;
using Table = KarmaClient.OrderServiceRef.Table;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for FinishOrderWindow.xaml
    /// </summary>
    public partial class FinishOrderWindow : Window
    {
        public Order CurrentOrder { get; set; }
        public List<Product> ComboboxData { get; set; }
        public List<Table> ListData { get; set; }

        public FinishOrderWindow()
        {
            InitializeComponent();
            PopulateEmployeeBox();
        }

        private void PopulateEmployeeBox()
        {
            EmployeeComboBox.ItemsSource = ComboboxData;
        }
    }
}
