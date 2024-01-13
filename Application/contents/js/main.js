$(document).ready(function () {
    DisplayCurrentTime();
});
function DisplayCurrentTime() {
    var dt = new Date();
    var weekdays = new Array(7);
    weekdays[0] = "Sunday";
    weekdays[1] = "Monday";
    weekdays[2] = "Tuesday";
    weekdays[3] = "Wednesday";
    weekdays[4] = "Thursday";
    weekdays[5] = "Friday";
    weekdays[6] = "Saturday";
    var refresh = 1000;
    document.getElementById('cDay').innerHTML = weekdays[dt.getDay()];
    document.getElementById('cTime').innerHTML = dt.toLocaleTimeString();
    document.getElementById('cDate').innerHTML = dt.toLocaleDateString("en-us");
    window.setTimeout('DisplayCurrentTime()', refresh);
}

function loginSuccess() {
    Swal.fire({
        toast: true,
        titleText: "You have logged in successfully.",
        type: "success",
        position: "top",
        showConfirmButton: false,
        timer: 3000
    })
}

function expirationAlert(message) {
    Swal.fire({
        toast: true,
        titleText: message,
        type: "warning",
        position: "top"
    })
}

function successRedirect(linkURL, message) {
    Swal.fire({
        titleText: "Success!",
        text: message,
        type: "success",
        allowOutsideClick: false,
        allowEscapeKey: false
    }).then(function () {
        window.location.href = linkURL;
    })
}

function errorRedirect(linkURL, message) {
    Swal.fire({
        titleText: "Unable to proceed!",
        text: message,
        type: "error",
        allowOutsideClick: false,
        allowEscapeKey: false
    }).then(function () {
        window.location.href = linkURL;
    })
}

function noAccessRedirect(linkURL) {
    Swal.fire({
        titleText: "You are not authorized to view this page.",
        type: "error",
        backdrop: `
        rgba(105,105,105,1)
        `
    }).then(function () {
        window.location.href = linkURL;
    })
}

function sessionRedirect(linkURL) {
    Swal.fire({
        titleText: "Session is no longer active.",
        type: "error",
        backdrop: `
        rgba(105,105,105,1)
        `
    }).then(function () {
        window.location.href = linkURL;
    })
}

function transactionAlert(msg, ref) {
    Swal.fire({
        titleText: "Success!",
        html: msg + "<br/> Transaction Reference Number: " + ref,
        type: "success"
    })
}

function transactionAlertRedirect(linkURL, msg, ref) {
    Swal.fire({
        titleText: "Success!",
        html: msg + "<br/> Transaction Reference Number: " + ref,
        type: "success",
        allowOutsideClick: false,
        allowEscapeKey: false
    }).then(function () {
        window.location.href = linkURL;
    })
}

function alertRedirect(linkURL, msg, ref, type) {
    Swal.fire({
        titleText: msg,
        html: "Transaction Reference Number: " + ref,
        type: type,
        allowOutsideClick: false,
        allowEscapeKey: false
    }).then(function () {
        window.location.href = linkURL;
    })
}

function linearFunction() {
    var h = document.getElementById("heart").style.display;
    if (h === "none")
            document.getElementById("heart").style.display="inline";
    else
            document.getElementById("heart").style.display="none";
}

function squareFunction() {
    var b = document.getElementById("bomb").style.display;
    if (b === "none")
            document.getElementById("bomb").style.display="inline";
    else
            document.getElementById("bomb").style.display="none";
            
    document.getElementById("heart").style.display="none";
}

function cubeFunction() {
    var g = document.getElementById("bug").style.display;
    if (g === "none")
            document.getElementById("bug").style.display="inline";
    else
            document.getElementById("bug").style.display="none";

    document.getElementById("bomb").style.display="none";
}

var obj = { status: false, ele: null };

function logoutAlert(me) {
    if (obj.status) return true;
    Swal.fire({
        titleText: "Are you sure you want to logout?", 
        type: "question",
        showCancelButton: true,
        confirmButtonColor: "btn-danger",
        confirmButtonText: "Yes",
        cancelButtonText: "No"
    }).then(result => {
        if (result.value) {
        window.location.href = "../Logout.aspx";
        } else {
        obj.status = false;
        }
    })
    obj.status = true;
    obj.ele = me;
    return false;
}

function deleteAlert(me) {
    if (obj.status) return true;
    Swal.fire({
        titleText: "Are you sure?",
        text: "You will no longer see this entry!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Delete",
        closeOnConfirm: false,
        closeOnCancel: true
    }).then(result => {
        if (result.value) {
        obj.ele.click();
        } else {
        obj.status = false;
        }
    })
    obj.status = true;
    obj.ele = me;
    return false;
}

