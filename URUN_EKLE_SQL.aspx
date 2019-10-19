<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="URUN_EKLE_SQL.aspx.vb" Inherits="UniMart.URUN_EKLE_SQL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="css_product/reset.css" type="text/css" media="all"/>
      <link href='http://fonts.googleapis.com/css?family=Asap' rel='stylesheet' type='text/css'/>
       <link rel="stylesheet" href="css_product/grid.css" type="text/css" media="all" />
      <script type="text/javascript" src="js_product/jquery-1.6.js" ></script>
      <script type="text/javascript" src="js_product/script.js"></script>
      <script type="text/javascript" src="js_product/content_switch.js"></script>
      <script type="text/javascript" src="js_product/jquery.easing.1.3.js"></script>
      <script type="text/javascript" src="js_product/superfish.js"></script>
      <script type="text/javascript" src="js_product/forms.js"></script>
      <script type="text/javascript" src="js_product/bgStretch.js"></script>
      <script type="text/javascript" src="js_product/jquery.color.js"></script>
      <script type="text/javascript" src="js_product/jquery.mousewheel.js"></script>
      <script type="text/javascript" src="js_product/jquery-ui.js"></script>
      <script type="text/javascript" src="js_product/cScroll.js"></script>
      <script type="text/javascript" src="js_product/jcarousellite.js"></script>
      <script src="js_product/googleMap.js" type="text/javascript"></script>
      <script src="js_product/jquery.msgBox.js" type="text/javascript"></script>
      <link href="css_product/msgBoxLight.css" rel="stylesheet" type="text/css"/>
    

    <meta charset="UTF-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/> 
		<meta name="viewport" content="width=device-width, initial-scale=1.0"/> 
		
		<meta name="description" content="Malatya Pazari" />
		<meta name="keywords" content="Malatya Pazari" />
		<meta name="author" content="Codrops" />
		
		<link rel="stylesheet" type="text/css" href="css_product/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css_product/demo.css" />
		<link rel="stylesheet" type="text/css" href="css_product/component.css" />
       

		<script src="js_product/modernizr.custom.js"></script>


<script type="text/javascript">
    
    function URUN_ADI_YAZINIZ() {

        $.msgBox({
            title: "ÜRÜNLER",
            content: "Lütfen ürün adını yazın..."
        });
    }

    function DOSYA_SIL_SECINIZ() {

        $.msgBox({
            title: "ÜRÜNLER",
            content: "Lütfen Silmek istediğiniz dosyayı seçiniz."
        });
    }

      function DOSYA_GUNCELLE_SECINIZ() {

        $.msgBox({
            title: "ÜRÜNLER",
            content: "Lütfen Güncellemek istediğiniz dosyayı seçiniz."
        });
    }

    function Urun_Bulunamadi() {

        $.msgBox({
            title: "ÜRÜNLER",
            content: "Aradığınız ürün bulunamadı."
        });
    }

    

    function DOSYA_SECINIZ() {

        $.msgBox({
            title: "ÜRÜNLER",
            content: "Dosya Seçiniz."
        });
    }
</script>

    <style type="text/css">
        .ddl
        {
            border:2px solid #7d6754;
            border-radius:5px;
            padding:3px;
            -webkit-appearance: none; 
            background-image:url('Images/Arrowhead-Down-01.png');
            background-position:88px;
            background-repeat:no-repeat;
            text-indent: 0.01px;/*In Firefox*/
            text-overflow: '';/*In Firefox*/
        }

        /* The switch - the box around the slider */
.switch {
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
}

/* Hide default HTML checkbox */
.switch input {
  opacity: 0;
  width: 0;
  height: 0;
}

/* The slider */
.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: .4s;
  transition: .4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 26px;
  width: 26px;
  left: 4px;
  bottom: 4px;
  background-color: white;
  -webkit-transition: .4s;
  transition: .4s;
}

input:checked + .slider {
  background-color: #2196F3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196F3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 34px;
}

.slider.round:before {
  border-radius: 50%;
}
</style>

</head>
<body>
    <form id="form1" runat="server">

         <div class="container">
             <ul id="gn-menu" class="gn-menu-main" >
				<li class="gn-trigger">
					<a class="gn-icon gn-icon-menu"><span>Menu</span></a>
					<!---<nav class="gn-menu-wrapper">
						<div class="gn-scroller">
							<ul class="gn-menu">
								
								<li><a runat="server" id="BtnYonetimRapor"  title="Yönetim Raporu">YRaporu</a></li>  
                             
								
								
							</ul>
						</div>
					</nav>-->
				</li>   
     
          <li> <asp:TextBox ID="TxtAra" runat="server" CssClass="Tracking_Text1"></asp:TextBox>    </li>           
          <li><a class="codrops-icon" id="Btn_Ara" runat="server" ><img src="images/ara.png" title="Ürün Ara" /></a></li>
          <li><a class="codrops-icon" id="Btn_Urun_Ekle" runat="server" >ÜRÜN EKLE</a></li>                 
          <li><a class="codrops-icon" id="Btn_iptal" runat="server" href="URUN_EKLE_SQL.aspx" >İŞLEM İPTAL</a></li>


                 <asp:Label ID="LBL_URUN_ID" runat="server" Font-Bold="false"></asp:Label>                                         
                 <asp:Label ID="Label1" runat="server" Font-Bold="false"></asp:Label>
                 <asp:Label ID="LblDosyaAdi" runat="server" Font-Bold="TRUE"></asp:Label>
                 <li><asp:Label ID="Beyanname_id" runat="server" Font-Bold="true" Visible="true" ></asp:Label></li>
                 <li><a class="codrops-icon " href="URUN_EKLE_SQL.aspx"><img src="images/home.png" /></a></li>
                 
             
   </ul>

