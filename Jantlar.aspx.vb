Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration
Imports System.Xml
Imports System.Xml.Linq
Imports System.Web.UI
Imports System.Net
Imports System.Net.Dns
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports MySql.Data.MySqlClient
Public Class Jantlar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'DOSYA_GRIDLE()
            DOSYA_GRIDLE_MYSQL()
        End If
    End Sub
    Public Sub DOSYA_GRIDLE_SQL()
        Dim cn1 As New SqlConnection
        cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con").ToString()
        Dim CMD As New SqlCommand("SELECT * FROM SatisSistemi.DBO.PRODUCTS WHERE PRODUCT_TYPE='Jant'", cn1)
        CMD.CommandType = CommandType.Text
        Dim DA As New SqlDataAdapter(CMD)
        Dim DT As New DataTable
        DA.Fill(DT)

        Repeater1.DataSource = DT
        Repeater1.DataBind()
    End Sub
    Public Sub DOSYA_GRIDLE_SQL_ara()
        Dim cn1 As New SqlConnection
        cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con").ToString()
        Dim CMD As New SqlCommand("SELECT * FROM SatisSistemi.DBO.PRODUCTS WHERE PRODUCT_TYPE='Jant' AND PRODUCT_NAME LIKE '%" + TxtAra.Text + "%'", cn1)
        CMD.CommandType = CommandType.Text
        Dim DA As New SqlDataAdapter(CMD)
        Dim DT As New DataTable
        DA.Fill(DT)

        Repeater1.DataSource = DT
        Repeater1.DataBind()
    End Sub
    Public Sub DOSYA_GRIDLE_MYSQL()
        Dim cn1 As New MySqlConnection
        cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con_mysql").ToString()
        Dim CMD As New MySqlCommand("SELECT * FROM PRODUCTS WHERE PRODUCT_TYPE='Jant' ORDER BY PRODUCT_ID DESC", cn1)
        CMD.CommandType = MySqlDbType.Text
        Dim DA As New MySqlDataAdapter(CMD)
        Dim DT As New DataTable
        DA.Fill(DT)

        Repeater1.DataSource = DT
        Repeater1.DataBind()
    End Sub
    Public Sub DOSYA_GRIDLE_MYSQL_ara()
        Dim cn1 As New MySqlConnection
        cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con_mysql").ToString()
        Dim CMD As New MySqlCommand("SELECT * FROM PRODUCTS WHERE PRODUCT_TYPE='Jant' AND PRODUCT_NAME LIKE '%" + TxtAra.Text + "%'", cn1)
        CMD.CommandType = MySqlDbType.Text
        Dim DA As New MySqlDataAdapter(CMD)
        Dim DT As New DataTable
        DA.Fill(DT)

        Repeater1.DataSource = DT
        Repeater1.DataBind()
    End Sub
    Private Sub Btn_Urun_Ara_Click(sender As Object, e As EventArgs) Handles Btn_Urun_Ara.Click
        'DOSYA_GRIDLE_SQL_ara()
        DOSYA_GRIDLE_MYSQL_ara()
    End Sub
End Class