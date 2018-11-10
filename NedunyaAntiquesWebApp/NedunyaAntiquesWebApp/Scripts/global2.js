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


 
});



$(document).load(function () {






});