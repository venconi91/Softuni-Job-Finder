$('#blah').attr('src', "../Content/assets/img/no-image.png");

$(".upload").change(function () {
    readURL(this);
});

function readURL(input) {
    var ext = $('.upload').val().split('.').pop().toLowerCase();
    if ($.inArray(ext, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
        $('#blah').attr('src', "../Content/assets/img/The-Error.gif");
        return;
    }

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

