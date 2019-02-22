// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    function suppressEnter(e) {
        if (e.key === "Enter") {
            e.preventDefault();
            return false;
        }
    }

    // Prepare the User-Edit-Template
    const addChoreTemplate = $($('#chore-template').html());
    const addUserTemplate = $($('#user-template').html());
    const jqForm = $("form");
    [
        jqForm, 
        addChoreTemplate, 
        addUserTemplate,
        $('.add-chores-form'),
        $('.user-form-group')
    ].forEach(item => item.keypress(suppressEnter));


    // Add CHORES form
    $('.btn-add-chore').click(e => {
        e.preventDefault();
        const dynamicClone = addChoreTemplate.clone(true);
        dynamicClone.insertBefore('.btn-add-chore');
    });
    
    // add a first chore-form (if not in edit mode)
    const jqDynChoresList = $('#dynamic-chores-list');
    const firstChoreClone = addChoreTemplate.clone(true);
    if (!jqDynChoresList.hasClass('edit-form')) {
        firstChoreClone.insertBefore('.btn-add-chore');
    }


    
    // Remove CHORES from
    jqDynChoresList.on('click',
        '.btn-remove-chore',
        function (e) {
            e.preventDefault();
            $(this).closest('.add-chores-form').remove();
            return false;
        });


    // Add USER Action
    jqDynChoresList.on('keyup.add-user-input',
        function (e) {
            if (e.key !== "Enter")
                return;
            e.preventDefault();
            const userAdderInput = $(e.target);
            const userName = userAdderInput.val().trim();
            if (userName === "")
                return;

            const dynamicClone = addUserTemplate.clone(true);
            const cloneUserInput = $(dynamicClone.children()[0]);

            cloneUserInput.val(userName);
            cloneUserInput.attr('size', userName.length);
            userAdderInput.val("");

            dynamicClone.insertBefore($(e.target).closest('.add-user-group'));
        });

    // Remove USER Action
    jqDynChoresList.on('click',
        '.btn-remove-user',
        function (e) {
            e.preventDefault();
            $(e.target).closest('.user-form-group').remove();
            return false;
        });


    jqDynChoresList.on('click',
        '.interval-type-selector',
        function () {
            // dont do anything unless selection changed
            const self = $(this);
            const lastVal = self.attr('data-last-value');
            const currVal = self.val();
            if (lastVal === currVal) {
                return;
            }
            self.attr('data-last-value', currVal);

            // remove current form
            self.next().remove();

            // add the correct template
            const newTemplate = $($('template#' + currVal.replace(" ", "-")).html());
            newTemplate.insertAfter(self);
        });


    // INDEX and Data-Mapping of all Chore fields
    jqForm.submit(function () {
        $('.add-user-input').prop("disabled", true);

        $('.add-chores-form').each(function (choreIdx, elem) {

            $(elem).find('.chore-title').attr('name', `Chores[${choreIdx}].Title`);

            $(elem).find('.chore-description').attr('name', `Chores[${choreIdx}].Description`);

            $(elem).find('.interval-type-selector').attr('name', `Chores[${choreIdx}].IntervalType`);

            $(elem).find('.chore-startdate').attr('name', `Chores[${choreIdx}].StartDay`);

            $(elem).find('.chore-duration').attr('name', `Chores[${choreIdx}].Duration`);

            $(elem).find('.normal-user-input').each(function (index) {
                $(this).attr('name', `Chores[${choreIdx}].AssignedUsers[${index}]`);
            });
        });
    });
});