let form = document.getElementById("appointForm");
let peselTextBoxFor = document.getElementById("peselTextBoxFor");
let specialistDropDownList = document.getElementById("specialistDropDownList");
let modalForm = document.getElementById("exampleModal2");

let sendButton = document.querySelector('#sendButton');


sendButton.addEventListener("click", e => {
    console.log("Inside");

    let regPesel = /^[1-9][0-9]{10}$/g;

    console.log(peselTextBoxFor.value);
    console.log(specialistDropDownList.value);
    
    let isCorrectPesel = regPesel.test(peselTextBoxFor.value);



    let informationMessage = modalForm.querySelector(".informationMessage");
    if (!isCorrectPesel) {
        e.preventDefault();
        informationMessage.innerHTML = "Pesel shoud has 11 numbers";
    } else if (specialistDropDownList.value == "none") {
        informationMessage.innerHTML = "Select specialist";
        e.preventDefault();
    } else {
        modalForm.style.visibility = 'hidden';
    }
});


function clearTextBoxFor() {
    peselTextBoxFor.value = "";
    specialistTextBoxFor.value = "none";
}



