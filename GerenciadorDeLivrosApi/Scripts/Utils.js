function GetPostMethod(Controller, Method, json, type) {
	var dataReturn = "";
	$.ajax({
		type: type,
		url: "/" + Controller + "/" + Method,

		dataType: 'html',
		data: json,
		contentType: "application/json; charset=utf-8",
		async: false,
		success: function (data) {
			dataReturn =  data;
		}
		, error: function (xhr, httpStatusMessage, customErrorMessage) {
			alert("Error");
			if (xhr.status === 410) {
				alert(customErrorMessage);
			}
		}	
	})
	return dataReturn;
}
function isEmpty(val) {
	return (val === undefined || val == null || val.length <= 0) ? true : false;
}
function MessageError(title, content) {

	$('#ModalTitle').text(title);
	$('#ModalContent').text(content);
	$('#ErrorModal').modal('show');
}
