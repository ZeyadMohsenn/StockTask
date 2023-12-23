$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);
        var storeId = btn.data('store-id');
        const swal = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-danger mx-2",
                cancelButton: "btn btn-success"
            },
            buttonsStyling: false
        });

        swal.fire({
            title: "Are you sure that you want to delete this store?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Stores/Delete/${storeId}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire({
                            title: "Deleted!",
                            text: "Store has been deleted.",
                            icon: "success"
                        });
                        btn.parents('tr').fadeOut();

                    },

                    error: function () {
                        swal.fire({
                            title: "Oops!",
                            text: "Something went wrong.",
                            icon: "error"
                        });
                    }
                });
            }
        });
    });
});
