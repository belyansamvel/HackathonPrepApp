$(() => {
    //$(".datepicker > input").datepicker({
    //    dateFormat: "yy-mm-dd"
    //});

    let showed = false;
    $(".anotherFamilyMemberField").fadeOut();
    $(".memberOperations").fadeOut();

    $("#otherFamilyMember").click(() => {
        if (showed) {
            $(".anotherFamilyMemberField").fadeOut();
            $(".memberOperations").fadeOut();
            showed = false;
        }
        else {
            $(".anotherFamilyMemberField").fadeIn();
            $(".memberOperations").fadeIn();
            showed = true;
        }
    });

    $(".addMember").click(() => {
        let index = $(".anotherFamilyMemberField").children().length;

        let table = $("<table>").addClass("table").attr("id", "anotherFamilyMemberField" + index);

        let name = $("<tr>");
        name.append($("<td><label>His/Her name</label></td>"));
        name.append($(`<input class="text-box single-line" id="Customer_FamilyMamber_${index}__Name" name="Customer.FamilyMamber[${index}].Name" type="text">`));
        //name.append($("<td>validation errors</td>"));

        let surename = $("<tr>");
        surename.append($("<td><label>His/Her surename</label></td>"));
        surename.append($(`<input class="text-box single-line" id="Customer_FamilyMamber_${index}__SurName" name="Customer.FamilyMamber[${index}].SurName" type="text">`));
        //surename.append($("<td>validation errors</td>"));

        let IDNumber = $("<tr>");
        IDNumber.append("<td><label>His/Her ID number</label></td>");
        IDNumber.append(`<input class="text-box single-line" data-val="true" data-val-required="The Int32 field is required." id="Customer_FamilyMamber_${index}__IDNumber" name="Customer.FamilyMamber[${index}].IDNumber" type="number">`);
        //IDNumber.append($("<td>validation errors</td>"));

        let workplace = $("<tr>");
        workplace.append("<td><label>His/Her workplace</label></td>");
        workplace.append(`<input class="text-box single-line" id="Customer_FamilyMamber_${index}__Workplace" name="Customer.FamilyMamber[${index}].Workplace" type="text">`);
        //workplace.append($("<td>validation errors</td>"));

        let salary = $("<tr>");
        salary.append("<td><label>His/Her net salary</label></td>");
        salary.append(`<input class="text-box single-line" data-val="true" data-val-number="The field must be a number." data-val-required="The Decimal field is required." id="Customer_FamilyMamber_${index}__NetSallary" name="Customer.FamilyMamber[${index}].NetSallary" type="text">`);
        //salary.append($("<td>validation errors</td>"));

        table.append(name);
        table.append(surename);
        table.append(IDNumber);
        table.append(workplace);
        table.append(salary);

        $(".anotherFamilyMemberField").append(table);
    });

    $(".removeMember").click(() => {
        $(".anotherFamilyMemberField").children().eq($(".anotherFamilyMemberField").children().length - 1).remove();
    });
});