   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   -    'RentACarWPF.Views.DodajIzmeniVoziloView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$  DodajNovoVozilo��5   	   $	��551��6!   $	��808��6.    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6P    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6u   .��5	      � 
�������$	��511��6   $	��Top=�6+   $��	0,0,1.6,0q�6C    � RowDefinitions 5
   
   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+    � ColumnDefinitions 5   
   �� 5      $	��150 �6   6-   �� 5      $	��250 �6   6-   �� 5      $	��150 �6   6-   �� 5      $	��250 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��0,2,3,89q�6   $ ��/Images/all_background.jpg��6#   $
��Fill=�6G    J� RenderTransformOrigin$ 0.5,0.5&�6V   $��4��6v   $��6��6�   �� 5   
   $��Segoe Print MS)�6   $��0��6P   $��0��6]   $��4��6m   $��Center=�6�   $��Center=�6�   $��24(�6�   $
��Bold"�6�   ��62   �� *TitleContent+6�   �� 5   
   $��Segoe Print MS)�6   $
��Bold"�61   $
��Id: ��6C   $��1��6O   $��0��6\   $��Center=�6l   $��Center=�6�   $��22(�6�   6�   �� 5   
   $��Segoe Print MS)�6   $
��Bold"�61   $��Marka: ��6C   $��2��6R   $��0��6_   $��Center=�6o   $��Center=�6�   $��22(�6�   6�   �� 5   
   $��Segoe Print MS)�6   $
��Bold"�61   $��Model: ��6C   $��3��6R   $��0��6_   $��Center=�6o   $��Center=�6�   $��22(�6�   6�   �� 5   
   $��Segoe Print MS)�6   $
��Bold"�61   $��Tip: ��6C   $��1��6P   $��2��6]   $��Center=�6m   $��Center=�6�   $��22(�6�   6�   �� 5    
   $��Segoe Print MS)�6   $
��Bold"�61   $��
Filijala: ��6C   $��2��6U   $��2��6b   $��Center=�6r   $��Center=�6�   $��22(�6�   6�   �� 5"   
   $��Segoe Print MS)�6   $
��Bold"�6/   $	��200��6A   $��50��6�   $��1��6�   $��10 0 0 0q�6�   $��1��6�   $
��Left=�6�   $��Center=�6�   $��22(�6�   ��6M   �� *V.Id+{�6d   �� *TextBoxEnabled+6
  �� 5#   
   
���  ��$��1��6M   $��1��6Z   $��Bottom=�6j   $��14(�6�   $
��Bold"�6�   ��6   �� *V.ValidationErrors[Id]+6�   �� 5$   
   
���  ��$��1��6@   $��1��6M   $��Bottom=�6]   $��14(�6x   $
��Bold"�6�   ��6   �� *	IdPostoji+6�   �� 5&   
   $��Segoe Print MS)�6   $
��Bold"�6/   $	��200��6A   $��50��6f   $��2��6r   $��10 0 0 0q�6   $��1��6�   $
��Left=�6�   $��Center=�6�   $��22(�6�   ��6M   �� *	V.Marka+6�   �� 5'   
   
���  ��$��2��6P   $��1��6]   $��Bottom=�6m   $��14(�6�   $
��Bold"�6�   ��6   �� *V.ValidationErrors[Marka]+6�   �� 5)   
   $��Segoe Print MS)�6   $
��Bold"�6/   $	��200��6A   $��50��6f   $��3��6r   $��10 0 0 0q�6   $��1��6�   $
��Left=�6�   $��Center=�6�   $��22(�6�   ��6M   �� *	V.Model+6�   �� 5*   
   
���  ��$��3��6P   $��1��6]   $��Bottom=�6m   $��14(�6�   $
��Bold"�6�   ��6   �� *V.ValidationErrors[Model]+6�   �� 5,   
   $��Segoe Print MS)�6   $
��Bold"�60   $	��200��6C   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6P   $��50��6u   $��1��6�   $��10 0 0 0q�6�   $��3��6�   $
��Left=�6�   $��Center=�6  $��22(�6,  ��6�   �� *Tipovi+ �� SelectedItem 6�   �� *SelektovanTip+6<  �� 5-   
   
���  ��$��1��6?   $��3��6L   $��Bottom=�6\   $��14(�6w   $
��Bold"�6�   ��6   �� *
TipError+6�   �� 5/   
   $��Segoe Print MS)�6   $
��Bold"�60   $	��200��6B   $
 TrueY�6O   $��50��6t   $��2��6�   	 �� DisplayMemberPath$	 Naziv��6�   $��10 0 0 0q�6�   $��3��6  $
��Left=�6  $��Center=�62  $��22(�6M  ��6�   �� *
Filijale+ 6�   �� *SelektovanaFilijala+6]  �� 50   
   
���  ��$��2��6D   $��3��6Q   $��Bottom=�6a   $��14(�6|   $
��Bold"�6�   ��6   �� *FilijalaError+6�   �� 52   
   $��Segoe Print MS)�6   $
��Bold"�6-   
������ 
������ 
 � Cursor$

 Hand��6s   $��4��6�   $��0��6�   $��4��6�   $��Center=�6  $��Center=�6  $��24(�69  $	��150��6G  $��60��6S  ��6�   �� *ButtonContent+��6�   �� *DodajIzmeniVoziloCommand+6a  �� 53   
   
��� � �$��4��6@   $��4��6M   $��0��6a   $��Bottom=�6q   $��Center=�6�   $��16(�6�   $
��Bold"�6�   ��6   �� *	Uspesno+6�   54      55      