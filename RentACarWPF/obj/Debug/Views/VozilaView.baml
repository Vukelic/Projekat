   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   "    RentACarWPF.Views.VozilaView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$  PregledVozila��5   	   $	��550��6   $	��558��6,    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6s   .��5	      �  � RowDefinitions 5
   
   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      $	��250 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��
0,2,0,-0.2q�6   $ ��/Images/all_background.jpg��6%   $
��Fill=�6I    J� RenderTransformOrigin$ 0.5,0.5&�6X   $��3��6x   $��4��6�   �� 5   
   $��Segoe Print MS)�6   $��PREGLED VOZILA��62   $��0��6H   $��0��6U   $��3��6e   $��Center=�6y   $��Center=�6�   $��30(�6�   $
��Bold"�6�   6�   �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6�   $��0��6�   $��10q�6�   $��Dodaj��6�   $��30(�6�   $
��Bold"�6�    � Cursor$
 Hand��6  y�6.   �� *
Vidljivo+��6�   �� *DodajVoziloCommand+6  �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��1��6�   $��1��6�   $��10q�6�   $��Izmeni��6�   $��30(�6�   $
��Bold"�6�   $
 Hand��6  y�6.   �� *
Vidljivo+��6�   �� *IzmeniVoziloCommand+6  �� 5   
   $��Segoe Print MS)�6   
������ 
������ $��2��6�   $��0��6�   $��10q�6�   $��Obrisi��6�   $��30(�6�   $
��Bold"�6�   $
 Hand��6  y�6.   �� *
Vidljivo+��6�   �� *ObrisiVoziloCommand+6  &   System.Windows.Controls.DataGrid  5   
   $��3��6   $��3��6    $��15q�64   
���   �
������    
IsReadOnly . 	   SelectionMode$	 Single=�5      
   AutoGenerateColumns
 .  ��5      �� *Vozila+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5      �� *SelektovanoVozilo+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Id+6U     5!      $ Marka��6%   $ 80 64    6?   �� *Marka+6[     5"      $ Model��6%   $ 80 64    6?   �� *Model+6[     5#      $ Filijala��6%   $ 80 67    6B   �� *Filijala.Naziv+6g     5$      $	 Tip��6%   $ 80 62    6=   �� *
Tip_vozila+6^     5%      $ Prosecna ocena:��6%   $ * 6>    6H   �� *ProsecnaOcena+6l   5'      5(      5)      