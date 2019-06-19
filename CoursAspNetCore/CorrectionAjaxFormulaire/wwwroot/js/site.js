// Write your JavaScript code.
$('.champ').on('keyup', function (e) {
    $.ajax({
        url: "/Home/TestChamp",
        type: "GET",
        dataType: "json",
        data: "nomChamp=" + $(this).attr('id') + "&valueChamp=" + $(this).val(),
        success: (response) => {
            if (response.error) {
                $('span[data-valmsg-for=' + $(this).attr('id') + ']').html(response.message);
            }
            else {
                $('span[data-valmsg-for=' + $(this).attr('id') + ']').html('');
            }
        }
    })
})

$('#addUserForm').on('submit', function (e)  {
    e.preventDefault();
    $('.btnValider').html("En cours d'inscription");
    $.ajax({
        url: $(this).attr('action'),
        type: $(this).attr('method'),
        dataType: "json",
        data: $(this).serialize(),
        success: (response) => {
            if (!response.error) {
                $('.btnValider').html(response.message);
                $('.btnValider').attr('disabled', true);
            }
        }
    })
})