   M S B A M L   `   `   `  ���� L  HCrowdUserManager, Version=2.12.1.1, Culture=neutral, PublicKeyToken=null3clr-namespace:CrowdUserManagerCrowdUserManager  !    CrowdUserManager.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CrowdUserManager     -     �Name$  CrowdUserManger�� � Title$ Crowd User Manager��$	��764��$��839.513�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � Icon$ media/index.ico��$��3q���Z� .��� -    �Name$ Grid_1��$
��Left=�$	��833�� J� RenderTransformOrigin$ 0.497,0.492&����	#FF3F3D41 � ColumnDefinitions �� .+��� ���	#FF46B9D1$��2q�$
��Left=�$	��690��$��	15,23,0,0q�$	��Top=�$	��388��._��� -   	 ��Name$	 recreateUserButton��$��Recreate...��$
��Left=�$	��Top=�$��50��$��
96,207,0,0q�$��18��$��10(����	#FFC3C1C1$y�Hidden=���Z� ��Z� �� -   
 ��Name$
 groupBox��$��Configuration��$
��Left=�$��438,597,0,0q�$	��Top=�$	��143��$	��380��
���  ��
�������$
��Bold"�$��14(��� -   $
 Groups_Settngs��$��Groups Settngs��$
��Left=�$��
438,10,0,0q�$	��Top=�$	��458��$	��380�����	#FFEEAFAF$��1q�$
��Bold"�
���  ��$��14(��� -    ��Name$ UserGropsListBox��$
��Left=�$��85��$��112,387,0,0q�$	��Top=�$	��248��
�������$��Normal"�$��10(� �� SelectionMode$ Extended=�$��2q����	#FFB6D44E��Z�  � ContextMenu �� .@�m� -   $��Remove�����	#FF3F3D41
�������$��0q�$
��Bold"��� -   $ listBoxAvailibleGroups��$
��Left=�$��85��$��113,556,0,0q�$	��Top=�$	��247��$��2q����	#FFF9980C
�������$��10(�$ Extended=���Z� �� -	   $	 copyGroupButton��$��Copy Groups...��$
��Left=�$��230,530,0,0q�$	��Top=�$	��130��
�������$��2,2,2,0q����	#FFF9980C$ 0.5,0.5&�$��26��$
��Bold"�$y�Hidden=���Z� �� -
   $	 resetPasswordButton��$��Reset Password��$
��Left=�$��260,475,0,0q�$	��Top=�$��88�����	#FF46B9D1$
��Bold"�$��11(�$ 0.898,0.842&���Z� ��Z� �� -   $	 nextUserButton��$	��>>>��$
��Left=�$��366,207,0,0q�$	��Top=�$��28��$��23�����	#FFFF0808$��14(�$��SimSun)�$
��Bold"�$y�Hidden=���Z� ��Z� �� -   $	 attributsButton��$��Show attributs...��$
��Left=�$��277,233,0,0q�$	��Top=�$��80�����	#FFC3C1C1$��10(�$y�Visible=���Z� ��Z� �� -   $	 
ExitButton��$
��Exit��$��Bottom=�$��75��
�������$��Calibri)�$��18(�$
��Bold"�$��2,0,2,2q����	#FF46B9D1$��Center=�$��	15,0,0,19q�$
��Left=���Z� �� -    ��Name$ SearchTextBox��$
��Left=�$��26��$��
113,99,0,0q�$	��Top=�$	��246�����	#FF3754D7
�������$��2q� �� 
CaretBrush �	#FF8FAC76��Z� �� -    ��Name$ label2��$��Search :��$
��Left=�$��	49,99,0,0q�$	��Top=����	#FF46B9D1$
��Bold"��� -    ��Name$ DirectoryComboBox��$
��Left=�$��
132,48,0,0q�$	��Top=�$	��224�� �� SelectedIndex$ 0��
���   �$
��Bold"���Z� ��Z� �� -   $ label_Copy1��$��Directory :��$
��Left=�$��	49,44,0,0q�$	��Top=�$ -2.003,0.846&����	#FF46B9D1$
��Bold"��� -   $ label��$��First Name :��$
��Left=�$��
32,249,0,0q�$	��Top=�$ -2.003,0.846&����	#FF46B9D1$
��Bold"��� -   $ UserNameBox��$
��Left=�$��23��$��113,208,0,0q�$	��Top=�$	��246�����	#FFB6D44E
�������$
��Bold"� �	#FF8FAC76$��2q���Z� �� -   $ FirstNameBox��$
��Left=�$��23��$��113,252,0,0q�$	��Top=�$	��246�����	#FFB6D44E
�������$
��Bold"� �	#FF8FAC76$��2q���Z� �� -   $ LastNameBox��$
��Left=�$��23��$��113,299,0,0q�$	��Top=�$	��247�����	#FFB6D44E
�������$
��Bold"� �	#FF8FAC76$��2q���Z� �� -   $ 
label_Copy��$��Last Name :��$
��Left=�$��
32,296,0,0q�$	��Top=�$ -2.003,0.846&����	#FF46B9D1$
��Bold"��� -   $ EmailBox��$
��Left=�$��23��$��112,343,0,0q�$	��Top=�$	��248�����	#FFB6D44E
�������$
��Bold"� �	#FF8FAC76$��2q���Z� �� -   $ label_Copy2��$��E- mail :  ��$
��Left=�$��
32,339,0,0q�$	��Top=�$ -2.003,0.846&����	#FF46B9D1$
��Bold"��� -   $ label_Copy3��$��User Name :��$
��Left=�$��
32,207,0,0q�$	��Top=�$ -2.003,0.846&����	#FF46B9D1$��77��$
��Bold"��� -   $	 SearchButton��$��Search��$
��Left=�$��230,125,0,0q�$	��Top=�$	��129��
�������$��27��$
��Bold"�$��2,0,2,2q����	#FF3754D7$��14(� �� 	IsDefault . ��Z� �� -    ��Name$ ActiveCheckBox��$��Active��$
��Left=�$��
39,173,0,0q�$	��Top=�$
��Bold"����	#FF46B9D1���	#FF46B9D1��Z� �� -   $	 CreateUpdateButton��$��Create��$
��Left=�$��112,471,0,0q�$	��Top=�$	��118��$ 0.033,0.465&�$��26�����	#FFB6D44E$��2,0,2,2q�$
��Bold"�$��14(�
���������Z� �� -   $ label1_Copy��$��Available :��$
��Left=�$��
32,552,0,0q�$	��Top=����	#FF46B9D1$
��Bold"�$ 	0.5,0.462&��� -   $	 addToGroupButton��$��Add to Group��$
��Left=�$��113,641,0,0q�$	��Top=�$	��117�����	#FFF9980C
�������$��2,0,2,2q�$��28��$
��Bold"���Z� �� -   $ label1��$��Groups :��$
��Left=�$��
32,387,0,0q�$	��Top=�$ -0.453,-0.272&����	#FF46B9D1$
��Bold"��� -    $	 DeleteUserButton��$��Delete User��$
��Left=�$��112,530,0,0q�$	��Top=�$	��118��$��26��$
��Bold"�$��3,3,3,0q����	#FF080808
���   �$y�Hidden=���Z� �� -!   $ createGroupTextBox��$
��Left=�$��26��$��572,376,0,0q�$	��Top=�$	��232�����	#FFFF0808$��2q���Z� �� -"   $ CreateGroupLabel��$��Group name :��$
��Left=�$��462,376,0,0q�$	��Top=�$ 0.477,0.577&�$
��Bold"�
��������� -#   $	 createGroupButton��$��Create Group��$
��Left=�$��698,400,0,0q�$	��Top=�$	��106��$��30�����	#FFFF0808$��2q�$
��Bold"�
���������Z� �� -$   $ existingGroupsComboBox��$
��Left=�$��
572,48,0,0q�$	��Top=�$	��232��$��26��$ 0����Z� �� -%   $ existingGroupsLabel��$��Existing groups :��$
��Left=�$��
462,48,0,0q�$	��Top=�$ 0.337,-0.154&�$
��Bold"�
��������� -&   $	 getGroupsButton��$	��Get��$
��Left=�$��
572,92,0,0q�$	��Top=�$��96�����	#FF3754D7$��2q�$��28��$
��Bold"�
���������Z� �� -'   $	 deleteGroupButton��$��Delete Group��$
��Left=�$��
716,92,0,0q�$	��Top=�$��88��$��28��
���   �$��3q�$y�Hidden=���Z� �� -(   $	 GetMembersButton��$��Group Members��$
��Left=�$��698,295,0,0q�$	��Top=�$	��106��$��28�����	#FF3754D7$��2,0,2,2q�$ 0.463,0.429&�$
��Bold"�
���������Z� �� -)   $
 Bulk_Upload��$��Bulk Upload��$
��Left=�$��438,468,0,0q�$	��Top=�$	��124��$	��380�����	#FF3754D7���	#FFA8B2DC$��14(�$
��Bold"�.���� -*   $	 browseButton��$��	Browse...��$
��Left=�$��
146,31,0,0q�$	��Top=�$��85��$��35��
�������$��3q�$��16(�
�������$
��Bold"�$ 0.518,0.431&���Z� �� -+   $ listBox��$
��Left=�$	��154��$��462,142,0,0q�$	��Top=�$	��342�����	#FF3754D7$��2q�
�������$
��Bold"���Z� �� -,    ��Name$  totalMembersCountTextBlock��$
��Left=�$��462,301,0,0q�$
��Wrap=�$	��Top=�$	��136��$��18��$ 0.506,-1.235&����	#FF3C467A�� --   $ ExpanderLabel��$��
expand >>>��$
��Left=�$��320,714,0,0q�$	��Top=�$��98�����	#FF46B9D1$
��Bold"�$��14(��� -.    ��Name$ image��$
��Left=�$��49��$��185,688,0,0q�$	��Top=�$��54��$��media/epam_logo_2.png���� -/   $	 button��$��Edit Config...��$
��Left=�$��672,659,0,0q�$	��Top=�$	��106��$��29��$��2q�
�������$
��Bold"���Z� �� -0   $	 	logButton��$��Open Log...��$
��Left=�$��486,659,0,0q�$	��Top=�$	��102��$��29��$��2q����	#FFB6D44E$
��Bold"����	#FFB6D44E��Z� 