// Hàm hiển thị các ngày trong tuần
function HienThiNgay() {
    alert('k')
    //var myModal = new bootstrap.Modal(document.getElementById('modal-suat-chieu'), {
    //    keyboard: false
    //})
   
    //myModal.show();
    //const daysContainer = document.querySelector(".nav-tabs");
    //const daysOfWeek = ["CN", "T2", "T3", "T4", "T5", "T6", "T7"];
    //const today = new Date();

    //// Làm sạch các tab hiện tại
    //daysContainer.innerHTML = "";

    //// Tạo các thẻ li cho 7 ngày tiếp theo
    //for (let i = 0; i < 7; i++) {
    //    const currentDate = new Date();
    //    currentDate.setDate(today.getDate() + i);

    //    const day = currentDate.getDate().toString().padStart(2, '0');
    //    const month = (currentDate.getMonth() + 1).toString().padStart(2, '0');
    //    const dayOfWeek = daysOfWeek[currentDate.getDay()];

    //    const liElement = `
    //        <li class="nav-item px-1 py-0">
    //            <a class="nav-link time" onclick="hi()" data-bs-toggle="tab" href="#menu${i}" data-day="${currentDate.toISOString().split('T')[0]}">
    //                <span>${day}</span>/${month}-${dayOfWeek}
    //            </a>
    //        </li>
    //    `;
      
    //    daysContainer.innerHTML += liElement;

        
    //}
}
//function hi(){
//    alert('hi')
//}
//const dayLink = daysContainer.querySelector(`a[href="#menu${i}"]`);
//dayLink.addEventListener('click', function (e) {
//    e.preventDefault();
//    alert(`Ngày bạn chọn là: ${day}/${month}`);
//    const selectedDate = this.getAttribute('data-day');  // Lấy ngày từ data-day
//    // Chuyển đổi selectedDate (yyyy-MM-dd) thành các phần ngày, tháng, năm
//    const dateParts = selectedDate.split('-');
//    const year = dateParts[0];
//    const month = dateParts[1];
//    const day = dateParts[2];

//    // Hiển thị ngày, tháng, năm
//    alert(`Ngày bạn chọn là: ${day}/${month}/${year}`);  // Bạn có thể thay đổi cách hiển thị tùy thích

//    const filmId = "123"; // Lấy ID phim tùy chỉnh của bạn
//    loadData(filmId, selectedDate);  // Gọi hàm loadData khi chọn ngày
//});
//// Hàm tải dữ liệu suất chiếu từ server
//function loadData(filmId, selectedDate) {
//    $.ajax({
//        url: '@Url.Action("LayDuLieuSuatChieu", "TrangChu")', // Đảm bảo URL chính xác
//        type: 'GET',
//        data: { id: filmId, date: selectedDate },  // Truyền đúng tham số vào URL
//        success: function (response) {
//            if (response && response.showtimes) {
//                const showTimeContainer = document.getElementById('show-time-container');
//                showTimeContainer.innerHTML = ''; // Làm sạch các suất chiếu hiện tại

//                response.showtimes.forEach(function (showtime) {
//                    const showTimeHTML = `
//                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-5 text-center">
//                            <a class="btn default time-xem">${showtime.time}</a>
//                            <div class="font-smaller padding-top-5">${showtime.availableSeats} ghế trống</div>
//                        </div>
//                    `;
//                    showTimeContainer.innerHTML += showTimeHTML;
//                });
//            } else {
//                const showTimeContainer = document.getElementById('show-time-container');
//                showTimeContainer.innerHTML = '<p>Không có suất chiếu cho ngày này.</p>';
//            }
//        },
//        error: function () {
//            const showTimeContainer = document.getElementById('show-time-container');
//            showTimeContainer.innerHTML = '<p>Đã có lỗi xảy ra khi tải thông tin.</p>';
//        }
//    });
//}
