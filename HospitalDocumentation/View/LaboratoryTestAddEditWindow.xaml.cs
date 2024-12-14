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
    public partial class LaboratoryTestAddEditWindow : Window
    {
        private readonly LaboratoryTestEntity _laboratoryTest;

        public LaboratoryTestAddEditWindow(LaboratoryTestEntity laboratoryTest)
        {
            InitializeComponent();
            _laboratoryTest = laboratoryTest;
            DataContext = _laboratoryTest;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_laboratoryTest.Type))
            {
                MessageBox.Show("Введите ФИО пациента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
