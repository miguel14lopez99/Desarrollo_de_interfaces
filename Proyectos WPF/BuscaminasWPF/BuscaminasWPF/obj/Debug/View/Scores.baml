   M S B A M L   `   `   `  ����H  DBuscaminasWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:BuscaminasWPF.ViewBuscaminasWPF.View  5   	       BuscaminasWPF.View.Scores   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:BuscaminasWPF.View     5   	     � Title$  Scores��5   	   $	��447��6   $	��294��6%   .��5	      � .+�5
   
   �� $��Name:��6   $
��Left=�6!   $	��Top=�6<   $��20q�6T   �� 5   
   -   5         ��Name$ txtName��5      $	��Top=�6#   $��
60,20,20,0q�6;   �� 5   
   -   5         ��Name$ lblScore��5      $��Score:��6&   $
��Left=�64   $	��Top=�6O   $��	20,50,0,0q�6g   �� 5   
   -   5         ��Name$ btnSave��5      $
��Save��6"   $	��Top=�61   $��
50,80,50,0q�6I   $��30��6]   $��16(�6i   6w   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgrPlayers��5      $��20,120,20,20q�6'      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6>   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *name+6>     5      $ Score��6?   	 6%   �� *score+6?   5      5      5      