   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   7 clr-namespace:RentACarWPF.ModelsRentACarWPF.Models  5   	   %    RentACarWPF.Views.LogovanjeView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RentACarWPF.Views     5   	   .a clr-namespace:RentACarWPF.Models     5   	     � Title$  LogovanjeWindow��5	   	   $	��450��6!   $��480.8��6.    � 
ResizeMode$ NoResize=�6<    � WindowStartupLocation$ CenterScreen=�6R    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6w   .��5
      � .+�5   
   �� $��0,10,0.4,-8q�6   $��/Images/background.jpg��6&   $
��Fill=�6F    J� RenderTransformOrigin$ 0.5,0.5&�6U   �� 5   
   
���   �$��10(�6#   $��Segoe Print)�61   
������ $��Korisnicko ime��6c   $
��Left=�6|   $��	89,78,0,0q�6�   $	��Top=�6�   $��24��6�   $��91��6�   $ 0.439,0.333&�6�   �� 5   
   $
��Left=�6   $��10(�6-   $��Segoe Print)�6;   $��24��6T   $��
185,78,0,0q�6`    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��101��6�   $ 1.519,-0.062&�6�   ��6�   �� *KorisnickoIme+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   
���  ��$��Bottom=�6?   $��8(�6Z   $
��Bold"�6g   $��185,0,163.4,297q�6y   $��16��6�   ��6   �� *
ProveraK+6�   �� 5   
   $��Lozinka��6   
���   �$��10(�65   $��Segoe Print)�6C   $
��Left=�6\   $��
89,125,0,0q�6w   $	��Top=�6�   $ 1.533,-1.115&�6�   $��66��6�   $��25��6�   G� 5   
   -   5        $
��Left=�5   �   $��10(�6�   $��Segoe Print)�6�   $��22��6�   $��185,128,0,0q�6
  $	��Top=�6  $	��101��67  $ 0.818,-3.232&�6C  &    RentACarWPF.Models.PasswordModel   EncryptedPassword 6   �� *PasswordSecureString+ �� Mode$ TwoWay=�$ PropertyChanged=�6C  �� 5   
   
���  ��$��Bottom=�6?   $��8(�6Z   $
��Bold"�6g   $��185,0,163.4,245q�6y   $��15��6�   ��6   �� *
ProveraL+6�   �� 5   
   -   5        $��10(�5      $��	Uloguj se��6   $��Segoe Print)�63   
������ 
������ 	 �� 	IsDefault	 . $
��Left=�6�   $��185,187,0,0q�6�   $	��Top=�6�   $	��101��6�   $��42��6	  ��6   �� *LogovanjeCommand+6  �� 5   
   $��10(�6   $��Registracija��6    $��Segoe Print)�67   
������ 
������ 	 . $
��Left=�6�   $��
24,348,0,0q�6�   $	��Top=�6�   $��74��6  $��42��6  ��6�   �� *RegistracijaCommand+6  �� 5   
   $��Jos uvek nemate nalog?��6   
���   �$��10(�6D   $��Segoe Print)�6R   $
��Left=�6k   $��
10,306,0,0q�6�   $	��Top=�6�   $ 1.533,-1.115&�6�   $	��153��6�   $��42��6�   �� 5   
   
���   �$��16(�6#   $��Segoe Print MS)�61   
������ $��		Welcome!��6f   $
��Left=�6~   $��	10,10,0,0q�6�   $	��Top=�6�   $��36��6�   $	��223��6�   $ 0.439,0.333&�6�   5      5      