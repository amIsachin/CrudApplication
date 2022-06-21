var swiper = new Swiper(".mySwiper", {
    slidesPerView: 1,
    spaceBetween: 30,
    autoplay:{
        delay: 2500,
        disableOnInteration:false
    },
    pagination: {
      el: ".swiper-pagination",
      clickable: true,
    },
  });

  var swiper = new Swiper(".course-swiper", {
    slidesPerView: 4,
    spaceBetween: 30,
    autoplay:{
      delay: 10000,
      disableOnInteration:false
    },
    pagination: {
      el: ".swiper-pagination",
      clickable: true
    }
  });