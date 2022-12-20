
//
/********************* Page Load js ************************/



    function BlazorScrollToId(id) {
        const element = document.getElementById(id);
    if (element instanceof HTMLElement) {
        element.scrollIntoView({
            behavior: "smooth",
            block: "start",
            inline: "nearest"
        });
        }
}

function showError(msg) {
    swal({
        title: "UYARI",
        text: msg,
        icon: "error",
        button: "Tamam"
    });
}
