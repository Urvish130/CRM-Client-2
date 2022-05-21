<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <script type="text/javascript" language="javascript">
         function myFunction() {
             var qty = txtqty.value;
             var rate = txtrate.value;
             var amount = qty * rate;
             txtamount.value = amount;
         }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtqty" ClientIDMode="Static" onkeyup="myFunction()" runat="server"></asp:TextBox>
         <asp:TextBox ID="txtrate" ClientIDMode="Static" Text="100"  runat="server"></asp:TextBox>

             <asp:TextBox ID="txtamount" ClientIDMode="Static"   runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
