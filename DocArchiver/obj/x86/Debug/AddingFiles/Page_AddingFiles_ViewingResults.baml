   M S B A M L   `   `   `  ����  DocArchiver1    +DocArchiver.AddingFiles.Page_ViewingResults   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $	��900��5      $	��750��6     N� Title$8  2Document Archiver - Adding Files - Viewing Results��5	      .��5      � .+�5   
   �� -   5        $��btnOK��5   Z   $��OK��6   $��39��6   $
��Left=�6*   $��404,631,0,0q�6E   $	��Top=�6g   $��89��6    J� SnapsToDevicePixels .  6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	dgFolders��5   j      AutoGenerateColumns .  $	��540��6/   $
��Left=�6<   $��	41,44,0,0q�6W   $	��Top=�6{   $	��819��6�      CanUserAddRows .     CanUserDeleteRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6P      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 5   &   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   �� 	 �� Path$
	 Name�
 �� Mode$
 OneWay=�5   &     5      $ Folder Path��6V   $	 200 5   '    5   %   �� $	 
FolderPath�$
 OneWay=�5   '     5      $ Status��6R   $ 70 5   '    5   %   �� $	 Status�$
 OneWay=�5   '     5      $ Status Message��6U   $	 200 5   '    5   %   �� $	 	StatusMsg�$
 OneWay=�5   '   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ Remove Original��6)    6B   �� $	 Should_RemOrg�5"      5#      5$      