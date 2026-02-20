function registroCondomino() {

    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const confirmPassword = document.getElementById("confirmPassword").value;
    const terms = document.getElementById("terminos").checked;

    if (!email || !password || !confirmPassword) {
        showMessage("Todos los campos requeridos deben ser completados.", true);
        return;
    }

    if (password !== confirmPassword) {
        showMessage("Las contraseñas no son iguales.", true);
        return;
    }

    if (!terms) {
        showMessage("Debe aceptar los términos para el registro.", true);
        return;
    }

    const data = {
        IdentificationType: document.getElementById("idType").value,
        Identification: document.getElementById("id").value,
        FirstName: document.getElementById("nombre").value,
        LastName: document.getElementById("apellidos").value,
        DateOfBirth: document.getElementById("fechaNacimiento").value,
        BranchNumber: document.getElementById("numeroFilial").value,
        HasBuilding: document.getElementById("tieneConstruccion").checked,
        Email: email,
        Password: password
    };

    fetch("Registro.aspx/RegistrarCondomino", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ elCondomino: data })
    })
        .then(response => response.json())
        .then(result => {
            showMessage(result.d, false);
        })
        .catch(error => {
            showMessage("Server error.", true);
        });
}

function showMessage(msg, isError) {
    const messageDiv = document.getElementById("mensaje");
    messageDiv.style.color = isError ? "red" : "green";
    messageDiv.innerText = msg;
}
