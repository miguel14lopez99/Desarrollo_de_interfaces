   M S B A M L   `   `   `  ����E  ALITTLE_ERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:LITTLE_ERP
LITTLE_ERP  5   	       LITTLE_ERP.TabsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:LITTLE_ERP     5   	     � Title$  
TabsWindow��5   	   $	��602��6   $	��924��6)    � 	Resources 5	         ComboTemplate �� Orientation �� Path  ComboTemplateForm  ComboTemplateIngredient��%w  &	        &	 q     &	 �     �� 5
   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� ��6   �� $
 name�5      5      �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� ��6   �� $ frmDesc�5      5      �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� ��6   �� $ ingDesc�5      5      5      .��5      � $��Stretch=�6   $
��auto��6)   $��0,0,0,0q�66   .+�5   
   �� $
��auto��6   $��10,115,10,10q�6#   $
��auto��69    �� TabStripPlacement$
 Left=�6F   $��Stretch=�6_   .@�5      �� -   5         ��Name$ tabHome��5      $
��HOME��6'   $��16(�65   .��5      � ���	#FFE5E5E56   5      �� 5      -   5        $ 
tabProfile��5      $��PROFILE��6*   $��16(�6;   .��5       � .+�5!      �� $��Previous Password��6   $
��Left=�68   $��	43,43,0,0q�6S   $	��Top=�6f   �� 5"      $��New Password��6   $
��Left=�63   $��	71,74,0,0q�6N   $	��Top=�6a   �� 5#      $��Repeat Password��6   $
��Left=�66   $��
54,105,0,0q�6Q   $	��Top=�6e   G� 5$      -   5         G�Name$ pwdPrevious��5$   "   $��208,45,453,0q�67   $	��Top=�6M   G� 5%      -   5        $ pwdNew��5%   "   $��208,76,453,0q�62   $	��Top=�6H   G� 5&      -   5        $ 	pwdRepeat��5&   "   $��208,107,453,0q�65   $	��Top=�6L   �� 5'      $��ROLES��6   $��43,158,258,46q�6.   .��5(      �� -   5         ��Name$ LblRoles��5(       $
��rol1��62   $
��Left=�6A   $��	10,10,0,0q�6\   $	��Top=�6o   5)      �� 5*      $��Right=�6   $	��160��68   $��	0,48,40,0q�6D    J� OpacityMask �	#FFFBFBFB$	��160��6o   $	��Top=�6|   $��profilePhoto.jpg��6�   �� 5+      -   5        $ lblUsername��5+      $��nombre usuario��61   $��Right=�6J   $��
0,212,58,0q�6f   	 J� RenderTransformOrigin$	 0.386,-0.065&�6z   $��31��6�   $	��Top=�6�   �� 5,      -   5        
 ��Name$
 btnChangePwd��5,      $��Change password��63   $��
0,49,263,0q�6M   $��77��6|   $	��Top=�6�   $��Right=�6�   $	��165��6�   5-      5.      �� 5/      -	   5        $ tabUsers��5/      $��USERS��6(   $��16(�67   .��50      � .+�51      &   System.Windows.Controls.DataGrid  -
   5          Name$ dgrUsers��51      $��10,82,10,10q�61   $��Stretch=�6F   $
��auto��6d      AutoGenerateColumns .     
IsReadOnly .    Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ Id User��6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *idUser+6L     54      $
 Name��6J    61   �� *name+6J   56      �� 57      -   5        $
 btnAdd��57      $	��New��6-   $
��Left=�6;   $��	10,25,0,0q�6V   $	��Top=�6i   $��84��6�   $��42��6�   $��14(�6�   6�   �� 58      -   5        $
 	btnModify��58      $��Modify��60   $
��Left=�6A   $��
115,25,0,0q�6\   $	��Top=�6p   $��84��6�   $��42��6�   $��14(�6�   6�   �� 59      -   5        $
 	btnDelete��59      $��Delete��60   $
��Left=�6A   $��
221,25,0,0q�6\   $	��Top=�6p   $��83��6�   $��42��6�   $��14(�6�   6�   �� 5:      $��Search:��6   $	��Top=�6.   $��
317,39,0,0q�6F   $
��Left=�6Z   $��57��6u   �� 5;      -   5         ��Name$ txtU_Search��5;      $	��Top=�63   $��376,44,10,0q�6K   6`   5<      5=      �� 5>      -   5        $ tabCustomers��5>      $��	CUSTOMERS��6,   $��16(�6?   .��5?      � .+�5@        -   5        $ dgrCustomers��5@      $��10,120,496,12q�65    .   .  5A      )  #System.Windows.Controls.DataGridRow �� 
TargetType��%E   '        �� 5B      "  6$   .�5C   "   -   5        5D      5E       5F        5G      $	 NIF��6I    61   �� *NIF+6I     5H      $
 Name��6J    61   �� *name+6J     5I      $ Surname��6M    61   �� *	surname+6M   5K      �� 5L      $��Search:��6   $	��Top=�6.   $��	10,10,0,0q�6F   $
