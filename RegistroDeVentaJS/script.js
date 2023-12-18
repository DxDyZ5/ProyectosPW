document.addEventListener("DOMContentLoaded", function () {
    
    cargarDatosLocalStorage();

    document.getElementById("detallesArticulos").addEventListener("input", calcularTotales);

    document.getElementById("pago").addEventListener("input", calcularCambio);

     document.getElementById("facturaForm").addEventListener("submit", function (event) {
        event.preventDefault(); 
        guardarFactura();
    });

    document.querySelector("#facturaForm button.btn-success").addEventListener("submit", function () {
        if (typeof jsPDF !== 'undefined') {
            imprimirRecibo();
        } else {
            console.error('Error: jsPDF no está definido.');
        }
    });

});

function calcularTotales() {
    
    const detallesArticulos = document.querySelectorAll("#detallesArticulos");

    let totalPagar = 0;

    detallesArticulos.forEach((detalle) => {
        const cantidad = parseFloat(detalle.querySelector("[name='cantidad[]']").value) || 0;
        const precio = parseFloat(detalle.querySelector("[name='precio[]']").value) || 0;

        const total = cantidad * precio;
        detalle.querySelector("[name='total[]']").value = total.toFixed(2);

        totalPagar += total;
    });

    
    document.getElementById("totalPagar").value = totalPagar.toFixed(2);

    document.getElementById("pago").value = "";
    document.getElementById("cambio").value = "";
}

function calcularCambio() {
   
    const pago = parseFloat(document.getElementById("pago").value) || 0;
    const totalPagar = parseFloat(document.getElementById("totalPagar").value) || 0;

    const cambio = pago - totalPagar;

    document.getElementById("cambio").value = cambio.toFixed(2);
}

function guardarFactura() {
    
    const formData = new FormData(document.getElementById("facturaForm"));

    const facturaData = {};
    formData.forEach((value, key) => {
        facturaData[key] = value;
    });

    localStorage.setItem("facturaData", JSON.stringify(facturaData));

    alert("Se ha guardado correctamente la factura");
}

function cargarDatosLocalStorage() {
   
    const facturaData = JSON.parse(localStorage.getItem("facturaData"));

    if (facturaData) {
   
        Object.keys(facturaData).forEach((key) => {
            const element = document.querySelector(`[name='${key}']`);
            if (element) {
                element.value = facturaData[key];
            }
        });

        calcularTotales();
    }
}

function imprimirRecibo() {
    const fechaHoraActual = new Date();
    const fechaHoraFormato = fechaHoraActual.toISOString().replace(/[-:]/g, "").split(".")[0];

    const formData = new FormData(document.getElementById("facturaForm"));

    const pdfInstance = new jsPDF();

    pdfInstance.setFont("helvetica");
    pdfInstance.setFontSize(12);

   
    pdfInstance.text("FACTURA", 20, 20);
    pdfInstance.text("Recibida por: Manuel Torres", 20, 30);
    pdfInstance.text("COPYRIGHT@  2023 OFFICIAL", 20, 40);

    pdfInstance.line(20, 45, 190, 45);

    let yOffset = 60;

    formData.forEach((value, key) => {
        pdfInstance.text(`${key}: ${value}`, 20, yOffset);
        yOffset += 10;
    });

    pdfInstance.line(20, yOffset, 190, yOffset);

    const totalPagar = parseFloat(document.getElementById("totalPagar").value) || 0;
    const pago = parseFloat(document.getElementById("pago").value) || 0;
    const cambio = parseFloat(document.getElementById("cambio").value) || 0;

    yOffset += 10; 
    pdfInstance.text(`Total a Pagar: ${totalPagar.toFixed(2)}`, 20, yOffset);
    yOffset += 10;
    pdfInstance.text(`Pago: ${pago.toFixed(2)}`, 20, yOffset);
    yOffset += 10;
    pdfInstance.text(`Cambio: ${cambio.toFixed(2)}`, 20, yOffset);

    pdfInstance.save(`Recibo_de_Venta_${fechaHoraFormato}.pdf`);

    return false;
}