   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   )    #RentACarWPF.Views.StartKorisnikView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$
  Home��5   	   $	��582��6   $	��764��6#    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6k   .��5	      � .+�5
   
   �  � RowDefinitions 5      �� 5      $	��100 �6    6/   �� 5      $	��150 �6    6/   �� 5      $	��150 �6    6/   �� 5      $	��150 �6    6/   �� 5      $��* �6    6-    � ColumnDefinitions 5      �� 5      $	��150 �6#   61   �� 5      $	��150 �6#   61   �� 5      $	��150 �6#   61   �� 5      $	��150 �6#   61   �� 5      $	��150 �6#   61   �� 5      $��* �6#   6/   .+�5      �� $��0,2,9.8,0.2q�6   $!��/Images/rent_background.jpg��6*   $
��Fill=�6O    J� RenderTransformOrigin$ 0.5,0.5&�6^   $��5��6~   $��5��6�   �� 5      $��/Images/logo.jpg��6   $��2��6.   $��0,0,130.8,145.4q�6B   $��2��6[   6n   �� 5      $��Nalog��6   $��10(�6'   $��Segoe Print MS)�65   $
��Bold"�6Q   
������ 
������ $��4��6�   $��33.04,10,22.36,36q�6�    � Cursor$
 Hand��6�   ��5       �� *ViewNalogCommand+�� 5!      $��Vozila��6   $��10(�6'   $��Segoe Print MS)�65   $
��Bold"�6Q   
������ 
������ $��1��6�   $��33.04,91,16.36,10.4q�6�   $
 Hand��6�   $��4��5"   8   $ 4.31,-4.296&�6H   ��6   �� *ViewVozilaCommand+6H   �� 5#      $��Rezervacije��6   $��10(�6,   $��Segoe Print MS)�6:   $
��Bold"�6V   
������ 
������ $��4��6�   $��2��6�   $��36.04,91.6,16.36,9.8q�6�   $
 Hand��6�   ��5$      �� *ViewRezervacijeCommand+�� 5%      $��Ocene��6   $��10(�6'   $��Segoe Print MS)�65   $
��Bold"�6Q   
������ 
������ $��2��6�   $��26.04,30.6,22.36,69.8q�6�   $
 Hand��6�   $��4��5&   7   ��6   �� *ViewOceneCommand+67   �� 5'      $��Cenovnik��6   $��10(�6)   $��Segoe Print MS)�67   $
��Bold"�6S   
������ 
������ $��4��6�   $��1��6�   $��26.04,10,16.36,96.4q�6�   $
 Hand��6�   $ 0.491,2.734&�5(   :   ��6   �� *ViewCenovnikCommand+6:   5*      5+      5,      