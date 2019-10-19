'------------------------------------------------------------------------------
' <otomatik üretildi>
'     Bu kod bir araç tarafından oluşturuldu.
'
'     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
'     kod tekrar üretildi. 
' </otomatik üretildi>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class URUN_EKLE_MYSQL
    
    '''<summary>
    '''form1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents form1 As Global.System.Web.UI.HtmlControls.HtmlForm
    
    '''<summary>
    '''BtnYonetimRapor denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnYonetimRapor As Global.System.Web.UI.HtmlControls.HtmlAnchor
    
    '''<summary>
    '''TxtAra denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TxtAra As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Btn_Ara denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_Ara As Global.System.Web.UI.HtmlControls.HtmlAnchor
    
    '''<summary>
    '''Btn_Urun_Ekle denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_Urun_Ekle As Global.System.Web.UI.HtmlControls.HtmlAnchor
    
    '''<summary>
    '''Btn_iptal denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_iptal As Global.System.Web.UI.HtmlControls.HtmlAnchor
    
    '''<summary>
    '''LBL_URUN_ID denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents LBL_URUN_ID As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Label1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Label1 As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''LblDosyaAdi denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents LblDosyaAdi As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Beyanname_id denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Beyanname_id As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Div_Urunler denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Div_Urunler As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''GridView1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents GridView1 As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Div_Urun_Ekle denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Div_Urun_Ekle As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''DropDownList4 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents DropDownList4 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''rfvType denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents rfvType As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''TXT_URUN_ADI denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_URUN_ADI As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''TXT_URUN_DETAY denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_URUN_DETAY As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''TXT_URUN_BIRIM denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_URUN_BIRIM As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''TXT_URUN_FIYAT denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_URUN_FIYAT As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''DropDownList1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents DropDownList1 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''DropDownList2 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents DropDownList2 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''DropDownList3 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents DropDownList3 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''CHC_KAMPANYA denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents CHC_KAMPANYA As Global.System.Web.UI.HtmlControls.HtmlInputCheckBox
    
    '''<summary>
    '''FileUpload1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents FileUpload1 As Global.System.Web.UI.WebControls.FileUpload
    
    '''<summary>
    '''Btn_Urun_Yukle_Kaydet denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_Urun_Yukle_Kaydet As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Btn_Urun_Yukle_Guncelle denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_Urun_Yukle_Guncelle As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Image1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Image1 As Global.System.Web.UI.WebControls.Image
End Class
