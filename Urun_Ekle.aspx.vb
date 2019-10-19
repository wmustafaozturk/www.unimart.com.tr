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
Public Class Urun_Ekle
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
        cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con").ToString()
        Dim CMD As New MySqlCommand("SELECT * FROM URUNLER", cn1)
        CMD.CommandType = MySqlDbType.Text
        Dim DA As New MySqlDataAdapter(CMD)
        Dim DT As New DataTable
        DA.Fill(DT)

        GridView1.DataSource = DT
        GridView1.DataBind()
    End Sub
    Private Sub Btn_Urun_Ara_Click(sender As Object, e As EventArgs) Handles Btn_Urun_Ara.Click
        URUN_ARA()
    End Sub
    Public Sub URUN_ARA()
        'If cn1.State = ConnectionState.Closed Then cn1.Open()
        Dim cn1 As New MySqlConnection
        cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con").ToString()
        Dim CMD As New MySqlCommand("SELECT * FROM URUNLER WHERE URUN_ADI LIKE  '%" + TxtAra.Text + "%'", cn1)

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
                ' e.Row.Cells(0).Visible = False
            Next
        End If
        '//////gridview kolon gizleme//////

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
        LBL_URUN_ID.Text = GridView1.SelectedRow.Cells(0).Text
        LblDosyaAdi.Text = GridView1.SelectedRow.Cells(7).Text
        TXT_URUN_ADI.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells(1).Text)
        TXT_URUN_DETAY.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells(2).Text)
        TXT_URUN_FIYAT.Text = GridView1.SelectedRow.Cells(3).Text
    End Sub
    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "BtnUrunSil" Then
            If LBL_URUN_ID.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_SIL_SECINIZ();", True)
                Exit Sub
            End If
            Dim cn1 As New MySqlConnection
            cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con").ToString()
            Dim cmd As New MySqlCommand("DELETE FROM URUNLER  WHERE URUN_ID='" + LBL_URUN_ID.Text + "' ", cn1)
            cmd.CommandType = MySqlDbType.Text
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            'BURADA KLASÖRDEKİ DOSYAYI SİLİYORUM
            Dim dosya_ismi As String = LblDosyaAdi.Text
            Dim kaynak As String = Server.MapPath("~/URUN_RESIMLER/") + dosya_ismi
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
    End Sub
    Private Function resim_boyulandir(resim As Stream, genislik As Integer, yukseklik As Integer) As Bitmap
        Dim orjinalresim As New Bitmap(resim)
        Dim yenigenislik As Integer = orjinalresim.Width
        Dim yeniyukseklik As Integer = orjinalresim.Height
        Dim enboyorani As Double = Convert.ToDouble(orjinalresim.Width) / Convert.ToDouble(orjinalresim.Height)
        'www.aspnetornekleri.com
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

            dosya_adi = sayi.ToString + FileUpload1.FileName
            'FileUploand1.SaveAs diyerek sunucumuzdaki files klasöürüne dosya adimizi degiştirerek kaydediyoruz..
            FileUpload1.SaveAs(Server.MapPath("URUN_RESIMLER/" + dosya_adi + uzanti))
            'Sonucu bildiriyoruz...
            Label1.Text = "Dosya başarı ile eklendi !!!"
            DOSYA_GRIDLE()

            'Dim resim As String = String.Empty
            'Dim yeniresim As Bitmap = Nothing
            'Try
            '    dosya_adi = FileUpload1.FileName
            '    yeniresim = resim_boyulandir(FileUpload1.PostedFile.InputStream, 400, 400)
            '    'yeni resim için boyut veriyoruz..
            '    resim = Server.MapPath("URUN_RESIMLER/") + dosya_adi
            '    'www.aspnetornekleri.com
            '    yeniresim.Save(resim, ImageFormat.Jpeg)
            'Catch ex As Exception
            '    Response.Write("Hata Oluştu: " + ex.Message.ToString())
            'Finally
            '    resim = String.Empty
            '    yeniresim.Dispose()
            '    Label1.Text = "Dosya başarı ile eklendi !!!"
            '    DOSYA_GRIDLE()
            'End Try


            'Dosyamızı klasöre kayıt ettik yanlız veritabanlı uygulamalarda veri tabaninada gerekli bilgileri kaydetmek isteyebiliriz...
            'Aşagıda kodlarla sunucumuza yüklediğimiz dosyanin bilgilerini veritabanina kaydediyoruz...
            Dim cn1 As New MySqlConnection
            cn1.ConnectionString = WebConfigurationManager.ConnectionStrings("Con").ToString()
            cn1.Open()


            Dim EKLE As New MySqlCommand("INSERT INTO URUNLER(URUN_RESMI,URUN_ADI,URUN_DETAY,URUN_FIYAT,URUN_BIRIM,URUN_GURUBU,RECORD_DATE,KAYIT_EDEN) 
                                                                  values (@URUN_RESMI,@URUN_ADI,@URUN_DETAY,@URUN_FIYAT,@URUN_BIRIM,@URUN_GURUBU,@RECORD_DATE,@KAYIT_EDEN) ", cn1)
            If dosya_adi = "" Then EKLE.Parameters.Add("@URUN_RESMI", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@URUN_RESMI", MySqlDbType.VarChar).Value = dosya_adi
            If TXT_URUN_ADI.Text = "" Then EKLE.Parameters.Add("@URUN_ADI", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@URUN_ADI", MySqlDbType.VarChar).Value = TXT_URUN_ADI.Text
            If TXT_URUN_DETAY.Text = "" Then EKLE.Parameters.Add("@URUN_DETAY", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@URUN_DETAY", MySqlDbType.VarChar).Value = TXT_URUN_DETAY.Text
            If TXT_URUN_FIYAT.Text = "" Then EKLE.Parameters.Add("@URUN_FIYAT", MySqlDbType.Decimal).Value = "0" Else EKLE.Parameters.Add("@URUN_FIYAT", MySqlDbType.Decimal).Value = TXT_URUN_FIYAT.Text
            If TXT_URUN_BIRIM.Text = "" Then EKLE.Parameters.Add("@URUN_BIRIM", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@URUN_BIRIM", MySqlDbType.VarChar).Value = TXT_URUN_BIRIM.Text
            If DropDownList1.Text = "" Then EKLE.Parameters.Add("@URUN_GURUBU", MySqlDbType.VarChar).Value = "0" Else EKLE.Parameters.Add("@URUN_GURUBU", MySqlDbType.VarChar).Value = DropDownList1.Text
            EKLE.Parameters.Add("@RECORD_DATE", MySqlDbType.DateTime).Value = Date.Now
            EKLE.Parameters.Add("@KAYIT_EDEN", MySqlDbType.VarChar).Value = 0

            If cn1.State = ConnectionState.Closed Then
                cn1.Open()
            End If
            EKLE.ExecuteNonQuery()
            DOSYA_GRIDLE()

        Else
            Label1.Text = "Dosya seçimi yapılmadı !!!"
        End If


    End Sub
    Protected Sub btnyukle_Click(sender As Object, e As EventArgs)
        If FileUpload1.HasFile Then
            Dim resim As String = String.Empty
            Dim yeniresim As Bitmap = Nothing
            Try
                yeniresim = resim_boyulandir(FileUpload1.PostedFile.InputStream, 210, 130)
                'yeni resim için boyut veriyoruz..
                resim = Server.MapPath("urun_resimler/") + Guid.NewGuid().ToString() + ".png"
                'www.aspnetornekleri.com
                yeniresim.Save(resim, ImageFormat.Jpeg)
            Catch ex As Exception
                Response.Write("Hata Oluştu: " + ex.Message.ToString())
            Finally
                resim = String.Empty
                yeniresim.Dispose()
            End Try
        End If
    End Sub
    Private Sub Btn_Urun_Ekle_ServerClick(sender As Object, e As EventArgs) Handles Btn_Urun_Ekle.ServerClick
        Div_Urunler.Visible = False
        Div_Urun_Ekle.Visible = True
    End Sub

End Class