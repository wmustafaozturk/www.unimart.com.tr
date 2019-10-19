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
Public Class URUN_EKLE_MYSQL
    Inherits System.Web.UI.Page
    Dim uzanti As String = ""
    Dim dosya_adi As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            DOSYA_GRIDLE()
        End If
    End Sub
    Public Sub DOSYA_GRIDLE()
        Dim cn1 As New MySqlConnection
        cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con_mysql").ToString()
        Dim CMD As New MySqlCommand("SELECT * FROM PRODUCTS ORDER BY PRODUCT_ID DESC", cn1)
        CMD.CommandType = MySqlDbType.Text
        Dim DA As New MySqlDataAdapter(CMD)
        Dim DT As New DataTable
        DA.Fill(DT)

        GridView1.DataSource = DT
        GridView1.DataBind()
    End Sub
    Private Sub Btn_Ara_ServerClick(sender As Object, e As EventArgs) Handles Btn_Ara.ServerClick
        URUN_ARA()
    End Sub
    Public Sub URUN_ARA()
        'If cn1.State = ConnectionState.Closed Then cn1.Open()
        Dim cn1 As New MySqlConnection
        cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con_mysql").ToString()
        Dim CMD As New MySqlCommand("SELECT * FROM PRODUCTS WHERE PRODUCT_NAME LIKE  '%" + TxtAra.Text + "%'", cn1)

        CMD.CommandType = MySqlDbType.Text
        Dim DA As New MySqlDataAdapter(CMD)
        Dim DT As New DataTable
        DA.Fill(DT)

        GridView1.DataSource = DT
        GridView1.DataBind()
        If DT.Rows.Count = 0 Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "Urun_Bulunamadi();", True)
        End If
    End Sub
    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        'mouse üzerine gelice satır renklendirmek için
        If e.Row.RowType = System.Web.UI.WebControls.DataControlRowType.DataRow Then
            ' when mouse is over the row, save original color to new attribute, and change it to highlight color
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#AFAFAF'")
            ' when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")
        End If

        '//////gridview kolon gizleme//////
        If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
            For i As Integer = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(2).Visible = False
            Next
        End If
        '//////gridview kolon gizleme//////

    End Sub
    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
        DOSYA_GRIDLE()
    End Sub
    Protected Sub secilenirenklendir(sender As Object, e As EventArgs)
        For Each row As GridViewRow In GridView1.Rows
            If row.RowIndex = GridView1.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
            End If
        Next
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged



        LBL_URUN_ID.Text = GridView1.SelectedRow.Cells(2).Text
            LblDosyaAdi.Text = GridView1.SelectedRow.Cells(10).Text
            TXT_URUN_ADI.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells(3).Text)
            TXT_URUN_DETAY.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells(4).Text)
            TXT_URUN_BIRIM.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells(5).Text)
            TXT_URUN_FIYAT.Text = GridView1.SelectedRow.Cells(6).Text
            DropDownList1.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells(7).Text) 'PRODUCT_CATEGORY
            DropDownList2.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells(8).Text) 'PRODUCT_BRAND
            DropDownList3.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells(11).Text) 'PRODUCT_SEZON
            DropDownList4.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells(12).Text) 'PRODUCT_TYPE
            Image1.ImageUrl = "../PRODUCT_IMAGE/" & GridView1.SelectedRow.Cells(10).Text

        ' bu alanda güncelleme yapılırken checkbox lara veritabanından bilgileri alıyorum 
        Dim cn1 As New MySqlConnection
        cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con_mysql").ToString()
        Dim cmd1 As New MySqlCommand("SELECT * FROM PRODUCTS WHERE PRODUCT_ID='" + LBL_URUN_ID.Text + "'", cn1)
        cmd1.CommandType = MySqlDbType.Text
        Dim da1 As New MySqlDataAdapter(cmd1)
        Dim dt1 As New DataTable
        da1.Fill(dt1)

        CHC_KAMPANYA.Checked = Convert.ToBoolean(dt1.Rows(0).Item("KAMPANYA").ToString())
    End Sub
    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "BtnUrunSil" Then
            If LBL_URUN_ID.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_SIL_SECINIZ();", True)
                Exit Sub
            End If
            Dim cn1 As New MySqlConnection
            cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con_mysql").ToString()
            Dim cmd As New MySqlCommand("DELETE FROM PRODUCTS  WHERE PRODUCT_ID='" + LBL_URUN_ID.Text + "' ", cn1)
            cmd.CommandType = MySqlDbType.Text
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            'BURADA KLASÖRDEKİ DOSYAYI SİLİYORUM
            Dim dosya_ismi As String = LblDosyaAdi.Text
            Dim kaynak As String = Server.MapPath("~/PRODUCT_IMAGE/") + dosya_ismi
            Dim dosya As New FileInfo(kaynak)
            dosya.Delete()
            'BURADA KLASÖRDEKİ DOSYAYI SİLİYORUM

            GridView1.DataSource = dt
            GridView1.DataBind()
            If dt.Rows.Count = 0 Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_SIL();", True)
            End If
            LBL_URUN_ID.Text = ""
            LblDosyaAdi.Text = ""
            Btn_iptal.Visible = True
            DOSYA_GRIDLE()
        End If
        If e.CommandName = "Btn_Grid_Guncelle" Then
            If LBL_URUN_ID.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_GUNCELLE_SECINIZ();", True)
                Exit Sub
            End If
            Div_Urunler.Visible = False
            Btn_Urun_Yukle_Kaydet.Visible = False
            Div_Urun_Ekle.Visible = True
            Btn_Urun_Yukle_Guncelle.Visible = True
        End If
        If e.CommandName = "BtnResimBuyut" Then
            If LBL_URUN_ID.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_SIL_SECINIZ();", True)
                Exit Sub
            End If
            'Dim sayi As String = LBL_URUN_ID.Text
            ''Response.Redirect("ImageHandler.ashx?ImID=" & sayi & "")
            'Response.Redirect("ImageHandler.ashx?ImID=" + sayi.ToString())
        End If
    End Sub
    Private Function resim_boyulandir(ByVal resim As Stream, ByVal genislik As Integer, ByVal yukseklik As Integer) As Bitmap
        Dim orjinalresim As Bitmap = New Bitmap(resim)
        Dim yenigenislik As Integer = orjinalresim.Width
        Dim yeniyukseklik As Integer = orjinalresim.Height
        Dim enboyorani As Double = Convert.ToDouble(orjinalresim.Width) / Convert.ToDouble(orjinalresim.Height)
        If enboyorani <= 1 AndAlso orjinalresim.Width > genislik Then
            yenigenislik = genislik
            yeniyukseklik = Convert.ToInt32(Math.Round(yenigenislik / enboyorani))
        ElseIf enboyorani > 1 AndAlso orjinalresim.Height > yukseklik Then
            yeniyukseklik = yukseklik
            yenigenislik = Convert.ToInt32(Math.Round(yeniyukseklik * enboyorani))
        End If

        Return New Bitmap(orjinalresim, yenigenislik, yeniyukseklik)
    End Function
    Private Sub Btn_Urun_Yukle_Kaydet_Click(sender As Object, e As EventArgs) Handles Btn_Urun_Yukle_Kaydet.Click
        If TXT_URUN_ADI.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "URUN_ADI_YAZINIZ();", True)
            Exit Sub
        End If

        If FileUpload1.FileName = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_SECINIZ();", True)
            Exit Sub
        End If

        ' FileUploand kontrolümüzde HasFile kodu ile dosya olup olmadığını kontrol ediyoruz...
        If FileUpload1.HasFile Then

            Dim rastgele As Random = New Random()
            Dim sayi As Integer = rastgele.[Next]()


            Dim resim As String = String.Empty
            Dim yeniresim As Bitmap = Nothing
            Try
                dosya_adi = sayi.ToString + FileUpload1.FileName
                yeniresim = resim_boyulandir(FileUpload1.PostedFile.InputStream, 800, 600)
                resim = Server.MapPath("~/PRODUCT_IMAGE/") + dosya_adi
                yeniresim.Save(resim, ImageFormat.Jpeg)

                Label1.Text = "Dosya başarı ile eklendi !!!"
                DOSYA_GRIDLE()

                Dim cn1 As New MySqlConnection
                cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con_mysql").ToString()
                cn1.Open()

                Dim EKLE As New MySqlCommand("INSERT INTO PRODUCTS(PRODUCT_NAME,PRODUCT_DETAILS,PRODUCT_UNIT,PRODUCT_PRICE,PRODUCT_CATEGORY,PRODUCT_BRAND,PRODUCT_SEZON,PRODUCT_TYPE,PRODUCT_IMAGE,KAMPANYA,RECORD_DATE,RECORD_NAME) 
                                                                  values (@PRODUCT_NAME,@PRODUCT_DETAILS,@PRODUCT_UNIT,@PRODUCT_PRICE,@PRODUCT_CATEGORY,@PRODUCT_BRAND,@PRODUCT_SEZON,@PRODUCT_TYPE,@PRODUCT_IMAGE,@KAMPANYA,@RECORD_DATE,@RECORD_NAME) ", cn1)
                If TXT_URUN_ADI.Text = "" Then EKLE.Parameters.Add("@PRODUCT_NAME", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@PRODUCT_NAME", MySqlDbType.VarChar).Value = TXT_URUN_ADI.Text
                If TXT_URUN_DETAY.Text = "" Then EKLE.Parameters.Add("@PRODUCT_DETAILS", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@PRODUCT_DETAILS", MySqlDbType.VarChar).Value = TXT_URUN_DETAY.Text
                If TXT_URUN_BIRIM.Text = "" Then EKLE.Parameters.Add("@PRODUCT_UNIT", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@PRODUCT_UNIT", MySqlDbType.VarChar).Value = TXT_URUN_BIRIM.Text
                If TXT_URUN_FIYAT.Text = "" Then EKLE.Parameters.Add("@PRODUCT_PRICE", MySqlDbType.Decimal).Value = "0" Else EKLE.Parameters.Add("@PRODUCT_PRICE", MySqlDbType.Decimal).Value = TXT_URUN_FIYAT.Text
                If DropDownList1.Text = "" Then EKLE.Parameters.Add("@PRODUCT_CATEGORY", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@PRODUCT_CATEGORY", MySqlDbType.VarChar).Value = DropDownList1.Text
                If DropDownList2.Text = "" Then EKLE.Parameters.Add("@PRODUCT_BRAND", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@PRODUCT_BRAND", MySqlDbType.VarChar).Value = DropDownList2.Text
                If DropDownList3.Text = "" Then EKLE.Parameters.Add("@PRODUCT_SEZON", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@PRODUCT_SEZON", MySqlDbType.VarChar).Value = DropDownList3.Text
                If DropDownList4.Text = "" Then EKLE.Parameters.Add("@PRODUCT_TYPE", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@PRODUCT_TYPE", MySqlDbType.VarChar).Value = DropDownList4.Text
                EKLE.Parameters.Add("@KAMPANYA", MySqlDbType.TinyText).Value = CHC_KAMPANYA.Checked
                If dosya_adi = "" Then EKLE.Parameters.Add("@PRODUCT_IMAGE", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@PRODUCT_IMAGE", MySqlDbType.VarChar).Value = dosya_adi
                EKLE.Parameters.Add("@RECORD_DATE", MySqlDbType.DateTime).Value = Date.Now
                EKLE.Parameters.Add("@RECORD_NAME", MySqlDbType.VarChar).Value = 0

                If cn1.State = ConnectionState.Closed Then
                    cn1.Open()
                End If
                EKLE.ExecuteNonQuery()
                DOSYA_GRIDLE()


            Catch ex As Exception
                Response.Write("Hata Oluştu: " & ex.Message.ToString())
            Finally
                resim = String.Empty
                yeniresim.Dispose()
            End Try
        End If
    End Sub
    Private Sub Btn_Urun_Yukle_Guncelle_Click(sender As Object, e As EventArgs) Handles Btn_Urun_Yukle_Guncelle.Click
        If LBL_URUN_ID.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_SIL_SECINIZ();", True)
            Exit Sub
        End If
        If FileUpload1.FileName = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_SECINIZ();", True)
            Exit Sub
        End If

        'BURADA KLASÖRDEKİ DOSYAYI SİLİYORUM
        Dim dosya_ismi As String = LblDosyaAdi.Text
        Dim kaynak As String = Server.MapPath("~/PRODUCT_IMAGE/") + dosya_ismi
        Dim dosya As New FileInfo(kaynak)
        dosya.Delete()
        LblDosyaAdi.Text = ""
        'BURADA KLASÖRDEKİ DOSYAYI SİLİYORUM


        If FileUpload1.HasFile Then

            Dim rastgele As Random = New Random()
            Dim sayi As Integer = rastgele.[Next]()


            Dim resim As String = String.Empty
            Dim yeniresim As Bitmap = Nothing
            Try
                dosya_adi = sayi.ToString + FileUpload1.FileName
                yeniresim = resim_boyulandir(FileUpload1.PostedFile.InputStream, 800, 600)
                resim = Server.MapPath("~/PRODUCT_IMAGE/") + dosya_adi
                yeniresim.Save(resim, ImageFormat.Jpeg)

                Label1.Text = "Dosya başarı ile eklendi !!!"
                Dim cn1 As New MySqlConnection
                cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con_mysql").ToString()
                cn1.Open()
                Dim GUNCELLE As New MySqlCommand("UPDATE PRODUCTS SET 
                                                                         PRODUCT_NAME=@PRODUCT_NAME
                                                                        ,PRODUCT_DETAILS=@PRODUCT_DETAILS
                                                                        ,PRODUCT_UNIT=@PRODUCT_UNIT
                                                                        ,PRODUCT_PRICE=@PRODUCT_PRICE
                                                                        ,PRODUCT_CATEGORY=@PRODUCT_CATEGORY
                                                                        ,PRODUCT_BRAND=@PRODUCT_BRAND
                                                                        ,PRODUCT_SEZON=@PRODUCT_SEZON
                                                                        ,PRODUCT_TYPE=@PRODUCT_TYPE
                                                                        ,KAMPANYA=@KAMPANYA
                                                                        ,PRODUCT_IMAGE=@PRODUCT_IMAGE WHERE  PRODUCT_ID='" + LBL_URUN_ID.Text + "'", cn1)
                If TXT_URUN_ADI.Text = "" Then GUNCELLE.Parameters.Add("@PRODUCT_NAME", MySqlDbType.VarChar).Value = "0" Else GUNCELLE.Parameters.Add("@PRODUCT_NAME", MySqlDbType.VarChar).Value = TXT_URUN_ADI.Text
                If TXT_URUN_DETAY.Text = "" Then GUNCELLE.Parameters.Add("@PRODUCT_DETAILS", MySqlDbType.VarChar).Value = "0" Else GUNCELLE.Parameters.Add("@PRODUCT_DETAILS", MySqlDbType.VarChar).Value = TXT_URUN_DETAY.Text
                If TXT_URUN_BIRIM.Text = "" Then GUNCELLE.Parameters.Add("@PRODUCT_UNIT", MySqlDbType.VarChar).Value = "0" Else GUNCELLE.Parameters.Add("@PRODUCT_UNIT", MySqlDbType.VarChar).Value = TXT_URUN_BIRIM.Text
                If TXT_URUN_FIYAT.Text = "" Then GUNCELLE.Parameters.Add("@PRODUCT_PRICE", MySqlDbType.Decimal).Value = "0" Else GUNCELLE.Parameters.Add("@PRODUCT_PRICE", MySqlDbType.Decimal).Value = TXT_URUN_FIYAT.Text
                If DropDownList1.Text = "" Then GUNCELLE.Parameters.Add("@PRODUCT_CATEGORY", MySqlDbType.VarChar).Value = "0" Else GUNCELLE.Parameters.Add("@PRODUCT_CATEGORY", MySqlDbType.VarChar).Value = DropDownList1.Text
                If DropDownList2.Text = "" Then GUNCELLE.Parameters.Add("@PRODUCT_BRAND", MySqlDbType.VarChar).Value = "0" Else GUNCELLE.Parameters.Add("@PRODUCT_BRAND", MySqlDbType.VarChar).Value = DropDownList2.Text
                If DropDownList3.Text = "" Then GUNCELLE.Parameters.Add("@PRODUCT_SEZON", MySqlDbType.VarChar).Value = "0" Else GUNCELLE.Parameters.Add("@PRODUCT_SEZON", MySqlDbType.VarChar).Value = DropDownList3.Text
                If DropDownList4.Text = "" Then GUNCELLE.Parameters.Add("@PRODUCT_TYPE", MySqlDbType.VarChar).Value = "0" Else GUNCELLE.Parameters.Add("@PRODUCT_TYPE", MySqlDbType.VarChar).Value = DropDownList4.Text
                GUNCELLE.Parameters.Add("@KAMPANYA", MySqlDbType.TinyText).Value = CHC_KAMPANYA.Checked
                If dosya_adi = "" Then GUNCELLE.Parameters.Add("@PRODUCT_IMAGE", MySqlDbType.VarChar).Value = "0" Else GUNCELLE.Parameters.Add("@PRODUCT_IMAGE", MySqlDbType.VarChar).Value = dosya_adi

                If cn1.State = ConnectionState.Closed Then
                    cn1.Open()
                End If
                GUNCELLE.ExecuteNonQuery()
                DOSYA_GRIDLE()
            Catch ex As Exception
                Response.Write("Hata Oluştu: " & ex.Message.ToString())
            Finally
                resim = String.Empty
                yeniresim.Dispose()
            End Try
        End If
        Div_Urunler.Visible = True
        Div_Urun_Ekle.Visible = False
    End Sub
    Private Sub Btn_Urun_Ekle_ServerClick(sender As Object, e As EventArgs) Handles Btn_Urun_Ekle.ServerClick
        Div_Urunler.Visible = False
        Div_Urun_Ekle.Visible = True
    End Sub

End Class
