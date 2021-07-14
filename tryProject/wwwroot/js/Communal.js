

var allCheckboxes = document.querySelectorAll('input[type=checkbox]');
var allCommunityWorks = Array.from(document.querySelectorAll('.filteredItem'));
var checked = {};

getChecked('WorkOrGive');
getChecked('Zones');
getChecked('CatersTo');


Array.prototype.forEach.call(allCheckboxes, function (el) {
    el.addEventListener('change', toggleCheckbox);
});

function toggleCheckbox(e) {
    getChecked(e.target.name);
    setVisibility();
}

function getChecked(name) {
    checked[name] = Array.from(document.querySelectorAll('input[name=' + name + ']:checked')).map(function (el) {
        return el.value;
    });
}

function setVisibility() {
    allCommunityWorks.map(function (el) {
        var WorkOrGive = checked.WorkOrGive.length ? _.intersection(Array.from(el.classList), checked.WorkOrGive).length : true;
        var Zones = checked.Zones.length ? _.intersection(Array.from(el.classList), checked.Zones).length : true;
        var CatersTo = checked.CatersTo.length ? _.intersection(Array.from(el.classList), checked.CatersTo).length : true;
       
        if (WorkOrGive && Zones && CatersTo) {
            el.style.display = 'flex';
        } else {
            el.style.display = 'none';
        }
    });
}

