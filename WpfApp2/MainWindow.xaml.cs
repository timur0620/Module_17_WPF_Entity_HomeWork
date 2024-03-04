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
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        DataBaseSQLEntities context = new DataBaseSQLEntities();
        List<Product> products;
        List<Client> clients;     
        public MainWindow()
        {         
            InitializeComponent();
            Preparing();
        }
        private void Preparing()
        {
            context.Client.Load();
            context.Product.Load();

            products = context.Product.Local.ToList();
            clients = context.Client.Local.ToList();

            dataGridClient.ItemsSource = clients;
            dataGridProduct.ItemsSource = products;
        }
        private void dataGridClient_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Client client = dataGridClient.SelectedItem as Client;
            txtId.Text = client.Id.ToString();
            txtLastName.Text = client.LastName.ToString();
            txtName.Text = client.Name.ToString();
            txtSurname.Text = client.Surname.ToString();
            txtNumberPhone.Text = client.NumberPhone.ToString();
            txtEmail.Text = client.Email.ToString();
            try
            {
                dataGridProduct.ItemsSource = context.Product.Where(p => p.Email == client.Email).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdate(object sender, RoutedEventArgs e)
        {   
            Client client = new Client();
            int id = int.Parse(txtId.Text);
            List<Client> cl = context.Client.Where(p => p.Id == id).ToList();
            if (cl.Count > 0)
            {
                client.Id = Convert.ToInt32(txtId.Text);
                client.Name = txtName.Text;
                client.Email = txtEmail.Text;
                client.LastName = txtLastName.Text;
                client.Surname = txtSurname.Text;
                client.NumberPhone = txtNumberPhone.Text;
                context.Client.AddOrUpdate(client);
                context.SaveChanges();

                context.Client.Load();
                dataGridClient.ItemsSource = context.Client.ToList();
            }
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != null & txtId.Text != "")
            {   
                Client client = new Client() { Id = Convert.ToInt32(txtId.Text) };
                context.Client.Attach(client);
                context.Client.Remove(client);
                context.SaveChanges();

                context.Client.Load();
                dataGridClient.ItemsSource = context.Client.ToList();
            }
        }
    }
}
