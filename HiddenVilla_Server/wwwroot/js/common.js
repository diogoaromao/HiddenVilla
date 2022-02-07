window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Operation Successful');
    } else if (type === "error") {
        toastr.error(message, 'Operation Failed');
    }
}

window.ShowSwal = (type, title, message) => {
    if (type === "success") {
        Swal.fire(
            title,
            message,
            'success'
        );
    } else if (type === "error") {
        Swal.fire(
            title,
            message,
            'error'
        );
    }
}