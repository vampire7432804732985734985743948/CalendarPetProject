document.addEventListener("DOMContentLoaded", function () {
    function positionToggleButton() {
        const skill = document.querySelector(".outline");
        const experienceIndicator = document.querySelector(".exp-indicator");

        if (!skill || !experienceIndicator) return;

        const skillRect = skill.getBoundingClientRect();
        const parentRect = skill.parentElement.getBoundingClientRect();

        const x = (skill.clientWidth - experienceIndicator.clientWidth) / 2;
        const y = (skill.clientHeight - experienceIndicator.clientHeight) / 2;

        experienceIndicator.style.left = x + "px";
        experienceIndicator.style.top = y + "px";
    }

    window.addEventListener("load", positionToggleButton);
    window.addEventListener("resize", positionToggleButton);

    const userAvatar = document.getElementById("avatar-profile");
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
        "#CDDC39", // Lime
        "#FFC107", // Amber
        "#FF9800", // Orange
        "#FF5722", // Deep Orange
        "#795548", // Brown
        "#607D8B"  // Blue Grey
    ];
    function setRandomColor() {
        const avatarDimention = 150;
        const randomIndex = Math.floor(Math.random() * avatarBackgoundColors.length);
        userAvatar.style.backgroundColor = avatarBackgoundColors[randomIndex]
        userAvatar.style.width = avatarDimention + "px";
        userAvatar.style.height = avatarDimention + "px";
    }
    setRandomColor();
  
});