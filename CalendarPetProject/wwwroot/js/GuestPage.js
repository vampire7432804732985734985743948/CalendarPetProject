AOS.init();

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

let accuiredSlogans = [slogans.length];
let slogan = document.getElementById("slogan");
function SelectSlogan() {
    slogan.style.opacity = 0;
    setTimeout(() => {
        let selectedSlogan = SelectRandomElement(slogans.length)
        for (var i = 0; i < accuiredSlogans.length; i++) {
            if (selectedSlogan == accuiredSlogans) {
                break;
                return;
            }
        }
        slogan.innerText = slogans[selectedSlogan];
        accuiredSlogans.push(selectedSlogan);
        if (accuiredSlogans[accuiredSlogans.length] != null) {
            accuiredSlogans = ClearArray(accuiredSlogans);
        }
        slogan.style.opacity = 1; 
    }, 500);
}
function ClearArray(array) {
    for (var i = 0; i < array.length; i++) {
        array[i] = null;
    }
}

UpdateBackground();
SelectSlogan();
setInterval(SelectSlogan, 2000);
setInterval(UpdateBackground, 2000);

var cards = document.getElementsByClassName("card");

document.addEventListener("mouseover", e => {
    const card = e.target.closest('.card');
    if (card) {
        for (let i = 0; i < cards.length; i++) {
            cards[i].style.filter = "grayscale(100%) blur(5px)";
        }
        card.style.filter = "grayscale(0%) blur(0px)";
    }
});

document.addEventListener("mouseout", e => {
    const card = e.target.closest('.card');
    if (card) {
        for (let i = 0; i < cards.length; i++) {
            cards[i].style.filter = "grayscale(0%) blur(0px)";
        }
    }
});