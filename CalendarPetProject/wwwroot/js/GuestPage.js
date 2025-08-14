document.addEventListener("DOMContentLoaded", function () {
    if (typeof AOS !== "undefined") {
        AOS.init();
    }

    if (window.showDescriptionFromServer === true || window.showDescriptionFromServer === "true") {
        showDescription(
            "From Razor",
            "This description was shown based on a condition in Razor.",
            "/Resources/Images/sample.jpg"
        );
    }
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
    const animationDuration = 10000; //ms
    function SelectRandomElement(numberOfElements) {
        return Math.floor(Math.random() * numberOfElements);
    }
    function fillProgress(durationInMs) {
        const progressBar = document.getElementById('progressBar');

        progressBar.style.transition = 'none';
        progressBar.style.width = '0%';

        void progressBar.offsetWidth;
        progressBar.style.transition = `width ${durationInMs}ms linear`;
        progressBar.style.width = '100%';
    }
    function UpdateBackground() {
        fillProgress(animationDuration);
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
    setInterval(SelectSlogan, animationDuration);
    setInterval(UpdateBackground, animationDuration);

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
    function showDescription(title, text, imageUrl) {
        document.getElementById('desc-title').innerText = title;
        document.getElementById('desc-paragraph').innerText = text;
        document.getElementById('desc-image').src = imageUrl;
        document.getElementById('card-description').style.display = 'block';
        document.getElementById('overlay').style.display = 'block';
        document.body.classList.add('no-scroll');
        document.body.filter = "brigthness(10%)";
    }
    window.hideDescription = function () {
        document.getElementById('card-description').style.display = 'none';
        document.getElementById('overlay').style.display = 'none';
        document.body.classList.remove('no-scroll');
    };
    hideDescription();
    function fetchCardDetails(cardId) {
        fetch(`/Home/GetCardDetails?id=${cardId}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error("Card not found");
                }
                return response.json();
            })
            .then(data => {
                showDescription(data.Title, data.Description, data.ImagePath);
            })
            .catch(error => {
                console.error("Error fetching card details:", error);
            });
    }
    document.querySelectorAll('.card').forEach(card => {
        card.addEventListener('click', () => {
            const id = card.getAttribute('data-id');
            fetchCardDetails(id);
        });
    });
});