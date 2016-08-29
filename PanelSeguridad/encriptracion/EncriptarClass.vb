Imports System.Text
Imports System.Security.Cryptography

Public Class EncriptarClass
    ''' <summary>
    ''' funcion para encriptacion del password diseñada por
    ''' German Alejandro Rodriguez
    ''' </summary>
    ''' <param name="pl_S_password"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Encriptacion(ByVal pl_S_password As String)

        Dim vl_S_passEncrip, vl_S_pass As String

        vl_S_pass = UCase(pl_S_password)
        vl_S_passEncrip = ""
        ' procedimiento de encripcion
        For index = 1 To Len(vl_S_pass)
            vl_S_passEncrip = vl_S_passEncrip & "0" & Asc(Mid(vl_S_pass, index, 1))
        Next

        Return vl_S_passEncrip

    End Function
    ''' <summary>
    ''' funcion para encriptacion del password MD5
    ''' </summary>
    ''' <param name="SourceText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Encriptacion_MD5(ByVal SourceText As String) As String

        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New UnicodeEncoding()
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New MD5CryptoServiceProvider()
        'Compute the hash value from the source
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'And convert it to String format for return
        Return Convert.ToBase64String(ByteHash)

    End Function


End Class
