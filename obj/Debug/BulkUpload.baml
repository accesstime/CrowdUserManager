   M S B A M L   `   `   `  ����L  HCrowdUserManager, Version=2.12.1.1, Culture=neutral, PublicKeyToken=null3clr-namespace:CrowdUserManagerCrowdUserManager  5   	   !    CrowdUserManager.BulkUpload   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CrowdUserManager     5   	   -   5          �Name$#  Atlassian_Crowd_Bulk_Uploader��5   	    � Title$ Crowd Bulk Uploader��5   	   $��376.331��6%   $��792.604��66    � WindowStyle$
 None=�6F    � 
ResizeMode$ NoResize=�6Y    � WindowStartupLocation$ CenterScreen=�6o    � Icon$ media/index.ico��6�   ���	#FF3754D7$��1q�6�   ��6�   Z� .��5	      � ���	#FF3F3D41$
��Left=�6"   $	��793��6=   .+�5
   
   �� -   5         ��Name$ verifyButton��5
      $��Verify��6'   $��Center=�68   $��350,0,360,22q�6U   $��Bottom=�6k   $��83��6�    �� 	IsDefault . $��2,0,2,2q�6�   ���	#FFEFF392$
��Bold"�6�   ���	#FF3754D7$��23��6.  ��6�   Z� 6.  �� 5   
   -   5        $ 
ExitButton��5      $
��Exit��6%   $��Right=�64   $��	0,0,10,21q�6P   $��Bottom=�6c   $��84��6~   $��2,0,2,2q�6�   ���	#FF747EBB$
��Bold"�6�   ���	#FF3754D7$��24��6  ��6�   Z� 6  &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��	10,27,0,0q�6@   $	��Top=�6S   $	��302��6k   $	��773��6x   	   HeadersVisibility$	 Column=�6�   
   ColumnHeaderHeight$
 22Q�6�      AlternatingRowBackground �	#FFECECEC   RowBackground
 ��������	#FF3754D7$��2q�6M     ClipboardCopyMode$ IncludeHeader=�6a  ��6�   Z�    Columns 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *	Process+   ClipboardContentBinding 6E   Z� 6h   0  *System.Windows.Controls.DataGridTextColumn  5         Header$ Email��6%    .   65   �� *F1+6L     5      $ 	FirstName��6%    .  68   �� *F2+6O     5      $ LastName��6%    .  67   �� *F3+6N     5      $ UserName��6%    .   67   �� *F4+6N     5      $ CrowdUserGroups��6%    .  6>   �� *F6+6U     5      $ 	Directory��6%    .  68   �� *	Directory+6V     5      $ Status��6%    .  65   �� *Status+6P   5      �� 5   
   -   5        $ CreateButton��5      $��Create��6'   $
��Left=�68   $��	10,0,0,20q�6S   $��Bottom=�6f   $��86��6�    J� RenderTransformOrigin$ 0.145,0.659&�6�   ���	#FF3754D7$��2,0,2,2q�6�   ���	#FFDA3A3A$
��Bold"�6*  $��25��6<  ��6�   Z� 6<  5      5      