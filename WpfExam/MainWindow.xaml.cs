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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Company> company = new List<Company>();

        public MainWindow()
        {
            InitializeComponent();

            company.Add(new Company() { Brend = "Test_1", Employees = new List<Human> { new Human {
                Name = "Ivan Ivanov", Phone = "+7-999-999-9999", Address = "Lenina st.", Post = "Director" }}});

            company.Add(new Company { Brend = "Test_2", Employees = new List<Human> { new Human {
                Name = "Петр Петров", Phone = "+7-999-999-9988", Address = "ул. Пушкина", Post = "Директор" },
                new Human { Name = "Сидор Сидоров", Phone = "+7-999-999-9977", Address = "ул. Достоевского", Post = "Главный инженер"}}});
            
            companyList.ItemsSource = company;
        }

        class Human
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string Post { get; set; }
        }

        class Company
        {
            public string Brend { get; set; }
            public List<Human> Employees { get; set; }
        }

        private void deleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            employeeList.Items.Remove(employeeList.SelectedItem);
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            employeeList.Items.Add(nameEmployee);
        }

        private void deleteCompany_Click(object sender, RoutedEventArgs e)
        {
            companyList.Items.Remove(companyList.SelectedItem);
        }

        private void addCompany_Click(object sender, RoutedEventArgs e)
        {
            companyList.Items.Add($"{companyList.SelectedItem}");
        }
    }
}