</div><!--end container-->

<div id="Div_Urunler" runat="server" class="grid">

                <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="False"
                    GridLines="None"
                    AllowPaging="True"
                    CssClass="mGrid"
                    PagerStyle-CssClass="pgr"
                    OnSelectedIndexChanged = "secilenirenklendir"
                    AlternatingRowStyle-CssClass="alt" PageSize="100">
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>

                    <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/select.png" ShowSelectButton="True"   SelectText="Seç" />  
                <asp:TemplateField   HeaderStyle-BackColor="#006699" >
                <ItemTemplate>
                    <asp:Button ID="BtnDosyaSil" CommandName="BtnUrunSil" runat="server"  CssClass="BtnGridSil"/>   
                    <a id="BtnResimBuyut" runat="server" href = "javascript:void(0)" onclick = "document.getElementById('PRODUCT_IMAGE').style.display='block';document.getElementById('fade').style.display='block'"  title="Resim Büyüt" ><img src="Images/big_image.png" /></a>                   
                    <asp:Button ID="Btn_Grid_Guncelle" CommandName="Btn_Grid_Guncelle" runat="server"  CssClass="BtnGridGuncelle"/>
                </ItemTemplate>
                </asp:TemplateField> 
                        <asp:BoundField DataField="PRODUCT_ID" HeaderText="ID"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>               
                        <asp:BoundField DataField="PRODUCT_NAME" HeaderText="ÜRÜN ADI"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>                         
                        <asp:BoundField DataField="PRODUCT_DETAILS" HeaderText="ÜRÜN DETAY"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>                         
                         <asp:BoundField DataField="PRODUCT_UNIT" HeaderText="ÜRÜN BİRİM"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField> 
                        <asp:BoundField DataField="PRODUCT_PRICE" HeaderText="ÜRÜN FİYAT"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField> 
                        <asp:BoundField DataField="PRODUCT_CATEGORY" HeaderText="ÜRÜN KATAGORİ"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField> 
                        <asp:BoundField DataField="PRODUCT_BRAND" HeaderText="ÜRÜN MARKA"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>                         
                        <asp:ImageField DataImageUrlField="PRODUCT_IMAGE" DataImageUrlFormatString="~\PRODUCT_IMAGE\{0}" ControlStyle-Height="100" ControlStyle-Width="100"  HeaderStyle-BackColor="#006699"  HeaderStyle-ForeColor="White" HeaderText="ÜRÜN RESIM" />
                        <asp:BoundField DataField="PRODUCT_IMAGE" HeaderText="ÜRÜN RESIM ADI"><HeaderStyle BackColor="#006699" ForeColor="White"  /></asp:BoundField>        
                        <asp:BoundField DataField="PRODUCT_SEZON" HeaderText="ÜRÜN SEZON"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>
                         <asp:BoundField DataField="PRODUCT_TYPE" HeaderText="ÜRÜN TİPİ"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>
                          <asp:TemplateField HeaderText="KAMPANYA" HeaderStyle-BackColor="#ff8000">
                             <ItemTemplate>
                                  <asp:CheckBox ID="GRD_CHC_KAMPANYA" class="toggle" runat="server"  Checked='<%# Bind("KAMPANYA") %>'  />
                             </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
                    <FooterStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />                
                </asp:GridView>
