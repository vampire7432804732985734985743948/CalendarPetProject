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
});