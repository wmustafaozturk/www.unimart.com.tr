Imports System.Web
Imports System.Web.Services
Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Xml
Imports System.Xml.Linq
Imports System.Web.UI
Imports System.Net
Imports System.Net.Dns

Public Class ImageHandler
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Dim cn1 As New SqlConnection
        Dim imageid As String = context.Request.QueryString("ImID")
        cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con").ToString()
        Dim CMD As New SqlCommand("SELECT * FROM SatisSistemi.DBO.PRODUCTS WHERE PRODUCT_ID='" + imageid + "'", cn1)
        CMD.CommandType = CommandType.Text
        Dim DA As New SqlDataAdapter(CMD)
        Dim DT As New DataTable
        DA.Fill(DT)

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class