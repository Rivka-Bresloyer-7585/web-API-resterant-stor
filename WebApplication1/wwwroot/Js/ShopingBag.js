bag = [];
orderItems = [];
sum = 0;

function showShopBag() {
    bag = JSON.parse(sessionStorage.getItem('bagProduct'));
    document.getElementById("itemCount").innerHTML = bag.length;
    bag.forEach((p) => {
        sum += p[0].price * p[1];
        drawOrdItem(p);
    });
    document.getElementById("totalAmount").innerHTML = sum;
}

function drawOrdItem(product) {
    temp = document.getElementById("temp-row");
    var cloneProduct = temp.content.cloneNode(true);
    cloneProduct.querySelector(".image").style.backgroundImage = "url(images/" + product[0].imageName + ")";
    cloneProduct.querySelector(".itemName").innerHTML = product[0].productName;
    cloneProduct.querySelector(".price").innerHTML = product[0].price;
    cloneProduct.querySelector(".onStack").innerHTML = product[1];
    cloneProduct.getElementById("deleteItem").addEventListener("click", () => { removeProduct(product) });
    document.querySelector("tbody").appendChild(cloneProduct);
}



function removeProduct(product) {
    flag = 0;
    if (product[1] > 1) {
        bag.forEach(prod => {
            if (prod[0].productId == product[0].productId && !flag) {
                prod[1] = prod[1] - 1;
                flag = 1;
            }
        })
    }
    else {
        bag = bag.filter(p => p[0].productId != product[0].productId);
    }
    sessionStorage.setItem('bagProduct', JSON.stringify(bag));
    document.querySelector("tbody").innerHTML = "";
    sum = 0;
    showShopBag();
}

function placeOrder() {
    bag.forEach((item) => {
        let orderItem = {
            ProductId: item[0].productId,
            Quantity: item[1],
            Product:item[0]
        };
        orderItems.push(orderItem);
    })
    let User = JSON.parse(sessionStorage.getItem('user'));
    let order = {
        OrderDate: new Date(),
        OrderSum: sum,
        UserId: User.userId,
        OrderItem: orderItems
    };

    fetch("api/Orders", {
        method:"POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(order),
    }).then(response => {
        if (response.ok) {
            alert(' לקוח ' + order.UserId + ' הזמנתך בוצעה בהצלחה' + ' עליך לשלם: ' + order.OrderSum + '₪');
        }
        else {
            alert('תקלה בביצוע ההזמנה');
        }
    }).catch(error => { alert(error); });

}

showShopBag();
