   M S B A M L   `   `   `  ����E  ABridgeCrew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BridgeCrew
BridgeCrew  5   	       BridgeCrew.MessagesWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:BridgeCrew     5   	     � Title$  MessagesWindow��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   �� $
��Fill=�6   $��/fondo_mensaje.jpg��6   �� 5   
   $
��From��6   $
��Left=�6   $��105,118,0,0q�6:   $	��Top=�6O   �� 5   
   $��To��6   $
��Left=�6   $��673,124,0,0q�68   $	��Top=�6M    J� RenderTransformOrigin$ 0.538,1.898&�6e   �� 5   
   -   5         ��Name$ cboFrom��5      $
��Left=�6$   $��
64,159,0,0q�6?   $	��Top=�6S   $	��120��6k   .@�5      �� $��Arrakis��6   �� 5      $��Bela Tegeuse��6   �� 5      $��Caladan��6   �� 5      $��Casa Capitular��6   �� 5      $��Chusuk��6   �� 5      $��	Conexión��6   �� 5      $��Corrin��6   �� 5      $
��Ecaz��6   5      �� 5   
   -   5         ��Name$ txtMsgContent��5      $��Center=�6)   $��0,58,0,0q�6F    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��352��6�   $	��123��6�   6�   �� 5   
   -   5         ��Name$ btnSend��5      $
��Send��6"   $
��Left=�61   $��325,221,0,0q�6L   $	��Top=�6a   $ 0.5,0.5&�6�   $��23��6�   $	��145��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.053Q�6&   T� 5      5      5!      �� 5"   
   -   5        $ cboTo��5"      $
��Left=�6"   $��624,170,0,0q�6=   $	��Top=�6R   $	��120��6j   $ 0.502,0.529&�6�   .@�5#      �� $��Arrakis��6   �� 5$      $��Bela Tegeuse��6   �� 5%      $��Caladan��6   �� 5&      $��Casa Capitular��6   �� 5'      $��Chusuk��6   �� 5(      $��	Conexión��6   �� 5)      $��Corrin��6   �� 5*      $
��Ecaz��6   5+      �� 5,   
   -   5         ��Name$ 	txtStatus��5,      $��Center=�6'   $��	0,290,0,0q�6D   $�� ��6W   $
��Wrap=�6_   $	��Top=�6s   $��31��6�   $	��164��6�   
�������6�   �� 5-   
   -   5        $ btnRead��5-      $
��Read��6"   $��Center=�61   $��	0,354,0,0q�6N   $	��Top=�6a   $��24��6y   $��82��6�   6�   � 5.   
   -   5         �Name$ pbMsgsBackup��5.      $
��Left=�6,   $��10��6G   $��639,396,0,0q�6S   $	��Top=�6h   $	��100��6�   �� 5/   
   -   5        	 ��Name$	 lblmsgBackup��5/      $��Backup��6&   $
��Left=�67   $��660,365,0,0q�6R   $	��Top=�6g   �� 50   
   -	   5        
 ��Name$
 imgFrom��50      $
��Left=�6!   $	��100��6<   $��	74,10,0,0q�6I   $	��Top=�6\   $	��100��6t   �� 51   
   -
   5        $
 imgTo��51      $
��Left=�6   $	��100��6:   $��
639,10,0,0q�6G   $	��Top=�6[   $	��100��6s   52      53      