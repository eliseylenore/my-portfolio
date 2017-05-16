$(document).ready(function () {
    $(".click-for-projects").click(function () {
        console.log("HEYYO");
        $.ajax({
            type: 'GET',
            url: $(this).data('request-url'),
            dataType: 'json',
            complete: function (result) {
                console.log(result);
                console.log("result.responseJSON[0]: " + result.responseJSON[0]);
                console.log("result.responseJSON[0].language: " + result.responseJSON[0].language);
                $(".projects").text("");
                for (var i = 0; i < 3; i++) {
                    $(".projects").append(
                    "<div class='project-display'>" +
                    "<h1>" +
                    result.responseJSON[i].name +
                    "</h1>" +
                    "</div>")                   
                }
                $(".spiel").hide();
                }
            });
    });
    $(".home-button").click(function () {
        $(".spiel").show();
        $(".projects").hide();
    })
  });