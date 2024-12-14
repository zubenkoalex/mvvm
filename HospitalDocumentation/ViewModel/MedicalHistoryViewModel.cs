using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.Model;
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
    public class MedicalHistoryViewModel : NotifyProperty
    {
        private ObservableCollection<MedicalHistoryEntity> _medicalHistories;
        private MedicalHistoryEntity? _selectedMedicalHistory;

        public ObservableCollection<MedicalHistoryEntity> MedicalHistories
        {
            get => _medicalHistories;
            set
            {
                _medicalHistories = value;
                OnPropertyChanged();
            }
        }

        public MedicalHistoryEntity? SelectedMedicalHistory
        {
            get => _selectedMedicalHistory;
            set
            {
                _selectedMedicalHistory = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public MedicalHistoryViewModel()
        {
            _medicalHistories = new ObservableCollection<MedicalHistoryEntity>();

            AddCommand = new RelayCommand(AddMedicalHistory);
            EditCommand = new RelayCommand(EditMedicalHistory, () => SelectedMedicalHistory != null);
            DeleteCommand = new RelayCommand(DeleteMedicalHistory, () => SelectedMedicalHistory != null);

            LoadMedicalHistories();
        }

        private void LoadMedicalHistories()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var medicalHistories = context.MedicalHistoryEntities.ToList();
                    MedicalHistories = new ObservableCollection<MedicalHistoryEntity>(medicalHistories);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void AddMedicalHistory()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var maxId = context.MedicalHistoryEntities.Max(m => m.Id);

                    var medicalHistory = new MedicalHistoryEntity
                    {
                        Id = maxId + 1, 
                        Diagnosis = "",
                        DescriptionOfTreatment = ""
                    };

                    var window = new MedicalHistoryAddEditWindow(medicalHistory);
                    if (window.ShowDialog() == true)
                    {

                        if (string.IsNullOrWhiteSpace(medicalHistory.Diagnosis))
                        {
                            MessageBox.Show("Диагноз обязателен для заполнения", "Ошибка");
                            return;
                        }

    
                        context.MedicalHistoryEntities.Add(medicalHistory);
                        context.SaveChanges();
                        LoadMedicalHistories();
                        MessageBox.Show("История болезни успешно добавлена!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при добавлении: {innerMessage}", "Ошибка");
            }
        }

        private void EditMedicalHistory()
        {
            if (SelectedMedicalHistory == null) return;

            try
            {
                using (var context = new HospContext())
                {
                    var medicalHistoryToEdit = context.MedicalHistoryEntities.Find(SelectedMedicalHistory.Id);
                    if (medicalHistoryToEdit == null)
                    {
                        MessageBox.Show("История болезни не найдена в базе данных", "Ошибка");
                        return;
                    }


                    var editedMedicalHistory = new MedicalHistoryEntity
                    {
                        Id = medicalHistoryToEdit.Id,
                        Diagnosis = medicalHistoryToEdit.Diagnosis,
                        DescriptionOfTreatment = medicalHistoryToEdit.DescriptionOfTreatment
                    };

                    var window = new MedicalHistoryAddEditWindow(editedMedicalHistory);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(editedMedicalHistory.Diagnosis))
                        {
                            MessageBox.Show("Диагноз обязателен для заполнения", "Ошибка");
                            return;
                        }

                       
                        context.Entry(medicalHistoryToEdit).CurrentValues.SetValues(editedMedicalHistory);
                        context.SaveChanges();
                        LoadMedicalHistories();
                        MessageBox.Show("История болезни успешно обновлена!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при обновлении: {innerMessage}", "Ошибка");
            }
        }

        private void DeleteMedicalHistory()
        {
            if (SelectedMedicalHistory == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранную историю болезни?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new HospContext())
                    {
                        var medicalHistoryToDelete = context.MedicalHistoryEntities.Find(SelectedMedicalHistory.Id);
                        if (medicalHistoryToDelete != null)
                        {
                            context.MedicalHistoryEntities.Remove(medicalHistoryToDelete);
                            context.SaveChanges();
                            LoadMedicalHistories();
                            MessageBox.Show("История болезни успешно удалена!", "Успешный успех");
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
