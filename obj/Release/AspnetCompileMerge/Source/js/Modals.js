/*
 | Autor: Ing. Maria de Lourdes Sosa Cruz
 clase para la manipulacion de modales del sistema
 */
function OpenModalViewPdf(nombre) {
    $('#ModalViewPFD').modal('show'); // abrir           
    /* $('#docPDF').append("<embed src='Comprobantes/" +nombre + "' type='application/pdf' style='width: 100%; height: 100%; '/>");*/
    var nombreArc = "Comprobantes/" + nombre;
    $('#docPDF').attr('src', nombreArc);
}

function OpenReporteUrbano() {
    $('#modalReporteUrbanos').modal('show'); // abrir
}