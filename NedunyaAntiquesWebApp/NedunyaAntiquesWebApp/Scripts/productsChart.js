
var width = 900,
    height = 600,
    radius = Math.min(width, height) / 3;

var color = d3.scale.ordinal()
    .range(["#f7fcfe", "#e5f5f9", "#ccece6", "#99d8c9", "#66c2a4", "#41ae76", "#238b45", "#006d2c", "#00441b", '#d9d9d9', '#bdbdbd', '#969696', '#737373', '#525252', '#252525', '#000000', '#ef3b2c', '#cb181d', '#a50f15', '#67000d', '#54278f', '#3f007d']);

var arc = d3.svg.arc()
    .outerRadius(radius - 10)
    .innerRadius(0);

var pie = d3.layout.pie()
    .sort(null)
    .value(function (d) { return d.count; });

var svg = d3.select("#canvas").append("svg")
    .attr("width", width)
    .attr("height", height)
    .append("g")
    .attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");

d3.json("http://localhost:51144/Products/api", function (error, jData){
    var data = [];
    jData.forEach(function (d) {
        var x = d.count;
        data.push({
            count: d.count,
            keyword: d.catName
        });
    });

    // Produce pie chart with data
    var g = svg.selectAll(".arc")
        .data(pie(data))
        .enter().append("g")
        .attr("class", "arc");

    g.append("path")
        .attr("d", arc)
        .attr("fill", function (d, i) { return color(i); })
        .transition()
        .ease("elastic")
        .duration(3000)
        .attrTween("d", tweenPie);


    // "extra" g to append legend
    g.append("path")
        .attr("d", arc)
        .attr("data-legend", function (d) { return d.data.keyword; })
        .attr("data-legend-pos", function (d, i) { return i; })
        .style("fill", function (d) { return color(d.data.keyword); });


    g.append("text")
        .attr("transform", function (d) { return "translate(" + arc.centroid(d) + ")"; })
        .attr("dy", ".35em")
        .style("text-anchor", "middle");

    function tweenPie(b) {
        b.innerRadius = 0;
        var i = d3.interpolate({ startAngle: 0, endAngle: 0 }, b);
        return function (t) { return arc(i(t)); };
    }

    var padding = 50,
        legx = radius + padding,
        legend = svg.append("g")
            .attr("class", "legend")
            .attr("transform", "translate(" + legx + ", 0)")
            .style("font-size", "12px")
            .call(d3.legend);

});
