function OpenLetreros(tipo, letrero) {
    Swal.fire({
        customClass: {
            confirmButton: 'swalBtnColor',
        },
        icon: tipo,
        title: letrero,
        color: '#FFF',
        showConfirmButton: true,
        background: 'rgba(250, 215, 160 , 0.8)',
        backdrop: `      rgba(0,0,0,0.7)
                                    left top
                                    no-repeat`,
        allowOutsideClick: false,
        confirmButtonColor: 'rgb(29 ,75, 14)',
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    })
}


$(document).ready(function () {
    $("input[name=radioName]").click(function () {
        if ($('input:radio[name=radioName]:checked').val() === 'm') {
            $('#<%=txtSuperficieRu.ClientID%>').mask("000000000.00");
        } else {
            $('#<%=txtSuperficieRu.ClientID%>').mask("000-000-000.00");
        }
    });
});



