using HospitalDocumentation.Model;
using HospitalDocumentation.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
using System.Windows.Input;

namespace HospitalDocumentation.ViewModel
{
    public class MainViewModel : NotifyProperty
    {
        private readonly IServiceProvider _serviceProvider;


        public ICommand OpenMedicalRecordCommand { get; }
        public ICommand OpenPatientCommand { get; }
        public ICommand OpenDoctorCommand { get; }
        public ICommand OpenAppointmentRecordCommand { get; }
        public ICommand OpenRecipeCommand { get; }
        public ICommand OpenDrugCommand { get; }
        public ICommand OpenDrugstoreCommand { get; }
        public ICommand OpenMedicalHistoryCommand { get; }
        public ICommand OpenLaboratoryTestCommand { get; }
        public ICommand OpenCarDoctorCommand { get; }

        public MainViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            OpenMedicalRecordCommand = new RelayCommand(OpenMedicalRecord);
            OpenPatientCommand = new RelayCommand(OpenPatient);
            OpenDoctorCommand = new RelayCommand(OpenDoctor);
            OpenAppointmentRecordCommand = new RelayCommand(OpenAppointmentRecord);
            OpenRecipeCommand = new RelayCommand(OpenRecipe);
            OpenDrugCommand = new RelayCommand(OpenDrug);
            OpenDrugstoreCommand = new RelayCommand(OpenDrugstore);
            OpenMedicalHistoryCommand = new RelayCommand(OpenMedicalHistory);
            OpenLaboratoryTestCommand = new RelayCommand(OpenLaboratoryTest);
            OpenCarDoctorCommand = new RelayCommand(OpenCarDoctor);
        }

        private void OpenMedicalRecord()
        {
            var window = _serviceProvider.GetRequiredService<MedicalRecordWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<MedicalRecordViewModel>();
            window.Show();
        }

        private void OpenPatient()
        {
            var window = _serviceProvider.GetRequiredService<PatientWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<PatientViewModel>();
            window.Show();
        }

        private void OpenDoctor()
        {
            var window = _serviceProvider.GetRequiredService<DoctorWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<DoctorViewModel>();
            window.Show();
        }

        private void OpenAppointmentRecord()
        {
            var window = _serviceProvider.GetRequiredService<AppointmentRecordWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<AppointmentRecordViewModel>();
            window.Show();
        }

        private void OpenRecipe()
        {
            var window = _serviceProvider.GetRequiredService<RecipeWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<RecipeViewModel>();
            window.Show();
        }

        private void OpenDrug()
        {
            var window = _serviceProvider.GetRequiredService<DrugWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<DrugViewModel>();
            window.Show();
        }

        private void OpenDrugstore()
        {
            var window = _serviceProvider.GetRequiredService<DrugstoreWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<DrugstoreViewModel>();
            window.Show();
        }

        private void OpenMedicalHistory()
        {
            var window = _serviceProvider.GetRequiredService<MedicalHistoryWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<MedicalHistoryViewModel>();
            window.Show();
        }

        private void OpenLaboratoryTest()
        {
            var window = _serviceProvider.GetRequiredService<LaboratoryTestWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<LaboratoryTestViewModel>();
            window.Show();
        }

        private void OpenCarDoctor()
        {
            var window = _serviceProvider.GetRequiredService<CarDoctorsWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<CarDoctorsViewModel>();
            window.Show();
        }
    }
}