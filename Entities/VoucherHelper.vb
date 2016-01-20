Imports System.Globalization

Public Class VoucherHelper

    Public Function GetEmptyVoucherDetail() As DataTable
        Dim query As String = "select LTRIM(RTRIM(VD_Acc_Cd)) as 'LedgerAccount','' As 'PartyName',VD_Amt as 'Amount'" & _
                                ",LTRIM(RTRIM(VD_Ref_No)) as 'RefNo',VD_Ref_Dt as 'RefDate'," & _
                                " LTRIM(RTRIM(VD_Narr)) as 'VoucherDesc' from Voucher_Detail where VD_Lnk_No='-1'"
        Dim datahelper = New DataHelper()
        Dim dt As DataTable = Nothing
        dt = datahelper.ExecuteQuery(query, CommandType.Text)

        Return dt


    End Function

    Public Sub SaveVoucherHeader(ByVal voucherHead As VoucherHeader)
        Dim Query As String = "If(Exists(select 'x' from " + InstitutionMasterData.XInstType + "_Voucher_Header where VH_Lnk_No=@VH_Lnk_No)) " & _
        " Begin " & _
        "Update " + InstitutionMasterData.XInstType + "_Voucher_Header Set " & _
        "VH_Lnk_Dt=@VH_Lnk_Dt" & _
        ",VH_Pty_Nm=@VH_Pty_Nm" & _
        ",VH_Chq_No=@VH_Chq_No" & _
        ",VH_Chq_Dt=@VH_Chq_Dt" & _
        ",VH_Ref_No=@VH_Ref_No" & _
        ",VH_Ref_Dt=@VH_Ref_Dt" & _
        ",VH_Amt=@VH_Amt" & _
        ",VH_Cr_Dr=@VH_Cr_Dr" & _
        ",VH_Abs_Amt=@VH_Abs_Amt" & _
        ",VH_Upd_By=@VH_Upd_By" & _
        ",VH_Upd_Dt=GetDate()" & _
        "where VH_Lnk_No=@VH_Lnk_No" & _
        " End " & _
        " Else " & _
        "Insert into " + InstitutionMasterData.XInstType + "_Voucher_Header(VH_Fin_Yr,VH_Inst_Cd,VH_Inst_Typ,VH_Brn_Cd,VH_Lnk_No,VH_Lnk_Dt,VH_Pty_Nm," & _
        "VH_Dbk_Cd,VH_Trn_Typ,VH_Chq_No,VH_Chq_Dt,VH_Ref_No,VH_VCH_Ref_No,VH_Ref_Dt,VH_Lgr_Cd,VH_Acc_Cd,VH_Amt,VH_Cr_Dr,VH_ABS_Amt,VH_Ent_Dt," & _
        "VH_Ent_By)values(@VH_Fin_Yr,@VH_Inst_Cd,@VH_Inst_Typ,@VH_Brn_Cd,@VH_Lnk_No,@VH_Lnk_Dt,@VH_Pty_Nm,@VH_Dbk_Cd,@VH_Trn_Typ," & _
        "@VH_Chq_No,@VH_Chq_Dt,@VH_Ref_No,@VH_VCH_Ref_No,@VH_Ref_Dt,@VH_Lgr_Cd,@VH_Acc_Cd,@VH_Amt,@VH_Cr_Dr,@VH_Abs_Amt,GetDate(),@VH_Ent_By)" & _
        " delete from " + InstitutionMasterData.XInstType + "_Voucher_Detail where Vd_Lnk_No=@VH_Lnk_No AND Vd_Inst_Cd=@VH_Inst_Cd"

        Dim dataHelper As DataHelper = New DataHelper()

        Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
        params.Add("@VH_Fin_Yr", voucherHead.VH_Fin_Yr)
        params.Add("@VH_Inst_Cd", voucherHead.VH_Inst_Cd)
        params.Add("@VH_Inst_Typ", voucherHead.VH_Inst_Typ)
        params.Add("@VH_Brn_Cd", voucherHead.VH_Brn_Cd)
        params.Add("@VH_Lnk_No", voucherHead.VH_Lnk_No)
        params.Add("@VH_Lnk_Dt", voucherHead.VH_Lnk_Dt.ToString("MM-dd-yyyy"))
        params.Add("@VH_Pty_Nm", voucherHead.VH_Pty_Nm.Trim)
        params.Add("@VH_Dbk_Cd", voucherHead.VH_Dbk_Cd)
        params.Add("@VH_Trn_Typ", voucherHead.VH_Trn_Typ)
        params.Add("@VH_Chq_No", IIf(String.IsNullOrEmpty(voucherHead.VH_Chq_No), DBNull.Value, voucherHead.VH_Chq_No))
        If voucherHead.VH_Chq_Dt.HasValue And Not String.IsNullOrEmpty(voucherHead.VH_Chq_No) Then
            params.Add("@VH_Chq_Dt", voucherHead.VH_Chq_Dt.Value.ToString("MM-dd-yyyy"))
        Else
            params.Add("@VH_Chq_Dt", DBNull.Value)
        End If

        params.Add("@VH_Ref_No", voucherHead.VH_Ref_No)
        params.Add("@VH_VCH_Ref_No", voucherHead.VH_VCH_Ref_No)
        If voucherHead.VH_Ref_Dt.HasValue Then
            params.Add("@VH_Ref_Dt", voucherHead.VH_Ref_Dt.Value.ToString("MM-dd-yyyy"))
        Else
            params.Add("@VH_Ref_Dt", DBNull.Value)
        End If

        params.Add("@VH_Lgr_Cd", voucherHead.VH_Lgr_Cd)
        params.Add("@VH_Acc_Cd", voucherHead.VH_Acc_Cd)

        If voucherHead.VH_Cr_Dr = "cr" Then
            voucherHead.VH_Amt = -voucherHead.VH_Amt
        End If

        params.Add("@VH_Amt", voucherHead.VH_Amt)
        params.Add("@VH_Cr_Dr", voucherHead.VH_Cr_Dr)
        params.Add("@VH_Abs_Amt", voucherHead.VH_ABS_Amt)
        params.Add("@VH_Ent_By", InstitutionMasterData.XUsrId)
        params.Add("@VH_Upd_By", InstitutionMasterData.XUsrId)
        dataHelper.ExecuteNonQuery(Query, CommandType.Text, params)



    End Sub

    Public Sub DeleteConfirmedVoucher(ByVal linkvoucherno As String)
        Dim deleteQuery As String
        Try
            deleteQuery = "delete from " + InstitutionMasterData.XInstType + "_Ledger where Lgr_Lnk_No='" + linkvoucherno + "'"
            Dim dataHelper As DataHelper = New DataHelper()
            dataHelper.ExecuteNonQuery(deleteQuery, CommandType.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteUnConfirmedVouchers(ByVal linkVoucherNumber As String)
        Dim deleteQuery As String
        deleteQuery = "Begin Tran " & _
            "Begin Try " & _
            "Delete from " + InstitutionMasterData.XInstType + "_Voucher_Header where VH_Lnk_No=@LnkNo " & _
                      " Delete from " + InstitutionMasterData.XInstType + "_Voucher_Detail where VD_Lnk_No=@LnkNo " & _
                      "Commit " & _
            "End Try " & _
            "Begin Catch " & _
            "RollBack " & _
            "End Catch "

        Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
        params.Add("@LnkNo", linkVoucherNumber)
        Dim dataHelper As DataHelper = New DataHelper()
        dataHelper.ExecuteNonQuery(deleteQuery, CommandType.Text, params)


    End Sub

    Public Sub SaveVoucherDetail(ByVal voucherdetail As VoucherDetails)
        'Dim detailSaveQuery = "If(Exists(select 'x' from " + InstitutionMasterData.XInstType + "_Voucher_Detail where VD_Lnk_No=@VD_Lnk_No and VD_Seq_No=@VD_Seq_No)) " & _
        '" Begin " & _
        '"Update " + InstitutionMasterData.XInstType + "_Voucher_Detail Set VD_Ref_No=@VD_Ref_No,VD_Ref_Dt=@VD_Ref_Dt,VD_Narr=@VD_Narr,VD_Acc_Cd=@VD_Acc_Cd,VD_Amt=@VD_Amt," & _
        '" VD_Cr_Dr=@VD_Cr_Dr,VD_Abs_Amt=@VD_Abs_Amt,VD_Upd_By=@VD_Upd_By,VD_Upd_Dt=GetDate() where VD_Lnk_No=@VD_Lnk_No and VD_Seq_No=@VD_Seq_No" & _
        '" End " & _
        '" Else " & _
        '    "Insert into " + InstitutionMasterData.XInstType + "_Voucher_Detail(VD_Fin_Yr,VD_Inst_Cd,VD_Inst_Typ,VD_Brn_Cd,VD_Lnk_No,VD_Dbk_Cd,VD_Trn_Typ,VD_Seq_No,VD_Ref_No,VD_VCH_Ref_No,VD_Ref_Dt,VD_Narr,VD_Lgr_Cd,VD_Acc_Cd,VD_Amt,VD_Cr_Dr," & _
        '                       "VD_ABS_Amt,VD_Ent_By,VD_Ent_Dt)values(@VD_Fin_Yr,@VD_Inst_Cd,@VD_Inst_Typ,@VD_Brn_Cd,@VD_Lnk_No,@VD_Dbk_Cd,@VD_Trn_Typ,@VD_Seq_No,@VD_Ref_No,@VD_VCH_Ref_No,@VD_Ref_Dt,@VD_Narr,@VD_Lgr_Cd,@VD_Acc_Cd,@VD_Amt,@VD_Cr_Dr," & _
        '                        "@VD_Abs_Amt,@VD_Ent_By,GETDATE())"

        Dim detailSaveQuery = "Insert into " + InstitutionMasterData.XInstType + "_Voucher_Detail(VD_Fin_Yr,VD_Inst_Cd,VD_Inst_Typ,VD_Brn_Cd,VD_Lnk_No,VD_Dbk_Cd,VD_Trn_Typ,VD_Seq_No,VD_Ref_No,VD_VCH_Ref_No,VD_Ref_Dt,VD_Narr,VD_Lgr_Cd,VD_Acc_Cd,VD_Amt,VD_Cr_Dr," & _
                       "VD_ABS_Amt,VD_Ent_By,VD_Ent_Dt,VD_Upd_By,VD_Upd_Dt)values(@VD_Fin_Yr,@VD_Inst_Cd,@VD_Inst_Typ,@VD_Brn_Cd,@VD_Lnk_No,@VD_Dbk_Cd,@VD_Trn_Typ,@VD_Seq_No,@VD_Ref_No,@VD_VCH_Ref_No,@VD_Ref_Dt,@VD_Narr,@VD_Lgr_Cd,@VD_Acc_Cd,@VD_Amt,@VD_Cr_Dr," & _
                        "@VD_Abs_Amt,@VD_Ent_By,GETDATE(),@VD_Upd_By,GetDate())"

        Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
        params.Add("@VD_Fin_Yr", voucherdetail.VD_Fin_Yr)
        params.Add("@VD_Inst_Cd", voucherdetail.VD_Inst_Cd)
        params.Add("@VD_Inst_Typ", InstitutionMasterData.XInstType)
        params.Add("@VD_Brn_Cd", voucherdetail.VD_Brn_Cd)
        params.Add("@VD_Lnk_No", voucherdetail.VD_Lnk_No)
        params.Add("@VD_Dbk_Cd", voucherdetail.VD_Dbk_Cd)
        params.Add("@VD_Trn_Typ", voucherdetail.VD_Trn_Typ)
        params.Add("@VD_Seq_No", voucherdetail.VD_Seq_No)
        params.Add("@VD_Ref_No", voucherdetail.VD_Ref_No)
        If voucherdetail.VD_Ref_Dt.HasValue Then
            params.Add("@VD_Ref_Dt", voucherdetail.VD_Ref_Dt.Value.ToString("MM-dd-yyyy"))
        Else
            params.Add("@VD_Ref_Dt", DBNull.Value)
        End If

        params.Add("@VD_Narr", voucherdetail.VD_Narr.Trim)
        params.Add("@VD_Lgr_Cd", voucherdetail.VD_Lgr_Cd)
        params.Add("@VD_Acc_Cd", voucherdetail.VD_Acc_Cd)
        params.Add("@VD_Amt", voucherdetail.VD_Amt)
        params.Add("@VD_Cr_Dr", voucherdetail.VD_Cr_Dr)
        params.Add("@VD_Abs_Amt", voucherdetail.VD_ABS_Amt)
        params.Add("@VD_Ent_By", InstitutionMasterData.XUsrId)
        params.Add("@VD_VCH_Ref_No", voucherdetail.VD_Vch_Ref_No)
        params.Add("@VD_Upd_By", InstitutionMasterData.XUsrId)

        Dim datahelper As DataHelper = New DataHelper()
        datahelper.ExecuteNonQuery(detailSaveQuery, CommandType.Text, params)

    End Sub

    Public Sub GetVoucherHeader(ByVal transType As String, ByVal daybookCode As String, ByVal voucherLinkNumber As String, ByRef voucherHeader As VoucherHeader, ByRef dtVoucherDetails As DataTable)
        Dim query As String = String.Empty
        Dim dtVoucherHeader As DataTable = Nothing
        Try
            query = String.Format("Select LTRIM(RTRIM([VH_Ref_No])) AS [VH_Ref_No],[VH_Lnk_Dt],[VH_Ref_Dt],[VH_VCH_Dt],LTRIM(RTRIM([VH_VCH_No])) AS [VH_VCH_No],LTRIM(RTRIM([VH_VCH_Ref_No])) AS [VH_VCH_Ref_No],LTRIM(RTRIM([VH_Chq_No])) AS [VH_Chq_No],[VH_Chq_Dt],[VH_Amt],[VH_Abs_Amt],LTRIM(RTRIM([VH_Cr_Dr])) AS [VH_Cr_Dr],LTRIM(RTRIM([VH_Pty_Nm])) AS [VH_Pty_Nm] from  " + InstitutionMasterData.XInstType + "_Voucher_Header where [VH_Lnk_No]='{0}' and [VH_Dbk_Cd]='{1}' and [VH_Trn_Typ]='{2}' and VH_Fin_Yr=" + InstitutionMasterData.XFinYr + " ", voucherLinkNumber, daybookCode, transType)
            Dim dataHelper As DataHelper = New DataHelper()
            dtVoucherHeader = dataHelper.ExecuteQuery(query, CommandType.Text, Nothing)
            If dtVoucherHeader.Rows.Count > 0 Then
                For Each item As DataRow In dtVoucherHeader.Rows
                    If voucherHeader Is Nothing Then
                        voucherHeader = New VoucherHeader()
                    End If
                    voucherHeader.VH_Ref_No = item("VH_Ref_No").ToString()

                    voucherHeader.VH_Ref_Dt = Convert.ToDateTime(item("VH_Ref_Dt").ToString())
                    voucherHeader.VH_Lnk_Dt = Convert.ToDateTime(item("VH_Lnk_Dt").ToString())
                    voucherHeader.VH_ABS_Amt = item("VH_Abs_Amt")
                    If item("VH_Chq_No") IsNot Nothing Then
                        voucherHeader.VH_Chq_No = item("VH_Chq_No").ToString()
                    End If

                    If item("VH_Chq_Dt") IsNot Nothing Then
                        voucherHeader.VH_Chq_Dt = Convert.ToDateTime(item("VH_Chq_Dt").ToString())
                        If (voucherHeader.VH_Chq_Dt.Value = Convert.ToDateTime("1/1/1900")) Then
                            voucherHeader.VH_Chq_Dt = Nothing
                        End If
                    End If
                    voucherHeader.VH_Pty_Nm = item("VH_Pty_Nm").ToString()
                    voucherHeader.VH_Amt = Convert.ToDecimal(item("VH_Amt").ToString)
                    voucherHeader.VH_Cr_Dr = item("VH_Cr_Dr").ToString()

                    If item("VH_VCH_Dt") IsNot DBNull.Value Then
                        voucherHeader.VH_VCH_Dt = item("VH_VCH_Dt").ToString()
                    End If

                    voucherHeader.VH_VCH_Ref_No = item("VH_VCH_Ref_No").ToString()

                    If item("VH_VCH_No") IsNot DBNull.Value Then
                        voucherHeader.VH_VCH_NO = item("VH_VCH_No").ToString()

                    End If
                Next
            End If
            query = String.Format("Select LTRIM(RTRIM(VD_Acc_Cd)) as 'LedgerAccount',LTRIM(RTRIM(ac.Am_Acc_Nm)) as 'AccountName',VD_ABS_Amt as 'Amount',LTRIM(RTRIM(VD_Cr_Dr)) as 'CrDr'" & _
                                ",LTRIM(RTRIM(VD_Ref_No)) as 'RefNo',VD_Ref_Dt as 'RefDate'," & _
                                " LTRIM(RTRIM(VD_Narr)) as 'VoucherDesc',LTRIM(RTRIM(VD_Seq_No)) as [VD_Seq_No] from " + InstitutionMasterData.XInstType + "_Voucher_Detail vd Inner Join " + InstitutionMasterData.XInstType + "_Accounts ac on vd.VD_Acc_Cd=ac.Am_Acc_Cd  where [VD_Lnk_No]='{0}' and [VD_Dbk_Cd]='{1}' and [VD_Trn_Typ]='{2}' ORDER BY [VD_Seq_No] Asc", voucherLinkNumber, daybookCode, transType)
            dtVoucherDetails = dataHelper.ExecuteQuery(query, CommandType.Text, Nothing)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function GetVoucherList(ByVal currentMode As String, ByVal transType As String, ByVal daybookCode As String) As DataTable
        Dim query As String = String.Empty
        Dim dtVoucherList As DataTable = Nothing
        Try
            If currentMode.ToLower() = "view" Then
                query = String.Format("select LTrim(RTrim(VH_Lnk_No)) AS [VH_Lnk_No] ,VH_Lnk_Dt,LTrim(RTrim(VH_Pty_Nm)) AS [VH_Pty_Nm],VH_ABS_Amt from " + InstitutionMasterData.XInstType + "_Voucher_Header " & _
                    " where VH_Trn_Typ='{0}' and VH_Inst_Cd='{1}' and VH_Inst_Typ='{2}' and VH_Dbk_Cd='{3}' ORDER BY VH_Lnk_Dt,VH_Lnk_No", transType, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, daybookCode)
            Else
                query = String.Format("select LTrim(RTrim(VH_Lnk_No)) AS [VH_Lnk_No],VH_Lnk_Dt,LTRIM(RTRIM(VH_Pty_Nm)) AS [VH_Pty_Nm],VH_ABS_Amt from " + InstitutionMasterData.XInstType + "_Voucher_Header " & _
                    " where VH_Trn_Typ='{0}' and VH_Inst_Cd='{1}' and VH_Inst_Typ='{2}' and VH_Dbk_Cd='{3}' and VH_Conf_Dt is null and VH_Conf_By is null ORDER BY VH_Lnk_Dt,VH_Lnk_No", transType, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, daybookCode)
            End If

            Dim dataHelper As DataHelper = New DataHelper()
            Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
            params.Add("@tranType", transType)
            dtVoucherList = dataHelper.ExecuteQuery(query, CommandType.Text, params)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtVoucherList
    End Function

    Public Function GetNextVoucherNumber(ByVal voucherDate As DateTime, ByVal dbkCode As String) As DataTable
        Dim query As String = String.Empty
        query = "Declare @month as int; " & _
        "Declare @date as int; " & _
        "set @month=MONTH(GetDate()); " & _
        "set @date=DAY(GetDate()); " & _
        "declare @nextVoucherNumber as int; " & _
        "If EXISTS(select 1 from " + InstitutionMasterData.XInstType + "_Voucher_Header where VH_Dbk_Cd=@dbkCd AND VH_VCH_No IS NOT NULL)" & _
        "set @nextVoucherNumber=(SELECT REPLACE(STR(MAX(RIGHT(VH_Vch_No, 4)) + 1, 4), SPACE(1), '0')  from " + InstitutionMasterData.XInstType + "_Voucher_Header where VH_Dbk_Cd=@dbkCd AND VH_VCH_No IS NOT NULL) " & _
        "ELSE " & _
        "set @nextVoucherNumber=1" & _
        "Declare @voucherNumber as varchar(8); " & _
        "Set @voucherNumber=REPLACE(STR(@month, 2), SPACE(1), '0') " & _
        "+REPLACE(STR(@date, 2), SPACE(1), '0') " & _
        "+REPLACE(STR(Convert(varchar(10),@nextVoucherNumber), 4), SPACE(1), '0') " & _
        "Select @voucherNumber as 'nextVoucherNumber',@nextVoucherNumber as 'NextCount' "

        Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
        params.Add("@dbkCd", dbkCode)
        Dim dt As DataTable = New DataTable()
        Dim dHelper As DataHelper = New DataHelper()
        dt = dHelper.ExecuteQuery(query, CommandType.Text, params)

        Return dt
    End Function

    Sub ConfirmVoucher(ByVal linkVoucherNo As String, ByVal voucherDate As DateTime, ByVal confirmVoucherNumber As String)
        Dim query As String = String.Empty

        query = "Update " + InstitutionMasterData.XInstType + "_Voucher_Header set VH_Vch_No=@voucherNumber,VH_VCH_Dt=@vchDt,VH_Conf_Dt=GetDate(),VH_Conf_By=@CnfBy " & _
          "where VH_Lnk_No=@linkNo " & _
          "Update " + InstitutionMasterData.XInstType + "_Voucher_Detail set VD_Vch_No=@voucherNumber,VD_Conf_Dt=GetDate(),VD_Conf_By=@CnfBy " & _
          "where VD_Lnk_No=@linkNo "


        Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
        params.Add("@voucherNumber", confirmVoucherNumber)
        params.Add("@linkNo", linkVoucherNo)
        params.Add("@CnfBy", InstitutionMasterData.XUsrId)
        params.Add("@vchDt", voucherDate.ToString("yyyy-MM-dd"))
        Dim dataHelper As DataHelper = New DataHelper()
        dataHelper.ExecuteNonQuery(query, CommandType.Text, params)
    End Sub

    'Sub ConfirmVoucher(ByVal daybookGoesOut As String, ByVal daybookGoesInto As String, ByVal linkVoucherNo As String, ByVal voucherDate As DateTime, ByVal confirmVoucherNumber As String, ByVal nextcount As String)
    '    Dim query As String = String.Empty

    '    query = "Begin Tran " & _
    '    "Begin Try " & _
    '        "Update " + InstitutionMasterData.XInstType + "_Voucher_Header set VH_Vch_No=@voucherNumber,VH_VCH_Dt=@vchDt,VH_Conf_Dt=GetDate(),VH_Conf_By=@CnfBy " & _
    '        "where VH_Lnk_No=@linkNo " & _
    '        "Update " + InstitutionMasterData.XInstType + "_Voucher_Detail set VD_Dbk_Cd=@dbkCdIn,VD_Vch_No=@voucherNumber,VD_Conf_Dt=GetDate(),VD_Conf_By=@CnfBy " & _
    '        "where VD_Lnk_No=@linkNo " & _
    '    "Commit " & _
    '    "End Try " & _
    '    "Begin Catch " & _
    '    "RollBack " & _
    '    "End Catch "

    '    '"declare @currDate as DateTime " & _
    '    '    "set @currDate=GETDATE() " & _

    '    Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
    '    params.Add("@voucherNumber", confirmVoucherNumber)
    '    params.Add("@nextVoucherNumber", nextcount)
    '    params.Add("@linkNo", linkVoucherNo)
    '    params.Add("@dbkCd", daybookGoesOut)
    '    params.Add("@dbkCdIn", daybookGoesInto)
    '    params.Add("@CnfBy", InstitutionMasterData.XUsrId)
    '    params.Add("@vchDt", voucherDate.ToString("yyyy-MM-dd"))
    '    Dim dataHelper As DataHelper = New DataHelper()
    '    dataHelper.ExecuteNonQuery(query, CommandType.Text, params)
    'End Sub

    Function GetVoucherCount(ByVal LinkNo As String) As Integer
        Dim query As String
        Dim dHelper As DataHelper = New DataHelper()
        Dim cnt As Integer
        query = "select count(Lgr_Lnk_No) from " + InstitutionMasterData.XInstType + "_Ledger where Lgr_Lnk_No like '%" + LinkNo + "%'  "
        cnt = dHelper.ExecuteScalar(query, CommandType.Text)
        Return cnt
    End Function

End Class