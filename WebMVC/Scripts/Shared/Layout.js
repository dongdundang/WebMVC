var message = document.getElementById("Message").value;
var messageType = document.getElementById("MessageType").value;

if (!isNullOrEmpty(message) && !isNullOrEmpty(messageType)) {
    notify(message, messageType);
}