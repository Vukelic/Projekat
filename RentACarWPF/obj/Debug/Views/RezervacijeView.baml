   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   '    !RentACarWPF.Views.RezervacijeView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$  PregledRezervacija��5   	   $��611.2��6$   $��913.1��63    � 
ResizeMode$ NoResize=�6A    � WindowStartupLocation$ CenterScreen=�6W    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6|   .��5	      � $��	0,0,0,-85q�6    � RowDefinitions 5
   
   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      $	��250 �6   6-   �� 5      $	��250 �6   6-   .+�5   
   �� $��0,2,-152.4,86.4q�6   $ ��/Images/all_background.jpg��6*   $
��Fill=�6N    J� RenderTransformOrigin$ 0.5,0.5&�6]   $��3��6}   $��4��6�   �� 5   
   $��Segoe Print MS)�6   $��PREGLED REZERVACIJA��62   $��0��6M   $��0��6Z   $��3��6j   $��Center=�6~   $��Center=�6�   $��30(�6�   $
��Bold"�6�   6�   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6a   $��0��6n   $��10q�6~   $��Dodaj��6�   $��30(�6�   $
��Bold"�6�    � Cursor$
 Hand��6�   ��5      �� *DodajRezervacijuCommand+6D   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6�   $��1��6�   $��10q�6�   $��Izmeni��6�   $��30(�6�   $
��Bold"�6�   $
 Hand��6�   y�6-   �� *
Vidljivo+��5      �� *IzmeniRezervacijuCommand+6A   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6�   $��2��6�   $��10q�6�   $��Obrisi��6�   $��30(�6�   $
��Bold"�6�   $
 Hand��6�   y�6-   �� *
Vidljivo+��5      �� *ObrisiRezervacijuCommand+6A   &   System.Windows.Controls.DataGrid  5   
   $��3��6   $	��300��6!   $��3��6.   $��0,40,-147.4,86.4q�6B   
���   �
������    
IsReadOnly . 	   SelectionMode$	 Single=�5       
   AutoGenerateColumns
 .  ��5!      �� *Rezervacije+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5"      �� *SelektovanaRezervacija+   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Id+6U     5%      $ Datum rezervacije��6%   $	 120 6@    6L   �� *Datum_rezervacije+6t     5&      $ Datum preuzimanja��6%   $	 120 6@    6L   �� *Datum_preuzimanja+6t     5'      $ Datum vracanja��6%   $	 120 6=    6I   �� *Datum_vracanja+6n     5(      $ Vozilo��6%   $	 100 65    6A   �� *Vozilo.Model+6d     5)      $ 
Osiguranje��6%   $	 100 69    6E   �� *Osiguranje.Broj_polise+6r     5*      $ Klijent��6%   $	 100 66    6B   �� *Klijent.Ime+6d     5+      $ Agent��6%   $	 100 64    6@   �� *	Agent.Ime+6`     5,      $ Ukupna cena:��6%   $ * 6;    6E   �� *CenaRezervacije+6k   5.      5/      50      