var CurrentController = "Home";

function HomeInit() {
	var Nome = $("#inputEmail");
	var Senha = $("#inputPassword");
	var ReSenha = $("#inputRePassword");
	var Descricao = $("#inputUser");
	if (!isEmpty(Nome))
		Nome.attr('maxlength', '40');
	if (!isEmpty(Senha))
		Senha.attr('maxlength', '40');
	if (!isEmpty(ReSenha))
		ReSenha.attr('maxlength', '40');
	if (!isEmpty(Descricao))
		Descricao.attr('maxlength', '40');
}

function ValidateLogin() {
	var Nome = $("#inputEmail").val();
	var Senha = $("#inputPassword").val()

	if (isEmpty(Nome) || isEmpty(Senha)) {
		swal({
			title: "Erro de Login",
			text: "Campo(s) sem Conteudos",
			icon: "error",
			button: "Confirm",
		});
		return false;
	}
	return true;
}
function ValidateRegister() {
	var Nome = $("#inputEmail").val();
	var Senha = $("#inputPassword").val();
	var ReSenha = $("#inputRePassword").val();
	var Descricao = $("#inputUser").val();
	

	if (isEmpty(Nome) || isEmpty(Senha) || isEmpty(ReSenha) || isEmpty(Descricao)) {
		swal({
			title: "Erro de Registro",
			text: "Campo(s) sem Conteudos",
			icon: "error",
			button: "Confirm",
		});
		return false;
	}
	else if (Senha != ReSenha) {
		swal({
			title: "Erro de Registro",
			text: "Campo 'Senha' com valor diferente do 'Repetir Senha'",
			icon: "error",
			button: "Confirm",
		});
		return false;
	}
	return true;
}
function Register() {
	if (ValidateRegister()) {
		var UserJson = JSON.stringify({
			Nome: $("#inputEmail").val(),
			Senha: $("#inputPassword").val(),
			Descricao: $("#inputUser").val()
		})
		var data = GetPostMethod(CurrentController, "Register", UserJson, "post");
		if (!isEmpty(data)) {
			swal({
				title: "Sucesso",
				text: "Usuario cadastrado com sucesso!",
				icon: "success",
				button: "Confirm",
			});
			$(".container.body-content").html(data);
			HomeInit();
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
function LogIn() {
	var UserJson = JSON.stringify({
		Nome : $("#inputEmail").val(),
		Senha: $("#inputPassword").val()
	})
	if (ValidateLogin()) {
		var data = GetPostMethod(CurrentController, "LogIn", UserJson, "POST");
		if (!isEmpty(data))
			$(".container.body-content").html(data);
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