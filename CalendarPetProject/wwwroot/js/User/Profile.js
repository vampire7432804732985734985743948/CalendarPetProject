document.addEventListener("DOMContentLoaded", function () {
    function positionToggleButton() {
        const skill = document.querySelector(".outline");
        const experienceIndicator = document.querySelector(".exp-indicator");

        if (!skill || !experienceIndicator) return;

        const skillRect = skill.getBoundingClientRect();
        const parentRect = skill.parentElement.getBoundingClientRect(); // optional if needed

        // Center the SVG inside the skill div
        const x = (skill.clientWidth - experienceIndicator.clientWidth) / 2;
        const y = (skill.clientHeight - experienceIndicator.clientHeight) / 2;

        experienceIndicator.style.left = x + "px";
        experienceIndicator.style.top = y + "px";
    }

    window.addEventListener("load", positionToggleButton);
    window.addEventListener("resize", positionToggleButton);
});