

document.addEventListener('DOMContentLoaded', () => {
    const datosForm = document.querySelector('#DATOS');

    datosForm.addEventListener('submit', async (e) => {
        e.preventDefault();

       
        const data = {};

      
        if (document.getElementById('telefono').value) {
            data.referencia1 = document.getElementById('telefono').value;
        }
        if (document.getElementById('correo').value) {
            data.referencia2 = document.getElementById('correo').value;
        }
        if (document.getElementById('direccion').value) {
            data.referencia3 = document.getElementById('direccion').value;
        }
        if (document.getElementById('direccion2').value) {
            data.referencia4 = document.getElementById('direccion2').value;
        }
        if (document.getElementById('profesion').value) {
            data.referencia5 = document.getElementById('profesion').value;
        }

        
        if (Object.keys(data).length > 0) {
            
            fetch('http://localhost:3000/referencias', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data),
            })
                .then(response => response.json())
                .then(responseData => {
                    
                    console.log('Respuesta del servidor:', responseData);

                    
                    window.location.href = 'index.html'; 
                })
                .catch(error => {
                    console.error('Error al enviar los datos al servidor:', error);
                });
        } else {
            
            window.location.href = 'index.html'; 
        }
    });
});
