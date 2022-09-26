/*
 * | Autor: Ing. Maria de Lourdes Sosa Cruz
clase js que realiza la interaccion del loader de la pagina  
*/
window.onload = loading();//document.oncontextmenu = function () { return false }// linea para eliminar clic derecho en la pagina
function loading() {
   $('#onload').fadeOut();
  //  $('#boddy').removeClass('hidden');
    $('#body').find('hidden').style.zIndex = -1000;
}