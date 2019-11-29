using KarmaClient.EmployeeServiceRef;
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
        //private readonly ReservedTableServiceClient _reservedTables = new ReservedTableServiceClient();
        private string name;
        public string phone;
        private string email;
        private string guests;
        private List<Table> tables = new List<Table>();
        private List<Table> selectedTables = new List<Table>();
        private string date;
        private string startTimeH;
        private string startTimeM;
        private string endTimeH;
        private string endTimeM;
        private string minuts;
        private DateTime dateReservation;
        private DateTime selectedDate;
       


        public Tables()
        {
            InitializeComponent();
            PopulateEmployeeCB();
            populateTables();
            FillMinutesHours();
           


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void populateTables()

        {
            
            tables = _table.GetAllTables();
            updateTable();
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

        private void updateTable()
        {
            availableTables.ItemsSource = null;
            availableTables.ItemsSource = tables;            
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            name = txtName.Text.ToString();
            phone = txtPhone.Text.ToString();
            email = txtEmail.Text.ToString();
            guests = txtGuests.Text.ToString();
            date = txtDate.Text.ToString();
            startTimeH = cbxStartTimeH.Text.ToString();
           // startTimeM = txtTimeStartM.Text.ToString();




            int guestsInt;
            int phoneInt;
            DateTime date2;

            //checks if there are only digits
            bool digitsOnlyGuests = guests.All(char.IsDigit);
            bool digitsOnlyPhone = phone.All(char.IsDigit);


            if (String.IsNullOrEmpty(phone) == true)
            {
                MessageBox.Show("Phone cannot be left empty");
            }
            else
            {
                if (digitsOnlyPhone == true)
                {
                    phoneInt = Convert.ToInt32(phone);
                }
                else
                {
                    MessageBox.Show("Phone number can only contain digits");
                }
            }



            if (String.IsNullOrEmpty(guests) == true)
            {
                MessageBox.Show("Guests cannot be left empty");
            }
            else
            {
                if (digitsOnlyGuests == true)
                {
                    guestsInt = Convert.ToInt32(guests);
                }
                else
                {
                    MessageBox.Show("Guests field can only contain digits");
                }

                if (String.IsNullOrEmpty(name) == true)
                {
                    MessageBox.Show("Name cannot be left empty");
                }
            }



            if (String.IsNullOrEmpty(email) == true)
            {
                MessageBox.Show("Email cannot be left empty");
            }


            if (String.IsNullOrEmpty(date) == true)
            {
                MessageBox.Show("Date cannot be left empty");
            }
            else
            {
                date2 = Convert.ToDateTime(date);
            }

            if ((String.IsNullOrEmpty(startTimeH))||(String.IsNullOrEmpty(startTimeM)) == true)
            {
                MessageBox.Show("Time cannot be left empty");
            }
            else
            {   if ((startTimeH.All(char.IsDigit)) && (startTimeM.All(char.IsDigit)) == false)
                {
                    MessageBox.Show("Time field can only contain digits");
                }
               
            }


        }

        private void availableTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tableName = null;
            foreach (Table tables in availableTables.SelectedItems)
            {
               
                selectedTables.Add(tables);
                tableName = tableName + ", " + tables.Name;
                txtSelectedTables.Text=tableName;

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

        //public DateTime selectedDate
        //{
        //    get { return dateReservation; }
        //    set { dateReservation = value; }
        //}

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
            
            //TODO take available tables



            MessageBox.Show(dateReservation.ToString());
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

        private void checkAvailableTables()
        {

        }

        private void checkGuestNumber()
        {
            
        }
    }
}
