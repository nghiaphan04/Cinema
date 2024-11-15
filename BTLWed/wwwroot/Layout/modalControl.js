var tenPhim;
var phimId;
var ngayChieu;
var gioChieu;
var idPhong;
var loaiPhong;
var tenPhong;
var selectedSeats = []; 
var selectDrink ;


function DongModalTheoId(idModal) {
    var modalInstance = bootstrap.Modal.getInstance(document.getElementById(idModal));
    if (modalInstance) modalInstance.hide();
}

function HienThiMoDalChonSuat(phimIdParam, tenphim) {
    var modalChonSuat = new bootstrap.Modal(document.getElementById('modal-suat-chieu'), {
        keyboard: false
    });

    phimId = phimIdParam;
    tenPhim = tenphim;

    
    


    document.querySelector('.film-name').innerHTML = tenphim;
    modalChonSuat.show();

    HienThiNgay(phimId); 
}

function HienThiNgay() {
    const daysContainer = document.querySelector(".nav-tabs");

    const daysOfWeek = ["CN", "T2", "T3", "T4", "T5", "T6", "T7"];
    const today = new Date();

    daysContainer.innerHTML = "";

    for (let i = 0; i < 7; i++) {
        const currentDate = new Date();
        currentDate.setDate(today.getDate() + i);

        const day = currentDate.getDate().toString().padStart(2, '0');
        const month = (currentDate.getMonth() + 1).toString().padStart(2, '0');
        const year = currentDate.getFullYear().toString();
        const formattedDate = `${year}-${month}-${day}`;
        const dayOfWeek = daysOfWeek[currentDate.getDay()];

        const liElement = `
            <li class="nav-item px-1 py-0">
                <a class="nav-link time" data-bs-toggle="tab" onclick="LaySuatChieu('${formattedDate}', '${phimId}')"
                   href="#menu${i}" data-day="${currentDate.toISOString().split('T')[0]}">
                    <span>${day}</span>/${month}-${dayOfWeek}
                </a>
            </li>
        `;

        daysContainer.innerHTML += liElement;
    }
}

function LaySuatChieu(ngay, id) {
    $.ajax({
        url: '/TrangChu/LayDuLieuSuatChieu',
        type: 'GET',
        data: { id: id, ngay: ngay },
        success: function (response) {
            var showTimeContainer = document.getElementById('suat-chieu');

            if (response && response.showtimes && response.showtimes.length > 0) {
                let html2D = ` <div class="col-md-12" style="margin-bottom:10px;margin-top: 10px;">
                        <span class="font-lg ms-3 bold font-transform-uppercase">2D Phụ đề</span>
                    </div>`;
                let html3D = ` <div class="col-md-12" style="margin-bottom:10px;margin-top: 10px;">
                        <span class="font-lg ms-3 bold font-transform-uppercase">3D Phụ đề</span>
                    </div>`;

                response.showtimes.forEach(function (showtime) {
                    if (showtime.loaiPhong === '2D') {
                        html2D += `
                            <div class="col-lg-2 col-md-2 col-sm-3 col-xs-5 text-center">
                                <a onclick="XacNhanSuatChieu('${showtime.gioChieu}','${showtime.idPhong}', '${showtime.loaiPhong}', '${id}', '${ngay}','${showtime.tenPhong}')"
                                   class="btn default px-5 time-xem">
                                    ${showtime.gioChieu}
                                </a>
                            </div>
                        `;
                    } else if (showtime.loaiPhong === '3D') {
                        html3D += `
                            <div class="col-lg-2 col-md-2 col-sm-3 col-xs-5 text-center">
                                <a onclick="XacNhanSuatChieu('${showtime.gioChieu}','${showtime.idPhong}', '${showtime.loaiPhong}', '${id}', '${ngay}','${showtime.tenPhong}')"
                                   class="btn default px-5 time-xem">
                                    ${showtime.gioChieu}
                                </a>
                            </div>
                        `;
                    }
                });

                showTimeContainer.innerHTML = html2D + html3D;

            } else {
                showTimeContainer.innerHTML = '<p class="ms-4">Không có suất chiếu cho ngày này.</p>';
            }
        },
        error: function () {
            const showTimeContainer = document.getElementById('show-time-container');
            showTimeContainer.innerHTML = '<p>Đã có lỗi xảy ra khi tải thông tin.</p>';
        }
    });
}
function XacNhanSuatChieu(giochieu, idphong,loaiphong , idphim, ngay, tenphong) {
    var modalXacNhan = new bootstrap.Modal(document.getElementById('modal-xac-nhan'), {
        keyboard: false
    });
    gioChieu = giochieu;
    loaiPhong = loaiphong;
    idPhong = idphong;
    tenPhong = tenphong;
    ngayChieu = ngay;
 

    document.querySelector('.tenphong').innerHTML = tenphong;
    document.querySelector('.ngaychieu').innerHTML = convertDateFormat(ngay);
    document.querySelector('.giochieu').innerHTML = giochieu;

    DongModalTheoId('modal-suat-chieu')

    modalXacNhan.toggle();
}

function convertDateFormat(ngay) {
    var ngayChieu = new Date(ngay);
    var dd = String(ngayChieu.getDate()).padStart(2, '0');
    var mm = String(ngayChieu.getMonth() + 1).padStart(2, '0');
    var yyyy = ngayChieu.getFullYear();
    return dd + '/' + mm + '/' + yyyy;
}

