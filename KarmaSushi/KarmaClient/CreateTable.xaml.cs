using KarmaClient.TableServiceRef;
using System;
using System.Linq;
using System.Windows;
using Table = KarmaClient.TableServiceRef.Table;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for CreateTable.xaml
    /// </summary>
    public partial class CreateTable : Window
    {
        private string Name;
        private string Seats;
        private int SeatsInt;
        private readonly TableServicesClient _table = new TableServicesClient();
        private bool isOk = false;
        public CreateTable()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text.ToString()) == true)
            {
                MessageBox.Show("Name cannot be left empty");
                isOk = false;
                
            }
            else
            {
                Name = txtName.Text.ToString();
                isOk = true;
                
            }

            if (String.IsNullOrEmpty(txtSeats.Text.ToString()) == true)
            {
                MessageBox.Show("Seats cannot be left empty");
                isOk = false;
            }
            else
            {
                Seats = txtSeats.Text.ToString();
                if (Seats.All(char.IsDigit) == true)
                {
                    SeatsInt = Convert.ToInt32(Seats);
                    isOk = true;
                }
                else
                {
                    MessageBox.Show("Seats can only contain digits");
                    isOk = false;
                }
            }

            if (isOk==true)
            {
                Table TableInsert = new Table();
                TableInsert.Name = Name;
                TableInsert.Seats = SeatsInt;
                _table.InsertTable(TableInsert);

                MessageBox.Show("Table created sucessfully");
                this.Close();
            }
           
           
        }
    }
}
