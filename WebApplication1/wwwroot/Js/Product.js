count = 0;
bagProduct = [];
catagories = [];
bool = false;

function drowProduct(product) {
    temp = document.getElementById("temp-card");
    var cloneProduct = temp.content.cloneNode(true);
    cloneProduct.querySelector(".price").innerHTML = product.price + "₪";
    cloneProduct.querySelector(".description").innerHTML = product.description;
    var img = cloneProduct.querySelector(".img-w");
    img.src = "./Images/" + product.imageName;
    img.addEventListener("mouseover", () => {
        if (img.src == "https://localhost:44383/Images/over/" + product.imageName)
            img.src = "./Images/" + product.imageName;
        else
            img.src = "./Images/over/" + product.imageName;
    })
    cloneProduct.querySelector("button").addEventListener("click", () => {
        addProductToBag(product);
    })
    document.getElementById("ProductList").appendChild(cloneProduct);
}

function getAllProduct() {
    fetch("api/Product").then(response => {
        return response.json();
    })
        .then(data => {
            if (data != null) {
                count = document.getElementById("counter");
                count.innerHTML = data.length;
                data.forEach(product => drowProduct(product));
            }
            else
                alert("שגיאה בהזנת הנתונים")
        })
}

function drowCatagory(catagory) {
    temp = document.getElementById("temp-category");
    var cloneCatagory = temp.content.cloneNode(true);
    cloneCatagory.querySelector(".OptionName").innerHTML = catagory.categoryName;
    var check = cloneCatagory.querySelector(".opt");
    check.addEventListener("click", () => {
        if (check.checked) {
            if (!bool) {
                document.getElementById("ProductList").innerHTML = "";
                document.getElementById("counter").textContent = 0;
                getProdactByCatagoryId(catagory.categoryId);
                bool = true;
            }
            else {
                bool = false;
                getProdactByCatagoryId(catagory.categoryId);
            }
        }
        else {
            count = document.getElementById("counter");
            count.innerHTML = "";
            document.getElementById("ProductList").innerHTML = "";
            getAllProduct();
        }
    })
    document.getElementById("filters").appendChild(cloneCatagory);
}

function getAllCatagory() {
    fetch("api/Catagory").then(response => {
        return response.json();
    })
        .then(data => {
            if (data != null) {
                data.forEach(catagory => drowCatagory(catagory));
            }
            else
                alert("שגיאה בהזנת הנתונים")
        })
}

function addProductToBag(product) {
    exist = 0;
    tempArr = [];
    oldBag = sessionStorage.getItem('bagProduct');
    if (bagProduct.length == 0 && oldBag != null) {
        bagProduct = JSON.parse(oldBag);
    }
    for (var i = 0; i < bagProduct.length; i++) {
        if (bagProduct[i][0].productId == product.productId) {
            bagProduct[i][1] = bagProduct[i][1] + 1;
            exist = 1;
        }
    }
    if (exist == 0) {
        tempArr[0] = product;
        tempArr[1] = 1;
        bagProduct.push(tempArr);
    }

    sessionStorage.setItem('bagProduct', JSON.stringify(bagProduct));
    document.getElementById("ItemsCountText").innerText = bagProduct.length;
    count++;
    sessionStorage.setItem("Count", count);
}

function getProdactByCatagoryId(catagoryId) {
        fetch("api/product/" + catagoryId)
        .then(response => {
        if (response.status == 204)
            alert("שגיאה בהזנת הנתונים");
        else if (response.ok)
            return response.json();
        }).then((products) => {
            count2 = document.getElementById("counter");
            count2.textContent = count2.textContent * 1 + products.length;
        for (p in products) {
            drowProduct(products[p]);
        }

    }).catch(err => console.log(err));
}

function getPage() {
    getAllProduct();
    getAllCatagory();

    listProd = JSON.parse(sessionStorage.getItem('bagProduct'));
    if (listProd != null) {
        document.getElementById("ItemsCountText").textContent = listProd.length;
    }
    else {
        document.getElementById("ItemsCountText").textContent = 0;
    }

}