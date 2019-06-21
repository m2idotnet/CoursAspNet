//Effectuer une requete ajax en utilisant l'objet jquery dés le chargement de la page
//$.ajax({
//    url: '/Home/TestAjax',
//    type: 'GET',
//    dataType: 'html',
//    success: (response) => {
//        alert(response);
//    }
//})

//Effectuer une requete ajax en cliquant sur un lien
$('.reqAjax').on('click', function (e) {
    e.preventDefault();
    $("#resultAjax").html("en cours de chargement");
    $.ajax({
        //Selection du href du lien sur le quel on clique
        url: $(this).attr('href'),
        type: 'GET',
        dataType: 'html',
        data: "dataPlus=" + $(this).attr('data-ajax'),
        success: (responseData) => {
            $("#resultAjax").html(responseData);
        },
        error: (err) => {
            console.dir(err);
            alert("Erreur serveur : " + err.statusText);
        }
    });
});
//soumettre un formulaire en ajax
$("#monForm").on('submit',
    function(e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            dataType: "html",
            success: (response) => {
                alert(response);
            }
        });
    });

$('.champ').on('keyup', function (e) {
    $.ajax({
        url: "/Home/TestChamp",
        type: "GET",
        data: "valueChamp=" + $(this).val(),
        dataType: "json",
        success: (response) => {
            if (response.error) {
                $(this).css('border-color', '#cd2127');
            } else {
                $(this).css('border-color', '#fff');
            }
        }
    });
})