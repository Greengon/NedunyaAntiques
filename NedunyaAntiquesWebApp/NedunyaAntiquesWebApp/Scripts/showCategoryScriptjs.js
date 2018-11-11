$(document).ready(function () {

$('.showList').click(function (e) {
    var category = this.getAttribute("choice");
    var subcategory = this.getAttribute("subchoice");
    $.ajax({
        type: "GET",
        url: "/Products/_ProductList",
        data: { Category: category, SubCategory: subcategory },
        success: function (data) {
            $("#product_list_container").html(data);
        },
        error: function () {
            alert("Something went wrong in controller");
        }
    });

    });

});