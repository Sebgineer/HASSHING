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

namespace HASSHING
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HASH hash = new HASH();

        public MainWindow()
        {
            InitializeComponent();
            hash.setHmac("MD5");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] message = Encoding.ASCII.GetBytes(Message.Text);
            byte[] key = Encoding.ASCII.GetBytes(Key.Text);
            byte[] value = hash.Hashing(message, key);
            HashedText.Content = Convert.ToBase64String(value);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)Select.SelectedItem;
            if (item.Content != null)
            {
                hash.setHmac(item.Content.ToString());
            }
        }
    }
}
