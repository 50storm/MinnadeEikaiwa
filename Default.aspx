<%@ Page Title="ホーム ページ" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="MinnadeEikaiwa._Default" %>

<%--<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<H1>ヘッダーコンテンツ</H1>
</asp:Content>--%>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
     $(function(){
         $("h2").css("background-color", "red");
     });
 </script>


    
       <h2>コンセプト</h2>
<ul>
    <li>楽しく！</li>
    <li>みんなで助け合う！</li>
    <li>フィードバックしあう！</li>
</ul>

</asp:Content>
