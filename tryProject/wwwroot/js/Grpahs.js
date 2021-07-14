var DevelopingCountries = {
    x: [1990, 1995, 2000, 2010, 2020],
    y: [21, 19, 15, 13, 14],
    type: 'scatter'
};

var SubSaharanAfrica = {
    x: [1990, 1995, 2000, 2010, 2020],
    y: [26, 26, 24, 17, 16],
    type: 'scatter'
};

var SouthAsia = {
    x: [1990, 2000, 2010, 2020],
    y: [31, 27, 25, 24, 23],
    type: 'scatter'
};

var Israel = {
    x: [1990, 2000, 2010, 2020],
    y: [7, 7, 6, 5, 4],
    type: 'scatter'
};

var LatinAmericaCaribean = {
    x: [1990, 2000, 2010, 2020],
    y: [10, 9, 7, 6, 5],
    type: 'scatter'
};

var data = [DevelopingCountries, SubSaharanAfrica, SouthAsia, Israel, LatinAmericaCaribean];

Plotly.newPlot('hunger', data);

var adoption = {
    x: [2004,2009,2014,2019,2020],
    y: [100,20,5,4,6],
    type: 'scatter'
};
var giving = {
    x: [2004, 2009, 2014, 2019, 2020],
    y: [100, 70, 75, 80, 90],
    type: 'scatter'
};

var bla = [adoption,giving]

Plotly.newPlot('heat', bla);