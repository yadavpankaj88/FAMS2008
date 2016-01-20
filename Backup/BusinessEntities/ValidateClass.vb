Imports System.Text

Public Class ValidateClass

    ''' <summary>
    ''' Determines whether the date lies with in the given financial year
    ''' </summary>
    ''' <param name="pProcessingDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckProcessingDate(pProcessingDate As DateTime) As Boolean
        If DateTime.Compare(pProcessingDate.Date, DateTime.Now.Date) <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Determines the FinancialYear
    ''' </summary>
    ''' <param name="pProcessingDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckFinancialYear(pProcessingDate As DateTime) As String
        Dim currentYear = pProcessingDate.Year
        Dim prevYear = pProcessingDate.Year - 1
        Dim nextYear = pProcessingDate.Year + 1

        If pProcessingDate.Date.Month > 3 Then
            Return String.Format("{0}", currentYear)
        Else
            Return String.Format("{0}", prevYear)
        End If

    End Function

    ''' <summary>
    ''' Determines the Next,prev financial year as well as the Current financial year begin date and end date
    ''' </summary>
    ''' <param name="pInstMaster"></param>
    ''' <remarks></remarks>
    Public Sub GetNextandPrevFinancialYear(ByVal pInstMaster As InstitutionMasterData)
        Dim currentYear As Integer

        currentYear = Convert.ToInt32(InstitutionMasterData.XFinYr)

        pInstMaster.XPrevYr = (currentYear - 1).ToString()
        pInstMaster.XNextYr = (currentYear + 1).ToString()

        pInstMaster.XYrBeginDate = New DateTime(currentYear, 4, 1)
        pInstMaster.XYrEndDate = New DateTime(currentYear + 1, 3, 31)
    End Sub


    Public Sub SetFinancialYear(ByVal pInstMaster As InstitutionMasterData)
        Dim currentYear As Integer

        currentYear = Convert.ToInt32(InstitutionMasterData.XFinYr)

        pInstMaster.XPrevYr = (currentYear - 1).ToString()
        pInstMaster.XNextYr = (currentYear + 1).ToString()

        InstitutionMasterData.XStartFinYr = New DateTime(currentYear, 4, 1)
        InstitutionMasterData.XEndFinYr = New DateTime(currentYear + 1, 3, 31)
    End Sub


    ''' <summary>
    ''' This will check the license date
    ''' </summary>
    ''' <param name="pProcessingDate"></param>
    ''' <param name="pFamDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckLicenseDate(pProcessingDate As DateTime, pFamDate As DateTime) As Boolean
        If (Date.Compare(pProcessingDate.Date, pFamDate.Date) >= 0) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' This will check the financial year
    ''' </summary>
    ''' <param name="pFinancialYear"></param>
    ''' <param name="pClosingYear"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckFinancialYear(pFinancialYear As String, pClosingYear As String) As Boolean
        Dim finYear As Integer = Convert.ToInt32(pFinancialYear)
        Dim closingYear As Integer = Convert.ToInt32(pClosingYear)
        If finYear <= closingYear Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' This function will validate the Ledger Account Code entered
    ''' </summary>
    ''' <param name="pAccCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CheckAccountCode(pAccCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim secondThirdCharacter, lastThreeCharacters As Integer

      

        Try

            If Not String.IsNullOrEmpty(pAccCode) Then

                If pAccCode.Length < 6 Then
                    Return False
                End If
                If (pAccCode.StartsWith("A") Or pAccCode.StartsWith("E") Or pAccCode.StartsWith("I") Or pAccCode.StartsWith("L")) Then
                    secondThirdCharacter = Convert.ToInt32(pAccCode.Substring(1, 2))
                    lastThreeCharacters = Convert.ToInt32(pAccCode.Substring(3))
                    'If secondThirdCharacter > 0 And secondThirdCharacter <= 99 Then
                    If lastThreeCharacters >= 1 And lastThreeCharacters <= 999 Then
                        IsValid = True
                    End If
                    'End If
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            IsValid = False
        End Try

        Return IsValid
    End Function

    Function CheckAccName(pAccName As String) As Boolean
        If String.IsNullOrEmpty(pAccName) Then
            Return False
        Else
            Return True
        End If
    End Function

    Function CheckNumber(pValue As String) As Boolean
        Return IsNumeric(pValue)
    End Function

    Function CheckReferenceDate(pReferenceDate As DateTime, ByRef pMessage As String, pVoucherDate As DateTime) As Boolean
        If DateTime.Compare(pReferenceDate.Date, pVoucherDate.Date) > 0 Then
            pMessage = "Reference Date cannot be greater than Voucher Date"
            Return False
        Else
            Return True
        End If
    End Function

    Function CheckVoucherDate(pVoucherDate As DateTime, ByRef pMessage As String) As Boolean
        If DateTime.Compare(pVoucherDate.Date, InstitutionMasterData.XDate.Date) > 0 Then
            pMessage = "Voucher Date cannot be greater than Processing Date"
            Return False
        ElseIf DateTime.Compare(InstitutionMasterData.XDate.AddMonths(-3).Date, pVoucherDate.Date) > 0 Then
            pMessage = "Voucher Date cannot be 3 months older than Processing Date"
            Return False
        Else
            Return True
        End If
    End Function


    Function CheckConfirmationdate(pConfirmDate As DateTime, ByRef pMessage As String, pVoucherDate As DateTime) As Boolean
        If DateTime.Compare(pConfirmDate.Date, InstitutionMasterData.XDate.Date) > 0 Then
            pMessage = "Confirmation Date cannot be greater than Processing Date"
            Return False
        ElseIf DateTime.Compare(pConfirmDate.Date, pVoucherDate.Date) < 0 Then
            pMessage = "Confirmation Date cannot be less than Voucher Date"
            Return False
        ElseIf pConfirmDate.Date < InstitutionMasterData.XStartFinYr.Date Or pConfirmDate.Date > InstitutionMasterData.XEndFinYr.Date Then
            pMessage = "Confirmation Date must be between" + InstitutionMasterData.XStartFinYr.Date + "and " + InstitutionMasterData.XEndFinYr.Date
            Return False
        Else
            Return True
        End If
    End Function

    Function CheckBalance(pBalanceAmt As Double, pVoucherAmt As Double) As Boolean
        If (pVoucherAmt <= pBalanceAmt) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckComboxSelected(pSelectedValue As Object) As Boolean
        If String.IsNullOrEmpty(pSelectedValue) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
