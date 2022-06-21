$(() => {
    $(".datepicker").datepicker({
        dateFormat: "yy-mm-dd"
    });

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
        name.append($(`<td><input type='text' name='name${index}' /></td>`));
        name.append($("<td>validation errors</td>"));

        let surename = $("<tr>");
        surename.append($("<td><label>His/Her surename</label></td>"));
        surename.append($(`<td><input type='text' name='surename${index}' /></td>`));
        surename.append($("<td>validation errors</td>"));

        let IDNumber = $("<tr>");
        IDNumber.append("<td><label>His/Her ID number</label></td>");
        IDNumber.append(`<td><input type="number" name="IDNumber${index}" /></td>`);
        IDNumber.append($("<td>validation errors</td>"));

        let workplace = $("<tr>");
        workplace.append("<td><label>His/Her workplace</label></td>");
        workplace.append(`<td><input type="text" name="workplace${index}" /></td>`);
        workplace.append($("<td>validation errors</td>"));

        let salary = $("<tr>");
        salary.append("<td><label>His/Her net salary</label></td>");
        salary.append(`<td><input type="text" name="salary${index}" /></td>`);
        salary.append($("<td>validation errors</td>"));

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