"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
document.getElementById("messageInput").value = "Stablishing Connection...";
var scrollableSection = document.querySelector('.chat-container');
var entry = document.createElement('p');
entry.className = "chat-message";
var WaitForMessageSent;


connection.on("ReceiveMessage", function (user, message, date) {
    DisplayRecievedMessage(user,message,date);
    if(WaitForMessageSent == true) scrollableSection.scrollTop = scrollableSection.scrollHeight;
});

connection.start().then(function () { document.getElementById("messageInput").value = "";  scrollableSection.scrollTop = scrollableSection.scrollHeight;}).catch(function (err) {
    return console.error(err.toString());
});



document.getElementById("messageInput").addEventListener("keydown", function (event) {
    if (event.key == "Enter") {  MessageSender(event); }
});

function DisplayRecievedMessage(user,message,date){
    var input1 = document.createElement("span");
    var input2 = document.createElement("span");
    var input3 = document.createElement("span");
    entry.className = "chat-message";
    input1.className = "chat-user";
    input2.className = "chat-content";
    input3.className = "chat-time";
    entry.appendChild(input1);
    entry.appendChild(input2);
    entry.appendChild(input3);
    document.getElementById("messageList").appendChild(entry);
    input1.textContent = user + " > ";
    input2.textContent = message;
    input3.textContent = " - " +date;
    entry = document.createElement('p');
}

function MessageSender(event){
    WaitForMessageSent = true;
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var date =  GetCurrentDate();
            connection.invoke("SendMessage", user, message, date).catch(function (err) {
                return console.error(err.toString());
            });
    event.preventDefault();
    document.getElementById("messageInput").value = message = "";
}


function GetCurrentDate(){
        var currentTime = new Date();
        var hour = currentTime.getHours();
        var minute = currentTime.getMinutes();
        var second = currentTime.getSeconds();
        var day = currentTime.getDate();
        var month = currentTime.getMonth() + 1;
        var year = currentTime.getFullYear();
    return `Date: ${day}/${month}/${year} - ${hour}:${minute}:${second}`;
}