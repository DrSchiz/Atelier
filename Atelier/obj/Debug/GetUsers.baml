   M S B A M L   `   `   `  ����B  >Atelier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AtelierAtelier  5   	       Atelier.GetUsers   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Atelier     5   	     � Title$  Пользователи��5   	   $	��450��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   �� 5      $
��0.3* �6   6.    � RowDefinitions 5   
   �� 5      $
��0.3* �6   6,   �� 5      6   �� 5      $
��0.3* �6   6,   �� 5      $
��0.3* �6   6,   .+�5   
   �� $��Пользователи:��6   $��0��5      $��0��5      $��20(�5      �� 5   
   $6��0Действующие пользователи:��6   $��0��5      $��0��5      $��20(�5      $��Bottom=�5      �� 5   
   $2��,Удалённые пользователи:��6   $��1��5      $��0��5       $��20(�5!      $��Bottom=�5"      &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ dgUsersActive��5#         CanUserAddRows .  $��0��5%      $��1��5&      $��3��5'         AutoGenerateColumns .     Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ Логин клиента��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Login+6X   5.        5/   
   -   5        $ dgUsersDeleted��5/       .  $��1��51      $��1��52      $��3��53       .   56        57      $ Логин клиента��6%    6<   �� *Login+6X   59      �� 5:   
   -   5        	 ��Name$	 	btnGoBack��5:      $��
Назад��5;      $��2��5<      $��0��5=      $
��40px��5>      $	��Top=�5?      $��25(�5@      5A      �� 5C   
   -   5        $	 Delete��5C      $��Удалить��5D      $��40��5E      $��2��5F      $��3��5G      $��Bottom=�5H      $��25(�5I      {�.  
���  ��5L      5M      5N      