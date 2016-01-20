Public Class ValidateUserClass

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

        currentYear = Convert.ToInt32(pInstMaster.XFinYr)

        pInstMaster.XPrevYr = (currentYear - 1).ToString()
        pInstMaster.XNextYr = (currentYear + 1).ToString()

        pInstMaster.XYrBeginDate = New DateTime(currentYear, 4, 1)
        pInstMaster.XYrEndDate = New DateTime(currentYear + 1, 3, 31)
    End Sub


    Public Function CheckLicenseDate(pProcessingDate As DateTime, pFamDate As DateTime) As Boolean
        If (Date.Compare(pProcessingDate.Date, pFamDate.Date) >= 0) Then
            Return True
        Else
            Return False
        End If

    End Function
    
    Public Function CheckFinancialYear(pFinancialYear As String, pClosingYear As String) As Boolean
        Dim finYear As Integer = Convert.ToInt32(pFinancialYear)
        Dim closingYear As Integer = Convert.ToInt32(pClosingYear)
        If finYear <= closingYear Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
