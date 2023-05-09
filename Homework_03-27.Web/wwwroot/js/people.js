$(() => {
    let counter = 1;

    $("#add-rows").on("click", function () {
        $("#ppl-rows").append(`<div class="row person-row" style='margin-bottom:10px;'>
                <div class="col-md-4">
                    <input class="form-control" type="text" name="people[${counter}].firstname" placeholder="First Name"/>
                </div>
                <div class="col-md-4">
                    <input class="form-control" type="text" name="people[${counter}].lastname" placeholder="Last Name"/>
                </div>
                <div class="col-md-4">
                    <input class="form-control" type="text" name="people[${counter}].age" placeholder="Age"/>
                </div>
                </div> `)
        counter++;
    });

    $("input").on('keyup', function () {
        const isValid = $("#fName").val() && $("#lName").val() && $("#age").val();
        $("button, .btn-primary").prop('disabled', !isValid);
    });
})