// Schedule Carousel
const scheduleCarousel = (function () {
    let currentIndex = 0;
    let totalDates = 0;
    function update() {
        const slides = document.querySelectorAll('.date-slide');
        slides.forEach((slide, index) => slide.classList.toggle('active', index === currentIndex));
        const prevBtn = document.getElementById('prevBtn');
        const nextBtn = document.getElementById('nextBtn');
        if (prevBtn) prevBtn.disabled = currentIndex === 0;
        if (nextBtn) nextBtn.disabled = currentIndex === totalDates - 1;
    }
    function paginateToNext() {
        const slides = document.querySelectorAll('.date-slide');
        const now = new Date();
        let nextIndex = 0;
        slides.forEach((slide, index) => {
            const matchDateStr = slide.dataset.matchDate;
            if (matchDateStr) {
                const matchDate = new Date(matchDateStr);
                if (matchDate > now && nextIndex === 0) nextIndex = index;
            }
        });
        currentIndex = nextIndex;
        update();
    }
    return {
        previous: () => { if (currentIndex > 0) { currentIndex--; update(); } },
        next: () => { if (currentIndex < totalDates - 1) { currentIndex++; update(); } },
        init: () => {
            const totalDatesInput = document.getElementById('totalDates');
            if (totalDatesInput) { totalDates = parseInt(totalDatesInput.value); currentIndex = 0; paginateToNext(); }
        }
    };
})();

// Soccer App
const app = window.soccerApp || {};

document.addEventListener('DOMContentLoaded', async () => {
    if (app.currentDivision && app.currentLeague) {
        await loadSchedule(app.currentDivision, app.currentLeague);
        const response = await fetch(`/Home/Scorers?division=${encodeURIComponent(app.currentDivision)}&league=${encodeURIComponent(app.currentLeague)}`);
        document.getElementById('scorersTable').innerHTML = await response.text();
    }
});

async function loadSchedule(division, league) {
    const response = await fetch(`/Home/Schedule?division=${encodeURIComponent(division)}&league=${encodeURIComponent(league)}`);
    document.getElementById('scheduleCarousel').innerHTML = await response.text();
    if (typeof scheduleCarousel !== 'undefined') scheduleCarousel.init();
}

function filterLeague(league) {
    app.currentLeague = league;
    document.getElementById('leagueDisplay').textContent = league;
    document.querySelectorAll('.division-container').forEach(div => div.classList.remove('active'));
    const divisionMap = { 'Regular Season': 'regularDivisions', 'Spence Cup': 'spenceDivisions', 'Challenge Cup': 'challengeDivisions' };
    const targetDiv = document.getElementById(divisionMap[league]);
    targetDiv.classList.add('active');
    const firstRadio = targetDiv.querySelector('input[type="radio"]');
    app.currentDivision = firstRadio.value;
    firstRadio.checked = true;
    document.getElementById('divisionDisplay').textContent = 'Division ' + app.currentDivision.replace(' DIVISION', '').replace('CH. CUP ', '').replace('SP. CUP ', '');
    loadSchedule(app.currentDivision, app.currentLeague);
    loadView(document.querySelector('input[name="view"]:checked').id.replace('view', '').toLowerCase(), app.currentDivision, app.currentLeague);
}

function filterDivision(division) {
    app.currentDivision = division;
    document.getElementById('divisionDisplay').textContent = 'Division ' + division.replace(' DIVISION', '').replace('CH. CUP ', '').replace('SP. CUP ', '');
    loadSchedule(app.currentDivision, app.currentLeague);
    loadView(document.querySelector('input[name="view"]:checked').id.replace('view', '').toLowerCase(), app.currentDivision, app.currentLeague);
}

async function toggleView(view) { await loadView(view, app.currentDivision, app.currentLeague); }

async function loadView(view, division, league) {
    const standingsTable = document.getElementById('standingsTable');
    const scorersTable = document.getElementById('scorersTable');
    const url = view === 'standings' ? `/Home/Standings?division=${encodeURIComponent(division)}&league=${encodeURIComponent(league)}` : `/Home/Scorers?division=${encodeURIComponent(division)}&league=${encodeURIComponent(league)}`;
    const response = await fetch(url);
    const html = await response.text();
    if (view === 'standings') { standingsTable.innerHTML = html; standingsTable.style.display = 'block'; scorersTable.style.display = 'none'; }
    else { scorersTable.innerHTML = html; standingsTable.style.display = 'none'; scorersTable.style.display = 'block'; }
}