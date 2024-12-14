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
    public partial class MedicalRecordAddEditWindow : Window
    {
        private readonly MedicalRecordEntity _medicalRecord;

        public MedicalRecordAddEditWindow(MedicalRecordEntity medicalRecord)
        {
            InitializeComponent();
            _medicalRecord = medicalRecord;
            DataContext = new MedicalRecordAddEditViewModel(medicalRecord);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_medicalRecord.PatientId == null)
            {
                MessageBox.Show("Выберите пациента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_medicalRecord.DoctorId == null)
            {
                MessageBox.Show("Выберите врача", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
