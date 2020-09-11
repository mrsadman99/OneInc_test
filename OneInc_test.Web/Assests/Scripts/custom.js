var options;

function setOprions(updateDate, name, surname, state, objectName, nameSelected) {
    options = {
        updateDate: updateDate
        , name: name
        , state: state
        , surname: surname
        , objectName: objectName
        , nameSelected: nameSelected
    }
}

function filterOptions() {
    $.get('/Policy/GetFilter',
        {
            updateDate: options.updateDate
            , name: options.name
            , state: options.state
            , surname: options.surname
            , objectName: options.objectName
            , nameSelected: options.nameSelected
        }).then(function (response) {
        $("#dialogContent").html(response);
        $("#modDialog").modal('show');
    })
}





function filterSetup() {
    setOprions($('#update')[0].value
        , $('#nameOwner')[0].value
        , $('#surnameOwner')[0].value
        , $('#stateSelector option:selected')[0].value
        , $('#nameObject')[0].value
        , $('#ownerInfo')[0].value
    );
    setContent();
    $("#modDialog").modal('hide');
}

function setContent() {
    $.get("/Projects/GetUpdated/",
        {
            updateDate: updateDate
            , name: name
            , state: state
            , surname: surname
            , objectName: objectName
            , nameSelected: nameSelected
        })
        .then(function (response) {
            $('#content').html(response);
        })
}


