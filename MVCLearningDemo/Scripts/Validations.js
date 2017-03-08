function IsFirstNameEmpty() {
    if (document.getElementById('TxtFName').value == "") {
        return "FirstName不能为空";
    } else {
        return "";
    }
}

function IsFirstNameInValid() {
    if (document.getElementById('TxtFName').value.indexOf('@') != -1) {
        return "FirstName不能包含@";
    } else {
        return "";
    }
}

function IsLastNameInValid() {
    if (document.getElementById('TxtLName').value.length > 5) {
        return 'Last Name should not contain more than 5 character';
    } else {
        return "";
    }
}

function IsSalaryEmpty() {
    if (document.getElementById('TxtSalary').value == "") {
        return 'Salary should not be empty';
    } else {
        return "";
    }
}

function IsSalaryInValid() {
    if (isNaN(document.getElementById('TxtSalary').value)) {
        return 'Enter valid salary';
    } else {
        return "";
    }
}

function IsValid() {
    var firstNameEmptyMessage = IsFirstNameEmpty();
    var firstNameInValidMessage = IsFirstNameInValid();
    var lastNameInValidMessage = IsLastNameInValid();
    var salaryEmptyMessage = IsSalaryEmpty();
    var salaryInvalidMessage = IsSalaryInValid();

    var finalErrorMessage = "Errors:";
    if (firstNameEmptyMessage != "")
        finalErrorMessage += "\n" + firstNameEmptyMessage;
    if (firstNameInValidMessage != "")
        finalErrorMessage += "\n" + firstNameInValidMessage;
    if (lastNameInValidMessage != "")
        finalErrorMessage += "\n" + lastNameInValidMessage;
    if (salaryEmptyMessage != "")
        finalErrorMessage += "\n" + salaryEmptyMessage;
    if (salaryInvalidMessage != "")
        finalErrorMessage += "\n" + salaryInvalidMessage;

    if (finalErrorMessage != "Errors:") {
        alert(finalErrorMessage);
        return false;
    }
    else {
        return true;
    }
}