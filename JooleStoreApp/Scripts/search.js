

$(document).ready(function () {
    var dict = {
        "Mechanical": [{ name: "Lighting", id: 1 }, { name: "Moniter", id: 2 }],
        "Electrical": [{ name: "Fans", id: 3 }, { name: "AC", id: 4 }],
        "Furniture": [{ name: "Bedframe", id: 5 }, { name: "Sofa", id: 6 }],
        "Stationary": [{ name: "Cabinet", id: 7 }, { name: "Table", id: 8 }]
    };

    $("#search-dropdown").change(() => {
        var value = $("#search-dropdown").val();
        $("#subcategory").empty();
        for (obj in dict[value]) {
            $("#subcategory").append("<option class='search__dropdown-list' value='" + dict[value][obj].id + "'>" + dict[value][obj].name + "</option>");
        }
    });

});
