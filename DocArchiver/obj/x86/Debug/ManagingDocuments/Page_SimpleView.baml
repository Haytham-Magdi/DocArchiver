   M S B A M L   `   `   `  ����F  BDocArchiver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DocArchiver.ManagingDocuments.Data"DocArchiver.ManagingDocuments.Data  5	   0   3    -DocArchiver.ManagingDocuments.Page_SimpleView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?my0clr-namespace:DocArchiver.ManagingDocuments.Data     5	   0   -   5        $	��900��5      $	��750��6     N� Title$+  %Document Archiver - Viewing Documents��5	       � 	Resources 5
      <   6DocArchiver.ManagingDocuments.Data.DsManagingDocuments   dsManagingDocuments $  vw_SimpleDocumentsViewViewSource �� Source �� Path �� Source 5 1vw_SimpleDocumentsViewImportanceDegreesViewSource 6 2vw_SimpleDocumentsViewImportanceDegreesViewSource1 4 0vw_SimpleDocumentsViewDocumentCommentsViewSource��%�  &	        &	      7   &	 Q     7  &	 �     7  &	 �     7    5   
   6!   �� 5   
    6H   �� $ Vw_SimpleDocumentsView�8   �� 5   
    6Y   �� $. (ImportanceDegrees_Vw_SimpleDocumentsView�8   �� 5   
    6Z   �� $. (Vw_SimpleDocumentsView_ImportanceDegrees�8   �� 5   
    6X   �� $0 *FK_Vw_SimpleDocumentsView_DocumentComments�8   5      .��5      � -   5         � DataContext# [ 5      .+�5   
   �� -   5        $��btnHome��5   [   $
��Home��6   $��39��6    $
��Left=�6,   $��
12,596,0,0q�6G    J� SnapsToDevicePixels .  $	��Top=�6�   $��89��6�   6�   �� 5   
   -   5        $��
btnRefresh��5   ]   $��Refresh��6   $��31��6#   $
��Left=�6/   $��	12,32,0,0q�6J    .  $	��Top=�6�   $��77��6�   6�   �� 5   
   -   5        $��btnSave��5   \   $
��Save��6   $��39��6    $
��Left=�6,   $��485,596,0,0q�6G    .  $	��Top=�6�   $��89��6�   6�   �� 5   
   -   5        $��btnReset��5   ]   $��Reset��6   $��39��6!   $
��Left=�6-   $��376,596,0,0q�6H    .  $	��Top=�6�   $��89��6�   6�   �� 5   
   -   5        $��cbImportanceDegrees��5   N   $��41��6   $
��Left=�6   $��
287,25,0,0q�6:   $	��Top=�6i   $	��221��6�    �� DisplayMemberPath$ ImportanceDegree_Desc��5        �� SelectedValuePath$ ImportanceDegree_Num��5!      ��5      �� $ DataContext.ImpDegs�	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType"
 �5!      �� 5%   
   -   5        $��button1��5%   ]   $��Button��6   $��45��6"   $
��Left=�6.   $��
558,19,0,0q�6I   $	��Top=�6l   $	��113��6�   6�   �� 5*   
   -	   5        $��tabControl1��5*   O   $	��472��6   $
��Left=�6"   $��0,89,0,0q�6=   $	��Top=�6b   $	��900��6z   .@�5,      �� -
   5        $��tabItemManage��5,   &   $��Manage��6   .��5-      � $	��422��6   .+�50      &   System.Windows.Controls.DataGrid  -   5        $��dg_Vw_SimpleDocumentsView��50   �      AutoGenerateColumns .     EnableRowVirtualization . $	��311��6Z   $
��Left=�6g   $��2,15,0,0q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   $	��Top=�6�   $	��882��6     CanUserDeleteRows .     CanUserAddRows .  ��6�   ��    Columns 51      4  .System.Windows.Controls.DataGridTemplateColumn  54         CellTemplate 55   "   �� 56   &   .R�57   *   �� $��btnOpenDocument��61   -   5        $��Open Document��57   H   58   $   59   '   5;      0  *System.Windows.Controls.DataGridTextColumn  5B      -   5        colCoreFile_ID��,  &System.Windows.Controls.DataGridColumn   Header$ Document ID��5B   n      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6�      
IsReadOnly .    CanUserSort . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� $ CoreFile_ID�6�     5D      -   5        colTitle��$ Title��5E   -   $
 Auto 6<    .   .  6   �� $ Title� �� Mode$ TwoWay=�5F        5J      -   5        colNofPages��$ Number of Pages��5K   #   $
 Auto 6<    .  .  6   �� $ NofPages�5L      4  .System.Windows.Controls.DataGridComboBoxColumn  5R      -   5        colImportance��$ 
Importance��5R   L   $	 110 6`      DisplayMemberPath$ ImportanceDegree_Desc��5T         SelectedValuePath$ ImportanceDegree_Num��6+      SelectedValueBinding 5U      �� $ ImportanceDegree_Num�$ TwoWay=�5W        5^      -   5        colIsCorrupted��$ Is Corrupted��5^   n   $
 Auto 6�    .  .  6I   �� $ IsCorrupted�5_        5b      -   5        colSize��$ 	File Size��5b   `   $
 Auto 6s    .  .  6B   �� $
 Size�5c   %   5h        5i      -   5        $��dg_DocumentComments��5i   �    .   . $��60��6Z   $
��Left=�6f   $��650,342,0,0q�6�   $ VisibleWhenSelected=�6  $	��Top=�6A  $	��173��6Y  ��6�   �� # [  5j        5k      -   5        documentComment_IDColumn��$ Document Comment ID��5k       . $ SizeToHeader 6�    6S   �� $ DocumentComment_ID�6�     5l      -   5        document_IDColumn��$ Document ID��5l   q   $ SizeToHeader 6�    6L   �� $ Document_ID�6�     5m      -   5        comment_TextColumn��$ Comment Text��5m   s   $ SizeToHeader 6�    6M   �� $ Comment_Text�6�   5o      5p      5q      �� 5r      -   5        $��tabItemSearch��5r   &   $��Search��6   .��5s      � .+�5x      �� -   5        $��txtDocTitle��5x   Y   $��32��6   $��Right=�6*   $��	0,55,24,0q�6F   $	��Top=�6l   $	��704��6�   �� 5z      -   5        $��
textBlock1��5z   Z   $��32��6    $
��Left=�6,   $��	12,56,0,0q�6G   $��Document Title��6l   $	��Top=�6�   $	��141��6�   $��14(�6�   �� 5{      -   5        $��txtDocFileName��5{   Y   $��32��6   $��Right=�6*   $��	0,93,24,0q�6F   $	��Top=�6o   $	��704��6�   �� 5|      -   5        $��
textBlock2��5|   h   $��14(�6    $��32��6.   $
��Left=�6:   $��	12,94,0,0q�6U   $��Document File Name:��6z   $	��Top=�6�   $	��141��6�   �� 5}      -   5        $��txtDocFolderPath��5}   Z   $��32��6   $��Right=�6*   $��
0,131,24,0q�6F   $	��Top=�6r   $	��704��6�   �� 5~      -   5        $��
textBlock3��5~   i   $��14(�6    $��32��6.   $
��Left=�6:   $��
12,132,0,0q�6U   $��Document Folder Path��6{   $	��Top=�6�   $	��141��6�   �� 5      -   5        $��	txtDocNum��5   Z   $��32��6   $��Right=�6*   $��
0,17,443,0q�6F   $	��Top=�6k   $	��285��6�   �� 5�      -   5        $��
textBlock4��5�   h   $��14(�6    $��32��6.   $
��Left=�6:   $��	12,18,0,0q�6U   $��Document Number��6z   $	��Top=�6�   $	��141��6�   �� 5�      -    5        $��txtNofPages1��5�   [   $��32��6   $��Right=�6*   $��0,169,633,0q�6F   $	��Top=�6o   $��95��6�   �� 5�      -!   5        $��
textBlock5��5�   i   $��14(�6    $��32��6.   $
��Left=�6:   $��
12,169,0,0q�6U   $��Number of Pages��6{   $	��Top=�6�   $	��141��6�   �� 5�      -"   5        $��txtNofPages2��5�   [   $��32��6   $��Right=�6*   $��0,168,513,0q�6F   $	��Top=�6o   $��95��6�   �� 5�      -#   5        $��chkIncludeCorrupted��5�   \   $��30��6   $��Right=�6+   $��0,207,402,0q�6G   $	��Top=�6w   $��77��6�   �� 5�      -$   5        $��chkIncludeNotCorrupted��5�   [   $��30��6   $
��Left=�6+   $��162,207,0,0q�6F   $	��Top=�6y   $��77��6�    d� 	IsChecked$
 TrueY�6�   �� 5�      -%   5        $��
textBlock6��5�   i   $��14(�6    $��32��6.   $
��Left=�6:   $��
12,205,0,0q�6U   $��Include Not Corrupted��6{   $	��Top=�6�   $	��141��6�   �� 5�      -&   5        $��
textBlock7��5�   j   $��14(�6    $��32��6.   $
��Left=�6:   $��282,207,0,0q�6U   $��Include Corrupted��6|   $	��Top=�6�   $	��121��6�   �� 5�      -'   5        $��chkIncludeMissing��5�   \   $��30��6   $��Right=�6+   $��0,245,402,0q�6G   $	��Top=�6u   $��77��6�   �� 5�      -(   5        $��chkIncludeNotMissing��5�   l   $��30��6   $
��Left=�6+   $
 TrueY�6F   $��162,245,0,0q�6W   $	��Top=�6�   $��77��6�   �� 5�      -)   5        $��
textBlock8��5�   i   $��14(�6    $��32��6.   $
��Left=�6:   $��
12,243,0,0q�6U   $��Include Not Missing��6{   $	��Top=�6�   $	��141��6�   �� 5�      -*   5        $��
textBlock9��5�   j   $��14(�6    $��32��6.   $
��Left=�6:   $��282,245,0,0q�6U   $��Include Missing��6|   $	��Top=�6�   $	��121��6�   5�      5�      5�      �� 5�   
   -+   5        $��label1��5�   [   $��Label��6   $��33��6    $
��Left=�6,   $��
169,30,0,0q�6G   $	��Top=�6i   $��66��6�   5�      5�      