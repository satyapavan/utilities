' Copy and paste the code from this page into your ThisOutlookSession project.

' In Outlook, press Alt+F11 to open the VBA editor and expand Microsoft Outlook Objects then double click on ThisOutlookSession to open it in the editing pane and Ctrl+V to paste the code.

' To use it you must first create a folder under your My Documents named OLAttachments (the code will not create it for you). Then select one or more messages and run the macro to save the attachments. You'll need to set macro security to warn before enabling macros or sign the macro. You can change the folder name or path where the attachments are saved by editing the code.

Public Sub SaveAttachments()
Dim objOL As Outlook.Application
Dim objMsg As Outlook.MailItem 'Object
Dim objAttachments As Outlook.Attachments
Dim objSelection As Outlook.Selection
Dim i As Long
Dim lngCount As Long
Dim strFile As String
Dim strFolderpath As String
Dim strDeletedFiles As String

    ' Get the path to your My Documents folder
    strFolderpath = CreateObject("WScript.Shell").SpecialFolders(16)
    On Error Resume Next

    ' Instantiate an Outlook Application object.
    Set objOL = CreateObject("Outlook.Application")

    ' Get the collection of selected objects.
    Set objSelection = objOL.ActiveExplorer.Selection

' The attachment folder needs to exist
' You can change this to another folder name of your choice

    ' Set the Attachment folder.
    strFolderpath = strFolderpath & "\OLAttachments\"

    ' Check each selected item for attachments.
    For Each objMsg In objSelection

    Debug.Print objMsg.Subject
    
    Set objAttachments = objMsg.Attachments
    lngCount = objAttachments.Count
        
    If lngCount > 0 Then
    
    ' Use a count down loop for removing items
    ' from a collection. Otherwise, the loop counter gets
    ' confused and only every other item is removed.
    
    For i = lngCount To 1 Step -1
    
    ' Get the file name.
    strFile = objAttachments.Item(i).FileName
    
    ' Combine with the path to the Temp folder.
    strFile = strFolderpath & strFile
    
    ' Save the attachment as a file.
    objAttachments.Item(i).SaveAsFile strFile
    
    Debug.Print strFile
    
    Next i
    End If
    
    Next
    
ExitSub:

Set objAttachments = Nothing
Set objMsg = Nothing
Set objSelection = Nothing
Set objOL = Nothing
End Sub
