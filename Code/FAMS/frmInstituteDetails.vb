Imports System.Configuration
Imports System.Data.SqlClient

Public Class frmInstituteDetails

    Private Sub frmInstituteDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim comboSource As New Dictionary(Of String, String)()
        'comboSource.Add("UR ", "Undergraduate Regular Section")
        'comboSource.Add("UP ", "Undergraduate Professional Section")
        'comboSource.Add("JR ", "Junior College Section")
        'comboSource.Add("PG ", "Post Graduate Section")
        'comboSource.Add("VO ", "Vocational (MCVC) Section")
        'comboSource.Add("PO ", "Polytechnic")
        'comboSource.Add("EN ", "Engineering College Section")
        'comboSource.Add("PP ", "Pre-Primary Section")
        'comboSource.Add("PR ", "Primary Section")
        'comboSource.Add("SE ", "Secondary Section")
        'comboSource.Add("SO ", "Society Section")
        'comboSource.Add("AB ", "Apex Body")
        'ddltype.DataSource = New BindingSource(comboSource, Nothing)
        'ddltype.DisplayMember = "Value"
        'ddltype.ValueMember = "Key"
        ddltype.Items.Add("Undergraduate Regular Section")
        ddltype.Items.Add("Undergraduate Professional Section")
        ddltype.Items.Add("Junior College Section")
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("connstr").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        Dim str As String = ""

        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "insert into Inst_Master values ('" + txtInstitution_nm.Text + "','" + ddltype.SelectedText + "','" + txtaddress.Text + "','" + txtphone_no.Text + "','" + txtemail.Text + "','" + txtfax.Text + "','" + txtwebsite_address.Text + "','" + txtpan.Text + "','" + txtstn_registration.Text + "','" + txtstnregistration_dt.Text + "','" + txt80G_registration.Text + "','" + txtprincipal_nm.Text + "','" + txtviceprincipal_nm.Text + "' , '" + txtregistration_no.Text + "','" + txtlink_no.Text + "','" + txtclosed_year.Text + "','" + txtsan_date.Text + "','" + txtfam_date.Text + "','" + txtexam_date.Text + "','" + txtpam_date.Text + "','" + txtlim_date.Text + "','" + txtbank_nm.Text + "','" + txtaccount_no.Text + "','" + txtinstitutional_ID.Text + "','" + txtadmission_rct.Text + "','" + txtexam_rct.Text + "','" + txtother_rct.Text + "','" + txtsociety_rct.Text + "' , '" + txtmiscellaneous_rct.Text + "','" + txtfemale_indicator.Text + "','" + txtserver_address.Text + "','" + txtuserID.Text + "','" + txtpassword.Text + "','" + txtmodule_code.Text + "')"
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
        txt80G_registration.Text = ""
        txtaccount_no.Text = ""
        txtaddress.Text = ""
        txtadmission_rct.Text = ""
        txtbank_nm.Text = ""
        txtclosed_year.Text = ""
        txtcode.Text = ""
        txtemail.Text = ""
        txtexam_date.Text = ""
        txtexam_rct.Text = ""
        txtfam_date.Text = ""
        txtfax.Text = ""
        txtfemale_indicator.Text = ""
        txtInstitution_nm.Text = ""
        txtinstitutional_ID.Text = ""
        txtlim_date.Text = ""
        txtlink_no.Text = ""
        txtmiscellaneous_rct.Text = ""
        txtmodule_code.Text = ""
        txtother_rct.Text = ""
        txtpam_date.Text = ""
        txtpan.Text = ""
        txtpassword.Text = ""
        txtphone_no.Text = ""
        txtprincipal_nm.Text = ""
        txtregistration_no.Text = ""
        txtsan_date.Text = ""
        txtserver_address.Text = ""
        txtservice_taxno.Text = ""
        txtsociety_rct.Text = ""
        txtstn_registration.Text = ""
        txtstnregistration_dt.Text = ""
        txtuserID.Text = ""
        txtviceprincipal_nm.Text = ""
        txtwebsite_address.Text = ""
        ddltype.Text = ""
    End Sub

    Private Sub dtpsam_date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpsam_date.ValueChanged
        txtsan_date.Text = dtpsam_date.Value.ToString("yyyy/MM/dd")
    End Sub

    Private Sub dtpfam_date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfam_date.ValueChanged
        txtfam_date.Text = dtpfam_date.Value.ToString("yyyy/MM/dd")
    End Sub

    Private Sub dtpexam_date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpexam_date.ValueChanged
        txtexam_date.Text = dtpexam_date.Value.ToString("yyyy/MM/dd")
    End Sub

    Private Sub dtppam_date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtppam_date.ValueChanged
        txtpam_date.Text = dtppam_date.Value.ToString("yyyy/MM/dd")
    End Sub

    Private Sub dtplim_date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtplim_date.ValueChanged
        txtlim_date.Text = dtplim_date.Value.ToString("yyyy/MM/dd")
    End Sub

  
    Private Sub dtpstn_regi_dt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpstn_regi_dt.ValueChanged
        txtstnregistration_dt.Text = dtpstn_regi_dt.Value.ToString("yyyy/MM/dd")
    End Sub
End Class