function resetPasswordAlert(me) {
    if (obj.status) return true;
    Swal.fire({
        titleText: "Are you sure?",
        text: "The password will be changed to a random password!",
        type: "question",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Yes",
        closeOnConfirm: false,
        closeOnCancel: true
    }).then(result => {
        if (result.value) {
        obj.ele.click();
        } else {
        obj.status = false;
        }
    })
    obj.status = true;
    obj.ele = me;
    return false;
}

function unlockUserAlert(me) {
    if (obj.status) return true;
    Swal.fire({
        titleText: "Are you sure?",
        text: "The selected user account will be unlocked.",
        type: "question",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Yes",
        closeOnConfirm: false,
        closeOnCancel: true
    }).then(result => {
        if (result.value) {
        obj.ele.click();
        } else {
        obj.status = false;
        }
    })
    obj.status = true;
    obj.ele = me;
    return false;
}

function confirmApplication(me, msg) {
    if (obj.status) return true;
    Swal.fire({
        titleText: "Are you sure you want to " + msg + "?",
        type: "question",
        showCancelButton: true,
        confirmButtonClass: "btn-success",
        confirmButtonText: "Yes",
        cancelButtonText: "No",
        closeOnConfirm: false,
        closeOnCancel: true
    }).then(result => {
        if (result.value) {
        obj.ele.click();
        } else {
        obj.status = false;
        }
    })
    obj.status = true;
    obj.ele = me;
    return false;
}

function confirmAlert(me, msg) {
    if (obj.status) return true;
    Swal.fire({
        titleText: "Are you sure",
        text: "you want to " + msg + " ?",
        type: "question",
        showCancelButton: true,
        confirmButtonClass: "btn-success",
        confirmButtonText: "Yes",
        cancelButtonText: "No",
        closeOnConfirm: false,
        closeOnCancel: true
    }).then(result => {
        if (result.value) {
        obj.ele.click();
        } else {
        obj.status = false;
        }
    })
    obj.status = true;
    obj.ele = me;
    return false;
}

$(function () {
    $(".datepicker").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'mm/dd/yy'
    });

    $('.combobox').combobox();
})

$(document).ready(function () {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

    function EndRequestHandler(sender, args) {
        $('.datepicker').datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'mm/dd/yy'
        });
    }
});

function PostToNewWindow() {
    originalTarget = document.forms[0].target;
    document.forms[0].target = '_blank';
    window.setTimeout("document.forms[0].target=originalTarget;", 300);
    return true;
}

function randomMinMax(min, max) {
    return Math.floor(min + (1 + max - min) * Math.random());
}

var bossLife = 10;
function animateBoss() {
    if (bossLife > 0) {
        document.getElementById("hp").style.display="block";
        document.getElementById("boss").style.display="block";

        var top = randomMinMax(20, 400);
        var left = randomMinMax(20, 400);
        var minSpeed = 500;
        var maxSpeed = 1000;

        if (bossLife < 4) {
            minSpeed = 200;
            maxSpeed = 400;
            $('#boss').attr('src', '../Contents/images/VGA.jpg');
        }
        
        var speed = randomMinMax(minSpeed, maxSpeed);

        $('#boss').animate({ top: top, left: left }, {
            duration: speed,
            queue: false,
            complete: animateBoss
        });
    }
}

function blinkBoss(count) {
    if (count > 0) {
        count--;
        
        $('#boss').animate({ "opacity": "toggle" }, {
            duration: 75,
            queue   : false,
            complete: function() {
                blinkBoss(count);
            }
        });
    }
    else {
        if (bossLife < 4)
            $('#boss').attr('src', '../Contents/images/VGA.jpg');
        else
            $('#boss').attr('src', '../Contents/images/VG.png');
    }
}

var explosionInProgress = false;
function triggerExplosion(top, left) {
    if (!explosionInProgress) {
        explosionInProgress = true;
        
        $('#boss').attr('src', '../Contents/images/VGO.jpg');
        blinkBoss(4);
            
        $('#explosion')
            .css({ top: top, left: left })
            .slideDown('fast')
            .slideUp(1000, function() {
                explosionInProgress = false;
                $('#boss').css({ "opacity": 1 });
        });
    }
}

function reciprocalFunction(e) {
    if (explosionInProgress) {
        return false;
    }
    else { 
        let health = document.getElementById("health");

        if (bossLife > 0) {
            triggerExplosion($('#boss').position().top - (e.offsetY/2), $('#boss').position().left + e.offsetX);
            bossLife--;
            health.value = bossLife;
        }
    
        if (bossLife == 0) {
            $('#boss').stop().hide("bounce", 1000);
            
            setTimeout(function() {
                document.getElementById("hp").style.display="none";
                document.getElementById("boss").style.display="none";
                document.getElementById("win").style.display="block";

                setTimeout(function() {
                    $('#BossModal').modal('hide');
                }, 4000);
            }, 2000);
        }
    }
}