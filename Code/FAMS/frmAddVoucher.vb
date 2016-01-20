Imports System.Configuration
Imports System.Data.SqlClient
Public Class frmAddVoucher
    Public link_no As Integer = 0
    Private Sub frmAddVoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        ddlcr_dr.Items.Add("cr")
        ddlcr_dr.Items.Add("dr")

        populategridview()
        KeyPreview = True

    End Sub

    Private Sub TextBoxRefNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtreferenceno.TextChanged

    End Sub

    Private Sub ButtonSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Dim frm As frmFAMSMain
        frm = Me.MdiParent
        Dim type As String = ""
        Dim val As Integer = frm.chkvalue
        'Dim entities As New FAMEntities()
        If val = 10 Then
            type = "CR"
        ElseIf val = 20 Then
            type = "CP"

        ElseIf val = 30 Then
            type = "BR"
        ElseIf val = 40 Then
            type = "BP"
        ElseIf val = 50 Then
            type = "CC"
        Else
            type = " JV"
        End If
        txtlinkvoucherdt.Text = dtplinkVoucherdt.Value.ToString("yyyy/MM/dd")
        txtchequedt.Text = dtpchequedt.Value.ToString("yyyy/MM/dd")
        txtreferencedt.Text = dtpreferencedt.Value.ToString("yyyy/MM/dd")
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("connstr").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        Dim str As String = ""

        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "insert into CG_Voucher_Header(VH_Fin_Yr,VH_Inst_Cd,VH_Inst_Typ,VH_Brn_Cd,VH_Lnk_No,VH_Pty_Nm,VH_Dbk_Cd,VH_Chq_No,VH_Ref_No,VH_Cr_Dr,VH_Amt,VH_Trn_Typ,VH_Lnk_Dt,VH_Chq_Dt,VH_Ref_Dt) values('2014','111','cp','001','100','" + txtpayeenm.Text + "','" + ddldaybookcode.SelectedValue + "','" + txtchequeno.Text + "','" + txtreferenceno.Text + "','" + ddlcr_dr.SelectedItem + "','" + txtamount.Text + "','" & type & "','" + txtlinkvoucherdt.Text + "','" + txtchequedt.Text + "','" + txtreferencedt.Text + "')"
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data saved successfully")
            clear()
            populategridview()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Application.Exit()
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("connstr").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        Dim str As String = ""

        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "delete from CG_Voucher_Header "
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ex.ToString()
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub populategridview()
        Dim frm As frmFAMSMain
        frm = Me.MdiParent
        Dim val As Integer = frm.chkvalue
        Dim type As String = ""
        If val = 10 Then
            type = "CR"
        ElseIf val = 20 Then
            type = "CP"

        ElseIf val = 30 Then
            type = "BR"
        ElseIf val = 40 Then
            type = "BP"
        ElseIf val = 50 Then
            type = "CC"
        Else
            type = " JV"
        End If
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("connstr").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim ds As New DataTable
        Dim cmd As New SqlCommand()
        Dim str As String = "select *  from CG_Voucher_Header where VH_Trn_Typ= '" & type & "'"
        Try
            'con.Open()          
            Dim da As SqlDataAdapter = New SqlDataAdapter(str, con)
            da.Fill(ds)
            DataGridView1.DataSource = ds
        Catch ex As Exception
            ex.ToString()

        End Try

    End Sub
    Private Sub clear()
        txtamount.Text = ""
        txtchequeno.Text = ""
        txtpayeenm.Text = ""
        txtreferenceno.Text = ""
        txtlinkvoucherdt.Text = ""
        txtchequedt.Text = ""
        txtreferencedt.Text = ""
        ddlcr_dr.Text = ""
        ddldaybookcode.Text = ""
    End Sub

    Private Sub dtplinkVoucherdt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtplinkVoucherdt.ValueChanged
        txtlinkvoucherdt.Text = dtplinkVoucherdt.Value.ToString("yyyy/MM/dd")
    End Sub

    Private Sub dtpchequedt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpchequedt.ValueChanged
        txtchequedt.Text = dtpchequedt.Value.ToString("yyyy/MM/dd")
    End Sub

    Private Sub dtpreferencedt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpreferencedt.ValueChanged
        txtreferencedt.Text = dtpreferencedt.Value.ToString("yyyy/MM/dd")
    End Sub

    
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txtlinkvoucherdt.Text = DataGridView1.CurrentRow.Cells(5).EditedFormattedValue()
        txtpayeenm.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString()
        txtchequeno.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString()
        txtchequedt.Text = DataGridView1.CurrentRow.Cells(12).EditedFormattedValue()
        txtreferenceno.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString()
        txtreferencedt.Text = DataGridView1.CurrentRow.Cells(15).EditedFormattedValue()
        'ddlcr_dr.Text = DataGridView1.CurrentRow.Cells(12).Value.ToString()
        txtamount.Text = DataGridView1.CurrentRow.Cells(19).Value.ToString()
        link_no = DataGridView1.CurrentRow.Cells(4).EditedFormattedValue()

    End Sub

    Private Sub frmAddVoucher_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.S And e.Modifiers = Keys.Control Then
                ButtonSave.PerformClick()
            End If
        End If

        If e.Control Then
            If e.KeyCode = Keys.E And e.Modifiers = Keys.Control Then
                btncancel.PerformClick()
            End If
        End If
    End Sub
End Class