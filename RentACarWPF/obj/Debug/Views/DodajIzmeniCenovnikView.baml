   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   /    )RentACarWPF.Views.DodajIzmeniCenovnikView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$  DodajIzmeniCenovnikView��5   	   $	��541��6)   $	��818��66    � 
ResizeMode$ NoResize=�6B    � WindowStartupLocation$ CenterScreen=�6X    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6}   .��5	      � 
�������$��0,0,0,1q�6   $
��Left=�6/   $	��808��6J    � RowDefinitions 5
   
   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+    � ColumnDefinitions 5   
   �� 5      $	��150 �6   6-   �� 5      $	��250 �6   6-   �� 5      $	��150 �6   6-   �� 5      $	��250 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��0,2,9.8,0.2q�6   $ ��/Images/all_background.jpg��6&   $
��Fill=�6J    J� RenderTransformOrigin$ 0.5,0.5&�6Y   $��5��6y   $��5��6�   �� 5   
   $��0��62   $��0��6?   $��4��6O   $��Center=�6c   $��Center=�6�   $��24(�6�   $��Segoe Print MS)�6�   $
��Bold"�6�   ��6   �� *TitleContent+6�   �� 5   
   $
��Id: ��6   $��1��6    $��0��6-   $��Center=�6=   $��Center=�6Z   $��Segoe Print MS)�6u   $
��Bold"�6�   $��22(�6�   6�   �� 5   
   $��
Datum od: ��6   $��2��6&   $��0��63   $��Center=�6C   $��Center=�6`   $��Segoe Print MS)�6{   $
��Bold"�6�   $��22(�6�   6�   �� 5   
   $��
Datum do: ��6   $��3��6&   $��0��63   $��Center=�6C   $��Center=�6`   $��Segoe Print MS)�6{   $
��Bold"�6�   $��22(�6�   6�   �� 5    
   $��Vozilo: ��6   $��1��6$   $��2��61   $��Center=�6A   $��Center=�6^   $��Segoe Print MS)�6y   $
��Bold"�6�   $��22(�6�   6�   �� 5!   
   $��Cena po danu: ��6   $��2��6*   $��2��67   $��Center=�6G   $��Center=�6d   $��Segoe Print MS)�6   $
��Bold"�6�   $��22(�6�   $��2��6�   $��0,30,243,30q�6�   $	��157��6�   6�   �� 5#   
   $	��200��6   $��50��6   $��2��6H   $��10 0 0 0q�6U   $��3��6g   $
��Left=�6w   $��Center=�6�   $��22(�6�   ��6*   �� *C.CenaPoDanu+6�   �� 5$   
   
���  ��$��2��6U   $��3��6b   $��Bottom=�6r   $��14(�6�   $
��Bold"�6�   ��6   �� * C.ValidationErrors[CenaPoDanu]+6�   �� 5&   
   $��Segoe Print MS)�6   $
��Bold"�6/   $	��200��6B   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6O   $��50��6�   $��1��6�   $��9.6,20,0,30q�6�   $��3��6�   $
��Left=�6�   $��Center=�6  $��22(�62  ��6t   �� *Vozila+ �� SelectedItem 6�   �� *SelektovanoVozilo+��5'      �� 5(      .R�5)      �� ��5*      `� 5+      	 �� StringFormat$	 {0} {1}��6+   .1�5,   "   �� 
 �� Path$
 Marka�6*   �� 5-   "   $
 Model�6*   5.      50      51      53      �� 55   
   
���  ��$��1��6B   $��3��6O   $��Bottom=�6_   $��14(�6z   $
��Bold"�6�   ��6   �� *VozilaError+6�   �� 57   
   $	��200��6   $��50��6   $��1��6e   $��10 0 0 0q�6r   $��1��6�   $
��Left=�6�   $��Center=�6�   $��22(�6�   ��6*   �� *C.Id+{�6@   �� *TextBoxEnabled+6�   �� 58   
   
���  ��$��1��6M   $��1��6Z   $��Bottom=�6j   $��14(�6�   $
��Bold"�6�   ��6   �� *C.ValidationErrors[Id]+6�   �� 59   
   
���  ��$��1��6@   $��1��6M   $��Bottom=�6]   $��14(�6x   $
��Bold"�6�   ��6   �� *	IdPostoji+6�   (  "System.Windows.Controls.DatePicker  5;   
   $��2��6   $��25��6#   $��9.6,41,30,34q�6W   $��1��6m      SelectedDate 6/   �� *C.DatumPocetka+6m   �� 5<   
   
���  ��$��2��6W   $��1��6d   $��Bottom=�6t   $��14(�6�   $
��Bold"�6�   ��6   �� *" C.ValidationErrors[DatumPocetka]+6�     5>   
   $��3��6   $��25��6#   $��9.6,41,30,34q�6U   $��1��6k    6/   �� *C.DatumKraja+6k   �� 5?   
   
���  ��$��3��6U   $��1��6b   $��Bottom=�6r   $��14(�6�   $
��Bold"�6�   ��6   �� * C.ValidationErrors[DatumKraja]+6�   �� 5B   
    � Cursor$
 Hand��6   $��4��6p   $��0��6}   $��4��6�   $��Center=�6�   $��Center=�6�   $��30(�6�   $��Segoe Print MS)�6�   $
��Bold"�6  
������ 
������ $	��150��6I  $��60��6U  ��6   �� *ButtonContent+��6A   �� *DodajIzmeniCenovnikCommand+6c  �� 5C   
   
��� � �$��4��6@   $��2��6M   $��0��6a   $��Bottom=�6q   $��Center=�6�   $��16(�6�   $
��Bold"�6�   ��6   �� *	Uspesno+6�   5E      5F      