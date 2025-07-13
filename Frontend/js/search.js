//Datepicker js
//$(function () {
//        $('#datetimepicker1').datetimepicker();
//});

$('select[name=things]').change(function () {
    if ($(this).val() == '') {
        window.location.href = 'CreateThingForm'; // Replace with the actual URL
    }
});
