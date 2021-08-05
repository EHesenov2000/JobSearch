$(document).ready(function () {

    document.getElementsByClassName("AddEducationItem")[0].onclick = function () {
        var a = document.createElement("div");
        var education =
            ` 
                                <div class="CandidateResumeItem">
                                    <input type="hidden" name="CandidateEducationItems[2].Id" value="@item.Id" />
                                    <input type="hidden" name="CandidateEducationItems[2].CandidateId" value="@item.CandidateId" />
                                    <div class="accordion mt-3 border-radius">@item.Title</div>
                                    <div class="panel mt-2">
                                        <p>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Title</span></div>
                                                <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="BEducation Title" name="CandidateEducationItems[2].Title" value="@item.Title"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Academy</span></div>
                                                <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="Education Academy" name="CandidateEducationItems[2].EducationPlace" value="@item.EducationPlace"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Years</span></div>
                                                <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="Years" name="CandidateEducationItems[2].Years" value="@item.Years"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Description</span></div>
                                                <div class="col-lg-9"><input style="min-height: 150px;max-height: 150px;" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="Description" name="CandidateEducationItems[2].Content" value="@item.Content"></div>
                                            </div>
                                            <div class="row">
                                                <div class="d-flex flex-row justify-content-end RemoveItem"><div class="btn backColorBlue py-2 px-2"><span class="blue">Remove</span></div></div>
                                            </div>
                                        </p>
                                    </div>
                                </div>
                                <br>
            `;
        a.innerHTML = education;

        document.getElementsByClassName("EducationItems")[0].appendChild(a);
    }
    document.getElementsByClassName("AddWorkItem")[0].onclick = function () {

        var a = document.createElement("div");
        var work = `
                                                         <div class="CandidateResumeItem">
                                    <input type="hidden" name="CandidateWorkItems[3].Id" value="@item.Id" />
                                    <input type="hidden" name="CandidateWorkItems[3].CandidateId" value="@item.CandidateId" />
                                <div class="accordion mt-3 border-radius">@item.Title</div>
                                <div class="panel mt-2">
                                    <p>
                                        <div class="row ">
                                            <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Title</span></div>
                                            <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="Title" name="CandidateWorkItems[@count1].Title"></div>
                                        </div>
                                        <br>
                                        <div class="row ">
                                            <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Start Date</span></div>
                                            <div class="col-lg-9"><input type="date" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="Start Date" name="CandidateWorkItems[@count1].StartDate"></div>
                                        </div>
                                        <br>
                                        <div class="row ">
                                            <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">End Date</span></div>
                                            <div class="col-lg-9"><input type="date" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="End Date" name="CandidateWorkItems[@count1].EndDate"></div>
                                        </div>
                                        <br>
                                        <div class="row ">
                                            <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Company</span></div>
                                            <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="Work Place" name="CandidateWorkItems[@count1].WorkPlace"></div>
                                        </div>
                                        <br>
                                        <div class="row ">
                                            <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Description</span></div>
                                            <div class="col-lg-9"><textarea style="min-height: 150px;max-height: 150px;" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="Description" name="CandidateWorkItems[@count1].Content"></textarea></div>
                                        </div>
                                        <div class="row">
                                            <div class="d-flex flex-row justify-content-end RemoveItem"><div class="btn backColorBlue py-2 px-2"><span class="blue">Remove</span></div></div>
                                        </div>
                                    </p>
                                </div>
                            </div>
                            <br>

`;
        a.innerHTML = work;
        document.getElementsByClassName("WorkItems")[0].appendChild(a);

    }
    document.getElementsByClassName("AddAwardItem")[0].onclick = function () {
        var a = document.createElement("div");
        var award = `
                                                               <div class="CandidateResumeItem">
                                    <input type="hidden" name="CandidateAwardItems[2].Id" value="@item.Id" />
                                    <input type="hidden" name="CandidateAwardItems[2].CandidateId" value="@item.CandidateId" />
                                <div class="accordion mt-3 border-radius">@item.Title</div>
                                <div class="panel mt-2">
                                    <p>
                                        <div class="row ">
                                            <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Title</span></div>
                                            <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="Title" name = "CandidateAwardItems[@count2].Title"></div>
                                        </div>
                                        <br>
                                        <div class="row ">
                                            <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Years</span></div>
                                            <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="Years" name = "CandidateAwardItems[@count2].Years"></div>
                                        </div>
                                        <br>
                                        <div class="row ">
                                            <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Description</span></div>
                                            <div class="col-lg-9"><textarea style="min-height: 150px;max-height: 150px;" class="border-0 border-radius backColorBlue py-2 px-3 w-100" placeholder="Description"name = "CandidateAwardItems[@count2].Content"></textarea></div>
                                        </div>
                                        <div class="row">
                                            <div class="d-flex flex-row justify-content-end RemoveItem"><div class="btn backColorBlue py-2 px-2"><span class="blue">Remove</span></div></div>
                                        </div>
                                    </p>
                                </div>

                            </div>
                            <br>
`;
        a.innerHTML = award;
        document.getElementsByClassName("AwardItems")[0].appendChild(a);

    }



    $(".ImageXIcon ").css("display", "flex ");

        $(".ImageXIcon").click(function (e) {
            e.preventDefault();
            console.log("A.Y.E");
            $(".HiddenInputImage").css("display", "none ");
            $(".HiddenInputImage").attr("value", "");
            $(".ImageAndUpload img").css("display", "none ");
            $(".ImageXIcon ").css("display", "none ");
        });
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

    //var acc = document.getElementsByClassName("accordion");
    //var i;

    //for (i = 0; i < acc.length; i++) {
    //    acc[i].addEventListener("click", function () {
    //        console.log("salam");
    //        this.classList.toggle("active");

    //        var panel = this.nextElementSibling;
    //        if (panel.style.maxHeight) {
    //            panel.style.maxHeight = null;
    //        } else {
    //            panel.style.maxHeight = panel.scrollHeight + "px";
    //        }
    //    });
    //}

    $(document).ready(function () {

        for (var i = 0; i < document.getElementsByClassName("RemoveItem").length; i++) {
            $(document).on("click", ".RemoveItem", function (e) {
                e.preventDefault();
                //this.parentElement.parentElement.parentElement.style.display = "none";
                $(this).parents(".CandidateResumeItem").empty();
            })
        }

    })
    $(document).ready(function () {
        $(document).on("click", ".accordion", function (e) {
            e.preventDefault();
            this.classList.toggle("active");

            var panel = this.nextElementSibling;
            if (panel.style.maxHeight) {
                panel.style.maxHeight = null;
            } else {
                panel.style.maxHeight = panel.scrollHeight + "px";
            }
        });
    });

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

//$(".duyme1").click(function () {
//  $(".leftSection").attr("class", "col-lg-9 py-5 leftSection");
//  $(".sidebar").fadeToggle();
//});

//for (var i = 0; i < document.getElementsByClassName("RemoveItem").length; i++) {
//    document.getElementsByClassName("RemoveItem")[i].addEventListener("click", function () {
//        this.parentElement.parentElement.parentElement.style.display = "none";
//    });
//}


//for (var i = 0; i < document.getElementsByClassName("RemoveImageItem").length; i++) {

//    document.getElementsByClassName("RemoveImageItem")[i].addEventListener("click", function () {
//        this.parentElement.style.display = "none ";
//    });
//}
for (var i = 0; i < document.getElementsByClassName("RemoveCVItem").length; i++) {

    document.getElementsByClassName("RemoveCVItem")[i].parentElement.style.display = "flex ";
    document.getElementsByClassName("RemoveCVItem")[i].parentElement.parentElement.style.display = "flex ";
}




//for (var i = 0; i < document.getElementsByClassName("accordion").length; i++) {
//    document.getElementsByClassName("accordion")[i].onclick = function () {
//        this.nextElementSibling.slideToggle();
//    }
//}

$(document).ready(function () {

    $(document).on("click", ".PortfolioXIcon", function (e) {
        e.preventDefault();
        console.log("salam");
        //$(this).parents(".img-box").attr("style", "background-color:unset");
        $(this).parents(".PositionRelativeForIcon").empty();
    })
})
$(document).ready(function () {

    $(document).on("click", ".RemoveCVItem", function (e) {
        e.preventDefault();
        //$(this).parents(".img-box").attr("style", "background-color:unset");
        $(this).parents(".RemoveCVItems").empty();
    })
})



$(document).ready(function () {


    ClassicEditor
        .create(document.querySelector('#editor'))
        .catch(error => {
            console.error(error);
        });
    InlineEditor
        .create(document.querySelector('#editor'))
        .catch(error => {
            console.error(error);
        });
    BalloonEditor
        .create(document.querySelector('#editor'))
        .catch(error => {
            console.error(error);
        });
    DecoupledEditor
        .create(document.querySelector('#editor'))
        .then(editor => {
            const toolbarContainer = document.querySelector('#toolbar-container');

            toolbarContainer.appendChild(editor.ui.view.toolbar.element);
        })
        .catch(error => {
            console.error(error);
        });
})


