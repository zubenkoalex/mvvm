using HospitalDocumentation.Model.Enities;
using System.Windows;

namespace HospitalDocumentation.View
{
    public partial class PatientAddEditWindow : Window
    {
        private readonly PatientEntity _patient;

        public PatientAddEditWindow(PatientEntity patient)
        {
            InitializeComponent();
            _patient = patient;
            DataContext = _patient;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_patient.Name))
            {
                MessageBox.Show("Введите ФИО пациента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_patient.Sex))
            {
                MessageBox.Show("Выберите пол пациента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_patient.PhoneNumber))
            {
                MessageBox.Show("Введите номер телефона", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}