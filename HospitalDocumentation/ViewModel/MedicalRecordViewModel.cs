using HospitalDocumentation.Model;
using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HospitalDocumentation.ViewModel
{
    public class MedicalRecordViewModel : NotifyProperty
    {
        private ObservableCollection<MedicalRecordEntity> _medicalRecords;
        private MedicalRecordEntity? _selectedMedicalRecord;

        public ObservableCollection<MedicalRecordEntity> MedicalRecords
        {
            get => _medicalRecords;
            set
            {
                _medicalRecords = value;
                OnPropertyChanged();
            }
        }

        public MedicalRecordEntity? SelectedMedicalRecord
        {
            get => _selectedMedicalRecord;
            set
            {
                _selectedMedicalRecord = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public MedicalRecordViewModel()
        {
            _medicalRecords = new ObservableCollection<MedicalRecordEntity>();

            AddCommand = new RelayCommand(AddMedicalRecord);
            EditCommand = new RelayCommand(EditMedicalRecord, () => SelectedMedicalRecord != null);
            DeleteCommand = new RelayCommand(DeleteMedicalRecord, () => SelectedMedicalRecord != null);

            LoadMedicalRecords();
        }

        private void LoadMedicalRecords()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var records = context.MedicalRecordEntities
                        .Include(m => m.Patient)
                        .Include(m => m.Doctor)
                        .Include(m => m.AppointmentRecord)
                        .Include(m => m.MedicalHistory)
                        .Include(m => m.Recipe)
                        .Include(m => m.LaboratoryTest)
                        .ToList();
                    MedicalRecords = new ObservableCollection<MedicalRecordEntity>(records);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void AddMedicalRecord()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var maxId = context.MedicalRecordEntities.Max(r => r.Id);

                    var record = new MedicalRecordEntity
                    {
                        Id = maxId + 1
                    };

                    var window = new MedicalRecordAddEditWindow(record);
                    if (window.ShowDialog() == true)
                    {
                        context.MedicalRecordEntities.Add(record);
                        context.SaveChanges();
                        LoadMedicalRecords();
                        MessageBox.Show("Медицинская карта успешно добавлена!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при добавлении: {innerMessage}", "Ошибка");
            }
        }

        private void EditMedicalRecord()
        {
            if (SelectedMedicalRecord == null) return;

            try
            {
                using (var context = new HospContext())
                {
                    var recordToEdit = context.MedicalRecordEntities.Find(SelectedMedicalRecord.Id);
                    if (recordToEdit == null)
                    {
                        MessageBox.Show("Медицинская карта не найдена в базе данных", "Ошибка");
                        return;
                    }

                    var editedRecord = new MedicalRecordEntity
                    {
                        Id = recordToEdit.Id,
                        PatientId = recordToEdit.PatientId,
                        DoctorId = recordToEdit.DoctorId,
                        AppointmentRecordId = recordToEdit.AppointmentRecordId,
                        MedicalHistoryId = recordToEdit.MedicalHistoryId,
                        RecipeId = recordToEdit.RecipeId,
                        LaboratoryTestId = recordToEdit.LaboratoryTestId
                    };

                    var window = new MedicalRecordAddEditWindow(editedRecord);
                    if (window.ShowDialog() == true)
                    {
                        context.Entry(recordToEdit).CurrentValues.SetValues(editedRecord);
                        context.SaveChanges();
                        LoadMedicalRecords();
                        MessageBox.Show("Медицинская запись успешно обновлена!", "Успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при обновлении: {innerMessage}", "Ошибка");
            }
        }

        private void DeleteMedicalRecord()
        {
            if (SelectedMedicalRecord == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранную медицинскую карту?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new HospContext())
                    {
                        var recordToDelete = context.MedicalRecordEntities.Find(SelectedMedicalRecord.Id);
                        if (recordToDelete != null)
                        {
                            context.MedicalRecordEntities.Remove(recordToDelete);
                            context.SaveChanges();
                            LoadMedicalRecords();
                            MessageBox.Show("Медицинская карта успешно удалена!", "Успешный успех");
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
