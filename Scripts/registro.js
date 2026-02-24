function validateForm() {

    let isValid = true;

    function checkField(id, errorId, message) {
        let value = document.getElementById(id).value;
        let errorSpan = document.getElementById(errorId);

        if (!value) {
            errorSpan.innerText = message;
            isValid = false;
        } else {
            errorSpan.innerText = "";
        }
    }

    checkField("idTipo", "errorIdType", "Seleccione Tipo de identificación");
    checkField("id", "errorId", "Identificación requerida");
    checkField("nombre", "errorNombre", "Nombre requerido");
    checkField("apellidos", "errorApellidos", "Apellidos requerido");
    checkField("fechaNacimiento", "errorFechaNacimiento", "Fecha de nacimiento requerida");
    checkField("numeroFilial", "errorNumeroFilial", "Número filial requerido");
    checkField("tieneConstruccion", "errorTieneConstruccion", "Seleccione tiene construcción?");
    checkField("email", "errorEmail", "Email requerido");
    checkField("password", "errorPassword", "Password requerida");
    checkField("confirmPassword", "errorConfirmarPassword", "Confirmar contraseña");
    checkField("rol", "errorRol", "Seleccione el rol");

    if (document.getElementById("password").value !==
        document.getElementById("confirmPassword").value) {

        document.getElementById("errorConfirmarPassword").innerText =
            "Contraseñas no son iguales";
        isValid = false;
    }

    if (!document.getElementById("terminos").checked) {
        document.getElementById("errorTerminos").innerText =
            "Para completar el registro debe aceptar los términos.";
        isValid = false;
    } else {
        document.getElementById("errorTerminos").innerText = "";
    }

    return isValid;
}

function registroCondomino() {

    if (!validateForm()) {
        return; //No realiza almacenamiento
    }

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


    const tieneConstruccionValue = document.getElementById("tieneConstruccion").value;

    const rolValue = document.getElementById("rol").value;

    if (!rolValue) {
        showMessage("Debe seleccionar un rol.", true);
        return;
    }


    const data = {
        idTipo: document.getElementById("idTipo").value,
        id: document.getElementById("id").value,
        nombre: document.getElementById("nombre").value,
        apellidos: document.getElementById("apellidos").value,
        fechaNacimiento: document.getElementById("fechaNacimiento").value,
        numeroFilial: document.getElementById("numeroFilial").value,
        tieneConstruccion: tieneConstruccionValue === "true",
        email: email,
        password: password,
        rol: document.getElementById("rol").value
    };

    fetch("Registro.aspx/RegistrarCondomino", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        //body: JSON.stringify(data)
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

function login() {

    const email = document.getElementById("loginEmail").value;
    const password = document.getElementById("loginPassword").value;

    const data = {
        email: email,
        password: password
    };

    fetch("Default.aspx/Login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(response => {

            if (response.d.success) {

                // Role is integer now
                if (response.d.tipoUsuario === 1) {
                    window.location.href = "Admin.aspx";
                } else {
                    window.location.href = "Condomino.aspx";
                }

            } else {
                document.getElementById("mensaje").innerText = "Credenciales inválidos";
            }

        });
}