using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace RepairShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<BasketItem> BasketItems { get; }

        public MainWindow()
        {
            InitializeComponent();

            BasketItems = new List<BasketItem>();

            string[] test = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            string[] itemsStr = File.ReadAllLines("items.txt", Encoding.UTF8);

            foreach (string itemStr in itemsStr)
            {
                string[] splited = itemStr.Split(';');
                BasketItem basketItem = new BasketItem()
                {
                    Id = int.Parse(splited[0]),
                    Image = splited[1],
                    Name = splited[2],
                    Description = splited[3],
                    Price = decimal.Parse(splited[4])
                };
                Item item = new Item(basketItem);
                item.OnAdd += Item_OnAdd;
                items.Children.Add(item);
            }
        }

        private void Item_OnAdd(object? sender, BasketItem e)
        {
            BasketItems.Add(e);
            MessageBox.Show("Товар успешно добавлен в корзину");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Basket basket = new Basket(BasketItems);
            basket.ShowDialog();
        }
    }
}
