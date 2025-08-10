document.addEventListener("DOMContentLoaded", function () {
    const chatBox = document.getElementById('chat-box');
    const sendBtn = document.getElementById('send');
    const userInput = document.getElementById('user-input');
    const form = document.querySelector('form');

    form.addEventListener('submit', e => e.preventDefault());

    sendBtn.addEventListener('click', async () => {
        const message = userInput.value.trim();
        if (!message) return;

        addMessage('User', message);

        userInput.value = '';

        try {
            const response = await fetch('/AITextGenerative/GetAIResponse', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ UserPrompt: message })
            });

            if (!response.ok) throw new Error('Network error');

            const data = await response.json();

            addMessage('AI', data.response);
        } catch (err) {
            addMessage('System', 'Error getting AI response: ' + err.message);
        }
    });
    function addMessage(sender, text) {
        const messageElem = document.createElement('div');
        if (sender == "AI") {
            messageElem.classList.add('chat-message-AI');
        }
        else {
            messageElem.classList.add('chat-message-user');
        }
        const formattedText = text.replace(/\n/g, '<br>');
        messageElem.innerHTML = `<strong>${sender}:</strong> ${formattedText}`;
        chatBox.appendChild(messageElem);
        chatBox.scrollTop = chatBox.scrollHeight;
    }

});