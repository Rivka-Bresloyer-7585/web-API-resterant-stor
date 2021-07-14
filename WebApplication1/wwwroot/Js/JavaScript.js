
function postUser() {
    let user = {
        userEmail: document.getElementById("h1").value,
        userPassword: document.getElementById("h2").value,
        userFirstName: document.getElementById("h3").value,
        userLastName: document.getElementById("h4").value
    };
    fetch("api/Values", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(user),
    }).then(response => {
        if (response.ok) {
            alert("המשתמש הוסף בהצלחה!!");
        }
        else {
            response.json().then(error1 => { alert(JSON.stringify(error1.errors)); })
        }
    })
}

function newUser() {
    let div = document.getElementById("hide");
    div.hidden = false;
}

function getUser() {
    let name = document.getElementById("name").value;
    let password = document.getElementById("pswd").value;
    fetch("api/values/" + name + "/" + password)
        .then(response => {
            return response.json();
        })
        .then(data1 => {
            if (data1.user != "") {
                sessionStorage.setItem('user', JSON.stringify(data1));
                window.location.href = "htmlpage1.html";
            }
        })
        .catch((error) => {
            alert("שם המשתמש או הסיסמא שגויים:( אנא נסה שוב")
            console.error("error:" + error);
        });
}

function putUser() {
    let oldUser = JSON.parse(sessionStorage.getItem('user'));
    let user = {
        email: document.getElementById("h1").value,
        password: document.getElementById("h2").value,
        firstName: document.getElementById("h3").value,
        lastName: document.getElementById("h4").value,
    }
    fetch("api/values/" + oldUser.userId, {
        method: "PUT",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(user),
    }).then((response) => {

        if (response.ok) {
            alert("הפרטים עודכנו בהצלחה!!");
            return response.json();
        }
        else
            alert("תקלה בעידכון הנתונים נסה שוב...");

    })
        //.catch((error) => {
        //    alert("Sorry, the update was not performed successfully");
        //});
}

