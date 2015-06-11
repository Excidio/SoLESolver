$(document).ready(function () {
    $("select").change(function () {
        $('#sole').html(createSole(this.value));
    });
});

function createSole(countElem) {
    countElem = parseInt(countElem);
    if (countElem >= 2 && countElem <= 4) {

        var inputs = "";
        for (var i = 0; i < countElem; i++) {
            inputs += "<div>";
            for (var j = 0; j < countElem + 1; j++) {
                inputs += "<input name=\"sole[" + i + "][" + j + "]\" type=\"text\" value=\"0\" />";
                if (j < countElem) {
                    inputs += "<label><i>x" + (j + 1) + "</i>" + (j < countElem - 1 ? " + " : " = ") + "</label>";
                }
            }

            inputs += "</div>";
        }

        return inputs;
    }

    return null;
}