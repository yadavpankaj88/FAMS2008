Imports System.Configuration
Imports System.Data.SqlClient

Public Class frmLedgerAccountManage


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("connstr").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        Dim str As String = ""

        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "insert into CG_Accounts(AM_Acc_Cd,AM_Acc_Nm,AM_Opn_Bal,AM_LLY_Budg,AM_LLY_Actu,AM_LYr_Budg,AM_LYr_Actu,AM_Cyr_Budg) values('2015','201','12','111','" + txtAccCode.Text + "','" + txtAccName.Text + "','" + ddlOpenBalEff.SelectedValue + "','" + txtLLYBudget.Text + "','" + txtLLYActual.Text + "', '" + txtLYBudget.Text + "','" + txtLYActual.Text + "','" + txtCYBudget.Text + "')"
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data saved successfully")
            clear()
        Catch ex As Exception
            ex.ToString()
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub clear()
        txtAccCode.Text = ""
        txtAccName.Text = ""
        txtCYActual.Text = ""
        txtCYBudget.Text = ""
        txtLLYActual.Text = ""
        txtLLYBudget.Text = ""
        txtLYActual.Text = ""
        txtLYBudget.Text = ""
        ddlOpenBalEff.Text = ""
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Application.Exit()
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click

    End Sub
End Class