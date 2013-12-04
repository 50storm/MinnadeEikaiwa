<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Calender.aspx.vb" Inherits="MinnadeEikaiwa.Calener" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"  >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
    <script type="text/javascript">
   /* $(function () {
        $("#txtMail").css("background-color", "red");
      //      alert('aaaaaa');

    });
    */
    $(function () {
        $("h2").css("background-color", "red");
        //Prefix:MainContent_ automatically added
        $('#MainContent_txtMail').css("background-color", "red");
    });
</script>
    <h2>コンセプト</h2>
<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White"  BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"  Height="190px" NextPrevFormat="FullMonth" Width="350px">

     <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
        VerticalAlign="Bottom" />
    <OtherMonthDayStyle ForeColor="#999999" />
    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
        Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
    <TodayDayStyle BackColor="#CCCCCC" />
    </asp:Calendar>


       <p>
          <asp:Label ID="lblYear" runat="server" Text="Label"></asp:Label>
          <asp:Label ID="Label3" runat="server" Text="Label">年</asp:Label>
          <asp:Label ID="lblMonth" runat="server" Text="Label"></asp:Label>
          <asp:Label ID="Label2" runat="server" Text="Label">月</asp:Label>
          <asp:Label ID="lblDay" runat="server" Text="Label"></asp:Label>
          <asp:Label ID="Label1" runat="server" Text="Label">日</asp:Label>
       </p>
       <p><asp:Label ID="Label4" runat="server" Text="Label">ニックネーム</asp:Label><asp:TextBox ID="txtName" runat="server"></asp:TextBox></p>
       <p><asp:Label ID="Label5" runat="server" Text="Label">メールアドレス</asp:Label><asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
           <input id="txtSample" type="text" /></p>
       <p><asp:Button ID="btnSubmit" runat="server" Text="Button" 
               onclientclick="return isOk();" />
           <asp:Button ID="Button1" runat="server" Text="新規登録" />
    </p>
</asp:Content>
