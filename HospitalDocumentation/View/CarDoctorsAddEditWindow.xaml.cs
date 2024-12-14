using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.ViewModel;
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

namespace HospitalDocumentation.View
{
    public partial class CarDoctorsAddEditWindow : Window
    {
        private readonly CarDoctorsEntity _car;

        public CarDoctorsAddEditWindow(CarDoctorsEntity car)
        {
            InitializeComponent();
            _car = car;
            DataContext = _car;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_car.Mark))
            {
                MessageBox.Show("Введите Марку", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_car.Model))
            {
                MessageBox.Show("Выберите Модель", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_car.Generation))
            {
                MessageBox.Show("Введите Поколение", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
