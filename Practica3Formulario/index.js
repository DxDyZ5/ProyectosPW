

document.addEventListener('DOMContentLoaded', () => {
    const idForm = document.querySelector('#ID');
    const datosForm = document.querySelector('#DATOS');
    const cedulaInput = document.getElementById('cedula');

    

    idForm.addEventListener('submit', async (e) => {
        e.preventDefault();

        const cedula = cedulaInput.value;       
        
        try {
            const response = await fetch(`https://api.digital.gob.do/v3/cedulas/${cedula}/validate`);
            const data = await response.json();

            if (data.valid) {
                 
                document.getElementById('Informacion').removeAttribute('disabled');
                document.getElementById("Validar").setAttribute('disabled', 'true');
                Swal.fire({
                    icon: 'success',
                    title: '¡La cédula ha sido validada con éxito!'
                });
            } else {
                Swal.fire({
                    icon: 'error',
                    title: '¡Cédula no encontrada!',
                    text: 'Verifique la cédula e inténtelo nuevamente'
                });
            }
        } catch (error) {
            console.error('Error al validar la cédula:', error);
        }
    });

    datosForm.addEventListener('submit', async (e) => {
        e.preventDefault();

        const cedula = cedulaInput.value;

       
        const cedulaRegistrada = await verificarCedulaRegistrada(cedula);

        if (cedulaRegistrada) {
            Swal.fire({
                icon: 'error',
                title: '¡Cédula ya registrada!',
                text: 'En el bono de ayuda no se puede registrar más de una vez con el mismo usuario.'
            });

            datosForm.reset();

            document.getElementById('Informacion').setAttribute('disabled', 'true');
            document.getElementById("Validar").removeAttribute('disabled');

            return;
        }

        
        const telefono = document.getElementById('telefono').value;
        const correo = document.getElementById('correo').value;
        const direccion = document.getElementById('direccion').value;
        const estadoCivil = document.getElementById('civil').value;
        const profesion = document.getElementById('profesion').value;
        const motivo = document.getElementById('motivo').value;

        
        const usuario = {
            cedula,
            telefono,
            correo,
            direccion,
            estadoCivil,
            profesion,
            motivo,
        };

        fetch('http://localhost:3000/usuarios', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(usuario),
        })
            .then(response => response.json())
            .then(data => {
                ; 
                  datosForm.reset();
                  window.location.href = 'Recomendaciones.html';                    
            })
            .catch(error => {
                console.error('Error al registrar el usuario:', error);
            });
    });

    async function verificarCedulaRegistrada(cedula) {
        const response = await fetch(`http://localhost:3000/usuarios?cedula=${cedula}`);
        const data = await response.json();
        return data.length > 0;
    }
});




const vista = document.getElementById("datos-button");

vista.addEventListener("click", () => {
    Swal.fire({
        title: 'Presidencia contraseña',
        input: 'password',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: 'Acceder',
        showLoaderOnConfirm: true,
        preConfirm: (password) => {
            return fetch('http://localhost:3000/login')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(response.statusText)
                    }
                    return response.json();
                })
                .then(data => {
                    if (password === data.password) {
                        return Promise.resolve();
                    } else {
                        throw new Error("Contraseña incorrecta");
                    }
                })
                .catch(error => {
                    Swal.showValidationMessage(`${error}`);
                });
        },
        allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => {
        if (result.isConfirmed) {
            window.open( "http://localhost:3000/usuarios",'_blank');
        }
    });
});

