   M S B A M L   `   `   `  ����P  LHospitalDocumentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HospitalDocumentation.ViewHospitalDocumentation.View  5   	   Q-clr-namespace:HospitalDocumentation.ViewModelHospitalDocumentation.ViewModel  5   	   2    ,HospitalDocumentation.View.DrugAddEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:HospitalDocumentation.View     5   	   <vm-clr-namespace:HospitalDocumentation.ViewModel     5   	     � Title$  DrugAddEditWindow��5	   	   $	��450��6#   $	��800��60   .��5
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
   �� $��Название:��6   $��0��6%   $��0��62   $��5q�6B   $��Center=�6M   �� 5   
   $��0��6   $��1��6   $��5q�6/   ��5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5!   
   $��Дозировка:��6   $��1��6&   $��0��63   $��5q�6C   $��Center=�6N   �� 5"   
   $��1��6   $��1��6   $��5q�6/   ��5#      �� *Dosage+$ PropertyChanged=��� 5&   
   $)��#Дата начала приёма:��6   $��2��6/   $��0��6<   $��5q�6L   $��Center=�6W   (  "System.Windows.Controls.DatePicker  5'   
   $��2��6   $��1��6"   $��5q�62      SelectedDate 5(      �� *	StartDate+�� 5+   
   $/��)Дата окончания приёма:��6   $��3��62   $��0��6?   $��5q�6O   $��Center=�6Z     5,   
   $��3��6   $��1��6"   $��5q�62    5-      �� *	EndDate+�� 50   
   $��7��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�51      $��Right=�6*   .+�52      �� -   5        $��Сохранить��52      $	��100��53      $��30��6   $��5q�6)   �� 54      $��Отмена��6    �� IsCancel$
 True��6&   $	��100��55      $��30��6   $��5q�6)   56      57      58      