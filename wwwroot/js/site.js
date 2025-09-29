function filterDivision(division) {
    currentDivisionFilter = division;
    const activeView = document.getElementById('standingsTable').style.display !== 'none' ? 'standings' : 'scorers';
    loadView(activeView, division);
}

async function toggleView(view) {
    await loadView(view, currentDivisionFilter);
}

async function loadView(view, division) {
    const standingsTable = document.getElementById('standingsTable');
    const scorersTable = document.getElementById('scorersTable');

    if (view === 'standings') {
        const response = await fetch(`/Home/Standings?division=${division}`);
        const html = await response.text();
        standingsTable.innerHTML = html;
        standingsTable.style.display = 'block';
        scorersTable.style.display = 'none';
    } else {
        const response = await fetch(`/Home/Scorers?division=${division}`);
        const html = await response.text();
        scorersTable.innerHTML = html;
        standingsTable.style.display = 'none';
        scorersTable.style.display = 'block';
    }
}