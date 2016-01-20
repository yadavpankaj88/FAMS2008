Public Class JournalHelper
    Public Sub SaveJournaldetail(ByVal Journaldetail As VoucherDetails)
        Dim detailSaveQuery = "If(Exists(select 'x' from " + InstitutionMasterData.XInstType + "_Voucher_Detail where VD_Lnk_No=@VD_Lnk_No )) " &
        " Begin " &
        "Update " + InstitutionMasterData.XInstType + "_Voucher_Detail Set VD_Ref_No=@VD_Ref_No,VD_Ref_Dt=@VD_Ref_Dt,VD_Narr=@VD_Narr,VD_Acc_Cd=@VD_Acc_Cd,VD_Amt=@VD_Amt," &
        " VD_Cr_Dr=@VD_Cr_Dr,VD_Abs_Amt=@VD_Abs_Amt,VD_Upd_By=@VD_Upd_By,VD_Upd_Dt=GetDate() where VD_Lnk_No=@VD_Lnk_No" &
        " End " &
        " Else " &
            "Insert into " + InstitutionMasterData.XInstType + "_Voucher_Detail(VD_Fin_Yr,VD_Inst_Cd,VD_Inst_Typ,VD_Brn_Cd,VD_Lnk_No,VD_Dbk_Cd,VD_Ref_No,VD_Ref_Dt,VD_Narr,VD_Lgr_Cd,VD_Acc_Cd,VD_Amt,VD_Cr_Dr," &
                               "VD_ABS_Amt,VD_Ent_By,VD_Ent_Dt)values(@VD_Fin_Yr,@VD_Inst_Cd,@VD_Inst_Typ,@VD_Brn_Cd,@VD_Lnk_No,@VD_Dbk_Cd,@VD_Ref_No,@VD_Ref_Dt,@VD_Narr,@VD_Lgr_Cd,@VD_Acc_Cd,@VD_Amt,@VD_Cr_Dr," &
                                "@VD_Abs_Amt,@VD_Ent_By,GETDATE())"

        Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
        params.Add("@VD_Fin_Yr", Journaldetail.VD_Fin_Yr)
        params.Add("@VD_Inst_Cd", Journaldetail.VD_Inst_Cd)
        params.Add("@VD_Inst_Typ", InstitutionMasterData.XInstType)
        params.Add("@VD_Brn_Cd", Journaldetail.VD_Brn_Cd)
        params.Add("@VD_Lnk_No", Journaldetail.VD_Lnk_No)
        params.Add("@VD_Dbk_Cd", Journaldetail.VD_Dbk_Cd)
       
        params.Add("@VD_Ref_No", Journaldetail.VD_Ref_No)
        If Journaldetail.VD_Ref_Dt.HasValue Then
            params.Add("@VD_Ref_Dt", Journaldetail.VD_Ref_Dt.Value.ToString("MM-dd-yyyy"))
        Else
            params.Add("@VD_Ref_Dt", DBNull.Value)
        End If

        params.Add("@VD_Narr", Journaldetail.VD_Narr.Trim)
        params.Add("@VD_Lgr_Cd", Journaldetail.VD_Lgr_Cd)
        params.Add("@VD_Acc_Cd", Journaldetail.VD_Acc_Cd)
        params.Add("@VD_Amt", Journaldetail.VD_Amt)
        params.Add("@VD_Cr_Dr", Journaldetail.VD_Cr_Dr)
        params.Add("@VD_Abs_Amt", Journaldetail.VD_ABS_Amt)
        params.Add("@VD_Ent_By", Journaldetail.VD_Ent_By)
        params.Add("@VD_VCH_Ref_No", Journaldetail.VD_Vch_Ref_No)
        params.Add("@VD_Upd_By", InstitutionMasterData.XUsrId)

        Dim datahelper As DataHelper = New DataHelper()
        datahelper.ExecuteNonQuery(detailSaveQuery, CommandType.Text, params)

    End Sub

End Class
