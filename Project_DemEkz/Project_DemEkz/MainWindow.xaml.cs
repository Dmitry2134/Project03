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
using System.Data.SqlClient;

namespace Project_DemEkz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBase dataBase = new DataBase();

        List<Material> materialsList = new List<Material>();

        public MainWindow()
        {
            InitializeComponent();
            UpdateList();
        }

        public void UpdateList()
        {
            if(wrap != null)
            wrap.Children.Clear();

            materialsList.Clear();

            Read();
            CreateItem();
        }       

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                UpdateList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
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

        private void Read()
        {
            string queryString = $"select * from materials";

            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            
            while (reader.Read())
            {
                Material material = new Material();

                material.name = reader["name"].ToString();
                material.category = reader["category"].ToString();
                material.price = (int)reader["price"];
                material.postavka = reader["postavka"].ToString();

                materialsList.Add(material);
            }
            reader.Close();
        }

        private void CreateItem()
        {
            for (int i = 0; i < materialsList.Count; i++)
            {
                Grid grid = new Grid();
                grid.Margin = new Thickness(10);

                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());

                grid.RowDefinitions[0].Height = new GridLength(35);
                grid.RowDefinitions[1].Height = new GridLength(35);
                grid.RowDefinitions[2].Height = new GridLength(35);
                grid.RowDefinitions[3].Height = new GridLength(35);

                var cb = new BrushConverter();

                Border border = new Border
                {
                    Width = 750,
                    BorderThickness = new Thickness(2),
                    BorderBrush = (Brush)cb.ConvertFrom("#FFC1C1"),
                    CornerRadius = new CornerRadius(20, 20, 20, 20),
                    Margin = new Thickness(15)
                };

                TextBlock nText = new TextBlock
                {
                    FontFamily = new FontFamily("Verdana"),
                    Foreground = (Brush)cb.ConvertFrom("#1b1464"),
                    Margin = new Thickness(180,0,0,0),
                    FontSize = 16,
                    Text = "Название товара: "+ materialsList[i].name + "\n"
                };

                TextBlock cgText = new TextBlock
                {
                    FontFamily = new FontFamily("Verdana"),
                    Foreground = (Brush)cb.ConvertFrom("#1b1464"),
                    FontSize = 16,
                    Margin = new Thickness(180, 0, 0, 0),
                    Text = "Категория: " + materialsList[i].category + "\n"
                };

                TextBlock prText = new TextBlock
                {
                    FontFamily = new FontFamily("Verdana"),
                    Foreground = (Brush)cb.ConvertFrom("#1b1464"),
                    FontSize = 16,
                    Margin = new Thickness(180, 0, 0, 0),
                    Text = "Стоимость : " + materialsList[i].price.ToString() + "\n"
                };

                TextBlock posText = new TextBlock
                {
                    FontFamily = new FontFamily("Verdana"),
                    Foreground = (Brush)cb.ConvertFrom("#1b1464"),
                    FontSize = 16,
                    Margin = new Thickness(180, 0, 0, 0),
                    Text = "Поставщик : " + materialsList[i].postavka + "\n"
                };

                Image image = new Image();
                image.Source = new BitmapImage(new Uri("pack://application:,,,/noimage.png"));
                image.Width = 110;
                image.Height = 110;
                image.Margin = new Thickness(10,20,0,0);
                image.HorizontalAlignment = HorizontalAlignment.Left;
                image.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetRowSpan(image, 3);
                grid.Children.Add(image);

                Grid.SetRow(nText, 0);
                grid.Children.Add(nText);
                Grid.SetRow(cgText, 1);
                grid.Children.Add(cgText);
                Grid.SetRow(prText, 2);
                grid.Children.Add(prText);
                Grid.SetRow(posText, 3);
                grid.Children.Add(posText);

                

                border.Child = grid;

                if (wrap != null)
                    wrap.Children.Add(border);
            }

        }


    }
}
//string name = tbName.Text;
//string category = tbCategory.Text;
//int price = Convert.ToInt32(tbPrice.Text);
//string postavka = tbPostavka.Text;

//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
//DataTable dataTable = new DataTable();

//string quareString = $"select id , name, category, price, postavka from materials  where name = '{name}' and category = '{category}' and price = '{price}' and postavka = '{postavka}' ";

//SqlCommand sqlCommand = new SqlCommand(quareString, dataBase.GetConnection());

//sqlDataAdapter.SelectCommand = sqlCommand;
//sqlDataAdapter.Fill(dataTable);

//if(dataTable.Rows.Count == 1)
//{
//    MessageBox.Show("Добавленно");
//}
//else
//{

//}