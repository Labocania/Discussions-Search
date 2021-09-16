// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var searchQuery = $("#search-query");
let valueArray = [];

$(".site-checkbox").click(function () {
    var $this = $(this);
    var value = "site:" + $this.attr("value").concat(" ");
    if ($this.is(":checked")) {
        valueArray.push(value);
        console.log(valueArray);
    }
    else {
        var index = valueArray.indexOf(valueArray.find(element => element.value));
        valueArray.splice(index, 1);
        console.log(valueArray)
    }
});

$("#primary-search").click(function (e) {
    console.info("click");
    var sites = "";
    var value = $("#primary-field").val();
    for (var i = 0; i < valueArray.length; i++) {
        sites += valueArray[i];
        if (i != valueArray.length - 1) {
            sites += "OR ";
        }
    }
    $("#primary-field").val(sites + value);
    console.info($("#primary-field").val());
    $('form').submit();
});
