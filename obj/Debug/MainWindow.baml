   M S B A M L   `   `   `  ����L  HCrowdUserManager, Version=2.12.1.1, Culture=neutral, PublicKeyToken=null3clr-namespace:CrowdUserManagerCrowdUserManager  5   	   !    CrowdUserManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CrowdUserManager     5   	   -   5          �Name$  CrowdUserManger��5   	    � Title$ Crowd User Manager��5   	   $	��764��6$   $��839.513��61    � WindowStartupLocation$ CenterScreen=�6A    � 
ResizeMode$ NoResize=�6f    � WindowStyle$
 None=�6|    � Icon$ media/index.ico��6�   $��3q�6�   ��6�   Z� .��5	      � -   5         �Name$ Grid_1��5	      $
��Left=�6   $	��833��66    J� RenderTransformOrigin$ 0.497,0.492&�6B   ���	#FF3F3D41 � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� ���	#FF46B9D1$��2q�6)   $
��Left=�6=   $	��690��6X   $��	15,23,0,0q�6e   $	��Top=�6x   $	��388��6�   ._�5      �� -   5        	 ��Name$	 recreateUserButton��5      $��Recreate...��61   $
��Left=�6G   $	��Top=�6b   $��50��6z   $��
96,207,0,0q�6�   $��18��6�   $��10(�6�   ���	#FFC3C1C1$y�Hidden=�6  ��6�   Z� ��6�   Z� 6  5      �� 5   
   -   5        
 ��Name$
 groupBox��5      $��Configuration��6%   $
��Left=�6<   $��438,597,0,0q�6W   $	��Top=�6l   $	��143��6�   $	��380��6�   
���  ��
�������$
��Bold"�6�   $��14(�6�   �� 5   
   -   5        $
 Groups_Settngs��5      $��Groups Settngs��6+   $
��Left=�6C   $��
438,10,0,0q�6^   $	��Top=�6r   $	��458��6�   $	��380��6�   ���	#FFEEAFAF$��1q�6�   $
��Bold"�6�   
���  ��$��14(�6�   �� 5   
   -   5         ��Name$ UserGropsListBox��5      $
��Left=�6,   $��85��6G   $��112,387,0,0q�6S   $	��Top=�6h   $	��248��6�   
�������$��Normal"�6�   $��10(�6�    �� SelectionMode$ Extended=�6�   $��2q�6�   ���	#FFB6D44E��6�   Z�  � ContextMenu 5      �� 5      .@�5      m� -   5        $��Remove��5      ���	#FF3F3D41
�������$��0q�6Y   $
��Bold"�6m   6   5      5      �� 5   
   -   5        $ listBoxAvailibleGroups��5      $
��Left=�62   $��85��6M   $��113,556,0,0q�6Y   $	��Top=�6n   $	��247��6�   $��2q�6�   ���	#FFF9980C
�������$��10(�6�   $ Extended=�6�   ��6�   Z� 6�   �� 5   
   -	   5        $	 copyGroupButton��5      $��Copy Groups...��6*   $
��Left=�6C   $��230,530,0,0q�6^   $	��Top=�6s   $	��130��6�   
�������$��2,2,2,0q�6�   ���	#FFF9980C$ 0.5,0.5&�6�   $��26��6  $
��Bold"�6  $y�Hidden=�6N  ��6�   Z� 6N  �� 5   
   -
   5        $	 resetPasswordButton��5      $��Reset Password��6.   $
��Left=�6G   $��260,475,0,0q�6b   $	��Top=�6w   $��88��6�   ���	#FF46B9D1$
��Bold"�6�   $��11(�6�   $ 0.898,0.842&�6   ��6�   Z� ��6�   Z� 6   �� 5   
   -   5        $	 nextUserButton��5      $	��>>>��6)   $
��Left=�6@   $��366,207,0,0q�6[   $	��Top=�6p   $��28��6�   $��23��6�   ���	#FFFF0808$��14(�6�   $��SimSun)�6  $
��Bold"�6"  $y�Hidden=�64  ��6�   Z� ��6�   Z� 64  �� 5   
   -   5        $	 attributsButton��5      $��Show attributs...��6*   $
��Left=�6F   $��277,233,0,0q�6a   $	��Top=�6v   $��80��6�   ���	#FFC3C1C1$��10(�6�   $y�Visible=�6	  ��6�   Z� ��6�   Z� 6	  �� 5    
   -   5        $	 
ExitButton��5       $
��Exit��6%   $��Bottom=�64   $��75��6O   
�������$��Calibri)�6�   $��18(�6�   $
��Bold"�6�   $��2,0,2,2q�6�   ���	#FF46B9D1$��Center=�6  $��	15,0,0,19q�6'  $
��Left=�6:  ��6Z   Z� 6:  �� 5!   
   -   5         ��Name$ SearchTextBox��5!      $
��Left=�6)   $��26��6D   $��
113,99,0,0q�6P   $	��Top=�6d   $	��246��6|   ���	#FF3754D7
�������$��2q�6�    �� 
CaretBrush �	#FF8FAC76��6�   Z� 6�   �� 5"   
   -   5         ��Name$ label2��5"      $��Search :��6    $
��Left=�63   $��	49,99,0,0q�6N   $	��Top=�6a   ���	#FF46B9D1$
��Bold"�6�   �� 5#   
   -   5         ��Name$ DirectoryComboBox��5#      $
��Left=�6.   $��
132,48,0,0q�6I   $	��Top=�6]   $	��224��6u    �� SelectedIndex$ 0��6�   
���   �$
��Bold"�6�   ��6�   Z� ��6  Z� �� 5$   
   -   5        $ label_Copy1��5$      $��Directory :��6%   $
��Left=�6;   $��	49,44,0,0q�6V   $	��Top=�6i   $ -2.003,0.846&�6�   ���	#FF46B9D1$
��Bold"�6�   �� 5%   
   -   5        $ label��5%      $��First Name :��6   $
��Left=�66   $��
32,249,0,0q�6Q   $	��Top=�6e   $ -2.003,0.846&�6}   ���	#FF46B9D1$
��Bold"�6�   �� 5&   
   -   5        $ UserNameBox��5&      $
��Left=�6'   $��23��6B   $��113,208,0,0q�6N   $	��Top=�6c   $	��246��6{   ���	#FFB6D44E
�������$
��Bold"�6�    �	#FF8FAC76$��2q�6�   ��6�   Z� 6�   �� 5'   
   -   5        $ FirstNameBox��5'      $
��Left=�6(   $��23��6C   $��113,252,0,0q�6O   $	��Top=�6d   $	��246��6|   ���	#FFB6D44E
�������$
��Bold"�6�    �	#FF8FAC76$��2q�6�   ��6�   Z� 6�   �� 5(   
   -   5        $ LastNameBox��5(      $
��Left=�6'   $��23��6B   $��113,299,0,0q�6N   $	��Top=�6c   $	��247��6{   ���	#FFB6D44E
�������$
��Bold"�6�    �	#FF8FAC76$��2q�6�   ��6�   Z� 6�   �� 5)   
   -   5        $ 
label_Copy��5)      $��Last Name :��6$   $
��Left=�6:   $��
32,296,0,0q�6U   $	��Top=�6i   $ -2.003,0.846&�6�   ���	#FF46B9D1$
��Bold"�6�   �� 5*   
   -   5        $ EmailBox��5*      $
��Left=�6$   $��23��6?   $��112,343,0,0q�6K   $	��Top=�6`   $	��248��6x   ���	#FFB6D44E
�������$
��Bold"�6�    �	#FF8FAC76$��2q�6�   ��6�   Z� 6�   �� 5+   
   -   5        $ label_Copy2��5+      $��E- mail :  ��6%   $
