
function autocomplete(form, inp) {

    var currentFocus;
    var arr = GetSearchKeys();

    form.addEventListener("keydown", formKeyDown);

    inp.addEventListener("input", inputInputEvent);

    inp.addEventListener("keydown", inputKeyDown);

    inp.addEventListener("click", inputClick);


    function inputKeyDown(e) {
        var x = document.getElementById(this.id + "autocomplete-list");
        if (x) x = x.getElementsByTagName("div");
        if (e.keyCode == 40) {
            currentFocus++;
            addActive(x);
        } else if (e.keyCode == 38) { //up
            currentFocus--;
            addActive(x);
        }
        else if (e.keyCode == 13) {
            e.preventDefault();
            if (currentFocus > -1) {
                if (x) x[currentFocus].click();
            }

            this.form.submit();
        }
    }

    function inputInputEvent(e) {
       
        var a, b, i, val = this.value;
        closeAllLists();
        currentFocus = -1;
        a = document.createElement("DIV");
        a.setAttribute("id", this.id + "autocomplete-list");
        a.setAttribute("class", "autocomplete-items");
        this.parentNode.appendChild(a);
      

        if (!val) {
            for (i = 0; i < arr.length; i++) {
                b = document.createElement("DIV");
                b.innerHTML += arr[i].substr(val.length);
                b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
                b.addEventListener("click", function (e) {
                    inp.value = this.getElementsByTagName("input")[0].value;
                    closeAllLists();
                });
                a.appendChild(b);
            }
        }
        else {
            for (i = 0; i < arr.length; i++) {
                if (arr[i].substr(0, val.length).toUpperCase() == val.toUpperCase()) {
                    b = document.createElement("DIV");
                    b.innerHTML = "<strong>" + arr[i].substr(0, val.length) + "</strong>";
                    b.innerHTML += arr[i].substr(val.length);
                    b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
                    b.addEventListener("click", function (e) {
                        inp.value = this.getElementsByTagName("input")[0].value;
                        closeAllLists();
                    });
                    a.appendChild(b);
                }
            }
        }
    }

    function formKeyDown(e) {

        if (e.keyCode == 13) {
            if (!inp.value) return;
            AddLocalSearches(inp.value);

        }
    }

    function AddLocalSearches(value) {
        if (!value) return;
        var localValues = localStorage.getItem("searchKeys");
        if (!localValues) {
            localStorage.setItem("searchKeys", value);
        }
        else {
            var localSearchesArray = localValues.split("{~}");
            var newLocalStorage = value;
            var b, limit = 4;
            for (b = 0; b < limit && b < localSearchesArray.length; b++) {
                if (localSearchesArray[b].toUpperCase() != value.toUpperCase())
                    newLocalStorage += "{~}" + localSearchesArray[b];
                else
                    limit = 5;
            }
            localStorage.setItem("searchKeys", newLocalStorage);
        }
    }

    function GetSearchKeys() {
        var localValues = localStorage.getItem("searchKeys");
        return localValues.split("{~}");
    }

    function addActive(x) {
        if (!x) return false;
        removeActive(x);
        if (currentFocus >= x.length) currentFocus = 0;
        if (currentFocus < 0) currentFocus = (x.length - 1);
        x[currentFocus].classList.add("autocomplete-active");
    }

    function removeActive(x) {
        for (var i = 0; i < x.length; i++) {
            x[i].classList.remove("autocomplete-active");
        }
    }

    function closeAllLists(elmnt) {
        var x = document.getElementsByClassName("autocomplete-items");
        for (var i = 0; i < x.length; i++) {
            if (elmnt != x[i] && elmnt != inp) {
                x[i].parentNode.removeChild(x[i]);
            }
        }
    }

    document.addEventListener("click", function (e) {
        closeAllLists(e.target);
    });

    function inputClick(e) {
        var a, b, i, val = this.value;
        closeAllLists();
        currentFocus = -1;
        a = document.createElement("DIV");
        a.setAttribute("id", this.id + "autocomplete-list");
        a.setAttribute("class", "autocomplete-items");
        this.parentNode.appendChild(a);

        if (!val) {
            for (i = 0; i < arr.length; i++) {
                b = document.createElement("DIV");
                b.innerHTML += arr[i].substr(val.length);
                b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
                b.addEventListener("click", function (e) {
                    inp.value = this.getElementsByTagName("input")[0].value;
                    closeAllLists();
                });
                a.appendChild(b);
            }
        }
        else {

            for (i = 0; i < arr.length; i++) {
                if (arr[i].substr(0, val.length).toUpperCase() == val.toUpperCase()) {
                    b = document.createElement("DIV");
                    b.innerHTML = "<strong>" + arr[i].substr(0, val.length) + "</strong>";
                    b.innerHTML += arr[i].substr(val.length);
                    b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
                    b.addEventListener("click", function (e) {
                        inp.value = this.getElementsByTagName("input")[0].value;
                        closeAllLists();
                    });
                    a.appendChild(b);
                }
            }
        }
    }
}

