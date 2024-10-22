const get = () => {
  const jsonData = {
    Nombre: "nombre",
    Correo: "correo",
    Telefono: "telefono_interesado",
    FechaEvento: "fecha",
    NumeroPersonas: "personas",
    EventoTipo: "tipoEvento",
    Horario: "horario",
  };

  const options = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(jsonData),
  };

  fetch("api/ContactoTrigger", options)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Ocurrió un error al reservar.");
      }
      return response.json();
    })
    .then((data) => {
      alert(data);
    })
    .catch((error) => {
      console.error("Fetch error:", error);
    });
};

document.addEventListener("DOMContentLoaded", get);
