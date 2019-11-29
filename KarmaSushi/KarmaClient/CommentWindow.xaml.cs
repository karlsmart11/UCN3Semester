using System;
using System.CodeDom;
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

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for CommentWindow.xaml
    /// </summary>
    public partial class CommentWindow : Window
    {
        public Order CurrentOrder { get; set; }

        public CommentWindow()
        {
            InitializeComponent();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentOrder.Comment = CommentTxtBox.Text;
            this.Close();
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
