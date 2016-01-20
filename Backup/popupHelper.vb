Public Class popupHelper

    Public Property selectedCode As String
    Public Property selectedCodeName As String
    Private skipSelectionChanged As Boolean = True
    Public Property currentMode As String
    Public Property TransType As String
    Public Property dbkCode As String

    Private _mode As Integer

    Sub New(pMode As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _mode = pMode
    End Sub

    Private Sub popupHelper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable = Nothing
        Select Case _mode
            Case 0
                Dim ledgerHelper As New LedgerAccountHelper()
                DataGridView1.Columns("VoucherNumber").Visible = False
                DataGridView1.Columns("VoucherDate").Visible = False
                DataGridView1.Columns("VoucherNarration").Visible = False
                DataGridView1.Columns("Amount").Visible = False
                dt = ledgerHelper.GetAccountDetails(String.Empty, True)
            Case 1
                Dim voucherHelper As New VoucherHelper
                DataGridView1.Columns("LedgerCode").Visible = False
                DataGridView1.Columns("AccountName").Visible = False
                dt = voucherHelper.GetVoucherList(currentMode, TransType, dbkCode)
        End Select



        DataGridView1.DataSource = dt
        skipSelectionChanged = False
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        'Try
        '    If Not skipSelectionChanged Then
        '        Dim ledgerSelected As DataRowView = DataGridView1.SelectedRows(0).DataBoundItem
        '        Dim ledgerCode = ledgerSelected("AM_Acc_Cd")
        '        selectedCode = ledgerCode
        '        Me.Close()
        '    End If

        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If Not skipSelectionChanged Then
            If DataGridView1.SelectedRows.Count > 0 Then
                Select Case _mode
                    Case 0
                        selectedCode = DataGridView1.SelectedRows(0).Cells("LedgerCode").Value.ToString
                        selectedCodeName = DataGridView1.SelectedRows(0).Cells("AccountName").Value.ToString
                    Case 1
                        selectedCode = DataGridView1.SelectedRows(0).Cells("VoucherNumber").Value.ToString
                End Select

                Me.Close()

            End If
        End If
    End Sub
End Class