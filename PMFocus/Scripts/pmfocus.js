///performing the same action as Ajax.BeginForm, but we'll be doing with our own code for customization and flexibility.

$(function () {
    var ajaxFormSubmit = function () {
        var $form = $(this);    // grab a reference to the form that is being submitted.

        // build an options object
        var options = {
            url: $form.attr("action"),      // get the URL by looking at the action attribute on that form
            type: $form.attr("method"),     // type of request to make (i.e., get/post) we can get that from the method attribute on the form
            data: $form.serialize()         // the data to send along to the server, whatever inputs in that form, we need to collect them all up, and to name value pairs and posted
        };

        //data		"searchTerm=&dropDownList=1"
        //type 		"get"
        //url 		"/Home/UpdateProject"

        // make asynchronous call back to the server with $.ajax
        // this function will be invoked and the response from the server will be in this data object.
        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-pmfocus-target"));
            var $newhtml = $(data);
            $target.replaceWith($newhtml);
            $newhtml.effect("highlight");       // JQuery UI Effect method to run the highlight effect, it can explode or pulsate or highlight.
        });
        // We need to prevent the Browser from doing its default action which is navigating away and going to the server by itself and redrawing the page.
        return false;
    };

    var submitAutocompleteProjName = function (event, ui) {
        var $input = $(this);           // point to the DOM element we're interacting with.
        $input.val(ui.item.label);      // this is the JQuery API to set the value of an input. ui is a parm that autocomplete pass in

        var $form = $input.parents("form:first");       // find the form, go and look through the parents above you, all the DOM elements above you, and find a form, in fact find the first form.
        $form.submit();                                 // once I find the form, there's a JQuery API where I can tell the form to submit itself. That will raise the submit event and that will ultimately come back
                                                        // into our AJAX form submit function that we wrote earlier.
        //var $data = $form.submit();
        //var $target = $($form.attr("projectHeader"));
        //var $newhtml = $data;
        //$target.replaceWith($newhtml);
        //$newhtml.effect("highlight");
    };

    var createProjectSearch = function () {
        var $input = $(this)        // when JQuery invokes this function, it will pass  along the input as this parm.
        //there's all sorts of options that you can specify for the autocomplete such as 1) minimum number of characters that the user has to type before
        //    it send the request to the server. 2) how many milliseconds it has to wait.
        var options = {
            source: $input.attr("data-pmfocus-autocompleteProjName"),      // tell the autocomplete widget where to get the data, take it from the URL that was embedded in that data dash attribute
            select: submitAutocompleteProjName  // when the select event occurs and call this function. When the user selects something, please call a function called submitAutocompleteProjName
        };

        $input.autocomplete(options);  // JQuery UI adds methods to JQuery like autocomplete and dialog and button and tabs and accordion etc.
    }

    // =======================STATUS SEARCH ==================================
    var createStatusSearch = function () {
        var $input = $(this)
        var $selectedVal = $("#dropDownList").val();
        if ($selectedVal == 3) {
            var options = {
                source: $input.attr("data-pmfocus-AutoCompleteStatus"),
                //            select: submitAutocompleteStatus
            };
            $input.autocomplete(options);  // JQuery UI adds methods to JQuery like autocomplete and dialog and button and tabs and accordion etc.
        }
    }

    $("#dropDownList").change(function () {
            var $selectedVal = $("#dropDownList").val();
            if ($selectedVal == 3) {
                $("input[data-pmfocus-AutoCompleteStatus]").each(createStatusSearch);
        }
        return false;
    });

    // ================DEPARTMENT Search =====================================
    var createDepartmentSearch = function () {
        var $input = $(this)
        var $selectedVal = $("#dropDownList").val();
        if ($selectedVal == 4) {
            var options = {
                source: $input.attr("data-pmfocus-AutoCompleteDepartment"),
                //            select: submitAutocompleteStatus
            };
            $input.autocomplete(options);  // JQuery UI adds methods to JQuery like autocomplete and dialog and button and tabs and accordion etc.
        }
    }

    $("#dropDownList").change(function () {
        var $selectedVal = $("#dropDownList").val();
        if ($selectedVal == 4) {
            $("input[data-pmfocus-AutoCompleteDepartment]").each(createDepartmentSearch);
        }
        return false;
    });

    // ================Stakeholder Search =====================================
    var createStakeholderSearch = function () {
        var $input = $(this)
        var $selectedVal = $("#dropDownList").val();
        if ($selectedVal == 2) {
            var options = {
                source: $input.attr("data-pmfocus-AutoCompleteStakeholder"),
                //            select: submitAutocompleteStatus
            };
            $input.autocomplete(options);  // JQuery UI adds methods to JQuery like autocomplete and dialog and button and tabs and accordion etc.
        }
    }

    $("#dropDownList").change(function () {
        var $selectedVal = $("#dropDownList").val();
        if ($selectedVal == 2) {
            $("input[data-pmfocus-AutoCompleteStakeholder]").each(createStakeholderSearch);
        }
        return false;
    });

    $("form[data-pmfocus-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-pmfocus-autocompleteProjName]").each(createProjectSearch);
    $("input[data-pmfocus-AutoCompleteStatus]").each(createStatusSearch);
    $("input[data-pmfocus-AutoCompleteDepartment]").each(createDepartmentSearch);
    $("input[data-pmfocus-AutoCompleteStakeholder]").each(createStakeholderSearch);

});