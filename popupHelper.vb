Public Class popupHelper

    Public selectedCode As String
    Public selectedCodeName As String
    Private skipSelectionChanged As Boolean = True
    Public currentMode As String
    Public TransType As String
    Public dbkCode As String
    Public selectedIndex As String

    Private _mode As Integer
    Private _voucherType As String

    Sub New(ByVal pMode As Integer, ByVal pvoucherType As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _mode = pMode
        _voucherType = pvoucherType
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
                dt = voucherHelper.GetVoucherList(currentMode, TransType, dbkCode, _voucherType)
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

    Private Sub RowSelected(ByVal isEnter As Boolean)
        If Not skipSelectionChanged Then
            If VoucherSelectionGrid.SelectedRows.Count > 0 Then
                Dim index = VoucherSelectionGrid.SelectedRows(0).Index
                If (isEnter) Then
                    index = selectedIndex
                End If
                Select Case _mode
                    Case 0
                        selectedCode = VoucherSelectionGrid.Rows(index).Cells("LedgerCode").Value.ToString
                        selectedCodeName = VoucherSelectionGrid.Rows(index).Cells("AccountName").Value.ToString
                    Case 1
                        selectedCode = VoucherSelectionGrid.Rows(index).Cells("VoucherNumber").Value.ToString
                End Select

                Me.Close()

            End If
        End If
    End Sub


    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles VoucherSelectionGrid.CellDoubleClick
        RowSelected(False)
    End Sub

    Public lastkey As String

    Private Sub VoucherSelectionGrid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles VoucherSelectionGrid.KeyPress
        If (e.KeyChar = ChrW(Keys.Enter)) Then
            RowSelected(True)
        Else
            Dim input = StrConv(e.KeyChar.ToString(), VbStrConv.Uppercase)
            lastkey += input
            Dim found As Boolean
            If StrConv(VoucherSelectionGrid.CurrentCell.Value.ToString.Substring(0, 1), VbStrConv.Uppercase) = input Then
                Dim curIndex = VoucherSelectionGrid.CurrentRow.Index
                If curIndex < VoucherSelectionGrid.Rows.Count - 1 Then
                    VoucherSelectionGrid.ClearSelection()
                    curIndex += 1

                    If _mode = 1 Then
                        VoucherSelectionGrid.CurrentCell = VoucherSelectionGrid.Rows(curIndex).Cells("VoucherNarration")
                    Else
                        VoucherSelectionGrid.CurrentCell = VoucherSelectionGrid.Rows(curIndex).Cells("AccountName")
                    End If

                    VoucherSelectionGrid.Rows(curIndex).Selected = True
                End If
            Else
                dgv_jumpRecord(lastkey, found)

                If Not found Then
                    lastkey = input
                    dgv_jumpRecord(lastkey, found)
                End If
            End If
        End If
    End Sub

    Public Sub dgv_jumpRecord(ByVal lastkey As String, ByRef found As Boolean)

        For i As Integer = 0 To (VoucherSelectionGrid.Rows.Count) - 1
            Dim rowText As String = String.Empty
            If _mode = 1 Then
                If VoucherSelectionGrid.Rows(i).Cells("VoucherNarration").Value <> Nothing Then
                    rowText = VoucherSelectionGrid.Rows(i).Cells("VoucherNarration").Value.ToString
                End If
            Else
                If VoucherSelectionGrid.Rows(i).Cells("AccountName").Value <> Nothing Then
                    rowText = VoucherSelectionGrid.Rows(i).Cells("AccountName").Value.ToString
                End If
            End If

                If StrConv(rowText.ToString(), VbStrConv.Uppercase).StartsWith(lastkey) Then
                VoucherSelectionGrid.ClearSelection()
                If _mode = 1 Then
                    VoucherSelectionGrid.CurrentCell = VoucherSelectionGrid.Rows(i).Cells("VoucherNarration")
                Else
                    VoucherSelectionGrid.CurrentCell = VoucherSelectionGrid.Rows(i).Cells("AccountName")
                End If
                VoucherSelectionGrid.Rows(i).Selected = True
                found = True
                Exit Sub
            End If

        Next
        found = False

    End Sub

    Private Sub VoucherSelectionGrid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles VoucherSelectionGrid.KeyDown
        If e.KeyCode = Keys.Enter Then
            selectedIndex = VoucherSelectionGrid.Rows.GetLastRow(DataGridViewElementStates.Selected)
        End If
    End Sub
End Class