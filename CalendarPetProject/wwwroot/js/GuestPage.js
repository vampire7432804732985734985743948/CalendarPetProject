const images = [
    "url('../Resources/Images/RandomBackgroundImages/Waterfall1.png')",
    "url('../Resources/Images/RandomBackgroundImages/DarkSpace2.png')",
    "url('../Resources/Images/RandomBackgroundImages/DarkSpace3.png')",
    "url('../Resources/Images/RandomBackgroundImages/DarkSpace4.png')",
    "url('../Resources/Images/RandomBackgroundImages/Mountain1.png')",
    "url('../Resources/Images/RandomBackgroundImages/Mountain2.png')",
    "url('../Resources/Images/RandomBackgroundImages/Mountain3.png')",
    "url('../Resources/Images/RandomBackgroundImages/Forest1.png')",
    "url('../Resources/Images/RandomBackgroundImages/Forest2.png')"
];

let index = 0;
const slider = document.getElementsByClassName("body-background")[0];
function SelectRandomElement(numberOfElements) {
    return Math.floor(Math.random() * numberOfElements);
}
function UpdateBackground() {
    slider.style.backgroundImage = images[SelectRandomElement(images.length)];
}

const slogans = [
    "YOUR TIME, ORGANIZED EFFORTLESSLY.",
    "PLAN SMART. LIVE FREE.",
    "NEVER MISS A MOMENT.",
    "WHERE YOUR DAY FINDS CLARITY.",
    "TURN CHAOS INTO CALENDAR.",
    "EVERY DATE, IN PLACE.",
    "YOUR FUTURE, SCHEDULED TODAY.",
    "LIFE’S BETTER WITH A PLAN."
];

let slogan = document.getElementById("slogan");
function SelectSlogan() {
    slogan.style.opacity = 0;
    setTimeout(() => {
        slogan.innerText = slogans[SelectRandomElement(slogans.length)];
        slogan.style.opacity = 1; 
    }, 500);
}


UpdateBackground();
SelectSlogan();
setInterval(SelectSlogan, 2000);
setInterval(UpdateBackground, 2000);