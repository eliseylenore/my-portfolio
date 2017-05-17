$(document).ready(function () {
    $(".starred-repositories").hide();
    $(".click-for-projects").click(function () {
        console.log("HEYYO");
        $.ajax({
            type: 'GET',
            url: $(this).data('request-url'),
            dataType: 'json',
            complete: function (result) {
                $(".spiel").hide();
                $(".starred-repositories").show();
                $(".projects").text("");
                console.log(result);
                console.log("result.responseJSON[0]: " + result.responseJSON[0]);
                console.log("result.responseJSON[0].language: " + result.responseJSON[0].language);
                var description = "";                
                for (var i = 0; i < 4; i++) {
                    if (result.responseJSON[i].description) {
                        description = result.responseJSON[i].description;
                    }
                    $(".projects").append(
                    "<div class='project-display'>" +
                    "<h1><a href='" +
                    result.responseJSON[i].html_Url +
                    "'>" +
                    result.responseJSON[i].name +
                    "</h1></a>" +
                    "<p>" +
                    description +
                    "</p>" + 
                    "<h4>Stars: " +
                    result.responseJSON[i].watchers +
                    "<h4>" +
                    "</div>") ;                              
                }
                
            }         
            });
        });
    $(".home-button").click(function () {
        $(".projects").hide();
        $(".spiel").show();
    });
  });