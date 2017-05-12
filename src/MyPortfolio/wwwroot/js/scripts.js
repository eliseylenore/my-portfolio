$(document).ready(function() {
    $.ajax({
        type: 'GET',
        url: '@Url.Action("/Projects/GetProjects")',
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