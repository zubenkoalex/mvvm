using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using HospitalDocumentation.Model;
using System.Windows;
using HospitalDocumentation.ViewModel;
using HospitalDocumentation.View;

namespace HospitalDocumentation
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }


        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HospContext>(options =>
            {
                options.UseSqlServer(@"Server=zubenkoag;Database=Hosp;User=user1;Password=sa;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false");
            });


            services.AddTransient<MainViewModel>();
            services.AddTransient<PatientViewModel>();
            services.AddTransient<PatientAddEditViewModel>();
            services.AddTransient<DoctorViewModel>();
            services.AddTransient<DoctorAddEditViewModel>();
            services.AddTransient<AppointmentRecordViewModel>();
            services.AddTransient<AppointmentRecordAddEditViewModel>();
            services.AddTransient<MedicalRecordViewModel>();
            services.AddTransient<MedicalRecordAddEditViewModel>();
            services.AddTransient<MedicalHistoryViewModel>();
            services.AddTransient<MedicalHistoryAddEditViewModel>();
            services.AddTransient<LaboratoryTestViewModel>();
            services.AddTransient<LaboratoryTestAddEditViewModel>();
            services.AddTransient<RecipeViewModel>();
            services.AddTransient<RecipeAddEditViewModel>();
            services.AddTransient<DrugViewModel>();
            services.AddTransient<DrugAddEditViewModel>();
            services.AddTransient<DrugstoreViewModel>();
            services.AddTransient<DrugstoreAddEditViewModel>(); 
            services.AddTransient<CarDoctorsViewModel>();
            services.AddTransient<CarDoctorAddEditViewModel>();


            services.AddTransient<MainWindow>();
            services.AddTransient<PatientWindow>();
            services.AddTransient<PatientAddEditWindow>();
            services.AddTransient<DoctorWindow>();
            services.AddTransient<DoctorAddEditWindow>();
            services.AddTransient<AppointmentRecordWindow>();
            services.AddTransient<AppointmentRecordAddEditWindow>();
            services.AddTransient<MedicalRecordWindow>();
            services.AddTransient<MedicalRecordAddEditWindow>();
            services.AddTransient<MedicalHistoryWindow>();
            services.AddTransient<MedicalHistoryAddEditWindow>();
            services.AddTransient<LaboratoryTestWindow>();
            services.AddTransient<LaboratoryTestAddEditWindow>();
            services.AddTransient<RecipeWindow>();
            services.AddTransient<RecipeAddEditWindow>();
            services.AddTransient<DrugWindow>();
            services.AddTransient<DrugAddEditWindow>();
            services.AddTransient<DrugstoreWindow>();
            services.AddTransient<DrugstoreAddEditWindow>();
            services.AddTransient<CarDoctorsAddEditWindow>();
            services.AddTransient<CarDoctorsWindow>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
            mainWindow.Show();
        }
    }
}
