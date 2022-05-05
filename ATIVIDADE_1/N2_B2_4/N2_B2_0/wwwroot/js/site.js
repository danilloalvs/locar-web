function apagarCategoria(id) {

    swal({
        title: "Tem certeza?",
        text: "A categoria será apagada para sempre!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-info",
        confirmButtonText: "Sim",
        cancelButtonText: "Não!",
        closeOnConfirm: false
    },
        function () {
            location.href = '/categoria/Delete?id=' + id;
        });
}

function apagarCliente(id) {

    swal({
        title: "Tem certeza?",
        text: "O cliente será apagado para sempre!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-info",
        confirmButtonText: "Sim",
        cancelButtonText: "Não!",
        closeOnConfirm: false
    },
        function () {
            location.href = '/cliente/Delete?id=' + id;
        });
}

function apagarDevolucao(id) {

    swal({
        title: "Tem certeza?",
        text: "A devolução será apagada para sempre!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-info",
        confirmButtonText: "Sim",
        cancelButtonText: "Não!",
        closeOnConfirm: false
    },
        function () {
            location.href = '/devolucao/Delete?id=' + id;
        });
}

function apagarEndereco(id) {

    swal({
        title: "Tem certeza?",
        text: "O endereço será apagado para sempre!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-info",
        confirmButtonText: "Sim",
        cancelButtonText: "Não!",
        closeOnConfirm: false
    },
        function () {
            location.href = '/endereco/Delete?id=' + id;
        });
}

function apagarLocacao(id) {

    swal({
        title: "Tem certeza?",
        text: "A locação será apagada para sempre!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-info",
        confirmButtonText: "Sim",
        cancelButtonText: "Não!",
        closeOnConfirm: false
    },
        function () {
            location.href = '/locacao/Delete?id=' + id;
        });
}

function apagarVeiculo(id) {

    swal({
        title: "Tem certeza?",
        text: "O veiculo será apagado para sempre!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-info",
        confirmButtonText: "Sim",
        cancelButtonText: "Não!",
        closeOnConfirm: false
    },
        function () {
            location.href = '/veiculo/Delete?id=' + id;
        });
}

