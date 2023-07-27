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
        public MainWindow()
        {
            InitializeComponent();
        }

        class Human
        {
            string name;
            string phone;
            string address;
            string post;
        }

        class Company
        {
            string brend;
            List<Human> listEmployee;
        }

        List<Company> listCompany;
        List<Human> listEmployee;

        
        private void deleteCompany_Click(object sender, RoutedEventArgs e)
        {
            Brend.Items.RemoveAt(Brend.Items.IndexOf(Brend.SelectedItem));
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee.Items.Add(nameEmployee.Text);
        }

        private void deleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee.Items.RemoveAt(Employee.Items.IndexOf(Employee.SelectedItem));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Brend.Items.Add(nameCompany.Text);
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            Employee.ItemsSource = Brend.Items;
        }
    }
}
