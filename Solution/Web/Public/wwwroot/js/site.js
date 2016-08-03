$(document).on("change", ".btn-file :file", function () {
	var input = $(this);
	var numberOfFiles = input.get(0).files ? input.get(0).files.length : 1;
	var label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
	input.trigger("fileselect", [numberOfFiles, label]);
});

$(function () {
	$(".input-daterange").datepicker({
		autoclose: true,
		todayHighlight: true,
		format: "m/d/yyyy"
	});

	$(".date-picker").datepicker({
		autoclose: true,
		todayHighlight: true,
		format: "m/d/yyyy"
	});

	$(".input-group.date").datepicker({
		autoclose: true,
		todayHighlight: true,
		format: "m/d/yyyy"
	});

	$(".phone-number").mask("(999) 999-9999");

	$("form").submit(function () {
		if ($(this).valid()) {
			$(".btn", this).attr("disabled", "disabled");
		}
	});

	$(".btn-confirm").click(function () {
		var title = $(this).data("confirmtitle");
		var message = $(this).data("confirmmessage");
		var action = $(this).data("confirmaction");

		bootbox.
			confirm({
				title: title,
				message: message,
				callback: function (result) {
					if (result) {
						window.location.href = action;
					}
				}
			});
	});

	$(".btn-confirm-delete").click(function () {
		var target = $(this).data("confirmtarget");
		var action = $(this).data("confirmaction");

		bootbox.
			confirm({
				title: "Confirm Delete - " + target,
				message: "Are you sure you want to delete this " + target + "?",
				callback: function (result) {
					if (result) {
						window.location.href = action;
					}
				}
			});
	});

	$(".btn-file :file").on("fileselect", function (event, numberOfFiles, label) {
		$("#" + $(this).attr("id") + "Name").val(label);
	});
});