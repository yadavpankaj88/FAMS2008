
Imports System.Data.Sql

Public Class SA4_Certificate
    Private c As DbConnect = New DbConnect()
    Dim typ As String = ""
    Dim sql As String = ""
    Dim dc As DataTable


 

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rpt As New SA4_certificateList
        'Dim j As Integer

        typ = ComboBoxCertificate.Text.Trim()
        dc.Clear()
        'If (x_Inst_typ = "UP") Then
        '    j = 25
        'Else
        '    j = 26
        'End If


        sql = "select STU_FULL_NM AS STU_FL_NM,stu_uid_no as inst_typ,BCDC_NM,CDM_CLS_NM AS CLASS_NAME,STU_AMT_36 AS BCDC_PAYABLE,ISNULL(STU_AMT_26,0) AS REGISTERED_FEE ,SUM(ISNULL(RCT_AMT_26,0)) AS REG_PAID,SUM(ISNULL(rct_amt_36,0)) AS BCDC_PAID,((ISNULL(STU_AMT_36,0)+ISNULL(STU_AMT_26,0))-(SUM(ISNULL(RCT_AMT_26,0))+SUM(ISNULL(rct_amt_36,0)))) AS BCDC_BAL,stu_caste,stu_catg FROM UR_stud_master,UG_CERT_DIPL_COURSES,UR_cls_div_master,UR_Rct_master WHERE BCDC_nm='" & typ & "' AND BCDC_CD=STU_BCDC_CD AND STU_CLDIV_CD=CDM_CD AND RCT_UID_NO=STU_UID_NO GROUP BY STU_FULL_NM,stu_uid_no,BCDC_NM,CDM_CLS_NM ,STU_AMT_36 ,STU_AMT_26,stu_caste,stu_catg UNION select STU_FULL_NM AS STU_FL_NM,stu_uid_no as inst_typ,BCDC_NM,CDM_CLS_NM AS CLASS_NAME,STU_AMT_36 AS BCDC_PAYABLE,ISNULL(STU_AMT_25,0) AS REGISTERED_FEE ,SUM(ISNULL(RCT_AMT_25,0)),SUM(ISNULL(rct_amt_36,0)) AS BCDC_PAID,(ISNULL(STU_AMT_36,0)+(ISNULL(STU_AMT_25,0))-(SUM(ISNULL(RCT_AMT_25,0))+SUM(ISNULL(rct_amt_36,0)))) AS BCDC_BAL,stu_caste,stu_catg FROM UP_stud_master,UG_CERT_DIPL_COURSES,UP_cls_div_master,UP_Rct_master WHERE BCDC_nm='" & typ & "' AND BCDC_CD=STU_BCDC_CD AND STU_CLDIV_CD=CDM_CD AND RCT_UID_NO=STU_UID_NO GROUP BY STU_FULL_NM,stu_uid_no,BCDC_NM,CDM_CLS_NM ,STU_AMT_36 ,STU_AMT_25,stu_caste,stu_catg order by cdm_CLS_nm,stu_full_nm"

        dc = c.populateDataTable(sql)
        If (dc.Rows.Count = 0) Then
            MsgBox("NO DATA FOUND")
        Else
            rpt.SetDataSource(dc)
            rpt.SetParameterValue("CERT_NM", "STUDENTS FOR:" & typ)
            rpt = globalx.RptHdrParam(rpt, "Outstanding Fees Statement")

            Report.CryRptVwr.ReportSource = rpt
            Report.MdiParent = MDI
            Report.Dock = DockStyle.Fill
            Report.Show()
        End If
    End Sub

    Private Sub SA4_Certificate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dc = c.populateDataTable("select distinct BCDC_NM from UG_CERT_DIPL_COURSES")
        'MsgBox("select distinct " & colNm & " from " & x_Inst_Typ & "_stud_master order by " & colNm & dc.Rows.Count)
        If dc.Rows.Count > 0 Then
            For i = 0 To dc.Rows.Count - 1
                ComboBoxCertificate.Items.Add(dc.Rows(i).Item(0))
            Next
        End If
        ComboBoxCertificate.SelectedIndex = 0
        ComboBoxCertificate.AutoCompleteMode = AutoCompleteMode.Suggest
        ComboBoxCertificate.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub
End Class