</div>
        

        <%--URUN EKLE ///////////////////////////////////////////////////////////////////////////////////////////////--%>
 <div id="Div_Urun_Ekle" class="KullaniciGiris" runat="server" visible="false" >
            
                <table class="mGrid">
                      <tr>
                        <td>ÜRÜN TİPİ :</td>
                        <td>
                        <asp:DropDownList ID="DropDownList4"  runat="server" Width="320px" BackColor="#0066cc" ForeColor="#ffffff" Font-Names="Andalus" CssClass="ddl">
                        <asp:ListItem  Value="0" Text="--Seç--" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Lastik" Value="Lastik"></asp:ListItem> 
                        <asp:ListItem Text="Jant" Value="jant"></asp:ListItem>  
                        <asp:ListItem Text="Akü" Value="Akü"></asp:ListItem>  
                    </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="DropDownList4" 
                            InitialValue="0" ErrorMessage="Ürün Tipi Seçmek Zorunludur"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                 <tr>
                        <td>ÜRÜN ADI :</td>
                        <td>
                            <asp:TextBox ID="TXT_URUN_ADI" runat="server" CssClass="Tracking_Text1"></asp:TextBox>
                        </td>
                    </tr>

                       <tr>
                        <td>ÜRÜN AÇIKLAMA :</td>
                        <td>
                            <asp:TextBox ID="TXT_URUN_DETAY" runat="server" CssClass="Tracking_Text1"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>ÜRÜN BIRIM :</td>
                        <td>
                            <asp:TextBox ID="TXT_URUN_BIRIM" runat="server" CssClass="Tracking_Text1" Text="ADET"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ÜRÜN FİYAT :</td>
                        <td>
                            <asp:TextBox ID="TXT_URUN_FIYAT" runat="server" CssClass="Tracking_Text1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ÜRÜN GURUBU :</td>
                        <td>
                        <asp:DropDownList ID="DropDownList1"  runat="server" Width="320px" BackColor="#0066cc" ForeColor="#ffffff" Font-Names="Andalus" CssClass="ddl">                        
                        <asp:ListItem Text="Binek" Value="Binek"></asp:ListItem> 
                        <asp:ListItem Text="Ticari" Value="Ticari"></asp:ListItem>  
                        <asp:ListItem Text="Suv" Value="Suv"></asp:ListItem>  
                            <asp:ListItem Text="Jant" Value="Jant"></asp:ListItem>  
                            <asp:ListItem Text="Akü" Value="Akü"></asp:ListItem>  
                    </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td>MARKA :</td>
                        <td>
                        <asp:DropDownList ID="DropDownList2"  runat="server" Width="320px" BackColor="#0066cc" ForeColor="#ffffff" Font-Names="Andalus" CssClass="ddl">                        
                        <asp:ListItem Text="Continental" Value="Continental"></asp:ListItem> 
                         <asp:ListItem Text="Barum" Value="Barum"></asp:ListItem>  
                        <asp:ListItem Text="Matador" Value="Matador"></asp:ListItem>  
                             <asp:ListItem Text="Jant" Value="Jant"></asp:ListItem> 
                            <asp:ListItem Text="Yiğit_Akü" Value="Yiğit_Akü"></asp:ListItem>  
                            <asp:ListItem Text="Mutlu_Akü" Value="Mutlu_Akü"></asp:ListItem>  
                            <asp:ListItem Text="Varta_Akü" Value="Varta_Akü"></asp:ListItem>  
                    </asp:DropDownList>
                        </td>
                    </tr>
                          <tr>
                        <td>SEZON :</td>
                        <td>
                        <asp:DropDownList ID="DropDownList3"  runat="server" Width="320px" BackColor="#0066cc" ForeColor="#ffffff" Font-Names="Andalus" CssClass="ddl">             
                        <asp:ListItem Text="Yazlik" Value="Yazlik"></asp:ListItem> 
                        <asp:ListItem Text="Kışlık" Value="Kışlık"></asp:ListItem>  
                        <asp:ListItem Text="4_Mevsim" Value="4_Mevsim"></asp:ListItem>  
                             <asp:ListItem Text="Jant" Value="Jant"></asp:ListItem>  
                            <asp:ListItem Text="Akü" Value="Akü"></asp:ListItem>  
                    </asp:DropDownList>
                            
                        </td>

                    </tr> 
                     <tr>
                        <td>KAMPANYA :</td>
                        <td>
                           <input  type="checkbox" name="CHC_KAMPANYA" runat="server"    id="CHC_KAMPANYA"    />
                        </td>
                    </tr>
                    <tr>
                       <td>ÜRÜN SEÇ :</td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="Tracking_Text1" />
                            </td>
                    </tr>                   

                        <tr>
                            <td>
                                <asp:Button ID="Btn_Urun_Yukle_Kaydet" runat="server" CssClass="Tracking_Buttons" Text="Kaydet" />  
                                <asp:Button ID="Btn_Urun_Yukle_Guncelle" runat="server" CssClass="Tracking_Buttons" Text="Güncelle" visible="false"/>  
                                <%--<asp:Button ID="Btn_Urun_Kaydet_Iptal"    runat="server" CssClass="Tracking_Buttons" Text="İptal" />--%>
                            </td>
                    </tr>
               
                </table>

    </div>
<%--URUN EKLE BITIS///////////////////////////////////////////////////////////////////////////////////////////////////--%>
<%--ürünler burda gösteriliyor--%>
<div id="fade" class="black_overlay"></div>
<div id="PRODUCT_IMAGE" class="PRODUCT_IMAGE_BOX"> 
<div id="MesajBoxHeaderCari" style="position:absolute;top:0px;right:0px;">
    <a href = "javascript:void(0)"  onclick = "document.getElementById('PRODUCT_IMAGE').style.display='none';document.getElementById('fade').style.display='none'"><img src="Images/iptal.png" /></a>
</div>
<div style="position:relative;top:30px;">
    <h3>ÜRÜN RESİM</h3>
    <asp:Image ID="Image1" runat="server" />
</div>
					
</div>
<%--ürünler detaylar bitiş--%>
    </form>
</body>
</html>
