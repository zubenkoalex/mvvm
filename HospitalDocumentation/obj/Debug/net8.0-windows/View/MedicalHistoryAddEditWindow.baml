   M S B A M L   `   `   `  ����P  LHospitalDocumentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HospitalDocumentation.ViewHospitalDocumentation.View  5   	   Q-clr-namespace:HospitalDocumentation.ViewModelHospitalDocumentation.ViewModel  5   	   <    6HospitalDocumentation.View.MedicalHistoryAddEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:HospitalDocumentation.View     5   	   <vm-clr-namespace:HospitalDocumentation.ViewModel     5   	     � Title$!  MedicalHistoryAddEditWindow��5	   	   $	��450��6-   $	��800��6:   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Диагноз:��6   $��0��6$   $��0��61   $��5q�6A   $��Center=�6L   �� 5   
   $��0��6   $��1��6   $��5q�6/   ��5   	   �� *	Diagnosis+ �� UpdateSourceTrigger$ PropertyChanged=��� 5!   
   $&�� Описание лечения:��6   $��1��6-   $��0��6:   $��5q�6J   $��Center=�6U   �� 5"   
   $��1��6   $��1��6   $��5q�6/   ��5#   	   �� *DescriptionOfTreatment+$ PropertyChanged=��� 5&   
   $��7��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�5'   	   $��Right=�6"   .+�5(      �� -   5        $��Сохранить��5(      $	��100��5)   	   $��30��6   $��5q�6!   �� 5*      $��Отмена��6    �� IsCancel$
 True��6&   $	��100��5+   	   $��30��6   $��5q�6!   5,      5-      5.      