var CurrentControllerLogOn = "LogOn";

function EditBookInit() {
	var Editores = $("#inputEditores");
	var Titulo = $("#inputTitle");
	var SubTitulo = $("#inputSubTitle");
	var Editora = $("#inputEditora");
	var NumeroEdicao = $("#inputNumeroEdicao");
	var AnoPublicacao = $("#inputDataPublicacao");
	var Resenha = $("#inputResenha");
	if (!isEmpty(Editores))
		Editores.attr('maxlength', '100');
	if (!isEmpty(Titulo))
		Titulo.attr('maxlength', '40');
	if (!isEmpty(SubTitulo))
		SubTitulo.attr('maxlength', '40');
	if (!isEmpty(Editora))
		Editora.attr('maxlength', '40');
	if (!isEmpty(NumeroEdicao))
		NumeroEdicao.attr('maxlength', '10');
	if (!isEmpty(AnoPublicacao))
		AnoPublicacao.attr('maxlength', '10');
	$('.datepicker').datepicker({
		format: 'dd/mm/yyyy',
		startDate: '-3d'
	});
}
function indexInit() {
	//$("#grid-data").bootgrid({
	//	ajax: true,
	//	post: function () {
	//		/* To accumulate custom parameter with the request object */
	//		return {
	//			id: "b0df282a-0d67-40e5-8558-c9e93b7befed"
	//		};
	//	},
	//	url: "/" + CurrentController + "/ReturnBook",
	//	formatters: {
	//		"link": function (column, row) {
	//			return "<a href=\"#\">" + column.id + ": " + row.id + "</a>";
	//		}
	//	}
	//});


}
function ValidateRegister() {
	var title = $("#inputTitle").val();
	var numeroExempalres = $("#inputNumeroExemplares").val();
	if (isEmpty(title) || isEmpty(numeroExempalres)) {
		swal({
			title: "Erro de Registro",
			text: "Campo(s) sem Conteudos",
			icon: "error",
			button: "Confirm",
		});
		return false;
	}
	return true;
}
function RegisterGenero() {
	if (!isEmpty($("#inputGeneroDescri").val())) {
		var GeneroJson = JSON.stringify({
			Descricao: $("#inputGeneroDescri").val(),
		})
		var data = GetPostMethod(CurrentControllerLogOn, "RegisterGenero", GeneroJson, "post");
		if (!isEmpty(data)) {
			//MessageError("Sucesso", "Genero cadastrado com sucesso!");
			swal({
				title: "Sucesso",
				text: "Genero cadastrado com sucesso",
				icon: "success",
				button: "Confirm",
			});
			$(".container.body-content").html(data);
			EditBookInit();
		} else {
			swal({
				title: "Erro Interno",
				text: "Erro no processo",
				icon: "error",
				button: "Confirm",
			});
		}
	}
	else {
		swal({
			title: "Erro de Registro",
			text: "Campo(s) sem Conteudos",
			icon: "error",
			button: "Confirm",
		});
	}
}
function SaveGenero() {
	if (!isEmpty($("#inputGeneroDescri").val())) {
		var GeneroJson = JSON.stringify({
			Descricao: $("#inputGeneroDescri").val(),
			Id: $('#Id').val()
		})
		var data = GetPostMethod(CurrentControllerLogOn, "SaveGenero", GeneroJson, "post");
		if (!isEmpty(data)) {
			swal({
				title: "Sucesso",
				text: "Atualizado com sucesso",
				icon: "success",
				button: "Confirm",
			});
			$(".container.body-content").html(data);
		}
		else {
			swal({
				title: "Erro Interno",
				text: "Erro no processo",
				icon: "error",
				button: "Confirm",
			});
		}
	}
	else {
		swal({
			title: "Erro de Registro",
			text: "Campo(s) sem Conteudos",
			icon: "error",
			button: "Confirm",
		});
	}
}

function RegisterBook() {
	if (ValidateRegister()) {
		var BookJson = JSON.stringify({
			Editores: $("#inputEditores").val(),
			Titulo: $("#inputTitle").val(),
			SubTitulo: $("#inputSubTitle").val(),
			Editora: $("#inputEditora").val(),
			NumeroEdicao: $("#inputNumeroEdicao").val(),
			AnoPublicacao: $("#inputDataPublicacao").val(),
			Resenha: $("#inputResenha").val(),
			NumeroExemplares: $("#inputNumeroExemplares").val(),
			Isbn: $("#inputISBN").val(),
			QtdPaginas: $("#inputQuantidadeDePaginas").val(),
			GeneroId: $('#Generos').val()
		})

		var data = GetPostMethod(CurrentControllerLogOn, "RegisterBook", BookJson, "post");
		if (!isEmpty(data)) {
			swal({
				title: "Sucesso",
				text: "Livro cadastrado com sucesso!",
				icon: "success",
				button: "Confirm",
			});
			$(".container.body-content").html(data);
			EditBookInit();
		}
		else {
			swal({
				title: "Erro Interno",
				text: "Erro no processo",
				icon: "error",
				button: "Confirm",
			});
		}
	}
}
function SaveBook() {
	if (ValidateRegister()) {
		var generoId = $('#Generos').val();
		var BookJson = JSON.stringify({
			Editores: $("#inputEditores").val(),
			Titulo: $("#inputTitle").val(),
			SubTitulo: $("#inputSubTitle").val(),
			Editora: $("#inputEditora").val(),
			NumeroEdicao: $("#inputNumeroEdicao").val(),
			AnoPublicacao: $("#inputDataPublicacao").val(),
			Resenha: $("#inputResenha").val(),
			NumeroExemplares: $("#inputNumeroExemplares").val(),
			Isbn: $("#inputISBN").val(),
			QtdPaginas: $("#inputQuantidadeDePaginas").val(),
			GeneroId: $('#Generos').val(),
			Id: $('#Id').val()
		})

		var data = GetPostMethod(CurrentControllerLogOn, "SaveBook", BookJson, "post");
		if (!isEmpty(data)) {
			swal({
				title: "Sucesso",
				text: "Atualizado com sucesso",
				icon: "success",
				button: "Confirm",
			});
			$(".container.body-content").html(data);
			EditBookInit();
			document.getElementById('Generos').value = generoId
		}
		else
			swal({
				title: "Erro Interno",
				text: "Erro no processo",
				icon: "error",
				button: "Confirm",
			});
	}
}
function search() {


	var SearchJson = JSON.stringify({
		Search: $("#search").val()
	})
	var data = GetPostMethod(CurrentControllerLogOn, "Index?Search=" + ($("#search").val()), SearchJson, "GET");
	if (!isEmpty(data)) {
		$(".container.body-content").html(data);
	}
}