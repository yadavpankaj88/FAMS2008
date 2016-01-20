Public Class popupHelper

    Public selectedCode As String
    Public selectedCodeName As String
    Private skipSelectionChanged As Boolean = True
    Public currentMode As String
    Public TransType As String
    Public dbkCode As String

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
                Me.Text = "Select Account"
                Dim ledgerHelper As New LedgerAccountHelper()
                VoucherSelectionGrid.Columns("VoucherNumber").Visible = False
                VoucherSelectionGrid.Columns("VoucherDate").Visible = False
                VoucherSelectionGrid.Columns("VoucherNarration").Visible = False
                VoucherSelectionGrid.Columns("Amount").Visible = False
                dt = ledgerHelper.GetAccountDetails(String.Empty, True)
            Case 1
                Me.Text = "Vouchers That Can Be Edited/Deleted/Confirmed"
                Dim voucherHelper As New VoucherHelper
                VoucherSelectionGrid.Columns("LedgerCode").Visible = False
                VoucherSelectionGrid.Columns("AccountName").Visible = False
                dt = voucherHelper.GetVoucherList(currentMode, TransType, dbkCode)
        End Select


        VoucherSelectionGrid.AutoGenerateColumns = False
        VoucherSelectionGrid.DataSource = dt
        skipSelectionChanged = False
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles VoucherSelectionGrid.SelectionChanged

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

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles VoucherSelectionGrid.CellDoubleClick
        If Not skipSelectionChanged Then
            If VoucherSelectionGrid.SelectedRows.Count > 0 Then
                Select Case _mode
                    Case 0
                        selectedCode = VoucherSelectionGrid.SelectedRows(0).Cells("LedgerCode").Value.ToString
                        selectedCodeName = VoucherSelectionGrid.SelectedRows(0).Cells("AccountName").Value.ToString
                    Case 1
                        selectedCode = VoucherSelectionGrid.SelectedRows(0).Cells("VoucherNumber").Value.ToString
                End Select

                Me.Close()

            End If
        End If
    End Sub
End Class