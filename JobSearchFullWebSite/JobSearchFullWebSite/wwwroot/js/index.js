$(document).ready(function () {
  $("#dropdownMenu2").click(function () {
    $(".dropdown-menu").slideToggle();
  });

  // Slick Slider
  $(".responsive").slick({
    dots: true,
    infinite: false,
    speed: 300,
    slidesToShow: 4,
    slidesToScroll: 1,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true,
        },
      },
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
        },
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        },
      },
      // You can unslick at a given breakpoint now by adding:
      // settings: "unslick"
      // instead of a settings object
    ],
  });
  $(".responsiveSlider").slick({
    dots: true,
    infinite: true,
    speed: 300,
    slidesToShow: 1,
    slidesToScroll: 1,
    responsive: [
      // You can unslick at a given breakpoint now by adding:
      // settings: "unslick"
      // instead of a settings object
    ],
  });
});
for (
  let index = 0;
  index < document.getElementsByClassName("work-card-contentP").length;
  index++
) {
  if (
    document.getElementsByClassName("work-card-contentP")[index].scrollHeight >
    100
  ) {
    document.getElementsByClassName("work-card-contentP")[
      index
    ].style.maxHeight = "100px";
    document.getElementsByClassName("work-card-contentP")[
      index
    ].style.paddingRight = "15px";
    document.getElementsByClassName("work-card-contentP")[
      index
    ].style.overflow = "overlay";
  } else {
  }
}

var date = new Date();
document.getElementsByClassName("NowYear")[0].innerHTML = date.getFullYear();

for (
  let index = 0;
  index < document.getElementsByClassName("sponsorItem").length;
  index++
) {
  document.getElementsByClassName("sponsorItem")[index].onmouseover =
    function () {
      for (
        let i = 0;
        i < document.getElementsByClassName("sponsorItem").length;
        i++
      ) {
        if (i != index) {
          document.getElementsByClassName("sponsorItem")[i].style.width =
            "60px";
          document.getElementsByClassName("sponsorItem")[i].style.height =
            "20px";
          document.getElementsByClassName("sponsorItem")[
            i
          ].style.transitionDuration = "0.3s";
        }
      }
    };
  document.getElementsByClassName("sponsorItem")[index].onmouseout =
    function () {
      for (
        let i = 0;
        i < document.getElementsByClassName("sponsorItem").length;
        i++
      ) {
        if (i != index) {
          document.getElementsByClassName("sponsorItem")[i].style.width =
            "100px";
          document.getElementsByClassName("sponsorItem")[i].style.height =
            "30px";
          document.getElementsByClassName("sponsorItem")[
            i
          ].style.transitionDuration = "0.3s";
        }
      }
    };
}

var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
  acc[i].addEventListener("click", function () {
    this.classList.toggle("active");

    var panel = this.nextElementSibling;
    if (panel.style.maxHeight) {
      panel.style.maxHeight = null;
    } else {
      panel.style.maxHeight = panel.scrollHeight + "px";
    }
  });
}

$(document).ready(function () {
  $(".Advanced").click(function () {
    $(".DropdownOnclickAdvanced").fadeToggle("slow");
  });
});
$(document).ready(function () {
  $(".SortBy").click(function () {
    $(".SortingBy").fadeToggle("slow");
  });
});
$(document).ready(function () {
  $(".AllClick").click(function () {
    $(".All").fadeToggle("slow");
  });
});

document.getElementsByClassName("AccountCreatingType")[0].onclick =
  function () {
    this.style.backgroundColor = "green";
    this.style.color = "white";
    document.getElementsByClassName(
      "AccountCreatingType"
    )[1].style.backgroundColor = "#e1f2e5";
    document.getElementsByClassName("AccountCreatingType")[1].style.color =
      "green";
  };
document.getElementsByClassName("AccountCreatingType")[1].onclick =
  function () {
    this.style.backgroundColor = "green";
    this.style.color = "white";
    document.getElementsByClassName(
      "AccountCreatingType"
    )[0].style.backgroundColor = "#e1f2e5";
    document.getElementsByClassName("AccountCreatingType")[0].style.color =
      "green";
  };


