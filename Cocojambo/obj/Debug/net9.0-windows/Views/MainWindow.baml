   M S B A M L   `   `   `  ����D  @Cocojambo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Cocojambo.ViewsCocojambo.Views  5   	        Cocojambo.Views.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Cocojambo.Views     5   	     � Title$  
MainWindow��5   	   $	��450��6   $
��1426��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��60      
IsReadOnly$
 True��6L   ��6   �� *Cars+ �� SelectedItem 5      �� *SelectedCars+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Автомобиль_ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Id+6S     5      $ 
Марка��6%   $
 auto 6V    64   �� *Mark.NameMark+6V     5      $ Модель��6%   $
 auto 6\    65   �� *Model.NameModelCar+6\     5      $ Поколение��6%   $
 auto 6f    68   �� *Generation.NameGeneration+6f     5      $ Тип топлива��6%   $
 auto 6^    6:   �� *Pacage.FuelType+6^     5      $# Объем двигателя��6%   $
 auto 6f    6>   �� *Pacage.EngineVolume+6f     5      $) #Мощность двигателя��6%   $
 auto 6h    6A   �� *Pacage.EnginePower+6h     5      $ Тип КПП��6%   $
 auto 6Y    66   �� *Pacage.Kpptype+6Y     5      $ Тип привода��6%   $
 auto 6_    6:   �� *Pacage.DriveType+6_     5      $ Тип кузова��6%   $
 auto 6]    69   �� *Pacage.CallType+6]     5      $ Цвет кузова��6%   $
 auto 6_    6:   �� *Pacage.CallColor+6_     5      $ Руль��6%   $
 auto 6U    63   �� *Pacage.Rudder+6U     5      $/ )Название комплектации��6%   $
 auto 6j    6D   �� *Pacage.NamePacage+6j     5      $ Пробег��6%   $
 auto 6Q    65   �� *	Mileage+6Q     5      $ Цена��6%   $
 auto 6M    63   �� *Price+6M     5       $ Год выпуска��6%   $
 auto 6Z    6:   �� *ReleaseYear+6Z   5#      �� 5$   
   $��Right=�6   $��Добавить��6L   $	��Top=�6_   $��30��6w   $��
0,12,135,0q�6�   $	��130��6�   $��1��6�   ��6-   �� *
AddCommand+6�   �� 5%   
   $
��Left=�6   $��Изменить��6L   $��Center=�6_   $��30��6z   $��	764,0,0,0q�6�   $	��130��6�   $��1��6�   ��6,   �� *EditCommand+6�   �� 5&   
   $
��Left=�6   $��Удалить��6N   $��Center=�6`   $��30��6{   $��	420,0,0,0q�6�   $	��130��6�   $��1��6�   ��6,   �� *DeleteCommand+6�   5'      5(      