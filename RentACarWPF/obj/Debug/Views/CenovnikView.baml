   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   $    RentACarWPF.Views.CenovnikView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$  CenovnikView��5   	   $	��616��6   $	��765��6+    � 
ResizeMode$ NoResize=�67    � WindowStartupLocation$ CenterScreen=�6M    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6r   .��5	      �  � RowDefinitions 5
   
   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      $	��250 �6   6-   �� 5      $	��250 �6   6-   .+�5   
   �� $��0,2,0.2,-0.6q�6   $ ��/Images/all_background.jpg��6'   $
��Fill=�6K    J� RenderTransformOrigin$ 0.5,0.5&�6Z   $��3��6z   $��4��6�   �� 5   
   $��PREGLED CENOVNIKA��6   $��0��6-   $��0��6:   $��3��6J   $��Center=�6^   $��Center=�6{   $��30(�6�   $��Segoe Print MS)�6�   $
��Bold"�6�   6�   �� 5   
   $��1��6   $��0��6   $��10q�6O   $��Dodaj��6[   $��30(�6k   $��Segoe Print MS)�6y   $
��Bold"�6�   
������ 
������  � Cursor$
 Hand��6�   y�6/   �� *
Vidljivo+��5      �� *DodajCenovnikCommand+6=   �� 5   
   $��1��6   $��1��6   $��10q�6O   $��Izmeni��6[   $��30(�6m   $��Segoe Print MS)�6{   $
��Bold"�6�   
������ 
������ $
 Hand��6�   y�6/   �� *
Vidljivo+��5      �� *IzmeniCenovnikCommand+6>   �� 5   
   $��1��6   $��2��6   $��10q�6P   $��Obrisi��6\   $��30(�6n   $��Segoe Print MS)�6|   $
��Bold"�6�   
������ 
������ $
 Hand��6�   y�60   �� *
Vidljivo+��5      �� *ObrisiCenovnikCommand+6>   &   System.Windows.Controls.DataGrid  5   
   $��3��6   $	��300��6!   $��3��6.   $��15q�6B   
���   �
������    
IsReadOnly . 	   SelectionMode$	 Single=�5       
   AutoGenerateColumns
 .  ��5!      �� *	Cenovnici+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5"      �� *SelektovaniCenovnik+   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Id+6V     5%      $ Dostupan od:��6%   $	 120 6;    6G   �� *DatumPocetka+6j     5&      $ Dostupan do:��6%   $	 120 6;    6G   �� *
DatumKraja+6h     5'      $ Cena po danu:��6%   $	 120 6<    6H   �� *
CenaPoDanu+6i     5(      $ Naziv vozila��6%   $	 120 6;    6G   �� *Vozilo.Model+6j     5)      $ Ukupna cena:��6%   $ * 6;    6E   �� *
UkupnaCena+6f   5+      5,      5-      