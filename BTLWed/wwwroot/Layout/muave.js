document.addEventListener("DOMContentLoaded", function () {
    const times = document.querySelectorAll('.time');
    const showTime = document.querySelector('.show-time');
    

    for (var time of times) {
        time.addEventListener('click', function () {
           
            if (showTime) {       
                showTime.classList.add('row'); 
            }

        });
    }

    var seats = document.querySelectorAll('.seat');
    for (let s of seats){
        s.addEventListener('click', function () {
            s.classList.toggle('seat-selected')   
        });

        
    }

    var seatPrice = 50; // Giá ti?n cho m?i gh?
    var selectedSeats = []; // Danh sách các gh? ?ã ch?n
    var selectedSeatsList = document.getElementById('selectedSeatsList');


    for (var i = 0; i < seats.length; ++i) {
        seats[i].onclick = function (e) {//id gh?
          
            var seatId = e.target.value;//truy cap sk dang continue truy cap or gan
            if (!selectedSeats.includes(seatId)) {
                selectedSeats.push(seatId);
            } else {
                selectedSeats.splice(selectedSeats.indexOf(seatId), 1);//loaiboi xdvitri
            }
            updateTotal(); // C?p nh?t t?ng ti?n sau m?i l?n thay ??i gh?
        };
    }

    function updateTotal() {
        var total = selectedSeats.length * seatPrice;
        var totalAmountElement = document.getElementById('totalAmount');
        totalAmountElement.textContent = total.toFixed(3);
        //var ganx = document.getElementById('ra-di');
        //ganx.textContent = 'T?ng s? ti?n vé: ' + total.toFixed(3)
       
        updateSelectedSeatsList();
    }

 

    function updateSelectedSeatsList() {
        selectedSeatsList.innerHTML = '' 
        //var xx = document.getElementById('chair-x')
        //xx.textContent = ''; // Xóa n?i dung hi?n t?i trên gh? "xx"

        if (selectedSeats.length > 0) {
            var seatItems = document.createElement('div')
            var congptucacghe = ''

            for (var i = 0; i < selectedSeats.length; i++) {
                congptucacghe += selectedSeats[i] + "  "
            }

            //seatItems.textContent = congptucacghe
            //selectedSeatsList.appendChild(seatItems)//hien thi ten ghe
            /*xx.textContent = congptucacghe*/
            selectedSeatsList.textContent = congptucacghe
        }
    }

    const count = (number) => {
        var num = document.getElementById('soluong' + number)
        var adD = document.getElementById('add' + number)
        var suB = document.getElementById('sub' + number)
        var cnt = 0

        const them = () => {
            cnt++
            num.textContent = cnt
            pay()
        }

        const giam = () => {
            if (cnt > 0) {
                cnt--
                num.textContent = cnt
                pay()
            }
        }

        adD.addEventListener('click', them)
        suB.addEventListener('click', giam)
    }

    count(1);
    count(2);
    count(3);
    var pay = () => {
        var tien = document.getElementById('money');
        var tien_o = document.getElementById('tien-bong')
        var soLuong1 = parseInt(document.getElementById('soluong1').textContent)
        var soLuong2 = parseInt(document.getElementById('soluong2').textContent)
        var soLuong3 = parseInt(document.getElementById('soluong3').textContent)
        var money = soLuong1 * 69 + soLuong2 * 99 + soLuong3 * 139
        tien.textContent = 'T?ng s? ti?n b?ng và n??c là: ' + money.toFixed(3)
        tien_o.textContent = 'T?ng s? ti?n b?ng và n??c là: ' + money.toFixed(3)
        tien.style.fontSize = '20px'
        tien.style.padding = '30px 0 0 20px'
        return money;
    }
    var buyss = document.querySelectorAll('.vemua')
    var jsContainer = document.querySelector('.js-container-x')
    function bongnuoc() {
        jsContainer.classList.add('open')
    }
    for (var buy of buyss) {
        buy.addEventListener('click', bongnuoc)
    }
    var closeicon3 = document.querySelector('.back-x')
    closeicon3.addEventListener('click', function () {
        jsContainer.classList.remove('open')
    })

  

    function ganClick(event) {
        const clickLink = event.target;
        const data = clickLink.textContent;

        const ngay_chieu = document.getElementById('ngaychieu');
        ngay_chieu.innerText = data;
    }

    for (var link of links) {
        link.addEventListener('click', ganClick);
    }
    function gantime(value) {
        //truy cap gia tri
        const timeClick = value.target
        //lay toan bo gia tri nhu chuoi
        const dataTime = timeClick.textContent

        const gio_chieu = document.getElementById('giochieu')
        //gan gia tr
        gio_chieu.innerText = dataTime
    }
    for (var timexem of timeXems) {
        timexem.addEventListener('click', gantime)
    }
});
