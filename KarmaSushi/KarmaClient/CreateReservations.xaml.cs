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
    /// This is all the logic behind the process of creating a reservation via CreateReservation.xaml
    /// </summary>
    public partial class CreateReservations : Window
    {
        public Reservation thisReservation = new Reservation();
        private List<Table> tablesToInsert = new List<Table>();
        private List<Table> tables = new List<Table>();
        private List<Table> _selectedTables = new List<Table>();
        private readonly EmployeeServiceClient _employee = new EmployeeServiceClient();
        private readonly TableServicesClient _table = new TableServicesClient();
        private readonly ReservationServicesClient _reservation = new ReservationServicesClient();
        private string name;
        private string phone;
        private string email;
        private string guests;
        private string date;
        private string startTimeH;
        private string startTimeM;
        private string dateReservationString;
        private int guestsInt;
        private int availableSeats = 0;


        public CreateReservations()
        {
            InitializeComponent();
            PopulateEmployeeCB();
            FillMinutesHours();
            btnCreate.IsEnabled = false;
            btnCheck.IsEnabled = false;
            btnAdd.IsEnabled = false;
            btnRemove.IsEnabled = false;
        }

        private void populateTable()
        {
            availableTables.ItemsSource = null;
            availableTables.ItemsSource = tables;

            selectedAvailableTables.ItemsSource = null;
            selectedAvailableTables.ItemsSource = _selectedTables;
        }

        private void PopulateEmployeeCB()
        {
            cbxEmployee.ItemsSource = null;
            cbxEmployee.ItemsSource = _employee.GetAllEmployees();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)

        {
            if (guestsInt > availableSeats)
            {
                MessageBox.Show("Number of guests (" + guestsInt+") exceeds selected seatings ("+ availableSeats+"). Select a bigger table or add more to the list.");

            }
            else
            {   //builds and "Employee" element from the selected employee
                var selectedEmployee = (EmployeeServiceRef.Employee)cbxEmployee.SelectedItem;
                thisReservation.Employee = new ReservationServiceRef.Employee
                {
                    Id = selectedEmployee.Id,
                    Name = selectedEmployee.Name,
                    Phone = selectedEmployee.Phone,
                    Email = selectedEmployee.Email
                };


                //adds the selected tables to the reservation
                foreach (Table thisTable in _selectedTables)
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

                // Inserts finished reservation into database.
                _reservation.InsertReservation(thisReservation);

                MessageBox.Show("Reservation created successfully");
                this.Close();
            }
        }
      
        private void FieldsCheck()
        {
            btnCreate.IsEnabled = false;
            name = txtName.Text.ToString();
            phone = txtPhone.Text.ToString();
            email = txtEmail.Text.ToString();
            guests = txtGuests.Text.ToString();
            date = txtDate.Text.ToString();
            DateTime date2;

            //checks if there are only digits
            bool digitsOnlyGuests = guests.All(char.IsDigit);
            bool digitsOnlyPhone = phone.All(char.IsDigit);

            //Enables "Show Tables" button
            //Check available tables for a "quick look" without filling in irrelevant fields
            if ((cbxStartTimeH.SelectedValue == null || cbxStartTimeM.SelectedValue == null) || (String.IsNullOrEmpty(date))==true)
            {
                btnCheck.IsEnabled = false;
            }
            else
            {
                btnCheck.IsEnabled = true;
            }

            //Enables "Create" button
            //Only create a reservation if all fields are filled in
            if (
                 ((String.IsNullOrEmpty(name) ) ||
                 (String.IsNullOrEmpty(phone)) ||
                 (String.IsNullOrEmpty(email)) ||
                 (String.IsNullOrEmpty(date)) ||
                 (String.IsNullOrEmpty(guests)) == true ) ||
                 (cbxStartTimeH.SelectedValue == null || cbxStartTimeM.SelectedValue == null || cbxEmployee.SelectedValue==null)
                 )
            {   
                btnCreate.IsEnabled = false;
            }
            else
            {
                if (digitsOnlyGuests == true && digitsOnlyPhone == true)
                {
                    guestsInt = Convert.ToInt32(guests);
                    date2 = Convert.ToDateTime(date);
                    btnCreate.IsEnabled = true;
                }
            }
        }

        private void FillMinutesHours()
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

            //kitchen closes at 21:00 - last reservation can be made at 20:45
            for (i = 12; i < 21; i++)
            {
                cbxStartTimeH.Items.Add(Convert.ToString(i)); 
            }

            //restaurant opens at 12:00 - a reservation can first end at 14:00
            for (i = 14; i < 23; i++)
            {
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

            _selectedTables.Clear();
        }

        private void cbxStartTimeM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FieldsCheck();
            //resets table data each time a change is made
            availableTables.ItemsSource = null;
            _selectedTables.Clear();
            availableSeats = 0;
            selectedAvailableTables.ItemsSource = null;

            //automatically fills in the end time of the reservation
            cbxEndTimeM.SelectedItem = cbxStartTimeM.SelectedItem;

            //updates local variable of the selected start time (minutes)
            startTimeM = cbxStartTimeM.SelectedItem.ToString();
        }

        private void cbxStartTimeH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FieldsCheck();
            //resets table data each time a change is made
            availableTables.ItemsSource = null;
            _selectedTables.Clear();
            availableSeats = 0;
            selectedAvailableTables.ItemsSource = null;

            //updates local variable of the selected start time (hour)
            startTimeH = cbxStartTimeH.SelectedItem.ToString();

            //automatically fills in the end time of the reservation
            try
            {   
                int startH = Convert.ToInt32(startTimeH);
                int endH = startH + 2;
                string endH2 = Convert.ToString(endH);
                cbxEndTimeH.SelectedItem = endH2;
            }
            catch (Exception ex) { }
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {   
            TimeCheck();

            //enables the buttons for the tables once a time check is performed - meaning date and time are selected
            btnAdd.IsEnabled = true;
            btnRemove.IsEnabled = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            foreach (Table selectedTable in availableTables.SelectedItems)
            {
                _selectedTables.Add(selectedTable);
                availableSeats = availableSeats + selectedTable.Seats;
                tables.Remove(tables.Find(x => x == selectedTable));
               
            }
            populateTable();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            foreach (Table selectedTable in selectedAvailableTables.SelectedItems)
            {
                tables.Add(selectedTable);
                availableSeats = availableSeats - selectedTable.Seats;
                _selectedTables.Remove(_selectedTables.Find(x => x == selectedTable)); 
            }
            populateTable();
        }

        private void txtDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FieldsCheck();

            //resets table data each time a new date is selected
            availableTables.ItemsSource = null;
            _selectedTables.Clear();
            availableSeats = 0;
            selectedAvailableTables.ItemsSource = null;
        }

        #region Text fields checking event handlers
        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            FieldsCheck();
        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            FieldsCheck();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            FieldsCheck();
        }

        private void txtGuests_TextChanged(object sender, TextChangedEventArgs e)
        {
            FieldsCheck();
        }

        private void cbxEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FieldsCheck();
        }
        #endregion
    }
}
