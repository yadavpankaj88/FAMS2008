Public Class VoucherHeader
    Dim _Finyear, inst_Cd, inst_Typ, brn_cd, lnk_no, pty_Nm, dbk_cd, trn_typ, chq_no, vch_refNo, ref_no, lgr_cd, vh_cnf_no, acc_cd, crdr, user As String
    Dim lnk_dt, entdate, vh_cnf_dt As DateTime
    Dim chq_dt, ref_dt As Nullable(Of DateTime)
    Dim amt, absamt As Decimal
    Property VH_Fin_Yr As String
        Get
            Return _Finyear
        End Get
        Set(value As String)
            _Finyear = value
        End Set
    End Property
    Property VH_Inst_Cd As String
        Get
            Return inst_Cd
        End Get
        Set(value As String)
            inst_Cd = value
        End Set
    End Property
    Property VH_Inst_Typ As String
        Get
            Return inst_Typ
        End Get
        Set(value As String)
            inst_Typ = value
        End Set
    End Property
    Property VH_Brn_Cd As String
        Get
            Return brn_cd
        End Get
        Set(value As String)
            brn_cd = value
        End Set
    End Property

    Property VH_Lnk_No As String
        Get
            Return lnk_no
        End Get
        Set(value As String)
            lnk_no = value
        End Set

    End Property
    Property VH_Lnk_Dt As DateTime
        Get
            Return lnk_dt
        End Get
        Set(value As DateTime)
            lnk_dt = value
        End Set
    End Property
    Property VH_Pty_Nm As String
        Get
            Return pty_Nm
        End Get
        Set(value As String)
            pty_Nm = value
        End Set
    End Property
    Property VH_Dbk_Cd As String
        Get
            Return dbk_cd
        End Get
        Set(value As String)
            dbk_cd = value
        End Set
    End Property

    Property VH_Trn_Typ As String
        Get
            Return trn_typ
        End Get
        Set(value As String)
            trn_typ = value
        End Set
    End Property

    Property VH_Chq_No As String
        Get
            Return chq_no
        End Get
        Set(value As String)
            chq_no = value
        End Set
    End Property

    Property VH_Chq_Dt As Nullable(Of DateTime)
        Get
            Return chq_dt
        End Get
        Set(value As Nullable(Of DateTime))
            chq_dt = value
        End Set
    End Property
    Property VH_Ref_No As String
        Get
            Return ref_no
        End Get
        Set(value As String)
            ref_no = value
        End Set
    End Property

    Property VH_VCH_Ref_No As String
        Get
            Return vch_refNo
        End Get
        Set(value As String)
            vch_refNo = value
        End Set
    End Property
    Property VH_Ref_Dt As Nullable(Of DateTime)
        Get
            Return ref_dt
        End Get
        Set(value As Nullable(Of DateTime))
            ref_dt = value
        End Set
    End Property
    Property VH_Lgr_Cd As String
        Get
            Return lgr_cd
        End Get
        Set(value As String)
            lgr_cd = value
        End Set
    End Property

    Property VH_Acc_Cd As String
        Get
            Return acc_cd
        End Get
        Set(value As String)
            acc_cd = value
        End Set
    End Property

    Property VH_Amt As Decimal
        Get
            Return amt
        End Get
        Set(value As Decimal)
            amt = value
        End Set
    End Property

    Property VH_Cr_Dr As String
        Get
            Return crdr
        End Get
        Set(value As String)
            crdr = value
        End Set
    End Property

    Property VH_ABS_Amt As Decimal
        Get
            Return absamt
        End Get
        Set(value As Decimal)
            absamt = value
        End Set
    End Property

    Property VH_Ent_Dt As DateTime
        Get
            Return entdate
        End Get
        Set(value As DateTime)
            entdate = value
        End Set
    End Property

    Property VH_Ent_By As String
        Get
            Return user
        End Get
        Set(value As String)
            user = value
        End Set
    End Property

    Property VH_VCH_NO As String
        Get
            Return vh_cnf_no
        End Get
        Set(value As String)
            vh_cnf_no = value
        End Set
    End Property

    Property VH_VCH_Dt As DateTime?
        Get
            Return vh_cnf_dt
        End Get
        Set(value As DateTime?)
            vh_cnf_dt = value
        End Set
    End Property
End Class
