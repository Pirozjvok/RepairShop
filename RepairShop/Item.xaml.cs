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

namespace RepairShop
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public event EventHandler<BasketItem>? OnAdd;

        public BasketItem BasketItem { get; }

        public Item(BasketItem item, string? text = null)
        {
            InitializeComponent();
            this.image.Source = new BitmapImage(new Uri(item.Image));
            this.name.Content = item.Name;
            this.desc.Content = item.Description;
            this.price.Content = $"{item.Price:F2} руб";
            if (text != null)
            {
                this.button.Content = text;
            }
            BasketItem = item;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnAdd?.Invoke(this, BasketItem);
        }
    }
}
