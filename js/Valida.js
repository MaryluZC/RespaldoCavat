function onlyNumbers(evt) {
    // code is the decimal ASCII representation of the pressed key.
    var code = (evt.which) ? evt.which : evt.keyCode;

    if (code == 8) { // backspace.
        return true;
    } else if (code >= 48 && code <= 57) { // is a number.
        return true;
    } else { // other keys.
        return false;
    }
}

function onlyletters(evt) {
    // code is the decimal ASCII representation of the pressed key.
    var code = (evt.which) ? evt.which : evt.keyCode;
    if (code == 8||code==32 ) { // backspace.
        return true;
    }
    else if ( (code >= 65 && code <= 90) || (code >= 97 && code <= 122)) { // is a letter.
        return true;
    } else { // other keys.
        return false;
    }
}