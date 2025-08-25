document.addEventListener("DOMContentLoaded", function () {
    const emailAddress = "MiraiDays@gmail.com";
    const copyText = document.querySelector(".project-email-address");
    copyText.textContent = emailAddress;
    copyText.addEventListener('click', () => {
        CopyText(emailAddress);
    });
    function CopyText(copiedText) {
        const text = copiedText;
        navigator.clipboard.writeText(text)
            .then(() => alert("Email address copied to clipboard!"))
            .catch(err => console.error("Copy failed: ", err));
    }
    function positionToggleButton() {
        const footer = document.getElementById("main-footer");
        const button = document.getElementById("footer-toggle-button");

        const footerHeight = footer.offsetHeight;
        button.style.bottom = `${footerHeight - 20}px`;
    }

    window.addEventListener("load", positionToggleButton);
    window.addEventListener("resize", positionToggleButton);

    const togleFooterButton = document.getElementById("footer-toggle-button");
    let isFooterHidden = false;
    function toggleFooter(isClosed) {
        const animationDuration = 500;
        const footer = document.getElementById("main-footer");
        if (!isClosed) {
            shiftElement(footer, "110px", animationDuration);
            rotateButton(togleFooterButton, "180deg", animationDuration);
        } else {
            shiftElement(footer, "0px", animationDuration);
            rotateButton(togleFooterButton, "0deg", animationDuration);
        }
    }
    function shiftElement(element, yShift, animationDuration) {
        if (element != null) {
            element.animate(
                [
                    { transform: "translateY(0px)" },
                    { transform: `translateY(${yShift})` }
                ],
                { duration: animationDuration, fill: "forwards", easing: "ease-in-out" }
            );
        }
    }
    function rotateButton(button, degrees, animationDuration) {
        if (button != null) {
            button.animate(
                [
                    { transform: "rotate(0deg)" },
                    { transform: `rotate(${degrees})` }
                ],
                { duration: animationDuration, fill: "forwards" }
            );
        }
    }
    togleFooterButton.addEventListener('click', () => {
        toggleFooter(isFooterHidden);
        isFooterHidden = !isFooterHidden;
    });

    const userAvatar = document.getElementById("avatar-background");
    const avatarBackgoundColors = [
        "#F44336", // Red
        "#E91E63", // Pink
        "#9C27B0", // Purple
        "#673AB7", // Deep Purple
        "#3F51B5", // Indigo
        "#2196F3", // Blue
        "#03A9F4", // Light Blue
        "#00BCD4", // Cyan
        "#009688", // Teal
        "#4CAF50", // Green
        "#8BC34A", // Light Green
        "#CDDC39", // Lime
        "#FFEB3B", // Yellow
        "#FFC107", // Amber
        "#FF9800", // Orange
        "#FF5722", // Deep Orange
        "#795548", // Brown
        "#607D8B"  // Blue Grey
    ];
    function setRandomColor() {
        const avatarDimention = 50;
        const randomIndex = Math.floor(Math.random() * avatarBackgoundColors.length);
        userAvatar.style.backgroundColor = avatarBackgoundColors[randomIndex]
        userAvatar.style.width = avatarDimention + "px";
        userAvatar.style.height = avatarDimention + "px";
    }
    setRandomColor();
});