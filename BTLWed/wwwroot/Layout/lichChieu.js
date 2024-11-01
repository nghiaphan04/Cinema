

document.addEventListener("DOMContentLoaded", function () {
    var haNoi = document.querySelector(".hanoi");
    var haNoiList = document.querySelector(".list-rap-hanoi");
    var daNang = document.querySelector(".danang");
    var daNangList = document.querySelector(".list-rap-danang");
    var ngheAn = document.querySelector(".nghean");
    var ngheAnList = document.querySelector(".list-rap-nghean");
    var haTinh = document.querySelector(".hatinh");
    var haTinhList = document.querySelector(".list-rap-hatinh");
    var thaiBinh = document.querySelector(".thaibinh");
    var thaiBinhList = document.querySelector(".list-rap-thaibinh");
    var bacGiang = document.querySelector(".bacgiang");
    var bacGiangList = document.querySelector(".list-rap-bacgiang");
    var vinhPhuc = document.querySelector(".vinhphuc");
    var vinhPhucList = document.querySelector(".list-rap-vinhPhuc");
    var canhBao = document.querySelector(".canh-bao")
    haNoiList.style.display = "none";
    daNangList.style.display = "none";
    ngheAnList.style.display = "none";
    haTinhList.style.display = "none"

    haNoi.addEventListener("click", function () {
        daNangList.style.display = "none";
        ngheAnList.style.display = "none";
        canhBao.style.display = "none"
        if (haNoiList.style.display === "block") {
            haNoiList.style.display = "none";
        } else {
            haNoiList.style.display = "block";
        }
    });

    daNang.addEventListener("click", function () {
        haNoiList.style.display = "none";
        ngheAnList.style.display = "none";
        if (daNangList.style.display === "block") {
            daNangList.style.display = "none";
        } else {
            daNangList.style.display = "block";
        }
    });

    ngheAn.addEventListener("click", function () {
        haNoiList.style.display = "none";
        daNangList.style.display = "none";

        if (ngheAnList.style.display === "block") {
            ngheAnList.style.display = "none";
        } else {
            ngheAnList.style.display = "block";
        }
    });
});



// chon rap hien phim
document.addEventListener("DOMContentLoaded", function () {
    const thanhXuan = document.querySelector(".thanh-xuan");
    const thanhXuanCinema = document.querySelector(".thanh-xuan-cinema");
    thanhXuanCinema.classList.add("closed");
    thanhXuan.addEventListener("click", function () {
        if (thanhXuanCinema.classList.contains("closed")) {
            thanhXuanCinema.classList.remove("closed");
        } else {
            thanhXuanCinema.classList.add("closed");
        }
    });


});
$(document).ready(function () {
    $("ul.list_tinh li").click(function () {
        $("ul.list_tinh li").removeClass("selected");
        $(this).addClass("selected");
    });

});
//  slide
const slider = document.querySelector('.slider');
const dots = document.querySelectorAll('.dot');
const cards = document.querySelectorAll('.card');
let currentIndex = 0;
const slidesToShow = 3;

function updateSlider() {
    if (currentIndex < 0) {
        currentIndex = 0;
    }
    if (currentIndex + slidesToShow > cards.length) {
        currentIndex = cards.length - slidesToShow;
    }
    const translateXValue = -currentIndex * (100 / slidesToShow);
    slider.style.transform = `translateX(${translateXValue}%)`;
    dots.forEach((dot) => dot.classList.remove('active'));

    const activeDotIndex = Math.floor(currentIndex / slidesToShow);
    dots[activeDotIndex].classList.add('active');
}


updateSlider();
dots.forEach((dot, index) => {
    dot.addEventListener('click', () => {
        currentIndex = index * slidesToShow;
        updateSlider();
    });
});
