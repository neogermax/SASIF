Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Adm_LinksSQLClass
   
#Region "CRUD"

    ''' <summary>
    ''' creala consulta para la tabla links parametrizada (READ)
    ''' </summary>
    ''' <param name="vp_S_Filtro"></param>
    ''' <param name="vp_S_Opcion"></param>
    ''' <param name="vp_S_Contenido"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read_AllLinks(ByVal vp_S_Filtro As String, ByVal vp_S_Opcion As String, ByVal vp_S_Contenido As String)

        Dim ObjListLinks As New List(Of Adm_LinksClass)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        If vp_S_Filtro = "N" And vp_S_Opcion = "ALL" Then
            sql.Append("SELECT L_Link_ID,L_Descripcion,L_Param1,L_Param2,L_Img,l_LinkPag,L_Estado FROM LINKS")
        Else

            If vp_S_Contenido = "ALL" Then
                sql.Append("SELECT L_Link_ID,L_Descripcion,L_Param1,L_Param2,L_Img,l_LinkPag,L_Estado FROM LINKS")
            Else
                sql.Append("SELECT L_Link_ID,L_Descripcion,L_Param1,L_Param2,L_Img,l_LinkPag,L_Estado FROM LINKS " & _
                      "WHERE " & vp_S_Opcion & " like '%" & vp_S_Contenido & "%'")
            End If
        End If

        StrQuery = sql.ToString

        ObjListLinks = conex.ObjLoad_All(StrQuery, "Links")

        Return ObjListLinks

    End Function

    ''' <summary>
    ''' funcion que crea el query para la insercion de nuevo link (INSERT)
    ''' </summary>
    ''' <param name="vp_Obj_Link"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertLinks(ByVal vp_Obj_Link As Adm_LinksClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""

        sql.AppendLine("INSERT LINKS (" & _
            "L_Link_ID," & _
            "L_Descripcion," & _
            "L_Param1," & _
            "L_Param2," & _
            "L_Img," & _
            "l_LinkPag," & _
            "l_Estado" & _
            ")")
        sql.AppendLine("VALUES (")
        sql.AppendLine("'" & vp_Obj_Link.Link_ID & "',")
        sql.AppendLine("'" & vp_Obj_Link.Descripcion & "',")
        sql.AppendLine("'" & vp_Obj_Link.Param1 & "',")
        sql.AppendLine("'" & vp_Obj_Link.Param2 & "',")
        sql.AppendLine("'" & vp_Obj_Link.Img & "',")
        sql.AppendLine("'" & vp_Obj_Link.LinkPag & "', ")
        sql.AppendLine("'" & 1 & "' ) ")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para la modificacion del link (UPDATE)
    ''' </summary>
    ''' <param name="vp_Obj_Link"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateLinks(ByVal vp_Obj_Link As Adm_LinksClass)

        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder
        Dim StrQueryID As String = ""
        Dim StrQuery As String = ""
        sql.AppendLine("UPDATE LINKS SET " & _
                       " L_Descripcion ='" & vp_Obj_Link.Descripcion & "', " & _
                       " L_Param1 =" & vp_Obj_Link.Param1 & ", " & _
                       " L_Param2 ='" & vp_Obj_Link.Param2 & "', " & _
                       " L_Img ='" & vp_Obj_Link.Img & "', " & _
                       " l_LinkPag ='" & vp_Obj_Link.LinkPag & "' " & _
                       " WHERE L_Link_ID = '" & vp_Obj_Link.Link_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

    ''' <summary>
    ''' funcion que crea el query para el estado del link (DELETE)
    ''' </summary>
    ''' <param name="vp_Obj_Link"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteLinks(ByVal vp_Obj_Link As Adm_LinksClass)
        Dim conex As New Conector
        Dim Result As String
        ' definiendo los objetos
        Dim sql As New StringBuilder

        Dim StrQuery As String = ""

        sql.AppendLine("UPDATE LINKS SET " & _
                       " l_Estado ='" & 2 & "' " & _
                       " WHERE L_Link_ID = '" & vp_Obj_Link.Link_ID & "'")

        StrQuery = sql.ToString

        Result = conex.StrInsert_and_Update_All(StrQuery)

        Return Result

    End Function

#End Region

#Region "CONSULTAS DROP LIST"

    ''' <summary>
    ''' crea la consulta para cargar el combo
    ''' </summary>
    ''' <param name="vp_S_Table"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadCharge_DropList(ByVal vp_S_Table As String)

        Dim ObjListDroplist As New List(Of Droplist_Class)
        Dim StrQuery As String = ""
        Dim conex As New Conector

        Dim sql As New StringBuilder

        sql.Append(" SELECT T_IndexColumna As ID, T_Traductor As descripcion FROM TC_TABLAS " & _
                   " WHERE T_Tabla = '" & vp_S_Table & "' AND T_Param = '1' ")
        StrQuery = sql.ToString

        ObjListDroplist = conex.ObjLoad_All(StrQuery, "Droplist_General")

        Return ObjListDroplist


    End Function

#End Region

#Region "CARGAR LISTAS"

    ''' <summary>
    ''' funcion que trae el listado de links para armar la tabla
    ''' </summary>
    ''' <param name="vp_S_StrQuery"></param>
    ''' <param name="vg_S_StrConexion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listLinks(ByVal vp_S_StrQuery As String, ByVal vg_S_StrConexion As String)

        'inicializamos conexiones a la BD
        Dim objcmd As OleDbCommand = Nothing
        Dim objConexBD As OleDbConnection = Nothing
        objConexBD = New OleDbConnection(vg_S_StrConexion)
        Dim ReadConsulta As OleDbDataReader = Nothing

        objcmd = objConexBD.CreateCommand

        Dim ObjListLinks As New List(Of Adm_LinksClass)

        'abrimos conexion
        objConexBD.Open()
        'cargamos consulta
        objcmd.CommandText = vp_S_StrQuery
        'ejecutamos consulta
        ReadConsulta = objcmd.ExecuteReader()

        'recorremos la consulta por la cantidad de datos en la BD
        While ReadConsulta.Read

            Dim objLinks As New Adm_LinksClass
            'cargamos datos sobre el objeto de login
            objLinks.Link_ID = ReadConsulta.GetString(0)
            objLinks.Descripcion = ReadConsulta.GetString(1)
            If Not (IsDBNull(ReadConsulta.GetValue(2))) Then objLinks.Param1 = ReadConsulta.GetValue(2) Else objLinks.Param1 = 0
            If Not (IsDBNull(ReadConsulta.GetValue(3))) Then objLinks.Param2 = ReadConsulta.GetString(3) Else objLinks.Param2 = ""
            If Not (IsDBNull(ReadConsulta.GetValue(4))) Then objLinks.Img = ReadConsulta.GetString(4) Else objLinks.Img = ""
            If Not (IsDBNull(ReadConsulta.GetValue(5))) Then objLinks.LinkPag = ReadConsulta.GetString(5) Else objLinks.LinkPag = ""
            objLinks.Estado = ReadConsulta.GetString(6)

            'agregamos a la lista
            ObjListLinks.Add(objLinks)

        End While

        'cerramos conexiones
        ReadConsulta.Close()
        objConexBD.Close()
        'retornamos la consulta
        Return ObjListLinks

    End Function

#End Region

 
End Class
