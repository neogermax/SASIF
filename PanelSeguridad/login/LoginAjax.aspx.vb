Public Class LoginAjax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'trae el jquery para hacer todo por debajo del servidor
        If Request.Form("action") <> Nothing Then
            'aterrizamos las opciones del proceso
            Dim vl_S_option_login As String = Request.Form("action")

            Select Case vl_S_option_login

                Case "Ingresar"
                    ingresar()
            End Select

        End If
    End Sub
    ''' <summary>
    ''' 'funcion que valida contra la BD si el usuario y contraseña son correctos
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ingresar()

        Dim vl_S_user, vl_S_password, vl_S_userEncrip As String
        Dim vl_B_existeUsuario As Boolean
        Dim vl_B_passwordCorrecto As Boolean
        Dim vl_B_cambioPassword As Boolean
        Dim vl_B_Estado As Boolean
        Dim vl_I_resultado As Integer

        Dim Encrip As New EncriptarClass
        Dim SQL_Login As New LoginSQLClass

        Dim ObjListLogin As New List(Of LoginClass)

        vl_S_user = Request.Form("user").ToString()
        vl_S_userEncrip = Encrip.Encriptacion_MD5(UCase(vl_S_user))

        vl_S_password = Request.Form("password").ToString()
        'llamamos al procedimiento de encripcion
        vl_S_password = Encrip.Encriptacion_MD5(vl_S_password)
        'llamamos modulo de consultas SQL(todos los usuarios) 
        ObjListLogin = SQL_Login.Read_AllUserLogin()
        'recorremos la lista de la consulta
        For Each row In ObjListLogin
            'verificamos el usuario exista
            If row.Name = UCase(vl_S_user) Then
                vl_B_existeUsuario = True
                'verificamos que el password sea igual al usuario para cambio de clave
                If row.Password = vl_S_userEncrip Then
                    vl_B_cambioPassword = True
                    Exit For
                End If
                'verificamos el estado del usuario
                If row.Estado = "2" Then
                    vl_B_Estado = True
                    Exit For
                End If
                'verificamos que el password sea correcto
                If row.Password = vl_S_password Then
                    vl_B_passwordCorrecto = True
                    Exit For
                Else
                    vl_B_passwordCorrecto = False
                    Exit For
                End If

            Else
                vl_B_existeUsuario = False
            End If
        Next
        'validamos consulta para devolver resultado al json
        If vl_B_existeUsuario = False Then
            vl_I_resultado = 2 'no existe usuario
        Else
            If vl_B_cambioPassword = True Then
                vl_I_resultado = 3 'cambio de password
                GoTo salto
            End If
            If vl_B_Estado = True Then
                vl_I_resultado = 4 'usuario deshabilitado
                GoTo salto
            End If
            If vl_B_passwordCorrecto = False Then
                vl_I_resultado = 1 ' contraseña incorrecta
            Else
                vl_I_resultado = 0 'ingreso
            End If
        End If
salto:
        Response.Write(vl_I_resultado)

    End Sub

End Class