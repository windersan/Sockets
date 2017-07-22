<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Country.aspx.cs" Inherits="Country" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    
    <div>
    
        COUNTRY:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
    </div>
      
    
    
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SUBMIT" />
        </p>
    </form>
</body>
</html>
