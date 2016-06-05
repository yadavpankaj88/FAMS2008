Public Class VoucherDetails
    Dim _Finyear, inst_Cd, inst_Typ, brn_cd, lnk_no, pty_Nm, dbk_cd, vchNo, vchrefno, seqNo, trn_typ, chq_no, ref_no, lgr_cd, vdNarr, acc_cd, crdr, user As String
    Dim _vd_lnk_dt, chq_dt, entdate As DateTime
    Dim ref_dt As Nullable(Of DateTime)
    Dim amt, absamt As Decimal
    Property VD_Fin_Yr() As String
        Get
            Return _Finyear
        End Get
        Set(ByVal value As String)
            _Finyear = value
        End Set
    End Property
    Property VD_Inst_Cd() As String
        Get
            Return inst_Cd
        End Get
        Set(ByVal value As String)
            inst_Cd = value
        End Set
    End Property
    Property VD_Inst_Typ() As String
        Get
            Return inst_Typ
        End Get
        Set(ByVal value As String)
            inst_Typ = value
        End Set
    End Property
    Property VD_Brn_Cd() As String
        Get
            Return brn_cd
        End Get
        Set(ByVal value As String)
            brn_cd = value
        End Set
    End Property

    Property VD_Lnk_No() As String
        Get
            Return lnk_no
        End Get
        Set(ByVal value As String)
            lnk_no = value
        End Set

    End Property

    Property VD_Dbk_Cd() As String
        Get
            Return dbk_cd
        End Get
        Set(ByVal value As String)
            dbk_cd = value
        End Set
    End Property

    Property VD_Trn_Typ() As String
        Get
            Return trn_typ
        End Get
        Set(ByVal value As String)
            trn_typ = value
        End Set
    End Property
    Property VD_Vch_No() As String
        Get
            Return vchNo
        End Get
        Set(ByVal value As String)
            vchNo = value
        End Set
    End Property

    Property VD_Vch_Ref_No() As String
        Get
            Return vchrefno
        End Get
        Set(ByVal value As String)
            vchrefno = value
        End Set
    End Property

    Property VD_Seq_No() As String
        Get
            Return seqNo
        End Get
        Set(ByVal value As String)
            seqNo = value
        End Set
    End Property

    Property VD_Ref_No() As String
        Get
            Return ref_no
        End Get
        Set(ByVal value As String)
            ref_no = value
        End Set
    End Property
    Property VD_Ref_Dt() As Nullable(Of DateTime)
        Get
            Return ref_dt
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            ref_dt = value
        End Set
    End Property
    Property VD_Narr() As String
        Get
            Return vdNarr
        End Get
        Set(ByVal value As String)
            vdNarr = value
        End Set
    End Property

    Property VD_Lgr_Cd() As String
        Get
            Return lgr_cd
        End Get
        Set(ByVal value As String)
            lgr_cd = value
        End Set
    End Property

    Property VD_Acc_Cd() As String
        Get
            Return acc_cd
        End Get
        Set(ByVal value As String)
            acc_cd = value
        End Set
    End Property

    Property VD_Amt() As Decimal
        Get
            Return amt
        End Get
        Set(ByVal value As Decimal)
            amt = value
        End Set
    End Property

    Property VD_Cr_Dr() As String
        Get
            Return crdr
        End Get
        Set(ByVal value As String)
            crdr = value
        End Set
    End Property

    Property VD_ABS_Amt() As Decimal
        Get
            Return absamt
        End Get
        Set(ByVal value As Decimal)
            absamt = value
        End Set
    End Property

    Property VD_Ent_Dt() As DateTime
        Get
            Return entdate
        End Get
        Set(ByVal value As DateTime)
            entdate = value
        End Set
    End Property

    Property VD_Ent_By() As String
        Get
            Return user
        End Get
        Set(ByVal value As String)
            user = value
        End Set
    End Property
    Property VD_Lnk_Dt() As DateTime
        Get
            Return _vd_lnk_dt
        End Get
        Set(ByVal value As DateTime)
            _vd_lnk_dt = value
        End Set
    End Property
End Class
