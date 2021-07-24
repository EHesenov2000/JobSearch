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
$(document).ready(function () {

    var acc = document.getElementsByClassName("accordion");
    var i;

    for (i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function () {
            console.log("salam");
            this.classList.toggle("active");

            var panel = this.nextElementSibling;
            if (panel.style.maxHeight) {
                panel.style.maxHeight = null;
            } else {
                panel.style.maxHeight = panel.scrollHeight + "px";
            }
        });
    }
})
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

// for (
//   let index = 0;
//   index < document.getElementsByClassName("UserProfileItem").length;
//   index++
// ) {
//   console.log(index);

//   document.getElementsByClassName("UserProfileItem")[index].onclick =
//     function () {
//       document.getElementsByClassName("UserProfileItem")[
//         index
//       ].style.backgroundColor = "#E8F0FA ";
//       document.getElementsByClassName("UserProfileItem")[index].style.color =
//         "blue ";
//       for (
//         let i = 0;
//         i < document.getElementsByClassName("UserProfileItem").length;
//         i++
//       ) {
//         if (i != index) {
//           document.getElementsByClassName("UserProfileItem")[
//             i
//           ].style.backgroundColor = "white ";
//           document.getElementsByClassName("UserProfileItem")[i].style.color =
//             "grey ";
//         }
//       }
//     };
// }
// anychart.onDocumentReady(function () {
//   // set the data
//   var data = {
//     header: ["Year", "Interest Expense on the Debt, USD bln."],
//     rows: [
//       [2007, 420],
//       [2008, 451],
//       [2009, 430],
//       [2010, 413],
//       [2011, 454],
//       [2012, 359],
//       [2013, 415],
//       [2014, 430],
//       [2015, 402],
//       [2016, 432],
//     ],
//   };

//   // create the chart
//   var chart = anychart.area();

//   // add the data
//   chart.data(data);

//   chart.container("container");
//   chart.draw();
// });
window.onload = function () {
  var chart = new CanvasJS.Chart("chartContainer", {
    animationEnabled: true,
    title: {
      text: "Elman Hasanov Map",
    },
    axisY: {
      title: "Xerite",
      valueFormatString: "#0,,.",
      suffix: "mn",
      stripLines: [
        {
          value: 3366500,
          label: "Ortalama",
        },
      ],
    },
    data: [
      {
        yValueFormatString: "#,### Units",
        xValueFormatString: "YYYY",
        type: "spline",
        dataPoints: [
          { x: new Date(2002, 0), y: 0 },
          { x: new Date(2003, 0), y: 2798000 },
          { x: new Date(2004, 0), y: 3386000 },
          { x: new Date(2005, 0), y: 6944000 },
          { x: new Date(2006, 0), y: 6026000 },
          { x: new Date(2007, 0), y: 2394000 },
          { x: new Date(2008, 0), y: 1872000 },
          { x: new Date(2009, 0), y: 2140000 },
          { x: new Date(2010, 0), y: 7289000 },
          { x: new Date(2011, 0), y: 4830000 },
          { x: new Date(2012, 0), y: 2009000 },
          { x: new Date(2013, 0), y: 2840000 },
          { x: new Date(2014, 0), y: 2396000 },
          { x: new Date(2015, 0), y: 1613000 },
          { x: new Date(2016, 0), y: 2821000 },
          { x: new Date(2017, 0), y: 2000000 },
        ],
      },
    ],
  });
  chart.render();
};

$(".duyme1").click(function () {
  $(".leftSection").attr("class", "col-lg-9 py-5 leftSection");
  $(".sidebar").fadeToggle();
});
