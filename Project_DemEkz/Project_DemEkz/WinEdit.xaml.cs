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

namespace Project_DemEkz
{
    /// <summary>
    /// Логика взаимодействия для WinEdit.xaml
    /// </summary>
    public partial class WinEdit : Window
    {
        AppContext db;
        public WinEdit()
        {
            InitializeComponent();

            db = new AppContext();
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }   

        private void btnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            WinSuppliers winSuppliers = new WinSuppliers();
            winSuppliers.Show();

            this.Close();
        }

        private void AddMaterial()
        {
            Material material = new Material
            {
                name = tbName.Text,
                category = tbCategory.Text,
                price = Convert.ToInt32(tbPrice.Text)
            };
            db.Materials.Add(material);
            MessageBox.Show("Добавленно");

            List<Material> materialsss = db.Materials.ToList();

            tbName.Text = materialsss[0].name;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddMaterial();
        }
    }
}
