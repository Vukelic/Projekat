   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   $    RentACarWPF.Views.FilijaleView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$  PregledFilijala��5   	   $��572.985��6!   $	��765��62    � 
ResizeMode$ NoResize=�6?    � WindowStartupLocation$ CenterScreen=�6U    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6z   .��5	      � $��	0,0,0,-55q�6    � RowDefinitions 5
   
   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      $	��250 �6   6-   �� 5      $	��250 �6   6-   .+�5   
   �� $��0,2,-6.4,58.4q�6   $ ��/Images/all_background.jpg��6(   $
��Fill=�6L    J� RenderTransformOrigin$ 0.5,0.5&�6[   $��3��6{   $��4��6�   �� 5   
   $��Segoe Print MS)�6   $��PREGLED FILIJALA��61   $��0��6I   $��0��6V   $��3��6f   $��Center=�6z   $��Center=�6�   $��30(�6�   $
��Bold"�6�   6�   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6b   $��0��6o   $��10q�6   $��Dodaj��6�   $��30(�6�   $
��Bold"�6�    � Cursor$
 Hand��6�   ��5      �� *DodajFilijaluCommand+6=   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6a   $��1��6n   $��10q�6~   $��Izmeni��6�   $��30(�6�   $
��Bold"�6�   $
 Hand��6�   ��5      �� *IzmeniFilijaluCommand+6>   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6`   $��2��6m   $��10q�6}   $��Obrisi��6�   $��30(�6�   $
��Bold"�6�   $
 Hand��6�   ��5      �� *ObrisiFilijaluCommand+6>   &   System.Windows.Controls.DataGrid  5   
   $��3��6   $	��300��6    $��3��6-   $��10,0,19.6,58.4q�6A   
���   �
������    
IsReadOnly . 	   SelectionMode$	 Single=�5      
   AutoGenerateColumns
 .  ��5       �� *
Filijale+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5!      �� *SelektovanaFilijala+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Id+6U     5$      $ Naziv��6%   $	 120 64    6@   �� *Naziv+6\     5%      $ Broj telefona��6%   $	 120 6<    6H   �� *BrojTelefona+6k     5&      $ Adresa��6%   $	 120 65    6A   �� *Adresa+6^     5'      $
 Grad��6%   $	 120 63    6?   �� *
Grad.Naziv+6`     5(      $ Drzava��6%   $ * 65    6?   �� *Grad.Drzava+6a   5*      5+      5,      