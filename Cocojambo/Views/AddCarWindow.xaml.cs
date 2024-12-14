using Cocojambo.Models.Entities;
using Cocojambo.ViewModels;
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

namespace Cocojambo.Views
{
    public partial class AddCarWindow : Window
    {
        private readonly CarEntity _car;
        public AddCarWindow(CarEntity car)
        {
            InitializeComponent();
            _car = car;
            DataContext = car;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_car.MarkId == null)
            {
                MessageBox.Show("Выберите Марку", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_car.ModelId == null)
            {
                MessageBox.Show("Выберите Модель", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_car.GenerationId == null)
            {
                MessageBox.Show("Выберите Поколение", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            DialogResult = true;
        }
    }
}