��Left=�6;   $��
32,339,0,0q�6V   $	��Top=�6j   $ -2.003,0.846&�6�   ���	#FF46B9D1$
��Bold"�6�   �� 5,   
   -   5        $ label_Copy3��5,      $��User Name :��6%   $
��Left=�6;   $��
32,207,0,0q�6V   $	��Top=�6j   $ -2.003,0.846&�6�   ���	#FF46B9D1$��77��6�   $
��Bold"�6�   �� 5-   
   -   5        $	 SearchButton��5-      $��Search��6'   $
��Left=�68   $��230,125,0,0q�6S   $	��Top=�6h   $	��129��6�   
�������$��27��6�   $
��Bold"�6�   $��2,0,2,2q�6�   ���	#FF3754D7$��14(�6    �� 	IsDefault . ��6�   Z� 6.  �� 5.   
   -   5         ��Name$ ActiveCheckBox��5.      $��Active��6+   $
��Left=�6<   $��
39,173,0,0q�6W   $	��Top=�6k   $
��Bold"�6�   ���	#FF46B9D1���	#FF46B9D1��6�   Z� 6�   �� 5/   
   -   5        $	 CreateUpdateButton��5/      $��Create��6-   $
��Left=�6>   $��112,471,0,0q�6Y   $	��Top=�6n   $	��118��6�   $ 0.033,0.465&�6�   $��26��6�   ���	#FFB6D44E$��2,0,2,2q�6�   $
��Bold"�6
  $��14(�6  
���������6�   Z� 6=  �� 50   
   -   5        $ label1_Copy��50      $��Available :��6%   $
��Left=�6;   $��
32,552,0,0q�6V   $	��Top=�6j   ���	#FF46B9D1$
��Bold"�6�   $ 	0.5,0.462&�6�   �� 51   
   -   5        $	 addToGroupButton��51      $��Add to Group��6+   $
��Left=�6B   $��113,641,0,0q�6]   $	��Top=�6r   $	��117��6�   ���	#FFF9980C
�������$��2,0,2,2q�6�   $��28��6  $
��Bold"�6  ��6�   Z� 6  �� 52   
   -   5        $ label1��52      $��Groups :��6    $
��Left=�63   $��
32,387,0,0q�6N   $	��Top=�6b   $ -0.453,-0.272&�6z   ���	#FF46B9D1$
��Bold"�6�   �� 53   
   -    5        $	 DeleteUserButton��53      $��Delete User��6+   $
