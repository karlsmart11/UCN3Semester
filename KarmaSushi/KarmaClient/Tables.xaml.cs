using KarmaClient.EmployeeServiceRef;
using KarmaClient.ReservationServiceRef;
using KarmaClient.TableServiceRef;
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
using Table = KarmaClient.TableServiceRef.Table;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {
        private readonly EmployeeServiceClient _employee = new EmployeeServiceClient();
        private readonly TableServicesClient _table = new TableServicesClient();
        private readonly ReservationServicesClient _reservation = new ReservationServicesClient();
        private string name;
        public string phone;
        private string email;
        private string guests;
        private List<Table> tables = new List<Table>();
        private List<Table> selectedTables = new List<Table>();
        private List<Table> onlyAvailable = new List<Table>();
        private string date;
        private string startTimeH;
        private string startTimeM;
        private string endTimeH;
        private string endTimeM;
        private DateTime dateReservation;
        private DateTime selectedDate;
        private int guestsInt;
        private int availableSeats;
        private string dateReservationString;
        private List<Table> tablesToInsert = new List<Table>();
        private int IsOk=1;
        

        public Reservation thisReservation = new Reservation();

        public Tables()
        {
            InitializeComponent();
            PopulateEmployeeCB();
            //populateTable();
            FillMinutesHours();
           


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void populateTable()
        {
            tables = _table.GetAllTables();
            availableTables.ItemsSource = null;
            availableTables.ItemsSource = tables;
        }



        public void PopulateEmployeeCB()
        {
            cbxEmployee.ItemsSource = null;
            cbxEmployee.ItemsSource = _employee.GetAllEmployees();
           

        }

        private void cbxEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
        }

       


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();


        }

        private void txtSelectedTables_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            name = txtName.Text.ToString();
            phone = txtPhone.Text.ToString();
            email = txtEmail.Text.ToString();
            guests = txtGuests.Text.ToString();
            date = txtDate.Text.ToString();


            int guestsInt;
            int phoneInt;
            DateTime date2;

            //checks if there are only digits
            bool digitsOnlyGuests = guests.All(char.IsDigit);
            bool digitsOnlyPhone = phone.All(char.IsDigit);

          

            if (String.IsNullOrEmpty(phone) == true)
            {
                MessageBox.Show("Phone cannot be left empty");
                IsOk ++;
            }
            else
            {
                if (digitsOnlyPhone == true)
                {
                    phoneInt = Convert.ToInt32(phone);
                    IsOk = 0;
                }
                else
                {
                    MessageBox.Show("Phone number can only contain digits");
                    IsOk ++;
                }
            }



            if (String.IsNullOrEmpty(guests) == true)
            {
                MessageBox.Show("Guests cannot be left empty");
                IsOk ++;
            }
            else
            {
                if (digitsOnlyGuests == true)
                { 
                    {
                        guestsInt = Convert.ToInt32(guests);
                        if (guestsInt > availableSeats)
                        {
                            MessageBox.Show("Number of guests exceeds available seating. Please select another table");
                            IsOk ++;

                        }
                        else IsOk = 0;
                    }

                    
                }
                else
                {
                    MessageBox.Show("Guests field can only contain digits");
                    IsOk ++;
                }

                if (String.IsNullOrEmpty(name) == true)
                {
                    MessageBox.Show("Name cannot be left empty");
                    IsOk ++;
                }
                else IsOk = 0;
            }



            if (String.IsNullOrEmpty(email) == true)
            {
                MessageBox.Show("Email cannot be left empty");
                IsOk ++;
            }
            else IsOk = 0;


            if (String.IsNullOrEmpty(date) == true)
            {
                MessageBox.Show("Date cannot be left empty");
                IsOk ++;
            }
            else
            {
                date2 = Convert.ToDateTime(date);
                IsOk = 0;
            }

            if ((String.IsNullOrEmpty(startTimeH)) || (String.IsNullOrEmpty(startTimeM)) == true)
            {
                MessageBox.Show("Time cannot be left empty");
                IsOk ++;
            }
            else IsOk = 0; 
           

           
           
            if (IsOk<1) 
            { 

            var selectedEmployee = (EmployeeServiceRef.Employee)cbxEmployee.SelectedItem;
            thisReservation.Employee = new ReservationServiceRef.Employee
            {
                Id = selectedEmployee.Id,
                Name = selectedEmployee.Name,
                Phone = selectedEmployee.Phone,
                Email = selectedEmployee.Email
            };

            foreach (Table thisTable in availableTables.SelectedItems)
            {
                tablesToInsert.Add(thisTable);
            }

            List<ReservationServiceRef.Table> listOfTablesToInsert = new List<ReservationServiceRef.Table>();
            foreach (var item in tablesToInsert)
            {
                ReservationServiceRef.Table tableToInsert = new ReservationServiceRef.Table();
                tableToInsert.Id = item.Id;
                tableToInsert.Name = item.Name;
                listOfTablesToInsert.Add(tableToInsert);

            }
            thisReservation.Tables = listOfTablesToInsert;
            //thisReservation.Tables = tablesToInsert.Select(
            //      t => new ReservationServiceRef.Table
            //      {
            //          Id = t.Id,
            //          Name = t.Name
            //      }).ToList();

            
                // Inserts finished reservation into database.
                _reservation.InsertReservation(thisReservation);

                MessageBox.Show("Reservation created successfully");
                this.Close();
            }

          


        }

        private void availableTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            availableSeats = 0;
            string tableName = null;


            foreach (Table thisTable in availableTables.SelectedItems)
            {

                tableName += $"{thisTable.Name}, ";
                txtSelectedTables.Text=tableName;

                availableSeats += thisTable.Seats;

                if (availableTables.SelectedIndex<0)
                {
                    txtSelectedTables.Text = "";
                }
            }





        }

      


        private void FillMinutesHours ()
        {
            cbxStartTimeM.Items.Add("00");
            cbxStartTimeM.Items.Add("15");
            cbxStartTimeM.Items.Add("30");
            cbxStartTimeM.Items.Add("45");

            cbxEndTimeM.Items.Add("00");
            cbxEndTimeM.Items.Add("15");
            cbxEndTimeM.Items.Add("30");
            cbxEndTimeM.Items.Add("45");

            int i;

            for (i=12; i<21; i++)
            {
                cbxStartTimeH.Items.Add(Convert.ToString(i));
                cbxEndTimeH.Items.Add(Convert.ToString(i));
            }
        }

    

        private void TimeCheck()
        {   
            //takes the reservation date from the calendar (time: 00:00:00)
            DateTime selectedDate = txtDate.SelectedDate.Value;
            selectedDate.AddMilliseconds(7);

            //takes the input time (without the date / current date)
            string startTime = startTimeH + ":" + startTimeM;
            DateTime dateWithStartTime = DateTime.Parse(startTime);

            //combines the reservation date from the calendar with the input time
            var dateReservation = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, dateWithStartTime.Hour, dateWithStartTime.Minute, dateWithStartTime.Second);
            thisReservation.Time = dateReservation;

            //take available tables
            dateReservationString = Convert.ToString(dateReservation);

            tables = _table.GetAvailableTables(dateReservationString);
            availableTables.ItemsSource = null;
            availableTables.ItemsSource = tables;



        }

      

        private void cbxStartTimeM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxEndTimeM.SelectedItem = cbxStartTimeM.SelectedItem;
            startTimeM = cbxStartTimeM.SelectedItem.ToString();

           
            

        }

        private void cbxStartTimeH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            startTimeH = cbxStartTimeH.SelectedItem.ToString();
     
            try
                {
                int startH = Convert.ToInt32(startTimeH);
                int endH = startH + 2;
                string endH2 = Convert.ToString(endH);
                cbxEndTimeH.SelectedItem = endH2;
                }
                catch (Exception ex)
                {

                }
            

            

        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            TimeCheck();
        }

       
    }
}
