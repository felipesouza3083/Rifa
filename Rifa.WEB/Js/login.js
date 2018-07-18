$(document).ready(function () {

    $("#btncadastrar").click(function () {
        CadastrarUsuario();
    });

    $("#btnlogin").click(function () {
        AutenticarUsuario();
    });
});

function guid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

function CadastrarUsuario() {
    $("#mensagemCad").html("Processando...");

    var fileUpload = $("#imagem").get(0);
    var files = fileUpload.files;

    //Pegando a extensao da imagem...
    var extensao = files[0].name.substring(files[0].name.length - 3, files[0].name.length);

    //Gerando um novo nome para a imagem...
    var filename = guid();
    filename += '.' + extensao;

    //atribuindo a imagem no formData...
    var data = new FormData();
    data.append('file', files[0], filename);

    $.ajax({
        url: "/Usuario/SalvarFoto",
        type: "POST",
        data: data,
        contentType: false,
        processData: false,
        success: function () { },
        error: function () { }
    });



    var model = {
        Nome: $("#nome").val(),
        Email: $("#email").val(),
        Login: $("#LoginCadastro").val(),
        Senha: $("#senha").val(),
        ConfirmSenha: $("#confirm-password").val(),
        Foto: filename,
        IdPerfil: 2
    };

    $.ajax({
        type: "POST",
        url: "/Usuario/CadastrarUsuario",
        data: model,
        success: function (msg) {
            $("#mensagemCad").html(msg);

            $("#nome").val("");
            $("#email").val("");
            $("#LoginCadastro").val("");
            $("#senha").val("");
            $("#confirm-password").val("");
            $("#imagem").val("");
        },
        error: function (e) {
            $("#mensagemCad").html("Ocorreu um erro." + e.status);
        }
    });

}

function AutenticarUsuario() {
    $("#mensagem").html("Autenticando o Usuário...");

    var model = {
        Login: $("#Login").val(),
        Senha: $("#Senha").val()
    }

    $.ajax({
        type: "POST",
        url: "/Usuario/AutenticarUsuario",
        data: model,
        success: function (msg) {
            debugger;
            if (ValidURL(msg)) {
                window.location.href = msg.redirectTo;
            }
            else {
                $("#mensagem").html(msg);
            }
        },
        error: function (e) {
            $("#mensagem").html("Ocorreu um erro: " + e.status);
        }
    })
}

function ValidURL(str) {
    if (str.redirectTo.includes("/")) {
        return true;
    }
    else {
        return false;
    }
}