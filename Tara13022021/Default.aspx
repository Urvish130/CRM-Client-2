<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>	
<!DOCTYPE html>	
<html>	
<head>	
    <meta charset="utf-8">	
    <meta http-equiv="X-UA-Compatible" content="IE=edge">	
    <title>Tara Instruments</title>	
    <!-- Tell the browser to be responsive to screen width -->	
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">	
    <!-- Bootstrap 3.3.6 -->	
    <link rel="stylesheet" href="../../bootstrap/css/bootstrap.min.css">	
    <!-- Font Awesome -->	
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">	
    <!-- Ionicons -->	
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">	
    <!-- Theme style -->	
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">	
    <!-- iCheck -->	
    <link rel="stylesheet" href="../../plugins/iCheck/square/blue.css">	
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->	
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->	
    <!--[if lt IE 9]>	
    <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>	
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>	
    <![endif]-->	
<style>	
    * {	
      margin: 0;	
      padding: 0;	
      box-sizing: border-box;	
      user-select: none;	
    }	
    .bg-img {	
      background: url("https://images.pexels.com/photos/34088/pexels-photo.jpg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940");	
      height: 100vh;	
      background-size: cover;	
      background-position: center;	
    }	
      .bg-img:after {	
        position: absolute;	
        content: "";	
        top: 0;	
        left: 0;	
        height: 100%;	
        width: 100%;	
        background: rgba(0, 0, 0, 0.7);	
      }	
    .content {	
      position: absolute;	
      top: 50%;	
      left: 50%;	
      z-index: 999;	
      text-align: center;	
      padding: 60px 32px;	
      width: 370px;	
      transform: translate(-50%, -50%);	
      background: rgba(255, 255, 255, 0.04);	
      box-shadow: -1px 4px 28px 0px rgba(0, 0, 0, 0.75);	
    }	
      .content header {	
        color: white;	
        font-size: 33px;	
        font-weight: 600;	
        margin: 0 0 35px 0;	
        font-family: "Montserrat", sans-serif;	
      }	
    .field {	
      position: relative;	
      height: 45px;	
      width: 100%;	
      display: flex;	
      background: rgba(255, 255, 255, 0.94);	
    }	
      .field span {	
        color: #222;	
        width: 40px;	
        line-height: 45px;	
      }	
      .field input {	
        height: 100%;	
        width: 100%;	
        background: transparent;	
        border: none;	
        outline: none;	
        color: #222;	
        font-size: 16px;	
        font-family: "Poppins", sans-serif;	
      }	
    .space {	
      margin-top: 16px;	
    }	
    .show {	
      position: absolute;	
      right: 13px;	
      font-size: 13px;	
      font-weight: 700;	
      color: #222;	
      display: none;	
      cursor: pointer;	
      font-family: "Montserrat", sans-serif;	
    }	
    .pass-key:valid ~ .show {	
      display: block;	
    }	
    .pass {	
      text-align: left;	
      margin: 10px 0;	
    }	
      .pass a {	
        color: white;	
        text-decoration: none;	
        font-family: "Poppins", sans-serif;	
      }	
      .pass:hover a {	
        text-decoration: underline;	
      }	
    .field input[type="submit"] {	
      background: #2c4391;	
      border: 1px solid #2691d9;	
      color: white;	
      font-size: 18px;	
      letter-spacing: 1px;	
      font-weight: 600;	
      cursor: pointer;	
      font-family: "Montserrat", sans-serif;	
    }	
      .field input[type="submit"]:hover {	
        background: #2691d9;	
      }	
    .login {	
      color: white;	
      margin: 20px 0;	
      font-family: "Poppins", sans-serif;	
    }	
    .links {	
      display: flex;	
      cursor: pointer;	
      color: white;	
      margin: 0 0 20px 0;	
    }	
    .facebook,	
    .instagram {	
      width: 100%;	
      height: 45px;	
      line-height: 45px;	
      margin-left: 10px;	
    }	
    .facebook {	
      margin-left: 0;	
      background: #4267b2;	
      border: 1px solid #3e61a8;	
    }	
    .instagram {	
      background: #e1306c;	
      border: 1px solid #df2060;	
    }	
    .facebook:hover {	
      background: #3e61a8;	
    }	
    .instagram:hover {	
      background: #df2060;	
    }	
    .links i {	
      font-size: 17px;	
    }	
    i span {	
      margin-left: 8px;	
      font-weight: 500;	
      letter-spacing: 1px;	
      font-size: 16px;	
      font-family: "Poppins", sans-serif;	
    }	
    .signup {	
      font-size: 15px;	
      color: white;	
      font-family: "Poppins", sans-serif;	
    }	
      .signup a {	
        color: #3498db;	
        text-decoration: none;	
      }	
        .signup a:hover {	
          text-decoration: underline;	
        }	
  </style>	
</head>	
<body class="hold-transition login-page">	
    <div class="bg-img">	
    <div class="content">	
        <form action="#" id="Form1" runat="server">	
      <header>	
        <asp:Image ID="Image1" Height="100px" Width="220px" ImageUrl="~/images/logo.png" runat="server" />	
      </header>	
      	
        <div class="field">	
          <span class="fa fa-user"></span>	
          <asp:TextBox ID="txtuname" class="form-control" placeholder="Email" runat="server"></asp:TextBox>	
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuname"	
                        Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" ValidationGroup="login" SetFocusOnError="true" ForeColor="Red"	
                        CssClass="validate"></asp:RequiredFieldValidator>	
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>	
        </div>	
        <div class="field space">	
          <span class="fa fa-lock"></span>	
          <asp:TextBox ID="txtpwd" class="form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>	
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpwd"	
                        Display="Dynamic" ErrorMessage="Please password" Text="(*) Required" ValidationGroup="login" SetFocusOnError="true" ForeColor="Red"	
                        CssClass="validate"></asp:RequiredFieldValidator>	
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>	
          	
        </div>	
        <div class="pass">	
          <a href="#">Forgot Password?</a>	
        </div>	
        <div class="field">	
        <%--  <input type="submit" value="LOGIN">	--%>
      	
                        <!-- /.login-box -->	
                        <asp:Button ID="btnlogin" class="btn btn-primary btn-block btn-flat" ValidationGroup="login" OnClick="btnlogin_Click" runat="server" Text="Login" />	
                    </div>	
              </div>
                    <!-- /.col -->	
                </div>	
                <!-- /.social-auth-links -->	
                <br />	
                <u><a href="#">I forgot my password</a></u>	
                <u><a href="register.html" style="margin-left: 20px" class="text-center">Register a new membership</a></u>	
                <!-- /.login-box -->	
                <!-- jQuery 2.2.3 -->	
                <script src="../../plugins/jQuery/jquery-2.2.3.min.js"></script>	
                <!-- Bootstrap 3.3.6 -->	
                <script src="../../bootstrap/js/bootstrap.min.js"></script>	
                <!-- iCheck -->	
                <script src="../../plugins/iCheck/icheck.min.js"></script>	
                <script>	
                    $(function () {	
                        $('input').iCheck({	
                            checkboxClass: 'icheckbox_square-blue',	
                            radioClass: 'iradio_square-blue',	
                            increaseArea: '20%' // optional	
                        });	
                    });	
                </script>	
      </form>	
    </div>	
  </div>	
   	
</body>	
</html>