   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   &     RentACarWPF.Views.OsiguranjaView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$  PregledOsiguranja��5   	   $	��550��6#   $	��523��60    � 
ResizeMode$ NoResize=�6<    � WindowStartupLocation$ CenterScreen=�6R    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6w   .��5	      � $��	0,0,0,-55q�6    � RowDefinitions 5
   
   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      $	��250 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��0,2,0.2,-0.2q�6   $ ��/Images/all_background.jpg��6'   $
��Fill=�6K    J� RenderTransformOrigin$ 0.5,0.5&�6Z   $��3��6z   $��4��6�   �� 5   
   $��Segoe Print MS)�6   $��PREGLED OSIGURANJA��61   $��0��6K   $��0��6X   $��3��6h   $��Center=�6|   $��Center=�6�   $��30(�6�   $
��Bold"�6�   6�   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6a   $��0��6n   $��10q�6~   $��Dodaj��6�   $��30(�6�   $
��Bold"�6�    � Cursor$
 Hand��6�   ��5      �� *DodajOsiguranjeCommand+6?   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6a   $��1��6n   $��10q�6~   $��Izmeni��6�   $��30(�6�   $
��Bold"�6�   $
 Hand��6�   ��5      �� *IzmeniOsiguranjeCommand+6@   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��2��6a   $��0��6n   $��10q�6~   $��Obrisi��6�   $��30(�6�   $
��Bold"�6�   $
 Hand��6�   ��5      �� *ObrisiOsiguranjeCommand+6@   &   System.Windows.Controls.DataGrid  5   
   $��3��6   $	��300��6    $��3��6-   $��15q�6A   
���   �
������    
IsReadOnly . 	   SelectionMode$	 Single=�5      
   AutoGenerateColumns
 .  ��5       �� *
Osiguranja+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5!      �� *SelektovanoOsiguranje+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Id+6U     5$      $ Tip osiguranja��6%   $	 120 6=    6I   �� *Tip_osiguranja+6n     5%      $ Broj polise��6%   $ * 6:    6D   �� *Broj_polise+6f   5'      5(      5)      