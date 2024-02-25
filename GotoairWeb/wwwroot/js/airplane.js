var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/airplane/getall' },
        "columns": [
            { data: 'serialNumber', width: '20%' },
            { data: 'airplaneModel.name', width: '25%' },
            { data: 'dateOfManufacture', width: '15%' },
            { data: 'airplaneState.name', width: '25%' },
            {
                data: 'id',
                render: function (data) {
                    return `<div class="text-center">
                        <div class="btn-group" role="group">
                            <a href="/admin/airplane/upsert?id=${data}" class="btn btn-primary m-1"> <i class="bi bi-pencil-square"></i></a>
                            <a onClick=Delete('/admin/airplane/delete/${data}') class="btn btn-danger m-1"> <i class="bi bi-trash-fill"></i></a>
                        </div>
                    </div>`
                },
                width: '15%'
            }
        ]
    });
}


const swalWithBootstrapButtons = Swal.mixin({
    customClass: {
        confirmButton: "btn btn-danger me-1",
        cancelButton: "btn btn-primary ms-1"
    },
    buttonsStyling: false
});

function Delete(url) {
    swalWithBootstrapButtons.fire({
        title: 'Вы уверены?',
        text: "При удалении данного элемента все данные, связанные с ним, будут также удалены.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: "Удалить",
        cancelButtonText: "Отмена",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'Delete',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}

