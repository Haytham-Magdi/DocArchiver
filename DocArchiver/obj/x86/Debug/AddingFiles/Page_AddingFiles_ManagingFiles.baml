   M S B A M L   `   `   `  ����  DocArchiver0    *DocArchiver.AddingFiles.Page_ManagingFiles   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $	��900��5      $	��750��6     N� Title$7  1Document Archiver - Adding Files - Managing Files��5	      .��5      � .+�5   
   �� -   5        $��	btnFinish��5   ^   $��Finish��6   $��39��6"   $��Right=�6.   $��
0,626,37,0q�6J   $	��Top=�6o   $��89��6�    J� SnapsToDevicePixels .  6�   �� 5   
   -   5        $��btnPrevious��5   `   $��Previous��6   $��39��6$   $
��Left=�60   $��458,626,0,0q�6K    .  $	��Top=�6�   $��89��6�   6�   �� 5   
   -   5        $��	btnCancel��5   ]   $��Cancel��6   $��39��6"   $
��Left=�6.   $��
41,626,0,0q�6I    .  $	��Top=�6�   $��89��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	dgFolders��5   j      AutoGenerateColumns .  $	��503��6/   $
��Left=�6<   $��	41,81,0,0q�6W   $	��Top=�6{   $	��822��6�      CanUserAddRows .     CanUserDeleteRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6P      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 5   &   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   �� 	 �� Path$
	 Name�
 �� Mode$
 OneWay=�5   &     5      $ Folder Path��6V   $	 200 5   '    5   %   �� $	 
FolderPath�$
 OneWay=�5   '     5      $ Status��6R   $ 70 5   '    5   %   �� $	 Status�$
 OneWay=�5   '     5      $ Status Message��6U   $	 200 5    '    5   %   �� $	 	StatusMsg�$
 OneWay=�5    '   4  .System.Windows.Controls.DataGridCheckBoxColumn  5"      $ Delete Source File��6)    6E   �� $#	 DeleteSourceFile_AfterCapture�   
IsReadOnly 5#      �� $"	 Cannot_Write_To_ParentFolder�  5%      $ Write Mark File��6)    6B   �� $#	 WriteMarkFile_To_SourceFolder� 5&      �� $"	 Cannot_Write_To_ParentFolder�  5(      $ Can Write To Folder��6)    6F   �� $	 CanWrite_To_ParentFolder�$
 OneWay=�  5*      $ Core Missing��6)    .  6?   �� $	 WasCoreMissing�6�   50      �� 51   
   -   5        $��btnTry1��51   ]   $��Try 1��6   $��39��6!   $
��Left=�6-   $��235,626,0,0q�6H   $	��Top=�6l   $��98��6�   6�   �� 52   
   -   5        $��
btnKeepAll��52   _   $��Keep All��6   $��25��6$   $
��Left=�60   $��
662,46,0,0q�6K   $	��Top=�6q   $��91��6�   6�   �� 53   
   -   5        $��btnDeleteAll��53   a   $��
Delete All��6   $��25��6&   $
��Left=�62   $��
662,12,0,0q�6M   $	��Top=�6u   $��91��6�   6�   54      55      