using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace Project1
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : Page
    {
        Project1Entities db = new Project1Entities();



        public home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            Home h = new Home();
            h.Namee = txtname.Text;
            h.Email = txtEmail.Text;
            h.Department = txtdepartment.Text;
            h.Password1 = txtpassword.Text;
            db.Homes.Add(h);
            db.SaveChanges();
            MessageBox.Show("data saved sucessful");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource=db.Homes.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Home h=db.Homes.FirstOrDefault(x=>x.Namee==txtname.Text);
          
            h.Email = txtEmail.Text;
            h.Department = txtdepartment.Text;
            h.Password1 = txtpassword.Text;
            db.Homes.AddOrUpdate(h);
            db.SaveChanges();
            MessageBox.Show("data update");

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            db.Homes.Remove(db.Homes.First(x=>x.Namee== txtname.Text));
            db.SaveChanges();
            MessageBox.Show("Removed");

       
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource= db.Homes.Where(x=>x.Namee.Contains(txtname.Text)).ToList();

        }
    }
}
