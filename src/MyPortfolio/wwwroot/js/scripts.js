$(document).ready(function () {
    $(".click-for-projects").click(function () {
        console.log("HEYYO");
        $.ajax({
            type: 'GET',
            url: $(this).data('request-url'),
            dataType: 'json',
            complete: function (result) {
                console.log(result);
                result.forEach(function (project) {
                    $(".projects").append(
                    "<div class='project-display'>" +
                    "<h1>" +
                    project.name +
                    "</h1>" +
                    "</div>"
                    );
                });
            }
        });
    });
});