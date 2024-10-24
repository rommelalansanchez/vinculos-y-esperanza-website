(function () {
  "use strict";
  const enviarMensaje = () => {
    document.querySelector(".loading").classList.add("d-block");
    document.querySelector(".error-message").classList.remove("d-block");
    document.querySelector(".sent-message").classList.remove("d-block");

    const nombre = document.getElementById("name-field").value;
    const correo = document.getElementById("email-field").value;
    const telefono = document.getElementById("phone-field").value;
    const asunto = document.getElementById("subject-field").value;
    const mensaje = document.getElementById("message-field").value;

    // Your JSON data
    const jsonData = {
      Nombre: nombre,
      Correo: correo,
      Telefono: telefono,
      Asunto: asunto,
      Mensaje: mensaje,
    };

    const options = {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(jsonData),
    };
    var url = "api/ContactoTrigger";
    fetch(url, options)
      .then((response) => {
        if (!response.ok) {
          throw new Error("Ocurrió un error al enviar.");
        }
        return response.json();
      })
      .then((data) => {
        document.querySelector(".loading").classList.remove("d-block");
        if (data.success) {
          document.querySelector(".sent-message").classList.add("d-block");
        } else {
          throw new Error(
            data.Message ? data.Message : "Form submission failed."
          );
        }
      })
      .catch((error) => {
        console.error("Fetch error:", error);
      });
  };

  let formRes = document.getElementById("forma-contacto");
  formRes.addEventListener("submit", (e) => {
    e.preventDefault();

    enviarMensaje();
  });
})();
