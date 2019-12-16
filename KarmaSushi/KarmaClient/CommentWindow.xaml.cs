using System.Windows;
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
