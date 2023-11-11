var dataTable;

$(document).ready(function () {
    loadDatatable();
});


function loadDatatable() {

    dataTable = $("#tbCategories").DataTable({
        "ajax": {
            "url": "/admin/category/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "categoryId", "width": "5%" },
            { "data": "name", "width": "50%" },
            { "data": "order", "width": "15%" },
            {
                "data": "categoryId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Category/Edit/${data}" class="btn btn-primary text-white px-1" style="cursor:pointer; width:100px;">
                                    <i class="bi bi-pencil-square"></i> Editar
                                </a>
                                &nbsp;
                                <a onClick=Delete("/Admin/Category/Delete/${data}") class="btn btn-danger text-white px-1" style="cursor:pointer; width:100px;">
                                    <i class="bi bi-trash"></i> Eliminar
                                </a>
                            </div>`;
                },
                "width": "30%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Elementos",
            "infoEmpty": "Mostrando 0 to 0 of 0 Elementos",
            "infoFiltered": "(Filtrado de _MAX_ total Elementos)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Elementos",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"

    });
}

function Delete(url) {
    swal({
        title: "Eliminar Categoría",
        text: "Esta seguro de eliminar esta categoría?",
        type: "warning",
        confirmButtonText: "Si, Eliminar",
        confirmButtonColor: "#DD6B55",
        showCancelButton: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}