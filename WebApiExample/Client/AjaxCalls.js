
function AuthenticateFunction(username, password, successCB, errorCB) {
    let access_token = localStorage.getItem("access_token");     

    if (access_token == undefined || access_token == null || access_token.length < 10) {

        errCB({responseText: 'No access_token'})
        return;
    }
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
            xhr.setRequestHeader('Authorization', 'Bearer ' + access_token);
        },
        success: successCB,
        error: errorCB,

    }
    $.ajax(ajaxCallObject);

}


 

function CheckIfAuthenticated() {
    var token = sessionStorage.getItem("access_token");
    if (token !== null && token.length > 5) {

        sessionStorage.setItem("access_token")
    }
    

}