   M S B A M L   `   `   `  ����F  BRentACarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:RentACarWPF.ModelsRentACarWPF.Models  5   	   5clr-namespace:RentACarWPF.ViewsRentACarWPF.Views  5   	   !    RentACarWPF.Views.NalogView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .a clr-namespace:RentACarWPF.Models     5   	   1localclr-namespace:RentACarWPF.Views     5   	     � Title$  	NalogView��5	   	   $	��450��6   $��480.8��6(    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L    � Icon$, &/RentACarWPF;component/Images/logo.jpg��6q   .��5
      � .+�5   
   �� $��0,2,0,0q�6   $��/Images/background.jpg��6"   $
��Fill=�6B    J� RenderTransformOrigin$ 0.5,0.5&�6Q   $��4��6q   �� 5   
   $��Stara Lozinka��6   $��10(�6(   $��Segoe Print)�66   $
��Left=�6O   $��
96,120,0,0q�6j   $	��Top=�6~   $ 1.533,-1.115&�6�   $��86��6�   $��26��6�   G� 5   
   -   5        $
��Left=�5   �   $��10(�6�   $��Segoe Print)�6�   $��22��6�   $��187,124,0,0q�6
  $	��Top=�6  $	��120��67  &    RentACarWPF.Models.PasswordModel   EncryptedPassword 6   �� *PasswordSecureString+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�67  �� 5   
   $��Nova Lozinka��6   $��10(�6'   $��Segoe Print)�65   $
��Left=�6N   $��
96,167,0,0q�6i   $	��Top=�6}   $ 1.533,-1.115&�6�   $��86��6�   $��26��6�   G� 5   
   -   5        $
��Left=�5   �   $��10(�6�   $��Segoe Print)�6�   $��22��6�   $��187,172,0,0q�6  $	��Top=�6   $	��120��68   6   �� *PasswordSecureString2+$ TwoWay=�$ PropertyChanged=�68  �� 5   
   $��10(�6   $��Segoe Print)�6   $��Sacuvaj��68   
������ 
������  �� 	IsDefault . $
��Left=�6�   $��187,261,0,0q�6�   $	��Top=�6�   $	��120��6   $��34��6  ��6}   �� *PromenaLozinkeCommand+6  �� 5   
   
���   �$��10(�6#   $��Segoe Print)�61   
������ $	��Ime��6c   $
��Left=�6q   $��
101,21,0,0q�6�   $	��Top=�6�   $��24��6�   $��86��6�   $ 0.439,0.333&�6�   �� 5   
   $
��Left=�6   $��10(�6-   $��Segoe Print)�6;   $��24��6T   $��
187,21,0,0q�6`   	 �� TextWrapping$
	 Wrap=�6t   $	��Top=�6�   $	��120��6�   ��6�   �� *K.Ime+$ PropertyChanged=�6�   �� 5   
   
���  ��$��Bottom=�6N   $��8(�6i   $
��Bold"�6v   $��187,0,129.4,359q�6�   ��6   �� *K.ValidationErrors[Ime]+6�   �� 5   
   
���  ��$��Bottom=�6R   $��8(�6m   $
��Bold"�6z   $��187,0,129.4,258q�6�   ��6   �� *K.ValidationErrors[Lozinka]+6�   �� 5   
   
���   �$��10(�6#   $��Segoe Print)�61   
������ $��Prezime��6c   $
��Left=�6u   $��	96,70,0,0q�6�   $	��Top=�6�   $��24��6�   $��86��6�   $ 0.439,0.333&�6�   �� 5   
   $
��Left=�6   $��10(�6-   $��Segoe Print)�6;   $��24��6T   $��
187,70,0,0q�6`   $
	 Wrap=�6t   $	��Top=�6�   $	��120��6�   ��6�   �� *	K.Prezime+$ PropertyChanged=�6�   �� 5   
   
���  ��$��Bottom=�6R   $��8(�6m   $
��Bold"�6z   $��187,0,129.4,310q�6�   ��6   �� *K.ValidationErrors[Prezime]+6�   5      5       