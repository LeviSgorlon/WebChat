"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
document.getElementById("messageInput").value = "Stablishing Connection...";
var scrollableSection = document.querySelector('.scrollable-section');

var WaitForMessageSent;


connection.on("ReceiveMessage", function (user, message, date) {
    var li = document.createElement("p");
    document.getElementById("messageList").appendChild(li);
    li.textContent = `${user} : ${message} - ${date} `;
    if(WaitForMessageSent == true) scrollableSection.scrollTop = scrollableSection.scrollHeight;
});

connection.start().then(function () { document.getElementById("messageInput").value = ""; }).catch(function (err) {
    return console.error(err.toString());
});



    document.getElementById("messageInput").addEventListener("keydown", function (event) {
    if (event.key == "Enter") {
        WaitForMessageSent = true;
        var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;
        var currentTime = new Date();
        var hour = currentTime.getHours();
        var minute = currentTime.getMinutes();
        var second = currentTime.getSeconds();
        var date = `${hour}:${minute}:${second}`;
        connection.invoke("SendMessage", user, message, date).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
        document.getElementById("messageInput").value = message = "";
        }
    });

