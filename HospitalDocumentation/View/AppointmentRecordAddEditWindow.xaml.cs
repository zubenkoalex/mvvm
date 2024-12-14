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
    public partial class AppointmentRecordAddEditWindow : Window
    {
        private readonly AppointmentRecordEntity _appointmentRecord;

        public AppointmentRecordAddEditWindow(AppointmentRecordEntity appointmentRecord)
        {
            InitializeComponent();
            _appointmentRecord = appointmentRecord;
            DataContext = _appointmentRecord;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_appointmentRecord.Reason))
            {
                MessageBox.Show("Введите ФИО пациента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
