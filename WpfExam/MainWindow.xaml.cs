using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
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
        ObservableCollection<Company> company = new ObservableCollection<Company>();

        public MainWindow()
        {
            InitializeComponent();

            company.Add(new Company() { Brend = "Test_1", Employees = new ObservableCollection<Human> { new Human {
                Name = "Ivan Ivanov", Phone = "+7-999-999-9999", Address = "Lenina st.", Post = "Director" }}});

            company.Add(new Company { Brend = "Test_2", Employees = new ObservableCollection<Human> { new Human {
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
            public ObservableCollection<Human> Employees { get; set; }

            public string ToString()
            {
                return Brend;
            }
        }

        private void deleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            Company selectCompany = new Company();
            selectCompany = companyList.SelectedItem as Company;
            selectCompany.Employees.Remove((Human) employeeList.SelectedItem);
            companyList.SelectedItem = selectCompany;
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (nameEmployee.Text == "Введите имя сотрудника")
            {
                MessageBox.Show("Сначала введите имя сотрудника.");
            }
            else
            {
                Company selectCompany = new Company();
                selectCompany = companyList.SelectedItem as Company;
                selectCompany.Employees.Add(new Human
                {
                    Name = nameEmployee.Text,
                    Phone = phoneEmployee.Text == "Введите номер телефона сотрудника" ? "Данные отсутствуют" : phoneEmployee.Text,
                    Address = addressEmployee.Text == "Введите адрес сотрудника" ? "Данные осутствуют" : addressEmployee.Text,
                    Post = postEmployee.Text == "Введите должность сотрудника" ? "Данные остутствуют" : postEmployee.Text,
                });
                companyList.SelectedItem = selectCompany;
            }
        }

        private void deleteCompany_Click(object sender, RoutedEventArgs e)
        {
            company.Remove((Company)companyList.SelectedItem);
        }

        private void addCompany_Click(object sender, RoutedEventArgs e)
        {
            bool check = false;
            foreach (var item in company)
            {
                if (nameCompany.Text == item.ToString())
                {
                    check = true;
                }
            }

            if (nameCompany.Text == "Введите название компании")
            {
                check = true;
            }

            if (check)
            {
                MessageBox.Show("Пожалуйста, введите название компании.");
            }
            else
            {
                company.Add(new Company { Brend = nameCompany.Text, Employees = new ObservableCollection<Human>() });
            }
        }
    }
}
