   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   $    RentACarWPF.Views.KlijentiView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$  PregledKlijenata��5   	   $	��550��6"   $	��513��6/    � 
ResizeMode$ NoResize=�6<    � WindowStartupLocation$ CenterScreen=�6R    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6w   .��5	      � $��0,0,3.4,-0.2q�6    � RowDefinitions 5
   
   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      $	��250 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��0,2,0.2,-0.2q�6   $ ��/Images/all_background.jpg��6'   $
��Fill=�6K    J� RenderTransformOrigin$ 0.5,0.5&�6Z   $��3��6z   $��4��6�   �� 5   
   $��Segoe Print MS)�6   $��PREGLED KLIJENATA��60   $��0��6I   $��0��6V   $��3��6f   $��Center=�6z   $��Center=�6�   $��30(�6�   $
��Bold"�6�   6�   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6a   $��0��6n   $��115,10,155,10q�6~   $��Obrisi��6�   $��30(�6�   $
��Bold"�6�    � Cursor$
 Hand��6�   $��2��5   <   ��6   �� *ObrisiKlijentaCommand+6R   &   System.Windows.Controls.DataGrid  5   
   $��3��6   $��2��6    $��15,15,10,21q�64   
���   �
������    
IsReadOnly . 	   SelectionMode$	 Single=�5      
   AutoGenerateColumns
 .  ��5      �� *
Klijenti+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5      �� *SelektovaniKlijent+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$
 Jmbg��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Jmbg+6Z     5"      $	 Ime��6%   $	 100 62    6?   �� *Ime+6Y     5#      $ Prezime��6%   $	 100 66    6C   �� *	Prezime+6a     5$      $ Korisnicko ime��6%   $	 100 6=    6J   �� *KorisnickoIme+6n     5%      $ Uloga��6%   $	 100 64    6A   �� *Uloga+6]   5'      5(      5)      