   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   1    +RentACarWPF.Views.DodajIzmeniOsiguranjeView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$  DodajNovoOsiguranje��5   	   $	��552��6%   $	��474��62    � 
ResizeMode$ NoResize=�6?    � WindowStartupLocation$ CenterScreen=�6U    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6z   .��5	      � 
�������$	��516��6   $	��Top=�6+   $��	0,0,0.2,0q�6C    � RowDefinitions 5
   
   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+    � ColumnDefinitions 5   
   �� 5      $	��150 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��0,2,10.2,-12q�6   $ ��/Images/all_background.jpg��6'   $
��Fill=�6K    J� RenderTransformOrigin$ 0.5,0.5&�6Z   $��2��6z   $��5��6�   �� 5   
   $��Segoe Print MS)�6   $��0��6N   $��0��6[   $��2��6k   $��Center=�6   $��Center=�6�   $��24(�6�   $
��Bold"�6�   ��60   �� *TitleContent+6�   �� 5   
   $��Segoe Print MS)�6   $
��Bold"�60   $
��Id: ��6B   $��1��6N   $��0��6[   $��Center=�6k   $��Center=�6�   $��22(�6�   6�   �� 5   
   $��Segoe Print MS)�6   $
��Bold"�60   $��Br polise: ��6B   $��2��6U   $��0��6b   $��Center=�6r   $��Center=�6�   $��22(�6�   6�   �� 5   
   $��Segoe Print MS)�6   $
��Bold"�60   $��Vrsta:��6B   $��3��6P   $��0��6]   $��Center=�6m   $��Center=�6�   $��22(�6�   6�   �� 5   
   $��Segoe Print MS)�6   $
��Bold"�6.   $	��200��6@   $��50��6�   $��1��6�   $��10 0 0 0q�6�   $��1��6�   $
��Left=�6�   $��Center=�6�   $��22(�6�   {�6L   �� *TextBoxEnabled+��6q   �� *O.Id+6  �� 5   
   
���  ��$��1��6M   $��1��6Z   $��Bottom=�6j   $��14(�6�   $
��Bold"�6�   ��6   �� *O.ValidationErrors[Id]+6�   �� 5   
   
���  ��$��1��6@   $��1��6M   $��Bottom=�6]   $��14(�6x   $
��Bold"�6�   ��6   �� *	IdPostoji+6�   �� 5    
   $��Segoe Print MS)�6   $
��Bold"�6.   $	��200��6A   $��50��6l   $��2��6x   $��10 0 0 0q�6�   $��1��6�   $
��Left=�6�   $��Center=�6�   $��22(�6�   ��6M   �� *O.Broj_polise+6�   �� 5!   
   
���  ��$��2��6V   $��1��6c   $��Bottom=�6s   $��14(�6�   $
��Bold"�6�   ��6   �� *!O.ValidationErrors[Broj_polise]+6�   �� 5#   
   $��Segoe Print MS)�6   $
��Bold"�6/   $	��200��6A   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6N   $��50��6�   $��3��6�   $��10 0 0 0q�6�   $��1��6�   $
��Left=�6�   $��Center=�6  $��22(�6*  ��6s   �� *Tipovi+ �� SelectedItem 6�   �� *SelektovanTip+6:  �� 5$   
   
���  ��$��3��6A   $��1��6N   $��Bottom=�6^   $��14(�6y   $
��Bold"�6�   ��6   �� *
VrstaError+6�   �� 5&   
   $��Segoe Print MS)�6   $
��Bold"�6-   
������ 
������ 	 � Cursor$
	 Hand��6t   $��4��6�   $��0��6�   $��2��6�   $��Center=�6  $��Center=�6#  $��24(�6>  $	��150��6L  $��60��6X  ��6�   �� *ButtonContent+��6�   �� *DodajIzmeniOsiguranjeCommand+6f  �� 5'   
   
��� � �$��4��6@   $��2��6M   $��0��6a   $��Bottom=�6q   $��Center=�6�   $��16(�6�   $
��Bold"�6�   ��6   �� *	Uspesno+6�   5(      5)      