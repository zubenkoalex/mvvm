using HospitalDocumentation.Model;
using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace HospitalDocumentation.ViewModel
{
    public class PatientViewModel : NotifyProperty
    {
        private ObservableCollection<PatientEntity> _patients;
        private PatientEntity? _selectedPatient;

        public ObservableCollection<PatientEntity> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropertyChanged();
            }
        }

        public PatientEntity? SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public PatientViewModel()
        {
            _patients = new ObservableCollection<PatientEntity>();
            
            AddCommand = new RelayCommand(AddPatient);
            EditCommand = new RelayCommand(EditPatient, () => SelectedPatient != null);
            DeleteCommand = new RelayCommand(DeletePatient, () => SelectedPatient != null);

            LoadPatients();
        }

        private void LoadPatients()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var patients = context.PatientEntities.ToList();
                    Patients = new ObservableCollection<PatientEntity>(patients);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void AddPatient()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var maxId = context.PatientEntities.Max(p => p.Id);

                    var patient = new PatientEntity
                    {
                        Id = maxId + 1, 
                        DateOfBirth = DateOnly.FromDateTime(DateTime.Today),
                        Name = "",
                        Sex = "", 
                        Address = "",
                        PhoneNumber = "",
                        Email = ""
                    };

                    var window = new PatientAddEditWindow(patient);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(patient.Name))
                        {
                            MessageBox.Show("ФИО пациента обязательно для заполнения", "Ошибка");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(patient.Sex))
                        {
                            MessageBox.Show("Пол пациента обязателен для заполнения", "Ошибка");
                            return;
                        }

        
                        context.PatientEntities.Add(patient);
                        context.SaveChanges();
                        LoadPatients();
                        MessageBox.Show("Пациент успешно добавлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при добавлении: {innerMessage}", "Ошибка");
            }
        }

        private void EditPatient()
        {
            if (SelectedPatient == null) return;

            try
            {
                using (var context = new HospContext())
                {
                    var patientToEdit = context.PatientEntities.Find(SelectedPatient.Id);
                    if (patientToEdit == null)
                    {
                        MessageBox.Show("Пациент не найден в базе данных", "Ошибка");
                        return;
                    }


                    var editedPatient = new PatientEntity
                    {
                        Id = patientToEdit.Id,
                        Name = patientToEdit.Name,
                        DateOfBirth = patientToEdit.DateOfBirth,
                        Sex = patientToEdit.Sex,
                        Address = patientToEdit.Address,
                        PhoneNumber = patientToEdit.PhoneNumber,
                        Email = patientToEdit.Email
                    };

                    var window = new PatientAddEditWindow(editedPatient);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(editedPatient.Name))
                        {
                            MessageBox.Show("ФИО пациента обязательно для заполнения", "Ошибка");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(editedPatient.Sex))
                        {
                            MessageBox.Show("Пол пациента обязателен для заполнения", "Ошибка");
                            return;
                        }

                        context.Entry(patientToEdit).CurrentValues.SetValues(editedPatient);
                        context.SaveChanges();
                        LoadPatients();
                        MessageBox.Show("Пациент успешно обновлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при обновлении: {innerMessage}", "Ошибка");
            }
        }

        private void DeletePatient()
        {
            if (SelectedPatient == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранного пациента?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new HospContext())
                    {
                        var patientToDelete = context.PatientEntities.Find(SelectedPatient.Id);
                        if (patientToDelete != null)
                        {
                            context.PatientEntities.Remove(patientToDelete);
                            context.SaveChanges();
                            LoadPatients();
                            MessageBox.Show("Пациент успешно удален!", "Успешный успех");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
                }
            }
        }
    }


}