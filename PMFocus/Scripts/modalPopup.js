
$(function () {

    var url = "";

    if ('@TempData["msg"]' != "") {
        $("#dialog-alert").dialog('open');
    }

    $("#dialog-edit").dialog({
        title: 'Create Log Record',
        autoOpen: false,
        resizable: false,
        width: 690,
        height: 600,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
            $(this).load(url);
        }
    });

    // dialog-edit-stakeholders
    $("#dialog-edit-stakeholders").dialog({
        title: 'Plan StakeHolders Management',
        autoOpen: false,
        resizable: false,
        width: 690,
        height: 600,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
            $(this).load(url);
        }
    });

    $("#dialog-create-project").dialog({
        title: 'Create New Project',
        autoOpen: false,
        resizable: false,
        width: 690,
        height: 600,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
            $(this).load(url);
        }
    });

    // Create Manager Record
    $("#dialog-create-manager").dialog({
        title: 'Create New Manager',
        autoOpen: false,
        resizable: false,
        width: 690,
        height: 600,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
            $(this).load(url);
        }
    });

    // Create Sponsor Record
    $("#dialog-create-sponsor").dialog({
        title: 'Create New Sponsor',
        autoOpen: false,
        resizable: false,
        width: 690,
        height: 600,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
            $(this).load(url);
        }
    });

    // dialog-create-department
    $("#dialog-create-department").dialog({
        title: 'Add New Department',
        autoOpen: false,
        resizable: false,
        width: 690,
        height: 600,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
            $(this).load(url);
        }
    });


    $("#lnkCreate").live("click", function (e) {
        //e.preventDefault(); //use this or return false
        url = $(this).attr('href');        // href = "/Home/createLog/1"
        $("#dialog-edit").dialog('open');

        return false;
    });

    // Plan Stakeholders Management
    $("#lnkCreateStake").live("click", function (e) {
        //e.preventDefault(); //use this or return false
        url = $(this).attr('href');        // "/Home/createStakeHolder/1"
        $("#dialog-edit-stakeholders").dialog('open');

        return false;
    });

    $("#dropDownList").change(function () {
        var $selectedVal = $(this).val();
        if ($selectedVal == 5) {
            url = $("a#lnkCreateProject").attr("href");
            $("#dialog-create-project").dialog('open');
        }

        return false;
    });

    /* Create Manager record from Manager Full Name DropDownList*/
    $("#_proj_mgr_id").change(function () {
        var $selectedVal = $(this).val();
        if ($selectedVal == 0) {
            url = $("a#lnkCreateManager").attr("href");
            $("#dialog-create-manager").dialog('open');
        }

        return false;
    });

    /* Create Sponsor record from Sponsor Full Name DropDownList*/
    $("#_proj_sponsor_id").change(function () {
        var $selectedVal = $(this).val();
        if ($selectedVal == 0) {
            url = $("a#lnkCreateSponsor").attr("href");
            $("#dialog-create-sponsor").dialog('open');
        }

        return false;
    });

    // Department Table
    $("#_dept_id").change(function () {
        var $selectedVal = $(this).val();
        if ($selectedVal == 0) {
            url = $("a#lnkCreateDepartment").attr("href");
            $("#dialog-create-department").dialog('open');
        }

        return false;
    });

    // CANCEL BUTTONS
    $("#btncancel").live("click", function (e) {
        $("#dialog-edit").dialog("close");
        return false;
    });

    /*btncancelStakeholder */
    $("#btncancelStakeholder").live("click", function (e) {
        $("#dialog-edit-stakeholders").dialog("close");
        return false;
    });

    /*btncancelProject */
    $("#btncancelProject").live("click", function (e) {
        $("#dialog-create-project").dialog("close");
        return false;
    });

    // btncancelManager
    $("#btncancelManager").live("click", function (e) {
        $("#dialog-create-manager").dialog("close");
        return false;
    });

    // btncancelSponsor
    $("#btncancelSponsor").live("click", function (e) {
        $("#dialog-create-sponsor").dialog("close");
        return false;
    });

    //btncancelDepartment
    $("#btncancelDepartment").live("click", function (e) {
        $("#dialog-create-department").dialog("close");
        return false;
    });

});