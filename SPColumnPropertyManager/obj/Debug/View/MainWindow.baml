   M S B A M L   `   `   `  ����  SPColumnPropertyManager(    "SPColumnPropertyManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$(  "SharePoint Column Property Manager��5   	   $	��525��64   $	��430��6@    � TaskbarItemInfo 5      *  $System.Windows.Shell.TaskbarItemInfo  5   
    � ContextMenu 5
      �� 5   
   .��5      � $��	0,0,0,-82q�6   .+�5   
   �� $��	Site Url:��6   $
��Left=�6$   $��	10,34,0,0q�6?   $	��Top=�6R   �� 5   
   $��Use current credentials?��6   $
��Left=�63   $��	10,65,0,0q�6N   $	��Top=�6a   �� 5   
   $��
User Name:��6   $
��Left=�6%   $��	23,96,0,0q�6@   $	��Top=�6S    J� RenderTransformOrigin$ -3.452,-0.876&�6k   �� 5   
   $��	Password:��6   $
��Left=�6$   $��
23,127,0,0q�6?   $	��Top=�6S   $ -3.452,-0.876&�6k   �� 5   
   $
��Left=�6   $��23��6-   $��	82,34,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6�   $	��368��6�   ��6`   �� *url+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5   
   $
��Left=�6   $��23��6-   $��	99,96,0,0q�69   $	��Top=�6�   $	��120��6�   $ -0.811,-0.854&�6�   ��6L   �� *
UserName+$ PropertyChanged=�{�6�   ��  �� ElementName$ chkUseDefaultCredentials�� �� Path$ 	IsChecked�G� 5   
   -   5        $��txtPassword��5      $
��Left=�6)   $��
99,135,0,0q�6D   $	��Top=�6X   $	��120��6p   {�. 6|   �� 5   
   $��Connect��6   $
��Left=�6#   $��57��6>   $��
268,96,0,0q�6J   $	��Top=�6^   $	��103��6v   ��6�   �� *
GetLists+$ TwoWay=���6�   �� $ txtPassword���� 5   
   -   5        $��chkUseDefaultCredentials��5      $�� ��63   $
��Left=�6>   $��
187,65,0,0q�6Y   $	��Top=�6m   $ 0.684,1.667&�6�   	 d� 	IsChecked	 6�   �� *UseDefaultCredentials+6�   �� 5   
   $��Choose List:��6   $
��Left=�6'   $��
23,204,0,0q�6B   $	��Top=�6V   �� 5   
   $
��Left=�6   $��114,208,0,0q�6.   $	��Top=�6C   $	��197��6[   {�. ��6x   �� *	ListNames+
 �� SelectedItem
 6�   �� *SelectedList+�� 5   
   $��Populate��6   $
��Left=�6$   $��357,208,0,0q�6?   $	��Top=�6T   $��75��6l   {�. ��6�   �� *	GetFields+&   System.Windows.Controls.DataGrid  5   
   $
��Left=�6   $��
49,272,0,0q�6.   $	��Top=�6B   $
��Auto��6Z      CanUserAddRows .     SelectionUnit$
 Cell=�6~      AutoGenerateColumns .    CanUserResizeColumns .     CanUserResizeRows .  ��6�   �� *	FieldRows+ � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType��%E   '        �� 5      "  6   .�5      -   5        5      5      5       �� 5!   
   -   5         ��Name$ 
LabelError��5!      $�� ��6$   $
��Left=�6/   $��
34,173,0,0q�6J   $	��Top=�6^   $	��359��6v   �� 5"   
   $A��;*Note* You must click out of the row to commit the changes!��6   $
��Left=�6V   $��32��6q   $��
49,235,0,0q�6}   $	��Top=�6�   $	��344��6�   5#      5$      