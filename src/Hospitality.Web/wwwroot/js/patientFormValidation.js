'use strict';
const form = document.getElementById("patientForm"); 
//const nameInput = form.getElementById("nameLabel").value;
//const surnameInput = form.getElementById("surnameLabel").value;
//const peselInput = form.getElementById("peselLabel").value;
//const dateOfBirthInput = form.getElementById("dateOfBirthLabel").value;
//const addressInput = form.getElementById("addressLabel").value;
const emailInput = document.getElementById('Email');
const phoneNumberInput = form.getElementById("phoneNumberLabel").value;
const sendButton = document.getElementById('saveButton');
const modalForm = document.getElementById("exampleModal");


// poprzednia próba: 

sendButton.addEventListener("click", e => {
    console.log("Inside");
    const regEmail = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,3}$/gi;
    const regPhoneNumber = /^([0-9]{3}[-\s]?){3}$/g;
    const regPesel = /^[0-9]{11}$/g;

    const isCorrectEmail = regEmail.test(emailInput.value.trim());
    //const isCorrectPhoneNumber = regPhoneNumber.test(phoneInput.value.trim());
    //const isCorrectPesel = regPesel.test(regInput.value.trim());
    const errorMessage = modalForm.querySelector(".errorMessage");
    if (!isCorrectEmail) {
        e.preventDefault();
        errorMessage.innerHTML = "Wrong format of email.";
    }

    else {
        errorMessage.innerHTML = "Wrong format of input";
    }
});

emailInput.addEventListener("input", () => {
    const regEmail = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,3}$/gi;
    var isCorrectEmail = regEmail.test(emailInput.value.trim());

    if (!isCorrectEmail && emailInput.value != "") {
        emailInput.style.color = "red";
    } else {
        emailInput.style.outline = "1px black";
        emailInput.style.border = "1px solid black";
    }
});
