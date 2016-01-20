Public Class SelectDaybookVoucher
    Private _Voucher_Type As String
    Property VoucherType() As String
        Get
            Return _Voucher_Type
        End Get
        Set(ByVal Value As String)
            _Voucher_Type = Value
        End Set
    End Property
    Private Sub SelectDaybookVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(VoucherType) Then
            Dim dbHelper As DayBooksHelper = New DayBooksHelper()
            Dim dt As DataTable = dbHelper.GetDaybooksByType(VoucherType)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    ComboBoxDaybookSelect.DataSource = dt
                    ComboBoxDaybookSelect.DisplayMember = "DisplayName"
                    ComboBoxDaybookSelect.ValueMember = "DM_Dbk_Cd"
                    ComboBoxDaybookSelect.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        InstitutionMasterData.currDaybookCode = ComboBoxDaybookSelect.SelectedValue
        Dim frmVoucherManager As frmAddVoucher = New frmAddVoucher()



    End Sub
End Class