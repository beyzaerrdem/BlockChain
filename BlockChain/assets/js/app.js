

        
let signupFormEl = document.getElementById("signupForm");
let loginFormEl = document.getElementById("loginForm");

let homeEl = document.getElementById("homePage");
let notificationsEl = document.getElementById("notificationPage");


var getHash = () => {
    
    const myTimeout = setTimeout(function(){
        let hash = window.location.hash;
        
        // for login page
        if(hash == "#signup"){
            signupFormEl.style.display = "flex";
            loginFormEl.style.display = "none";
        }else if(hash == "#login"){
            signupFormEl.style.display = "none";
            loginFormEl.style.display = "flex";
        }
        // for login page

        // for index page
        else if(hash == "#home"){
            homeEl.style.display = "block";
            notificationsEl.style.display = "none";

        }else if(hash == "#notifications"){
            homeEl.style.display = "none";
            notificationsEl.style.display = "block";
        }

        // for index page


    }, 10);
};

