const images = [
    "url('../Resources/Images/RandomBackgroundImages/Waterfall1.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/DarkSpace1.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/DarkSpace2.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/DarkSpace3.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/DarkSpace4.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/Mountain1.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/Mountain2.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/Forest1.jpg')",
    "url('../Resources/Images/RandomBackgroundImages/Forest2.jpg')",
];

let index = 0;
const slider = document.getElementsByClassName("body-background")[0];
function updateBackground() {
    const randomIndex = Math.floor(Math.random() * images.length);
    slider.style.backgroundImage = images[randomIndex];
}
updateBackground();
setInterval(updateBackground, 2000);