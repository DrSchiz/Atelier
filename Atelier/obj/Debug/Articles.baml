   M S B A M L   `   `   `  ����B  >Atelier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AtelierAtelier  5   	       Atelier.Articles   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Atelier     5   	     � Title$  Изделия��5   	   $	��450��6   $	��800��6&   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      $
��0.3* �6   6.    � RowDefinitions 5   
   �� 5      $
��0.3* �6   6,   �� 5      6   �� 5      $
��0.3* �6   6,   �� 5      $
��0.3* �6   6,   �� 5      $
��0.3* �6   6,   �� 5      $
��0.3* �6   6,   .+�5   
   �� $��Изделия:��6   $��0��5      $��0��5      $��20(�5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgArticles��5         CanUserAddRows .  $��0��5      $��1��5      $��6��5         AutoGenerateColumns .     Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+6R     5"      $ Вид изделия��6%    6:   �� *	IdType1+6X     5#      $ Цена��6%    63   �� *Price+6O   5%      �� 5&   
   -   5        	 ��Name$	 	btnGoBack��5&      $��
Назад��5'      $��0��5(      $��34��5)      $	��Top=�5*      $��25(�5+      $��2��6   $��	615,0,0,0q�63   6F   �� 5,   
   $��Название:��6   $��2��5-      $	��Top=�5.      $��2��6(   $��	615,0,0,0q�6<   $��26��6O   �� 5/   
   -   5        
 ��Name$

 Name��5/      $��2��50      $	��Top=�51      $��2��6*   $��
615,26,0,0q�6>   $��26��6R   $��2��6^   �� 52   
   $��Вид изделия:��6   $��3��53      $	��Top=�54      $��2��6(   $��	615,0,0,0q�6<   $��26��6O   �� 55   
   -   5         ��Name$ TypeArticles��55      $��3��56      $	��Top=�57      $��2��6*   $��
615,26,0,0q�6>   $��26��6R   $��2��6^   6o   �� 59   
   $��	Цена:��6   $��4��5:      $	��Top=�5;      $��2��6(   $��	615,0,0,0q�6<   $��26��6O   �� 5<   
   -   5        $
 Price��5<      $��4��5=      $	��Top=�5>      $��2��6*   $��
615,26,0,0q�6>   $��26��6R   $��2��6^   �� 5@   
   -   5        $	 Create��5@      $��Создать��5A      $��52��5B      $��5��5C      $��Center=�5D      $��25(�5E      
������$��2��5G      $��	615,0,0,0q�6%   68   5H      5I      