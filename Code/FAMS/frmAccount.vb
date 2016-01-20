Imports System.Configuration
Imports System.Data.SqlClient

Public Class frmAccount

    Private Sub txtnet_09_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnet_09.TextChanged

    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        'Dim strConnString As String = ConfigurationManager.ConnectionStrings("connstr").ConnectionString
        'Dim con As New SqlConnection(strConnString)
        'Dim cmd As New SqlCommand()
        'Dim str As String = ""

        'Try
        '    con.Open()
        '    cmd.Connection = con
        '    cmd.CommandText = "insert into CG_Accounts values ('" + txtfinancial_year.Text + "','" + txtbranch_code.Text + "','" + txtledger_code.Text + "','" + txtaccount_code.Text + "','" + txtaccount_nm.Text + "','" + txtcall.Text + "','" + txtopening_blnc.Text + "','" + txtbalance_effect.Text + "','" + txtabsolute_blnc.Text + "','" + txtnet_04.Text + "','" + txtnet_05.Text + "','" + txtnet_06.Text + "','" + txtnet_07.Text + "' , '" + txtnet_08.Text + "','" + txtnet_09.Text + "','" + txtnet_10.Text + "','" + txtnet_11.Text + "','" + txtnet_12.Text + "','" + txtnet_01.Text + "','" + txtnet_02.Text + "','" + txtnet_03.Text + "','" + txtlly_budget.Text + "','" + txtlly_actual.Text + "','" + txtlyr_budget.Text + "','" + txtlyr_actual.Text + "','1','12/12/2015','1','12/12/2015')"
        '    cmd.ExecuteNonQuery()
        '    MessageBox.Show("Data saved successfully")
        '    clear()

        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString())
        'Finally
        '    con.Close()
        'End Try
    End Sub
    Private Sub clear()

        txtabsolute_blnc.Text = ""
        txtnet_01.Text = ""
        txtnet_02.Text = ""
        txtnet_03.Text = ""
        txtnet_04.Text = ""
        txtnet_05.Text = ""
        txtnet_06.Text = ""
        txtnet_07.Text = ""
        txtnet_08.Text = ""
        txtnet_09.Text = ""
        txtnet_10.Text = ""
        txtnet_11.Text = ""
        txtnet_12.Text = ""
        txtledger_code.Text = ""
        txtlly_actual.Text = ""
        txtlly_budget.Text = ""
        txtlyr_actual.Text = ""
        txtlyr_budget.Text = ""
        txtfinancial_year.Text = ""
        txtbalance_effect.Text = ""
        txtbranch_code.Text = ""
        txtaccount_code.Text = ""
        txtaccount_nm.Text = ""
        txtcall.Text = ""
        txtopening_blnc.Text = ""
        txtbalance_effect.Text = ""

    End Sub
End Class