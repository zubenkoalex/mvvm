using HospitalDocumentation.Model;
using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HospitalDocumentation.ViewModel
{
    public class MedicalRecordAddEditViewModel : NotifyProperty
    {
        private MedicalRecordEntity _medicalRecord;
        private ObservableCollection<PatientEntity> _patients;
        private ObservableCollection<DoctorEntity> _doctors;
        private ObservableCollection<AppointmentRecordEntity> _appointmentRecords;
        private ObservableCollection<MedicalHistoryEntity> _medicalHistories;
        private ObservableCollection<RecipeEntity> _recipes;
        private ObservableCollection<LaboratoryTestEntity> _laboratoryTests;

        public MedicalRecordEntity MedicalRecord
        {
            get => _medicalRecord;
            set
            {
                _medicalRecord = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PatientEntity> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DoctorEntity> Doctors
        {
            get => _doctors;
            set
            {
                _doctors = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AppointmentRecordEntity> AppointmentRecords
        {
            get => _appointmentRecords;
            set
            {
                _appointmentRecords = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MedicalHistoryEntity> MedicalHistories
        {
            get => _medicalHistories;
            set
            {
                _medicalHistories = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<RecipeEntity> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<LaboratoryTestEntity> LaboratoryTests
        {
            get => _laboratoryTests;
            set
            {
                _laboratoryTests = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public MedicalRecordAddEditViewModel(MedicalRecordEntity medicalRecord)
        {
            _medicalRecord = medicalRecord;
            LoadData();
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private void LoadData()
        {
            using (var context = new HospContext())
            {
                Patients = new ObservableCollection<PatientEntity>(context.PatientEntities.ToList());
                Doctors = new ObservableCollection<DoctorEntity>(context.DoctorEntities.ToList());
                AppointmentRecords = new ObservableCollection<AppointmentRecordEntity>(context.AppointmentRecordEntities.ToList());
                MedicalHistories = new ObservableCollection<MedicalHistoryEntity>(context.MedicalHistoryEntities.ToList());
                Recipes = new ObservableCollection<RecipeEntity>(context.RecipeEntities.ToList());
                LaboratoryTests = new ObservableCollection<LaboratoryTestEntity>(context.LaboratoryTestEntities.ToList());

            }
        }

        private bool CanSave()
        {
            return MedicalRecord.PatientId != null &&
                   MedicalRecord.DoctorId != null;
        }

        private void Save()
        {
            var window = Application.Current.Windows.OfType<MedicalRecordAddEditWindow>().FirstOrDefault();
            window.DialogResult = true;
            window.Close();
        }
    }
}
