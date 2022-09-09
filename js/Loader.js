window.onload = loading();
//document.oncontextmenu = function () { return false }// linea para eliminar clic derecho en la pagina
function loading() {
    $('#onload').fadeOut();
    $('#boddy').removeClass('hidden');
}