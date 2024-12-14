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
    public partial class DoctorAddEditWindow : Window
    {
        private readonly DoctorEntity _doctor;

        public DoctorAddEditWindow(DoctorEntity doctor)
        {
            InitializeComponent();
            _doctor = doctor;
            DataContext = _doctor;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_doctor.Name))
            {
                MessageBox.Show("Введите ФИО пациента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_doctor.Speciality))
            {
                MessageBox.Show("Выберите пол пациента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_doctor.PhoneNumber))
            {
                MessageBox.Show("Введите номер телефона", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
