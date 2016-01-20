Imports System.Configuration
Imports System.Data.SqlClient

Public Class frmVoucherDetails

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    End Sub

    Private Sub frmVoucherDetailsvb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dr As SqlDataReader
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("connstr").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        Dim str As String = ""
        Dim val As Integer = 100
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select VH_Lnk_No,VH_Lnk_Dt,VH_Vch_No,VH_Vch_Dt,VH_Ref_No,VH_Ref_Dt,VH_Amt from CG_Voucher_Header where VH_Lnk_No ='" & val & "'"
            dr = cmd.ExecuteReader()
            While dr.Read()
                txtvoucher_link.Text = dr("VH_Lnk_No").ToString()
                txtvoucher_date.Text = dr("VH_Lnk_Dt").ToString()
                txtconfirmedvoucher.Text = dr("VH_Vch_No").ToString()
                txtconfirmedvoucher_dt.Text = dr("VH_Vch_Dt").ToString()
                txtreferenceno.Text = dr("VH_Ref_No").ToString()
                txtreferencedt.Text = dr("VH_Ref_Dt").ToString()
                txtvoucheramount.Text = dr("VH_Amt").ToString()

            End While
            
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            con.Close()
        End Try


    End Sub
End Class