��Left=�6Y   $��65��6t   �� 5M      -   5        $ txtCustomerSearch��5M      $	��Top=�69   $��70,15,496,0q�6Q   6f   �� 5N      -   5        $
 btnNewCustomer��5N      $	��New��65   $
��Left=�6C   $	��Top=�6^   $��84��6v   $��42��6�   $��14(�6�   $��	10,64,0,0q�6�   6�   �� 5O      -   5        $
 btnDeleteCustomer��5O      $��Delete��68   $
��Left=�6I   $	��Top=�6d   $��84��6|   $��42��6�   $��14(�6�   $��
103,64,0,0q�6�   6�   �� 5P      $��
0,22,20,23q�6   $��Right=�61   $	��460��6M   $��Stretch=�6Y   $	��390��6u   .+�5Q      �� $	��NIF��6    $��Right=�6.   $��35��6J   $��34��6U    �� Left$ 39��6a   �� 5R      $
��Name��6    $��Right=�6/   $��54��6K   $��34��6V   $ 21��6b   
 �� Top$ 34��6s   �� 5S      $��Surname��6    $��Right=�62   $��75��6N   $��34��6Y   $ 68��6e   �� 5T      $��Address��6    $��Right=�62   $��66��6N   $��34��6Y   $ 4��6e   $	 102��6u   �� 5U      $��Phone��6    $��Right=�60   $��54��6L   $��34��6W   $ 18��6c   $	 136��6t   �� 5V      $��Email��6    $��Right=�60   $��49��6L   $��34��6W   $ 23��6c   $	 170��6t   �� 5W      $��Region��6    $��Right=�61   $��60��6M   $��40��6X   $ 12��6d   $	 209��6u   �� 5X      -   5        $ txtNIF��5X   "   $��25��62    �� TextWrapping$
 Wrap=�6>   $��Right=�6R   $	��372��6n   $ 77��6z   $ 6��6�   �� 5Y      -   5        $ txtName��5Y   "   $��25��63   $
 Wrap=�6?   $��Right=�6S   $	��372��6o   $ 77��6{   $ 40��6�   �� 5Z      -   5        $ 
txtSurname��5Z   "   $��25��66   $
 Wrap=�6B   $��Right=�6V   $	��372��6r   $ 77��6~   $ 76��6�   �� 5[      -   5        $ 
txtAddress��5[   "   $��25��66   $
 Wrap=�6B   $��Right=�6V   $	��372��6r   $ 77��6~   $	 108��6�   �� 5\      -   5        $ txtPhone��5\   "   $��25��64   $
 Wrap=�6@   $��Right=�6T   $	��372��6p   $ 77��6|   $	 142��6�   �� 5]      -   5        $ txtEmail��5]   "   $��25��64   $
 Wrap=�6@   $��Right=�6T   $	��372��6p   $ 77��6|   $	 176��6�   �� 5^      -   5        $ 
txtZipCode��5^   "   $
 Wrap=�66   $��Right=�6o   $	��215��6�   $��25��6�   $ 77��6�   $	 319��6�   �� 5_      $��State��6    $��Right=�60   $��45��6L   $��40��6W   $ 28��6c   $	 244��6t   �� 5`      $
��City��6    $��Right=�6/   $��40��6K   $��40��6V   $ 34��6b   $	 281��6s   �� 5a      $��ZIP code��6    $��Right=�63   $��75��6O   $��40��6Z   $ 2��6f   $	 315��6v   �� 5b      -   5         ��Name$ cmbState��5b   #   $��Right=�65   $	��215��6Q   #��[  6]   $��32��6�   $��Bottom=�6�   $ 77��6�   $	 244��6�   �� 5c      -   5        $ 	cmbRegion��5c   #   $��Right=�66   $	��215��6R   #��[  6^   $��32��6�   $ 77��6�   $	 207��6�   �� 5d      -   5        $ cmbCity��5d   #   $��Right=�64   $	��215��6P   #��[  6\   $��32��6�   $��Bottom=�6�   $ 77��6�   $	 280��6�   �� 5e      -   5        $ 
cmbZipCode��5e   #   $��Right=�67   $	��215��6S   #��[  6_   $��32��6�   $��Bottom=�6�   $ 77��6�   $	 349��6�   �� 5f      -    5        $
 btnSave��5f   !   $
��Save��62   $��Right=�6A   $	��Top=�6]   $	��120��6u   $��65��6�   $��14(�6�   $	 316��6�   $	 265��6�   5g      �� 5h      -!   5        $
 btnFill��5h      $
��Fill��6.   $
��Left=�6=   $	��Top=�6X   $��84��6p   $��42��6{   $��14(�6�   $��
196,64,0,0q�6�   6�   5i      5j      �� 5k      -"   5        $ 
tabProduct��5k      $��PRODUCTS��6*   $��16(�6<   .��5l      � .+�5m        -#   5        $ dgrProducts��5m      $
��auto��64   $
��auto��6B   $��10,121,10,11q�6O    .   .  5n      ��%E   '        �� 5o      "  6$   .�5p   "   -$   5        5q      5r       5s        5t      $ ID��6O    61   �� *	idProduct+6O     5u      $
 Form��6R    61   �� *form.frmDesc+6R     5v      $ 
Ingredient��6X    61   �� *ingredient.ingDesc+6X     5w      $ Amount��6L    61   �� *amount+6L     5x      $ Price��6K    61   �� *price+6K   5z      �� 5{      $��Search:��6   $	��Top=�6.   $��	10,10,0,0q�6F   $
��Left=�6Y   $��65��6t   �� 5|      -%   5        $ txtP_Search��5|      $	��Top=�63   $��70,15,267,0q�6K   6`   �� 5}      -&   5        $
 btnP_New��5}      $	��New��6/   $
��Left=�6=   $	��Top=�6X   $��	10,64,0,0q�6p   $��42��6�   $��84��6�   $��14(�6�   6�   �� 5~      -'   5        $
 btnP_Del��5~      $��Delete��6/   $
��Left=�6@   $	��Top=�6[   $��
103,64,0,0q�6s   $��42��6�   $��84��6�   $��14(�6�   6�   �� 5      $��Form:��6   $��Right=�6,   $	��Top=�6H   $��
0,46,473,0q�6`   �� 5�      -(   5        $ 	cmbP_Form��5�      $	��Top=�62   $��
0,51,281,0q�6J   $��Right=�6^   $	��191��6z   #��[ 6�   �� 5�      $��Ingredient:��6   $��Right=�62   $	��Top=�6N   $��
0,82,473,0q�6f   �� 5�      -)   5        $ cmbP_Ingredient��5�      $	��Top=�68   $��
0,87,281,0q�6P   $��Right=�6d   $	��191��6�   #��[ 6�   �� 5�      $��Price:��6   $��Right=�6-   $	��Top=�6I   $��
0,46,193,0q�6a   �� 5�      -*   5        $ 
txtP_Price��5�      $��Right=�62   $	��Top=�6N   $��	0,51,10,0q�6f   $	��183��6y   �� 5�      -+   5        $
 	btnP_Save��5�      $
��Save��60   $��Right=�6?   $	��Top=�6[   $��	0,10,68,0q�6s   $��31��6�   $��84��6�   $��14(�6�   6�   �� 5�      $��Amount:��6   $��Right=�6.   $	��Top=�6J   $��
0,84,193,0q�6b   �� 5�      -,   5        $ txtP_Amount��5�      $��Right=�63   $	��Top=�6O   $��	0,89,10,0q�6g   $	��183��6z   5�      5�      �� 5�      --   5        $ tabSupliers��5�      $��SUPLIERS��6+   $��16(�6=   .��5�      � .+�5�      �� $��Search:��6   $	��Top=�6.   $��	10,10,0,0q�6F   $
��Left=�6Y   $��65��6t   �� 5�      -.   5        $ txtS_Search��5�      $	��Top=�63   $��70,15,267,0q�6K   6`     5�      -/   5        $ dgrSupliers��5�      $
��auto��64   $
��auto��6B   $��10,55,10,11q�6O    .   .  5�        5�      $ ID��6O    61   �� *	idSuplier+6O     5�      $
 Name��6J    61   �� *name+6J     5�      $ Goods��6K    61   �� *goods+6K   5�      5�      5�      �� 5�      -0   5        $ tabOrder��5�      $��ORDERS��6(   $��16(�68   .��5�      � .+�5�      �� $��Search:��6   $	��Top=�6.   $��	10,10,0,0q�6F   $
��Left=�6Y   $��65��6t   �� 5�      -1   5        $ txtO_Search��5�      $	��Top=�63   $��70,15,267,0q�6K   6`   �� 5�      -2   5        $
 btnO_New��5�      $	��New��6/   $
��Left=�6=   $	��Top=�6X   $��	10,64,0,0q�6p   $��42��6�   $��84��6�   $��14(�6�   6�   �� 5�      -3   5        $
 btnO_Del��5�      $��Delete��6/   $
��Left=�6@   $	��Top=�6[   $��
103,64,0,0q�6s   $��42��6�   $��84��6�   $��14(�6�   6�   �� 5�      -4   5         ��Name$ 	sldStatus��5�       � Maximum$ 40Q�60    �� TickPlacement$ BottomRight=�6=    �� TickFrequency$ 10Q�6Y    �� IsSnapToTickEnabled . $��
313,74,0,0q�6�   $
��Left=�6�   $	��185��6�   $��32��6�   $	��Top=�6�   6�     5�      -5   5        $ 	dgrOrders��5�      $
��auto��62   $
��auto��6@   $��10,121,10,11q�6M    .   .  5�        5�      $ ID��6M      SortDirection$ 
DescendingX�6Y    61   �� *	idOrder+6Y     5�      $
 Date��6i    61   �� *
datetime+ �� StringFormat$ 
dd/MM/yyyy��6i     5�      $ Total��6K    61   �� *total+6K     5�      $
 conf��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6?      	CellStyle 5�   "   �� 5�   &   *  $System.Windows.Controls.DataGridCell"  6,     �� Triggers  5�   *   �� 5�   .   ! �� Binding! 6:   �� *status.confirmed+" �� Value	" False6_   .a�5�   2   �� # �� Property# � ��$ �� Value
$ �  ��6O   5�   /   �� 5�   .   ! 6:   �� *status.confirmed+" True6_   .a�5�   2   �� # � ��
$ � � �6O   5�   /   5�   '   5�        5�      $	 lab��61   $ 40 6>    5�   "   �� 5�   &   "  6,     5�   *   �� 5�   .   ! 6:   �� *status.labeled+	" False6]   .a�5�   2   �� # � ��
$ �  ��6O   5�   /   �� 5�   .   ! 6:   �� *status.labeled+" True6]   .a�5�   2   �� # � ��
$ � � �6O   5�   /   5�   '   5�        5�      $
 sent��61   $ 40 6?    5�   "   �� 5�   &   "  6,     5�   *   �� 5�   .   ! 6:   �� *status.sent+	" False6Z   .a�5�   2   �� # � ��
$ �  ��6O   5�   /   �� 5�   .   ! 6:   �� *status.sent+" True6Z   .a�5�   2   �� # � ��
$ � � �6O   5�   /   5�   '   5�        5�      $	 inv��61   $ 40 6>    5�   "   �� 5�   &   "  6,     5�   *   �� 5�   .   ! 6:   �� *status.invoiced+	" False6^   .a�5�   2   �� # � ��
$ �  ��6O   5�   /   �� 5�   .   ! 6:   �� *status.invoiced+" True6^   .a�5�   2   �� # � ��
$ � � �6O   5�   /   5�   '   5�      5�      �� 5�      -6   5        % ��Name$% 	lblStatus��5�       $
��Left=�63   $��
503,74,0,0q�6N   $
��Wrap=�6b   $��Status: Unconfirmed��6v   $	��Top=�6�   �� 5�      -7   5        $
 	btnO_Zoom��5�      $
��Zoom��60   $
��Left=�6?   $	��Top=�6Z   $��
196,64,0,0q�6r   $��42��6�   $��84��6�   $��14(�6�   6�   5�      5�      �� 5�      -8   5        $ tabInvoices��5�      $��INVOICES��6+   $��16(�6=   .��5�      � .+�5�        -9   5        $ dgrInvoices��5�      $��10,121,10,10q�64   $��Stretch=�6J   $
��auto��6h    .   . &   RowStyle& 5�      �� 5�      "  6$     5�   "   �� 5�   &   ! 62   �� *	accounted+" True6P   .a�5�   *   �� # � ��
$ � � �6G   5�   '   5�       5�        5�      $ Invoice��6H    61   �� *id+6H     5�      $ Order��6S    61   �� *order.idOrder+6S     5�      $
 Date��6f    61   �� *date+$ 
dd/MM/yyyy��6f     5�      $
 Date��6O   '   
Visibility$' 	Collapsed=�6]    61   �� *	accounted+6]   5�      �� 5�      -:   5        $
 btnI_Add��5�      $	��New��6/   $
��Left=�6=   $��	10,64,0,0q�6X   $	��Top=�6k   $��84��6�   $��42��6�   $��14(�6�   6�   �� 5�      -;   5        $
 btnI_Delete��5�      $��Delete��62   $
��Left=�6C   $��
103,64,0,0q�6^   $	��Top=�6r   $��83��6�   $��42��6�   $��14(�6�   6�   �� 5�      -<   5        $
 	btnI_Zoom��5�      $
��Zoom��60   $
��Left=�6?   $	��Top=�6Z   $��
196,64,0,0q�6r   $��42��6�   $��84��6�   $��14(�6�   6�   �� 5�      -=   5        $
 
btnI_Print��5�      $��Print��61   $
��Left=�6A   $	��Top=�6\   $��
290,64,0,0q�6t   $��42��6�   $��84��6�   $��14(�6�   6�   �� 5�      $��Search:��6   $	��Top=�6.   $��10q�6F   $
��Left=�6R   $��57��6m   �� 5�      ->   5        $ txtI_Search��5�      $	��Top=�63   $��
70,15,10,0q�6K   6_   5�      5�      5�      �� 5   
   $
��Left=�6   $	��100��6+   $��	10,10,0,0q�68   $	��Top=�6K   $	��100��6c   $��profilePhoto.jpg��6o   ( � Cursor$
( None��6�   �� 5  
   -?   5        $ lblUserName��5     $��User: ��6%   $
��Left=�66   $��
140,21,0,0q�6Q   $	��Top=�6e   $��16(�6}   �� 5  
   -@   5        $ lblDate��5     $��Date: ��6!   $��
140,57,0,0q�62   $	��Top=�6F   $��16(�6^   $
��Left=�6l   �� 5  
   -A   5        $
 	btnLogout��5     $��Log Out��6$   $��Right=�66   $��	0,30,30,0q�6R   $	��Top=�6e   $��75��6}   $��30��6�   6�   5     5     