   M S B A M L   `   `   `  ����P  LHospitalDocumentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HospitalDocumentation.ViewHospitalDocumentation.View  5   	   Q-clr-namespace:HospitalDocumentation.ViewModelHospitalDocumentation.ViewModel  5   
   ;    5HospitalDocumentation.View.MedicalRecordAddEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:HospitalDocumentation.View     5   	   <vm-clr-namespace:HospitalDocumentation.ViewModel     5   
     � Title$   MedicalRecordAddEditWindow��5	   	   $	��450��6,   $	��800��69    � WindowStartupLocation$ CenterOwner=�6E   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Пациент:��6   $��0��6$   $��5q�61   $��Center=�6<   �� 5   
   $��0��6   $��1��6    $��5q�60    �� SelectedValuePath$ Id��5        �� DisplayMemberPath$
 Name��5!      ��5      �� *
Patients+ �� SelectedValue 5      �� *MedicalRecord.PatientId+5!      �� 5$   
   $��	Врач:��6   $��1��6!   $��5q�6.   $��Center=�69   �� 5%   
   $��1��6   $��1��6    $��5q�60   $ Id��5(      $
 Name��5)      ��5&      �� *	Doctors+ 5'      �� *MedicalRecord.DoctorId+5)      �� 5,   
   $��Дата записи:��6   $��2��6(   $��5q�65   $��Center=�6@   �� 5-   
   $��2��6   $��1��6    $��5q�60   $ Id��50      $
 Date��51      ��5.      �� *AppointmentRecords+ 5/      �� *#!MedicalRecord.AppointmentRecordId+51      �� 54   
   $��Диагноз:��6   $��3��6$   $��5q�61   $��Center=�6<   �� 55   
   $��3��6   $��1��6    $��5q�60   $ Id��58      $ 	Diagnosis��59      ��56      �� *MedicalHistories+ 57      �� * MedicalRecord.MedicalHistoryId+59      �� 5<   
   $3��-Дата назначения рецепта:��6   $��4��64   $��5q�6A   $��Center=�6L   �� 5=   
   $��4��6   $��1��6    $��5q�60   $ Id��5@      $
 Date��5A      ��5>      �� *	Recipes+ 5?      �� *MedicalRecord.RecipeId+5A      �� 5C   
   $��Анализ:��6   $��5��6#   $��5q�60   $��Center=�6;   �� 5D   
   $��5��6   $��1��6    $��5q�60   $ Id��5G      $
 Type��5H      ��5E      �� *LaboratoryTests+ 5F      �� * MedicalRecord.LaboratoryTestId+5H      �� 5K   
   $��7��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�5L      $��Right=�6.   .+�5M      �� -   5        $��Сохранить��5M      $	��100��5N      $��30��6!   $��5q�6-   �� 5O      $��Отмена��6    �� IsCancel$
 True��6&   $	��100��5P      $��30��6!   $��5q�6-   5Q      5R      5S      