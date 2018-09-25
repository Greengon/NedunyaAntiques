$(document).ready(function() {

        // Add class="selected" to tab + tbody
    $('#tabs a:first').addClass('selected');

        // Get the value of the tab link, and display tbody
        $('#tabs a').click(function() {
                // Switch class="selected" for tabs
                $('#tabs a').removeClass('selected');
            $(this).addClass('selected');
                this.blur();
                return false;

            }
        );
    }
);

$(window).load(function () {
	
    $(".product-description > .trigger_popup_fricc").click(function () {
        $(this).siblings('.hover_bkgr_fricc').show();
    });
    $('.hover_bkgr_fricc').click(function () {
         $('.hover_bkgr_fricc').hide();
    });
    $('.popupCloseButton').click(function () {
        ('.hover_bkgr_fricc').hide();
    });
});