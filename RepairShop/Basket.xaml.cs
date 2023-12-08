using System;
using System.Collections.Generic;
using System.IO;
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

namespace RepairShop
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        public List<BasketItem> BasketItems { get; }

        public Basket(List<BasketItem> basketItems)
        {
            InitializeComponent();
            BasketItems = basketItems;
            ShowItems();
        }

        private void ShowItems()
        {
            items.Children.Clear();
            foreach (var basketItem in BasketItems)
            {
                Item item = new Item(basketItem, "Удалить");
                item.OnAdd += Item_OnAdd;
                items.Children.Add(item);
            }
        }

        private void Item_OnAdd(object? sender, BasketItem e)
        {
            BasketItems.Remove(e);
            ShowItems();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> lines = new List<string>();
            foreach (var basketItem in BasketItems)
            {
                lines.Add($"{basketItem.Id};{basketItem.Name};{basketItem.Price}");
            }
            if (!Directory.Exists("orders"))
                Directory.CreateDirectory("orders");
            File.WriteAllLines($"orders/order{DateTime.Now.ToString("ddMMyy_hhmmss")}.txt", lines);
            MessageBox.Show("Заказ успешно создан");
            BasketItems.Clear();
            this.Close();
        }
    }
}
