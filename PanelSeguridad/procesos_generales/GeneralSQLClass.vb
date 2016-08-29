Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class GeneralSQLClass

#Region "CONSULTAS"

    ''' <summary>
    ''' funcion generica para hacer el query si esta repetido el ID 
    ''' </summary>
    ''' <param name="vp_S_NameTabla"></param>
    ''' <param name="vp_S_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadExist(ByVal vp_S_NameTabla As String, ByVal vp_S_ID As String, ByVal vp_S_Column As String, ByVal vp_S_Consecutivo As String)

        Dim StrQuery As String = ""
        Dim Result As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.AppendLine("SELECT COUNT(1) FROM " & vp_S_NameTabla & _
                       " WHERE " & vp_S_Column & " = '" & vp_S_ID & "'")

        If vp_S_Consecutivo <> "" Then
            sql.AppendLine(" AND OR_Consecutivo ='" & vp_S_Consecutivo & "'")
        End If

        StrQuery = sql.ToString

        Result = conex.IDis(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion generica para hacer el query si esta repetido el ID conformadopor varios campos 
    ''' </summary>
    ''' <param name="vp_S_NameTabla"></param>
    ''' <param name="vp_S_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadExist_VariantKeys(ByVal vp_S_NameTabla As String, ByVal vp_S_Column As String, ByVal vp_S_Column_2 As String, ByVal vp_S_Column_3 As String, ByVal vp_S_ID As String, ByVal vp_S_ID_2 As String, ByVal vp_S_ID_3 As String)

        Dim StrQuery As String = ""
        Dim Result As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.AppendLine("SELECT COUNT(1) FROM " & vp_S_NameTabla & _
                      " WHERE " & vp_S_Column & " = '" & vp_S_ID & "' AND " & vp_S_Column_2 & " = '" & vp_S_ID_2 & "'")

        If vp_S_Column_3 <> "" Then
            sql.AppendLine(" AND " & vp_S_Column_3 & " ='" & vp_S_ID_3 & "'")
        End If

        StrQuery = sql.ToString

        Result = conex.IDis(StrQuery)

        Return Result

    End Function


    ''' <summary>
    ''' crea la consulta para la tabla encabezado trae los datps de la aplicacion
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ChargeEncabezado(ByVal vp_S_ID As String)
        Dim StrQuery As String = ""
        Dim Result As String = ""
        Dim conex As New Conector
        Dim ObjListGeneral As New List(Of Droplist_Class)

        Dim sql As New StringBuilder

        sql.AppendLine("SELECT E_Titulo,E_LogoSasif,E_LogoEmpresa,E_parrafo_1,E_parrafo_2,E_parrafo_3 FROM ENCABEZADO " & _
                       " WHERE E_ID = '" & vp_S_ID & "'")

        StrQuery = sql.ToString

        ObjListGeneral = conex.ObjLoad_All(StrQuery, "encabezado")

        Return ObjListGeneral

    End Function

#End Region

#Region "CARGAR LISTAS"

    ''' <summary>
    ''' GENERA LA LISTA PARA GUARDAR LOSDATOS DE PROGRAMA
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListEncabezado(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListGeneral As New List(Of Droplist_Class)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()
        While ReadConsulta.Read

            Dim objEncabezado As New Droplist_Class
            'cargamos datos sobre el objeto de login
            objEncabezado.Titulo = ReadConsulta.GetString(0)
            objEncabezado.LogoSasif = ReadConsulta.GetString(1)
            objEncabezado.LogoEmpresa = ReadConsulta.GetString(2)
            objEncabezado.parrafo_1 = ReadConsulta.GetString(3)
            objEncabezado.parrafo_2 = ReadConsulta.GetString(4)
            objEncabezado.parrafo_3 = ReadConsulta.GetString(5)
            'agregamos a la lista
            ObjListGeneral.Add(objEncabezado)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListGeneral


    End Function

    ''' <summary>
    ''' funcion que trae el listado de campos de CUALQUIER TABLA para armar el droplist
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listdrop(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListDroplist As New List(Of Droplist_Class)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        While ReadConsulta.Read

            Dim objDropList As New Droplist_Class
            'cargamos datos sobre el objeto de login
            objDropList.ID = ReadConsulta.GetValue(0)
            objDropList.descripcion = ReadConsulta.GetValue(1)

            'agregamos a la lista
            ObjListDroplist.Add(objDropList)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListDroplist

    End Function

    ''' <summary>
    ''' funcion que trae el listado de campos de CUALQUIER TABLA para armar el droplist con variable
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listdropFlex(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListDroplist As New List(Of Droplist_Class)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        While ReadConsulta.Read

            Dim objDropList As New Droplist_Class
            'cargamos datos sobre el objeto de login
            objDropList.ID = ReadConsulta.GetValue(0)
            objDropList.descripcion = ReadConsulta.GetValue(1)
            objDropList.tipo = ReadConsulta.GetValue(2)

            'agregamos a la lista
            ObjListDroplist.Add(objDropList)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListDroplist

    End Function

#End Region

End Class
