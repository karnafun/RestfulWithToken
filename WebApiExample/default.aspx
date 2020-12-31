<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApiExample._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   @Scripts.Render("~/bundles/jquery")
    <title></title>
</head>
<body>
    <form id="form1" runat="server"> 
        </form>
        <div>
        <h2> Get Token: </h2>
        <div>
            <input type="text" id="username" value="user" />
            <input type="password" id="password"  value="user"/>
            <button onclick="GetToken()">Submit</button>
        </div>


            <div>
                 <button onclick="LogOut()"> Logout</button>
            </div>
            <div>
                <button onclick="getPersonalInfo()"> Get Personal Info</button>
            </div>


            <div > 
                <span id="results_ph"> 

                </span>

            </div>

    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.js" integrity="sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc=" crossorigin="anonymous"></script> 
    <script>          
        function GetToken() {
            console.log(username.value, password.value); 
            getTokenAjax(username.value, password.value);
        }

        function LogOut() {
			localStorage.setItem("username", undefined);
			localStorage.setItem("password", undefined);
			localStorage.setItem("access_token", undefined);
        }

        function getTokenAjax(username, password) {
			let data = {
				username: username,
				password: password,
				grant_type: "password"
			}
            $.ajax({
                url: "https://localhost:44326/token",
                type: "POST",
                data: { username: username, password: password, grant_type: "password" },
                success: function (res) {
                    localStorage.setItem("username", username);
                    localStorage.setItem("password", password);
                    localStorage.setItem("access_token", res.access_token);
                    successCB(res);
                    
                },
                error:errorCB,
            })
        }
		

		// Retrieve
		
        function getPersonalInfo() {
			let access_token = localStorage.getItem("access_token");
            let username= localStorage.getItem("username");
			let password = localStorage.getItem("password");
			
            let data = {
                username: username,
                password: password,                
				grant_type: "password"
            }

            let ajaxCallObject = {
				url: "https://localhost:44326/api/data/authenticate",
				type: "GET",
				data: data,
				beforeSend: function (xhr) {
					xhr.setRequestHeader('Authorization', 'Bearer '+access_token);
				},
                success: successCB,
                error: errCB,

            }
            $.ajax(ajaxCallObject);
            console.log(ajaxCallObject);
        }


        function successCB(res) {
			console.log(res)
			alert("success" + res)
			let res = "success:\n" + res;
			$('#results_ph').html(res)			
        }
        function errCB(err) {
			let res = "Error:\n" + err.responseText
			$('#results_ph').html(res)
        }



	</script>
    
</body>
</html>
