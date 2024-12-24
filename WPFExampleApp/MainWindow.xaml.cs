using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFExampleApp
{
    // Класс для хранения текста
    public class TextItem
    {
        public string Text { get; set; }
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<TextItem> Items { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Items = new ObservableCollection<TextItem>();
            DataGridExample.ItemsSource = Items;
        }

        // Обработчик нажатия на кнопку "Добавить"
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string text = InputTextBox.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                Items.Add(new TextItem { Text = text });
                InputTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Введите текст!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обработчик нажатия на кнопку "Удалить"
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текущий элемент из DataGrid
            var button = sender as Button;
            var dataItem = button?.DataContext as TextItem;

            if (dataItem != null)
            {
                Items.Remove(dataItem); // Удаляем элемент из коллекции
            }
        }
    }
}
