Imports System
Imports System.Data.SqlClient
Imports System.Configuration



Public Class frmCashBankAccountManage

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("connstr").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()

        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "insert into CG_Daybooks(DM_Dbk_Cd,DM_Dbk_Nm,DM_Dbk_Typ,DM_Acc_Cd,DM_Bnk_Nm,DM_Bnk_Brn,DM_Bnk_AcNo,DM_Bnk_OD) values('" & txtdaybook_code.Text & "','" & txtdaybook_nm.Text & "','" & ddldaybook_type.SelectedItem & "','" & ddlacc_code.SelectedItem & "','" & txtbank_nm.Text & "','" & txtbranch_nm.Text & "','" & txtaccount_no.Text & "','" & txtbank_od.Text & "' )"
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data saved successfully")
            clear()
        Catch ex As Exception

            MessageBox.Show(ex.ToString())

        Finally
            con.Close()
        End Try
    End Sub
    Private Sub clear()
        txtaccount_no.Text = ""
        txtbank_nm.Text = ""
        txtbank_od.Text = ""
        txtbranch_nm.Text = ""
        txtdaybook_code.Text = ""
        txtdaybook_nm.Text = ""
        ddlacc_code.Text = ""
        ddldaybook_type.Text = ""
    End Sub

    Private Sub frmCashBankAccountManage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ddldaybook_type.Items.Add("b")
        ddldaybook_type.Items.Add("a")
        ddldaybook_type.Items.Add("v")

        ddlacc_code.Items.Add("abc")
        ddlacc_code.Items.Add("xyz")
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Application.Exit()
    End Sub
End Class