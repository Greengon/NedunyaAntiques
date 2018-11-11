$(document).ready(function() {


    $(".product-description > .trigger_popup_fricc").click(function () {
        $(this).siblings('.hover_bkgr_fricc').show();
    });
    $('.hover_bkgr_fricc').click(function () {
        $('.hover_bkgr_fricc').hide();
    });
    $('.popupCloseButton').click(function () {
        ('.hover_bkgr_fricc').hide();
    });

/*
        $('#exampleModal').on('show.bs.modal',
            function(event) {
                var button = $(event.relatedTarget); // Button that triggered the modal
                var recipient = button.data('whatever'); // Extract info from data-* attributes
                // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
                // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
                var modal1 = $(this);
                modal1.find('.modal-title').text('New message to ' + recipient);
                modal1.find('.modal-body input').val(recipient);


        });*/


    

    //open accordion for chosen category
    $(function () {

        // check if there is a hash in the url
        var value = window.location.hash.split('#')[1];
        if (window.location.hash != '') {
            // show the panel based on the hash now:
            var url = window.location.toString();
            if (url.match('#')) {
                $("#" + value).collapse('show');
            }
        }

    });

    function GetURLParameter(sParam) {
        var sPageURL = window.location.search.substring(1);
        var sURLVariables = sPageURL.split('&');
        for (var i = 0; i < sURLVariables.length; i++) {
            var sParameterName = sURLVariables[i].split('=');
            if (sParameterName[0] == sParam) {
                return sParameterName[1];
            }
        }
    }

    $(function () {

        var category = GetURLParameter('category');
        var subcategory = GetURLParameter('subcategory');
        if (category != null) {
            $('.showList[choice='+category+']').trigger('click');
        } else if (subcategory != null) {
            $('.showList[choice=' + subcategory + ']').trigger('click');
        }
    });



});



$(document).load(function () {




});