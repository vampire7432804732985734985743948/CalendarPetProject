const images = [
    "url('../Resources/Images/RandomBackgroundImages/DarkSpace1.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/DarkSpace2.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/Mountain1.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/Mountain2.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/Forest1.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/Forest2.jpg')"
];

let index = 0;
const slider = document.getElementsByClassName("body-background")[0];

slider.style.backgroundImage = "url('../Resources/Images/RandomBackgroundImages/DarkSpace1.jpg')";
function updateBackground() {
    index = (index + 1) % images.length;
    slider.style.backgroundImage = images[index];
}

setInterval(updateBackground, 2000);