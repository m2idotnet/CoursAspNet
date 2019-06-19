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
        //data : "toto=",
        success: (responseData) => {
            
            $("#resultAjax").html(responseData);
        },
        error: (err) => {
            console.dir(err);
            alert("Erreur serveur : " + err.statusText)
        }
    })
});
