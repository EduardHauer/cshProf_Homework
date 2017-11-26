using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string connectionString =
      @"Data Source=(localdb)\MSSQLLocalDB;
        Initial Catalog=Lesson7HW;
        Integrated Security=True;
        Pooling=False";

        public static bool t;

        public MainWindow()
        {
            InitializeComponent();

            Update(-1, true);
        }

        void Update(int selectedIndex, bool start)
        {
            if (start)
            {
                string sqlExpression2 = @"SELECT * FROM Employee";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression2, connection);
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeeList.Items.Add(reader.GetString(1));
                        }
                    }
                }

                string sqlExpression = @"SELECT * FROM Department";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            departmentList.Items.Add(reader.GetString(1));
                            department.Items.Add(reader.GetString(1));
                        }
                    }
                }
            }
            else if (t)
            {
                type.Content = "Employee";
                name.IsEnabled = true;
                age.IsEnabled = t;
                salary.IsEnabled = t;
                department.IsEnabled = t;
                add.IsEnabled = true;

                employeeList.SelectedIndex = -1;
                employeeList.Items.Clear();
                employeeList.Items.Add("null");

                string sqlExpression2 = @"SELECT * FROM Employee";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression2, connection);
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeeList.Items.Add(reader.GetString(1));
                        }
                    }
                }
            }
            else
            {
                type.Content = "Department";
                name.IsEnabled = true;
                age.IsEnabled = t;
                salary.IsEnabled = t;
                department.IsEnabled = t;
                add.IsEnabled = true;

                departmentList.SelectedIndex = -1;
                departmentList.Items.Clear();
                departmentList.Items.Add("null");

                string sqlExpression = @"SELECT * FROM Department";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            departmentList.Items.Add(reader.GetString(1));
                            department.Items.Add(reader.GetString(1));
                        }
                    }
                }
            }
            if (selectedIndex > 0) edit.IsEnabled = false;
            else edit.IsEnabled = false;
        }

        private void Employee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            departmentList.SelectedIndex = -1;
            t = true;
            Update((sender as ListView).SelectedIndex, false);
        }

        private void Department_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            employeeList.SelectedIndex = -1;
            t = false;
            Update((sender as ListView).SelectedIndex, false);
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (t)
            {
                if (department.SelectedIndex > 0)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string sqlExpression =
                     $@"INSERT INTO Employee (Name, Age, Salary, DepartmentId)
                    VALUES (N'{name.Text}', '{int.Parse(age.Text)}', '{float.Parse(salary.Text)}', '{department.SelectedIndex}')";

                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.ExecuteNonQuery();
                    }
                    employeeList.Items.Add($"{name.Text}");
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlExpression =
                 $@"INSERT INTO Department (Name)
                    VALUES (N'{name.Text}')";

                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
                department.Items.Add($"{name.Text}");
                departmentList.Items.Add($"{name.Text}");
            }
        }
    }
}
