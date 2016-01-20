Public Class Daybooks

    Inherits BaseEntity
    Dim DM_Fn_Yr, DM_Inst_Cd, DM_Inst_Typ, DM_Brn_CD, DM_Dbk_Cd, DM_Dbk_Nm, DM_Dbk_Typ, DM_Acc_Cd, DM_Bnk_Nm, DM_Bnk_Brn, DM_Bnk_AcNo, DM_Bnk_OD As String

    Property DMFinYear() As String
        Get
            Return DM_Fn_Yr
        End Get
        Set(ByVal Value As String)
            DM_Fn_Yr = Value
        End Set
    End Property

    Property DMInstCd() As String
        Get
            Return DM_Inst_Cd
        End Get
        Set(ByVal Value As String)
            DM_Inst_Cd = Value
        End Set
    End Property

    Property DMInstTyp() As String
        Get
            Return DM_Inst_Typ
        End Get
        Set(ByVal Value As String)
            DM_Inst_Typ = Value
        End Set
    End Property

    Public Property DMBranchCode() As String
        Get
            Return DM_Brn_CD
        End Get
        Set(ByVal Value As String)
            DM_Brn_CD = Value
        End Set
    End Property

    Property DMDaybookCode() As String
        Get
            Return DM_Dbk_Cd
        End Get
        Set(ByVal Value As String)
            DM_Dbk_Cd = Value
        End Set
    End Property

    Property DMDaybookType() As String
        Get
            Return DM_Dbk_Typ
        End Get
        Set(ByVal Value As String)
            DM_Dbk_Typ = Value
        End Set
    End Property

    Property DMDaybookName() As String
        Get
            Return DM_Dbk_Nm
        End Get
        Set(ByVal Value As String)
            DM_Dbk_Nm = Value
        End Set
    End Property

    Property DMAccountCode() As String
        Get
            Return DM_Acc_Cd
        End Get
        Set(ByVal Value As String)
            DM_Acc_Cd = Value
        End Set
    End Property

    Property DMBankName() As String
        Get
            Return DM_Bnk_Nm
        End Get
        Set(ByVal Value As String)
            DM_Bnk_Nm = Value
        End Set
    End Property

    Property DMBankBranch() As String
        Get
            Return DM_Bnk_Brn
        End Get
        Set(ByVal Value As String)
            DM_Bnk_Brn = Value
        End Set
    End Property

    Property DMBankAccNo() As String
        Get
            Return DM_Bnk_AcNo
        End Get
        Set(ByVal Value As String)
            DM_Bnk_AcNo = Value
        End Set
    End Property

    Property DMBankOD() As String
        Get
            Return DM_Bnk_OD
        End Get
        Set(ByVal Value As String)
            DM_Bnk_OD = Value
        End Set
    End Property



End Class
