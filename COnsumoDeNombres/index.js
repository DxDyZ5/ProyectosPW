const urlApi = 'https://localhost:7117/api/Personajes/ObtenerPersonajes';


async function getData(){
    try{
        const res = await fetch(urlApi);
        const data = await res.json();
        return data;
    } catch (error){
        console.error("error al obtener la data: ", error);
        return [];
    }
}


function DisplayData(data){
    const nameData = document.getElementById("data-Name");
    data.forEach((dato, index) => {
        const dataDiv = document.createElement("div");
        dataDiv.className = "DATA";
        dataDiv.innerHTML = `
            <ul class="SIGNS">
            <li>
            <input type="checkbox"  name="signs" id="name${index}" autocomplete ="signs">
            <label for="name${index}">${dato.nombre} ${dato.apellido}</label>
            <div class="content"> 
            <img class="image" src="${dato.imagen}" alt="${dato.altText}">
            <p>Fecha de nacimiento: ${dato.fechaDeNacimiento}</p>
            <p>Descripción: ${dato.descripcion} </p>
            <p>Habilidad: ${dato.habilidad}</p>   
            </div>
            </li>
            </lu>
        `;
        nameData.appendChild(dataDiv);
    });
}


async function init(){
    const Personajes = await getData();
    DisplayData(Personajes);
}

init();