��Left=�6A   $��112,530,0,0q�6\   $	��Top=�6q   $	��118��6�   $��26��6�   $
��Bold"�6�   $��3,3,3,0q�6�   ���	#FF080808
���   �$y�Hidden=�6-  ��6�   Z� 6-  �� 54   
   -!   5        $ createGroupTextBox��54      $
��Left=�6.   $��26��6I   $��572,376,0,0q�6U   $	��Top=�6j   $	��232��6�   ���	#FFFF0808$��2q�6�   ��6�   Z� 6�   �� 55   
   -"   5        $ CreateGroupLabel��55      $��Group name :��6*   $
��Left=�6A   $��462,376,0,0q�6\   $	��Top=�6q   $ 0.477,0.577&�6�   $
��Bold"�6�   
�������6�   �� 56   
   -#   5        $	 createGroupButton��56      $��Create Group��6,   $
��Left=�6C   $��698,400,0,0q�6^   $	��Top=�6s   $	��106��6�   $��30��6�   ���	#FFFF0808$��2q�6�   $
��Bold"�6  
���������6�   Z� 6  �� 57   
   -$   5        $ existingGroupsComboBox��57      $
��Left=�63   $��
572,48,0,0q�6N   $	��Top=�6b   $	��232��6z   $��26��6�   $ 0��6�   ��6�   Z� �� 58   
   -%   5        $ existingGroupsLabel��58      $��Existing groups :��6-   $
��Left=�6I   $��
462,48,0,0q�6d   $	��Top=�6x   $ 0.337,-0.154&�6�   $
��Bold"�6�   
�������6�   �� 59   
   -&   5        $	 getGroupsButton��59      $	��Get��6*   $
��Left=�68   $��
572,92,0,0q�6S   $	��Top=�6g   $��96��6   ���	#FF3754D7$��2q�6�   $��28��6�   $
��Bold"�6�   
���������6�   Z� 6  �� 5:   
   -'   5        $	 deleteGroupButton��5:      $��Delete Group��6,   $
��Left=�6C   $��
716,92,0,0q�6^   $	��Top=�6r   $��88��6�   $��28��6�   
���   �$��3q�6�   $y�Hidden=�6�   ��6�   Z� 6�   �� 5;   
   -(   5        $	 GetMembersButton��5;      $��Group Members��6+   $
��Left=�6C   $��698,295,0,0q�6^   $	��Top=�6s   $	��106��6�   $��28��6�   ���	#FF3754D7$��2,0,2,2q�6�   $ 0.463,0.429&�6
  $
��Bold"�6.  
���������6�   Z� 6@  �� 5<   
   -)   5        $
 Bulk_Upload��5<      $��Bulk Upload��6(   $
��Left=�6=   $��438,468,0,0q�6X   $	��Top=�6m   $	��124��6�   $	��380��6�   ���	#FF3754D7���	#FFA8B2DC$��14(�6�   $
��Bold"�6�   .��5=      �� -*   5        $	 browseButton��5=      $��	Browse...��6+   $
��Left=�6?   $��
146,31,0,0q�6Z   $	��Top=�6n   $��85��6�   $��35��6�   
�������$��3q�6�   $��16(�6�   
�������$
��Bold"�6  $ 0.518,0.431&�6)  ��6�   Z� 6)  5>      �� 5?   
   -+   5        $ listBox��5?      $
��Left=�6#   $	��154��6>   $��462,142,0,0q�6K   $	��Top=�6`   $	��342��6x   ���	#FF3754D7$��2q�6�   
�������$
��Bold"�6  ��6�   Z� 6  �� 5@   
   -,   5         ��Name$  totalMembersCountTextBlock��5@      $
��Left=�68   $��462,301,0,0q�6S   $
��Wrap=�6h   $	��Top=�6|   $	��136��6�   $��18��6�   $ 0.506,-1.235&�6�   ���	#FF3C467A6�   �� 5A   
   --   5        $ ExpanderLabel��5A      $��
expand >>>��6'   $
��Left=�6E   $��320,714,0,0q�6`   $	��Top=�6u   $��98��6�   ���	#FF46B9D1$
��Bold"�6�   $��14(�6�   6�   �� 5B   
   -.   5         ��Name$ image��5B      $
��Left=�6   $��49��6:   $��185,688,0,0q�6F   $	��Top=�6[   $��54��6s   $��media/epam_logo_2.png��6~   �� 5C   
   -/   5        $	 button��5C      $��Edit Config...��6!   $
��Left=�6:   $��672,659,0,0q�6U   $	��Top=�6j   $	��106��6�   $��29��6�   $��2q�6�   
�������$
��Bold"�6�   ��6�   Z� 6�   �� 5D   
   -0   5        $	 	logButton��5D      $��Open Log...��6$   $
��Left=�6:   $��486,659,0,0q�6U   $	��Top=�6j   $	��102��6�   $��29��6�   $��2q�6�   ���	#FFB6D44E$
��Bold"�6�   ���	#FFB6D44E��6�   Z� 6  5F      5G      