function XacNhanChonGhe() {
    var modalChonGhe = new bootstrap.Modal(document.getElementById('modal-chon-ghe'), {
        keyboard: false
    });
    DongModalTheoId('modal-xac-nhan')
    modalChonGhe.show();
    LayDanhSachGhe()
}
function LayDanhSachGhe() {
    $.ajax({
        url: '/TrangChu/LayDuLieuGhe',
        type: 'GET',
        data: { idPhong: idPhong },
        success: function (response) {
            var soGheMoiHang = 10; 
            var danhSachGhe = [...response.dsGheThuong, ...response.dsGheVip, ...response.dsGheDoi];  
            var soGhe = danhSachGhe.length;
            var soHang = Math.ceil(soGhe / soGheMoiHang);
            var seatContainer = document.getElementById('total-seats');
            var seatHtml = "";
       
            for (var i = 0; i < soHang; i++) {
                var rowHtml = `<div class="full_width d-flex justify-content-center align-content-center">`;
                var rowClass = "border-primary seat mx-4 ";

                if (i < 5) {
                    rowClass = "border-success seat mx-4 "; 
                }

                var doubleSeatHtml = "";  

                for (var j = 0; j < soGheMoiHang; j++) {
                    var gheIndex = i * soGheMoiHang + j;

                    if (gheIndex < soGhe) {
                        var ghe = danhSachGhe[gheIndex];
                        var colorClass = "btn-light"; 
                        var disabledAttr = ""; 
                        if (ghe.trangThai === 'da_dat') {
                            colorClass = "btn-danger"; 
                            disabledAttr = "disabled"; 
                        }

                        if (ghe.loaiGhe === "Đôi") {
                            if (j % 2 === 0) {
                                doubleSeatHtml += `<div class="seats">
                        <input ${disabledAttr} onclick="XuLiClickChonCho(this)" class="border-danger btn my-2 mx-5 border-2 ${colorClass}  double-seat" type="button" value="${ghe.soGhe},${danhSachGhe[gheIndex + 1].soGhe} " }>
                    </div>`;
                                j++;
                               
                            }
                        } else {
                            
                            rowHtml += `<div class="seats">
                    <input class="seat btn my-2 border-2 ${rowClass} ${colorClass}" onclick="XuLiClickChonCho(this)" type="button" value="${ghe.soGhe}" ${disabledAttr}>
                </div>`;
                        }
                    } else {
                        break;
                    }
                }

                rowHtml += doubleSeatHtml;

                rowHtml += `</div>`;
                seatHtml += rowHtml;
            }

            seatContainer.innerHTML = seatHtml;

        },
        error: function () {
            console.error("Error loading seats data");
        }
    });
}



function XuLiClickChonCho(btn) {
    
    if (btn.disabled) return;

    btn.classList.toggle('seat-selected');

    var gheValue = btn.value;

    if (btn.classList.contains('seat-selected')) {
        selectedSeats.push(gheValue);
    } else {
        var index = selectedSeats.indexOf(gheValue);
        if (index !== -1) {
            selectedSeats.splice(index, 1);
        }
    }

    document.getElementById('selectedSeatsList').innerText = selectedSeats.join(', ');
}


function HienThiModalCombo() {
    var modalCombo = new bootstrap.Modal(document.getElementById('modal-chon-combo'), {
        keyboard: false
    });

    DongModalTheoId('modal-chon-ghe')

    modalCombo.show();
    LayDuLieuDoUong()
}

function LayDuLieuDoUong() {
    $.ajax({
        url: '/TrangChu/LayDuLieuDoUong',
        type: 'GET',
        data: { idPhong: idPhong },
        success: function (response) {

            var danhSachDoUong = response.dsDoUong;
            var html = '';

            danhSachDoUong.forEach(function (doUong, index) {
                html += `
                    <tr>
                        <td>${index + 1}</td>
                        <td>${doUong.ten}</td>
                        <td>${doUong.gia}</td>
                        <td><input type="number" min="0" max="100" value="0" step="1" class="so-luong" 
                                   data-gia="${doUong.gia}" data-id="${doUong.id}" data-ten="${doUong.ten}"></td>
                    </tr>
                `;
            });

            document.getElementById('danh-sach-do-uong').innerHTML = html;
            var soLuongInputs = document.querySelectorAll('.so-luong');
            soLuongInputs.forEach(function (input) {
                input.addEventListener('change', function () {
                    capNhatTongTien(soLuongInputs);
                });
            });

            capNhatTongTien(soLuongInputs);
        },

        error: function () {
            console.error("Error loading drinks data");
        }
    });
}

function capNhatTongTien(soLuongInputs) {
    var tongTien = 0;
    selectDrink = [];

    soLuongInputs.forEach(function (input) {
        var soLuong = parseInt(input.value) || 0;
        var gia = parseInt(input.getAttribute('data-gia'));
        var drinkId = input.getAttribute('data-id');
        var drinkName = input.getAttribute('data-ten'); // Retrieve the drink name

        if (soLuong > 0) {
            selectDrink.push({ id: drinkId, name: drinkName, quantity: soLuong }); // Include the name in selectDrink
        }

        tongTien += soLuong * gia;
    });

    document.getElementById('total-drink').innerText = tongTien.toLocaleString() + ' VND';
}



function HienThiModalThanhToan(){
    var modalThanhToan = new bootstrap.Modal(document.getElementById('modal-thanh-toan'), {
        keyboard: false
    });
    DongModalTheoId('modal-chon-combo')
    modalThanhToan.show();
    console.log("Thông tin thanh toán:");
    console.log("Phim ID:", phimId);
    console.log("Tên phim:", tenPhim);
    console.log("Ngày chiếu:", convertDateFormat(ngayChieu));
    console.log("Giờ chiếu:", gioChieu);
    console.log("ID phòng:", idPhong);
    console.log("Loại phòng:", loaiPhong);
    console.log("Tên phòng:", tenPhong);
    console.log("Ghế đã chọn:", selectedSeats.join(', '));
    console.log("Đồ uống đã chọn:", selectDrink);
}

