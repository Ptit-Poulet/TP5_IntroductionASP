$(document).ready(function () {

    //$(".edit-icon").hover(function () {
    //    $(this).tooltip();
    //})

    //$(".delete-icon").hover(function () {
    //    $(this).tooltip();
    //})

    $('.edit, .delete').tooltip({
        position: {
            my: 'center top',
            at: 'center bottom'
        }
    });
});