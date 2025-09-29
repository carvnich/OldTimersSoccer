const scheduleCarousel = (function () {
    let currentIndex = 0;
    let totalDates = 0;

    function update() {
        const slides = document.querySelectorAll('.date-slide');
        slides.forEach((slide, index) => {
            slide.classList.toggle('active', index === currentIndex);
        });

        const prevBtn = document.getElementById('prevBtn');
        const nextBtn = document.getElementById('nextBtn');

        if (prevBtn) prevBtn.disabled = currentIndex === 0;
        if (nextBtn) nextBtn.disabled = currentIndex === totalDates - 1;
    }

    return {
        previous: function () {
            if (currentIndex > 0) {
                currentIndex--;
                update();
            }
        },
        next: function () {
            if (currentIndex < totalDates - 1) {
                currentIndex++;
                update();
            }
        },
        init: function () {
            const totalDatesInput = document.getElementById('totalDates');
            if (totalDatesInput) {
                totalDates = parseInt(totalDatesInput.value);
                currentIndex = 0;
                update();
            }
        }
    };
})();