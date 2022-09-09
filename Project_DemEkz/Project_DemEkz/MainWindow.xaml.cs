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

namespace Project_DemEkz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;

        public MainWindow()
        {
            InitializeComponent();

            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            db = new AppContext();

            List<Material> materials = db.Materials.ToList();

            if (materials.Count != 0)
            {
                List<Material> materialsList = new List<Material>
                {

                };

                tableMaterials.ItemsSource = materials;
            }
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            WinEdit winEdit = new WinEdit();
            winEdit.Show();

            this.Close();
        }

        private void btnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            WinSuppliers winSuppliers = new WinSuppliers();
            winSuppliers.Show();

            this.Close();
        }
    }
}
