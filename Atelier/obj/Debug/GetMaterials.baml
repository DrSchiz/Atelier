   M S B A M L   `   `   `  ����B  >Atelier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AtelierAtelier  5   	       Atelier.GetMaterials   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Atelier     5   	     � Title$  GetMaterials��5   	   $	��450��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      $
��0.3* �6   6.    � RowDefinitions 5   
   �� 5      $
��0.3* �6   6,   �� 5      6   �� 5      $
��0.3* �6   6,   �� 5      $
��0.3* �6   6,   .+�5   
   �� $��Материалы:��6   $��0��5      $��0��5      $��20(�5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgMaterials��5         CanUserAddRows .  $��0��5      $��1��5      $��3��5         AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$# Номер материала��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *НомерМатериала+6c     5       $ Количество��6%    69   �� * Количество10мРул+6`     5!      $ Цена/шт.��6%    67   �� *ЦенаШт+6T     5"      $ Вид материала��6%    6<   �� *ВидМатериала+6_     5#      $ Поставщик��6%    68   �� *Поставщик+6X   5%      �� 5&   
   -   5        	 ��Name$	 	btnGoBack��5&      $��
Назад��5'      $��1��5(      $��0��5)      $
��40px��5*      $	��Top=�5+      $��25(�5,      6   �� 5-   
   $��Количество:��6   $��40��5.      $��1��5/      $��2��50      $	��Top=�51      �� 52   
   -   5        
 ��Name$
 Amount��52      $��40��53      $��1��54      $��2��55      $��Bottom=�56      �� 57   
   -   5        $		 Buy��57      $��Купить��58      $��40��59      $��1��5:      $��3��5;      $��Bottom=�5<      $��25(�5=      
�������{�.  5?   #   5@      5A      