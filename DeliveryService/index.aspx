﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DeliveryService.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send an e-mail</title>

    <link href="Content/Site.css" type="text/css" rel="stylesheet"/>

</head>
<body>

    <header ><center><b><h1>Send e-mail</h1></b></center></header>
    <form
        id="form1"
        runat="server"
        
        >
        <br /><br /><br /><br />
   <table align="center" width ="60%">
       <tr>
           <td>From</td>
           <td>
               <asp:TextBox ID="to" runat="server" Text="" Width="80%"></asp:TextBox>
           </td>
       </tr>

        <tr>
           <td>To</td>
           <td>
               <asp:TextBox ID="from" runat="server" Text="" Width="80%"></asp:TextBox>
           </td>
       </tr>

        <tr>
           <td>Subject</td>
           <td>
               <asp:TextBox ID="subject" runat="server" Text="" Width="80%"></asp:TextBox>
           </td>
       </tr>

        <tr>
           <td>Body</td>
           <td>
               <asp:TextBox ID="body" runat="server" Text="" Width="80%" Height="150px" TextMode="MultiLine"></asp:TextBox>
           </td>
       </tr>

        <tr>
           <td>Attachemnt</td>
           <td>
               <asp:FileUpload ID="fileUpload1" runat="server"></asp:FileUpload>

           </td>
       </tr>
        <tr>
           <td></td>
           <td>
                <asp:Button ID="send" OnClick="send_Click" runat="server" Text="Send" class="btn btn-success"></asp:Button>
               </td>
       </tr>
       <tr>
           <td></td>
           <td>
                <asp:Label ID="status" runat="server" Text="" Width="80%"></asp:Label>
           </td>
       </tr>
       
       <asp:Button ID="Button2" OnClick="Home" runat="server" align ="center" Text="Home Page"></asp:Button> 

   </table>
    </form>

     
</body>
</html>
