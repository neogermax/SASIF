Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class MenuSQLClass

    ''' <summary>
    ''' crea la consulta para el menu
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllOptionsMenu(ByVal vp_S_User As String)

        Dim ObjListMenu As New List(Of MenuClass)
        Dim StrQuery As String = ""
        Dim StrQueryRol As String = ""

        Dim conex As New Conector
        Dim rol As String

        Dim sql As New StringBuilder

        sql.Append("SELECT U_Rol_ID FROM USUARIOS WHERE U_Usuario_ID = '" & vp_S_User & "'")
        StrQuery = sql.ToString
        rol = conex.IDis(StrQuery)

        StrQuery = ""
        sql = New StringBuilder

        If rol = "ADMIN" Then
            sql.Append("SELECT U_nombre AS Nombre," & _
                  "U_Estado AS EstadoUsuario," & _
                  "R_Rol_ID AS IDRol," & _
                  "R_Descripcion AS DescripcionRol," & _
                  "R_Sigla AS Sigla," & _
                  "OR_OPRol_ID AS IDOpcionRol," & _
                  "OR_Consecutivo AS Consecutivo," & _
                  "OR_Tipo As Tipo," & _
                  "[OR_Subrol/rol] AS Sub_Rol," & _
                  "L_Link_ID AS IDlink," & _
                  "L_Descripcion AS DescripcionLink," & _
                  "L_Param1 AS Parametro_1," & _
                  "L_Param2 AS Parametro_2," & _
                  "l_LinkPag AS Ruta, " & _
                  "U_Usuario_ID as Usuario  " & _
          "FROM ROLES R " & _
          "INNER JOIN OPTION_ROL OP ON OP.OR_OPRol_ID = R.R_Rol_ID " & _
          "LEFT JOIN LINKS L ON OP.OR_Link_ID = L.L_Link_ID " & _
          "LEFT JOIN USUARIOS U ON U.U_Rol_ID = R.R_Rol_ID " & _
          "WHERE  U_Usuario_ID = '" & vp_S_User & "' " & _
          "UNION " & _
          "SELECT NULL AS Nombre," & _
                  "NULL AS EstadoUsuario," & _
                  "R_Rol_ID AS IDRol," & _
                  "R_Descripcion AS DescripcionRol," & _
                  "R_Sigla AS Sigla," & _
                  "OR_OPRol_ID AS IDOpcionRol," & _
                  "OR_Consecutivo AS Consecutivo," & _
                  "OR_Tipo As Tipo," & _
                  "[OR_Subrol/rol] AS Sub_Rol," & _
                  "L_Link_ID AS IDlink," & _
                  "L_Descripcion AS DescripcionLink," & _
                  "L_Param1 AS Parametro_1," & _
                  "L_Param2 AS Parametro_2," & _
                  "l_LinkPag AS Ruta, " & _
                  "NULL as Usuario  " & _
          "FROM ROLES R " & _
          "INNER JOIN OPTION_ROL OP ON OP.OR_OPRol_ID = R.R_Rol_ID " & _
          "LEFT JOIN LINKS L ON OP.OR_Link_ID = L.L_Link_ID " & _
          "WHERE R_Rol_ID = [OR_Subrol/rol] " & _
          "ORDER BY OR_Tipo, OR_OPRol_ID, OR_Consecutivo asc ")
        Else
            sql.Append("SELECT U_nombre AS Nombre," & _
                       "U_Estado AS EstadoUsuario," & _
                       "R_Rol_ID AS IDRol," & _
                       "R_Descripcion AS DescripcionRol," & _
                       "R_Sigla AS Sigla," & _
                       "OR_OPRol_ID AS IDOpcionRol," & _
                       "OR_Consecutivo AS Consecutivo," & _
                       "OR_Tipo As Tipo," & _
                       "[OR_Subrol/rol] AS Sub_Rol," & _
                       "L_Link_ID AS IDlink," & _
                       "L_Descripcion AS DescripcionLink," & _
                       "L_Param1 AS Parametro_1," & _
                       "L_Param2 AS Parametro_2," & _
                       "l_LinkPag AS Ruta, " & _
                       "U_Usuario_ID as Usuario  " & _
            "FROM ROLES R " & _
            "INNER JOIN OPTION_ROL OP ON OP.OR_OPRol_ID = R.R_Rol_ID " & _
            "LEFT JOIN LINKS L ON OP.OR_Link_ID = L.L_Link_ID " & _
            "LEFT JOIN USUARIOS U ON U.U_Rol_ID = R.R_Rol_ID " & _
            "WHERE  U_Usuario_ID = '" & vp_S_User & "' " & _
            "ORDER BY OR_Tipo, OR_OPRol_ID asc, OR_Consecutivo ")
        End If

        StrQuery = sql.ToString

        ObjListMenu = conex.ObjLoad_All(StrQuery, "Menu")

        Return ObjListMenu

    End Function

    ''' <summary>
    ''' funcion que trae el listado para armar el menu
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listMenu(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListMenu As New List(Of MenuClass)
        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()
        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objMenu As New MenuClass
            'cargamos datos sobre el objeto de login
            If Not (IsDBNull(ReadConsulta.GetValue(0))) Then objMenu.Nombre = ReadConsulta.GetString(0) Else objMenu.Nombre = ""
            If Not (IsDBNull(ReadConsulta.GetValue(1))) Then objMenu.EstadoUsuario = ReadConsulta.GetString(1) Else objMenu.EstadoUsuario = ""
            If Not (IsDBNull(ReadConsulta.GetValue(2))) Then objMenu.IDRol = ReadConsulta.GetString(2) Else objMenu.IDRol = ""
            If Not (IsDBNull(ReadConsulta.GetValue(3))) Then objMenu.DescripcionRol = ReadConsulta.GetString(3) Else objMenu.DescripcionRol = ""
            If Not (IsDBNull(ReadConsulta.GetValue(4))) Then objMenu.Sigla = ReadConsulta.GetString(4) Else objMenu.Sigla = ""
            objMenu.IDOpcionRol = ReadConsulta.GetString(5)
            objMenu.Consecutivo = ReadConsulta.GetValue(6)
            objMenu.Tipo = ReadConsulta.GetString(7)
            objMenu.Sub_Rol = ReadConsulta.GetString(8)
            objMenu.IDlink = ReadConsulta.GetString(9)
            objMenu.DescripcionLink = ReadConsulta.GetString(10)
            objMenu.Parametro_1 = ReadConsulta.GetValue(11)
            objMenu.Parametro_2 = ReadConsulta.GetValue(12)
            objMenu.Ruta = ReadConsulta.GetString(13)
            If Not (IsDBNull(ReadConsulta.GetValue(14))) Then objMenu.Usuario = ReadConsulta.GetString(14) Else objMenu.Usuario = ""

            'agregamos a la lista
            ObjListMenu.Add(objMenu)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListMenu

    End Function

End Class
