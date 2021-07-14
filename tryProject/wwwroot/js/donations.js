

var allCheckboxes = document.querySelectorAll('input[type=checkbox]');
var allCommunityWorks = Array.from(document.querySelectorAll('.filteredItem'));
var checked = {};


getChecked('Purposes');
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
        var Purposes = checked.Purposes.length ? _.intersection(Array.from(el.classList), checked.Purposes).length : true;
        var CatersTo = checked.CatersTo.length ? _.intersection(Array.from(el.classList), checked.CatersTo).length : true;

        if (CatersTo && Purposes) {
            el.style.display = 'block';
        } else {
            el.style.display = 'none';
        }
    });
}


