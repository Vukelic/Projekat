   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   !    RentACarWPF.Views.OceneView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$  PregledOcena��5   	   $	��550��6   $	��518��6+    � 
ResizeMode$ NoResize=�67    � WindowStartupLocation$ CenterScreen=�6M    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6r   .��5	      � $��	0,0,0,-75q�6    � RowDefinitions 5
   
   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      $	��250 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��0,2,0.2,-0.2q�6   $ ��/Images/all_background.jpg��6'   $
��Fill=�6K    J� RenderTransformOrigin$ 0.5,0.5&�6Z   $��3��6z   $��4��6�   �� 5   
   $��Segoe Print MS)�6   $��PREGLED OCENA��62   $��0��6G   $��0��6T   $��3��6d   $��Center=�6x   $��Center=�6�   $��30(�6�   $
��Bold"�6�   6�   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6a   $��0��6n   $��10q�6~   $��Dodaj��6�   $��30(�6�   $
��Bold"�6�    � Cursor$
 Hand��6�   ��5      �� *DodajOcenuCommand+6:   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6�   $��1��6�   $��10q�6�   $��Izmeni��6�   $��30(�6�   $
��Bold"�6�   $
 Hand��6�   y�6-   �� *
Vidljivo+��5      �� *IzmeniOcenuCommand+6;   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��2��6�   $��0��6�   $��10q�6�   $��Obrisi��6�   $��30(�6�   $
��Bold"�6�   $
 Hand��6�   y�6.   �� *
Vidljivo+��5      �� *ObrisiOcenuCommand+6;   &   System.Windows.Controls.DataGrid  5   
   $��3��6   $	��300��6!   $��3��6.   $��15q�6B   
���   �
������    
IsReadOnly . 	   SelectionMode$	 Single=�5      
   AutoGenerateColumns
 .  ��5       �� *Ocene+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5!      �� *SelektovanaOcena+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Id+6U     5$      $ Ocena��6%   $ 60 64    6?   �� *
Vrednost+6^     5%      $ Vozilo��6%   $ 80 65    6@   �� *Vozilo.Marka+6c     5&      $  ��6%   $ 80 6/    6:   �� *Vozilo.Model+6]     5'      $ Klijent��6%   $ 80 66    6A   �� *Klijent.Ime+6c     5(      $  ��6%   $ * 6/    69   �� *Klijent.Prezime+6_   5*      5+      5,      