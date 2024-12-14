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
    public partial class MedicalHistoryAddEditWindow : Window
    {
        private readonly MedicalHistoryEntity _medicalHistory;

        public MedicalHistoryAddEditWindow(MedicalHistoryEntity medicalHistory)
        {
            InitializeComponent();
            _medicalHistory = medicalHistory;
            DataContext = _medicalHistory;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_medicalHistory.Diagnosis))
            {
                MessageBox.Show("Введите ФИО пациента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
