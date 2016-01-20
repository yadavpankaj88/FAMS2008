Imports System.Configuration
Imports System.Data.SqlClient

Public Class frmUserMaster

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("connstr").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        Dim str As String = ""

        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "insert into User_Master(Usr_Mdl_Cd,Usr_Inst_Typ,Usr_Nm,Usr_Role,Usr_Pwd) values ('" + ddlmodule_code.SelectedItem + "','" + ddltype.SelectedItem + "','" + txtuser_name.Text + "','" + txtuser_role.Text + "','" + txtpassword.Text + "')"
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
        ddlmodule_code.Text = ""
        txtpassword.Text = ""
        txtuser_name.Text = ""
        txtuser_role.Text = ""
        ddltype.Text = ""
    End Sub

    Private Sub frmUserMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ddlmodule_code.Items.Add("SAM")
        ddlmodule_code.Items.Add("SAT")
        ddlmodule_code.Items.Add("EXAM")
        ddlmodule_code.Items.Add("FAM")
        ddlmodule_code.Items.Add("PAM ")
        ddlmodule_code.Items.Add("LiM ")
        ddlmodule_code.Items.Add("FADS ")

        ddltype.Items.Add("UR ")
        ddltype.Items.Add("UP ")
        ddltype.Items.Add("JR ")
        ddltype.Items.Add("PG ")
        ddltype.Items.Add("VO ")
    End Sub
End Class