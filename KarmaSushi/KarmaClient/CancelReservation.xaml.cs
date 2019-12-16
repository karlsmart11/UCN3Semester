using KarmaClient.ReservationServiceRef;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace KarmaClient
{
    /// <summary>
    /// This is all the logic behind cancelling a reservation via CancelReservation.xaml
    /// </summary>
    public partial class CancelReservation : Window
    {
        private readonly ReservationServicesClient _reservation = new ReservationServicesClient();
        private Reservation reservationToDelete;
        private List<Reservation> reservations = new List<Reservation>();
        private List<Reservation> desiredReservations = new List<Reservation>();
        private List<int> reservationIDs2 = new List<int>();
        private List<int> updatedReservations = new List<int>();
        private List<int> reservationIDs;
        private int selectedId;


        public CancelReservation()
        {
            InitializeComponent();
            populateDataGridWithSOAP();
        }

        private void txtDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
          reservationIDs = new List<int>();
          DataTable dt = setUpDataGrid();
          reservations = _reservation.GetAllReservations();

            try
            {
                foreach (var item in reservations)
                {
                    DateTime date = item.Time;
                    DateTime dateNow = txtDate.SelectedDate.Value;

                    int result = DateTime.Compare(date.Date, dateNow.Date);
                    if (result == 0)
                    {
                        reservationIDs.Add(item.Id);
                        DataRow newRow = dt.NewRow();
                        newRow[0] = item.Id.ToString();
                        reservationIDs2.Add(item.Id);
                        
                        if (item.Customer != null)
                        {
                            newRow[1] = item.Customer.Name.ToString();
                        }
                        else
                        {
                            newRow[1] = null;
                        }
                        newRow[2] = date;

                        dt.Rows.Add(newRow);
                    }
                }
                ListOfReservations.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ListOfReservations_CurrentCellChanged(object sender, EventArgs e)
        {
            reservations = _reservation.GetAllReservations();

            // fills the table with all reservations whenever something is clicked
            int currentRowIndex = ListOfReservations.Items.IndexOf(ListOfReservations.CurrentItem);

            if (currentRowIndex >= 0)
            {
                selectedId = reservationIDs[currentRowIndex];
                int selectedIdInt = Convert.ToInt32(selectedId.ToString());

                foreach (Reservation thisReservation in reservations)
                {
                    if (thisReservation.Id == selectedIdInt)
                    {
                        reservationToDelete = thisReservation;
                    }
                }
            }
        }


        public DataTable setUpDataGrid()
        {
            DataTable dt = new DataTable();

            DataColumn Id = new DataColumn("Id", typeof(int));
            DataColumn Customer = new DataColumn("Customer", typeof(string));
            DataColumn Time = new DataColumn("Time", typeof(DateTime));

            dt.Columns.Add(Id);
            dt.Columns.Add(Customer);
            dt.Columns.Add(Time);

            return dt;
        }

        public void populateDataGridWithSOAP()
        {
            reservationIDs = new List<int>();
            DataTable dt = setUpDataGrid();

            try
            {
                reservations = _reservation.GetAllReservations();
                foreach (Reservation currentReservation in reservations)
                {
                    reservationIDs.Add(currentReservation.Id);
                }

                foreach (var item in reservations)
                {
                    DateTime date = item.Time;
                    DataRow newRow = dt.NewRow();

                    newRow[0] = item.Id.ToString();
                    if (item.Customer != null)
                    {
                        newRow[1] = item.Customer.Name.ToString();
                    }
                    else
                    {
                        newRow[1] = null;
                    }
                    newRow[2] = date;

                    dt.Rows.Add(newRow);
                }
                ListOfReservations.ItemsSource = dt.DefaultView;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _reservation.DeleteReservation(reservationToDelete);
            MessageBox.Show("Reservation deleted succesfully");
            populateDataGridWithSOAP();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
