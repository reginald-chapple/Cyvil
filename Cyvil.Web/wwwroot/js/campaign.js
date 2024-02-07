function saveCampaign() {
    if ($("#campaign-form").valid()) {
        var myModalEl = document.getElementById('saveCampaignModal');
        var modal = bootstrap.Modal.getInstance(myModalEl)
        // console.log(formData);
        $.ajax({
            type: "POST",
            beforeSend: function (xhr) {  
                xhr.setRequestHeader("XSRF-TOKEN",  
                    $('input:hidden[name="__RequestVerificationToken"]').val());  
            },  
            url: "/Campaigns/Create",
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                modal.hide();
                document.getElementById("campaign-form").reset();
                // SELECT Name, COUNT(Name), StateId, COUNT(StateId) FROM Cities GROUP BY Name, StateId HAVING COUNT(Name) > 1 AND COUNT(StateId) > 1;
                flashToast(response.message);
                $("#campaignData").append(`<tr>
                    <td scope="row">${response.name}</td>
                    <td>${response.cause}</td>
                    <td>
                        <a href='/Campaigns${response.id}/Details'>View</a>
                    </td>
                </tr>`)
            },
            error: function (request, status, error) {
                modal.hide();
                document.getElementById("campaign-form").reset();
                // flashToast(request.responseText);
            }

        });
    }
}