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
    document.getElementsByClassName("AddEducationItem")[0].onclick = function () {
        var a = document.createElement("div");
        var education =
            ` 
                                <div class="CandidateResumeItem">
                                    <input type="hidden" class="EducationClickItem" name="CandidateEducationItems[2].Id" value="@item.Id" />
                                    <input type="hidden" class="EducationClickItem" name="CandidateEducationItems[2].CandidateId" value="@item.CandidateId" />
                                    <div class="accordion mt-3 border-radius">@item.Title</div>
                                    <div class="panel mt-2">
                                        <p>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Title</span></div>
                                                <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100 EducationClickItem" placeholder="BEducation Title" name="CandidateEducationItems[2].Title" value="@item.Title"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Academy</span></div>
                                                <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100 EducationClickItem" placeholder="Education Academy" name="CandidateEducationItems[2].EducationPlace" value="@item.EducationPlace"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Years</span></div>
                                                <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100 EducationClickItem" placeholder="Years" name="CandidateEducationItems[2].Years" value="@item.Years"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Description</span></div>
                                                <div class="col-lg-9"><input style="min-height: 150px;max-height: 150px;" class="border-0 border-radius backColorBlue py-2 px-3 w-100 EducationClickItem" placeholder="Description" name="CandidateEducationItems[2].Content" value="@item.Content"></div>
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
        for (var i = 0; i < document.getElementsByClassName("EducationClickItem").length / 6; i++) {
            document.getElementsByClassName("EducationClickItem")[i * 6].setAttribute("name", `CandidateEducationItems[` + i + `].Id`);
            document.getElementsByClassName("EducationClickItem")[i * 6 + 1].setAttribute("name", `CandidateEducationItems[` + i + `].CandidateId`);
            document.getElementsByClassName("EducationClickItem")[i * 6 + 2].setAttribute("name", `CandidateEducationItems[` + i + `].Title`);
            document.getElementsByClassName("EducationClickItem")[i * 6 + 3].setAttribute("name", `CandidateEducationItems[` + i + `].EducationPlace`);
            document.getElementsByClassName("EducationClickItem")[i * 6 + 4].setAttribute("name", `CandidateEducationItems[` + i + `].Years`);
            document.getElementsByClassName("EducationClickItem")[i * 6 + 5].setAttribute("name", `CandidateEducationItems[` + i + `].Content`);
        }

    }
    document.getElementsByClassName("AddWorkItem")[0].onclick = function () {

        var a = document.createElement("div");
        var work = `
                                 
                                <div class="CandidateResumeItem">
<input type="hidden" name="CandidateWorkItemsId[]" value="@item.Id"/>
                                    <input type="hidden" class="WorkClickItem" name="CandidateWorkItems[].Id" value="@item.Id" />
                                    <input type="hidden" class="WorkClickItem" name="CandidateWorkItems[].CandidateId" value="@item.CandidateId" />
                                    <div class="accordion mt-3 border-radius">@item.Title</div>
                                    <div class="panel mt-2">
                                        <p>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Title</span></div>
                                                <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100 WorkClickItem" placeholder="Title" name="CandidateWorkItems[].Title" value="@item.Title"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Start Date</span></div>
                                                <div class="col-lg-9"><input type="date" class="border-0 border-radius backColorBlue py-2 px-3 w-100 WorkClickItem" placeholder="Start Date" name="CandidateWorkItems[].StartDate" value="@item.StartDate"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">End Date</span></div>
                                                <div class="col-lg-9"><input type="date" class="border-0 border-radius backColorBlue py-2 px-3 w-100 WorkClickItem" placeholder="End Date" name="CandidateWorkItems[].EndDate" value="@item.EndDate"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Company</span></div>
                                                <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100 WorkClickItem" placeholder="Work Place" name="CandidateWorkItems[].WorkPlace" value="@item.WorkPlace"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Description</span></div>
                                                <div class="col-lg-9"><input style="min-height: 150px;max-height: 150px;" class="border-0 border-radius backColorBlue py-2 px-3 w-100 WorkClickItem" placeholder="Description" name="CandidateWorkItems[].Content" value="@item.Content"></div>
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
        for (var i = 0; i < document.getElementsByClassName("WorkClickItem").length / 7; i++) {
            document.getElementsByClassName("WorkClickItem")[i * 7].setAttribute("name", `CandidateWorkItems[` + i + `].Id`);
            document.getElementsByClassName("WorkClickItem")[i * 7 + 1].setAttribute("name", `CandidateWorkItems[` + i + `].CandidateId`);
            document.getElementsByClassName("WorkClickItem")[i * 7 + 2].setAttribute("name", `CandidateWorkItems[` + i + `].Title`);
            document.getElementsByClassName("WorkClickItem")[i * 7 + 3].setAttribute("name", `CandidateWorkItems[` + i + `].StartDate`);
            document.getElementsByClassName("WorkClickItem")[i * 7 + 4].setAttribute("name", `CandidateWorkItems[` + i + `].EndDate`);
            document.getElementsByClassName("WorkClickItem")[i * 7 + 5].setAttribute("name", `CandidateWorkItems[` + i + `].WorkPlace`);
            document.getElementsByClassName("WorkClickItem")[i * 7 + 6].setAttribute("name", `CandidateWorkItems[` + i + `].Content`);
        }

    }
    document.getElementsByClassName("AddAwardItem")[0].onclick = function () {
        var a = document.createElement("div");
        var award = `
                                    

                                <div class="CandidateResumeItem">
 <input type="hidden" name="CandidateAwardItemsId[]" value="@item.Id"/>
                                    <input type="hidden" class="AwardClickItem" name="CandidateAwardItems[].Id" value="@item.Id" />
                                    <input type="hidden" class="AwardClickItem" name="CandidateAwardItems[].CandidateId" value="@item.CandidateId" />
                                    <div class="accordion mt-3 border-radius">@item.Title</div>
                                    <div class="panel mt-2">
                                        <p>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Title</span></div>
                                                <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100 AwardClickItem" placeholder="Title" name="CandidateAwardItems[].Title" value="@item.Title"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Years</span></div>
                                                <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100 AwardClickItem" placeholder="Years" name="CandidateAwardItems[].Years" value="@item.Years"></div>
                                            </div>
                                            <br>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Description</span></div>
                                                <div class="col-lg-9"><input style="min-height: 150px;max-height: 150px;" class="border-0 border-radius backColorBlue py-2 px-3 w-100 AwardClickItem" placeholder="Description" name="CandidateAwardItems[].Content" value="@item.Content"></div>
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

        for (var i = 0; i < document.getElementsByClassName("AwardClickItem").length / 5; i++) {
            document.getElementsByClassName("AwardClickItem")[i * 5].setAttribute("name", `CandidateAwardItems[` + i + `].Id`);
            document.getElementsByClassName("AwardClickItem")[i * 5 + 1].setAttribute("name", `CandidateAwardItems[` + i + `].CandidateId`);
            document.getElementsByClassName("AwardClickItem")[i * 5 + 2].setAttribute("name", `CandidateAwardItems[` + i + `].Title`);
            document.getElementsByClassName("AwardClickItem")[i * 5 + 3].setAttribute("name", `CandidateAwardItems[` + i + `].Years`);
            document.getElementsByClassName("AwardClickItem")[i * 5 + 4].setAttribute("name", `CandidateAwardItems[` + i + `].Content`);
        }

    }
    document.getElementsByClassName("AddSkillItem")[0].onclick = function () {
        var a = document.createElement("div");
        var skill =
            ` 
                                                <div class="CandidateResumeItem">
                                    <input type="hidden" name="CandidateSkillsId[]" value="@item.Id" />
                                    <input type="hidden" class="SkillClickItem" name="CandidateSkills[].Id" value="@item.Id" />
                                    <input type="hidden" class="SkillClickItem" name="CandidateSkills[].CandidateId" value="@item.CandidateId" />
                                    <div class="accordion mt-3 border-radius">@item.Name</div>
                                    <div class="panel mt-2">
                                        <p>
                                            <div class="row ">
                                                <div class="col-lg-3 d-flex flex-row align-items-center"><span class="grey ">Title</span></div>
                                                <div class="col-lg-9"><input type="text" class="border-0 border-radius backColorBlue py-2 px-3 w-100 SkillClickItem" placeholder="Title" name="CandidateSkills[].Name" value="@item.Name"></div>
                                            </div>
                                            <div class="row">
                                                <div class="d-flex flex-row justify-content-end RemoveItem"><div class="btn backColorBlue py-2 px-2"><span class="blue">Remove</span></div></div>
                                            </div>
                                        </p>
                                    </div>
                                </div>
                                <br>
            `;
        a.innerHTML = skill;
        document.getElementsByClassName("SkillItems")[0].appendChild(a);
        for (var i = 0; i < document.getElementsByClassName("SkillClickItem").length / 3; i++) {
            document.getElementsByClassName("SkillClickItem")[i * 3].setAttribute("name", `CandidateSkills[` + i + `].Id`);
            document.getElementsByClassName("SkillClickItem")[i * 3 + 1].setAttribute("name", `CandidateSkills[` + i + `].CandidateId`);
            document.getElementsByClassName("SkillClickItem")[i * 3 + 2].setAttribute("name", `CandidateSkills[` + i + `].Name`);
        }

    }
    for (var i = 0; i < document.getElementsByClassName("RemoveItem").length; i++) {
        $(document).on("click", ".RemoveItem", function (e) {
            e.preventDefault();
            //this.parentElement.parentElement.parentElement.style.display = "none";
            $(this).parents(".CandidateResumeItem").empty();
            for (var i = 0; i < document.getElementsByClassName("EducationClickItem").length / 6; i++) {
                document.getElementsByClassName("EducationClickItem")[i * 6].setAttribute("name", `CandidateEducationItems[` + i + `].Id`);
                document.getElementsByClassName("EducationClickItem")[i * 6 + 1].setAttribute("name", `CandidateEducationItems[` + i + `].CandidateId`);
                document.getElementsByClassName("EducationClickItem")[i * 6 + 2].setAttribute("name", `CandidateEducationItems[` + i + `].Title`);
                document.getElementsByClassName("EducationClickItem")[i * 6 + 3].setAttribute("name", `CandidateEducationItems[` + i + `].EducationPlace`);
                document.getElementsByClassName("EducationClickItem")[i * 6 + 4].setAttribute("name", `CandidateEducationItems[` + i + `].Years`);
                document.getElementsByClassName("EducationClickItem")[i * 6 + 5].setAttribute("name", `CandidateEducationItems[` + i + `].Content`);
            }
            for (var i = 0; i < document.getElementsByClassName("WorkClickItem").length / 7; i++) {
                document.getElementsByClassName("WorkClickItem")[i * 7].setAttribute("name", `CandidateWorkItems[` + i + `].Id`);
                document.getElementsByClassName("WorkClickItem")[i * 7 + 1].setAttribute("name", `CandidateWorkItems[` + i + `].CandidateId`);
                document.getElementsByClassName("WorkClickItem")[i * 7 + 2].setAttribute("name", `CandidateWorkItems[` + i + `].Title`);
                document.getElementsByClassName("WorkClickItem")[i * 7 + 3].setAttribute("name", `CandidateWorkItems[` + i + `].StartDate`);
                document.getElementsByClassName("WorkClickItem")[i * 7 + 4].setAttribute("name", `CandidateWorkItems[` + i + `].EndDate`);
                document.getElementsByClassName("WorkClickItem")[i * 7 + 5].setAttribute("name", `CandidateWorkItems[` + i + `].WorkPlace`);
                document.getElementsByClassName("WorkClickItem")[i * 7 + 6].setAttribute("name", `CandidateWorkItems[` + i + `].Content`);
            }
            for (var i = 0; i < document.getElementsByClassName("AwardClickItem").length / 5; i++) {
                document.getElementsByClassName("AwardClickItem")[i * 5].setAttribute("name", `CandidateAwardItems[` + i + `].Id`);
                document.getElementsByClassName("AwardClickItem")[i * 5 + 1].setAttribute("name", `CandidateAwardItems[` + i + `].CandidateId`);
                document.getElementsByClassName("AwardClickItem")[i * 5 + 2].setAttribute("name", `CandidateAwardItems[` + i + `].Title`);
                document.getElementsByClassName("AwardClickItem")[i * 5 + 3].setAttribute("name", `CandidateAwardItems[` + i + `].Years`);
                document.getElementsByClassName("AwardClickItem")[i * 5 + 4].setAttribute("name", `CandidateAwardItems[` + i + `].Content`);
            }
            for (var i = 0; i < document.getElementsByClassName("SkillClickItem").length / 3; i++) {
                document.getElementsByClassName("SkillClickItem")[i * 3].setAttribute("name", `CandidateSkills[` + i + `].Id`);
                document.getElementsByClassName("SkillClickItem")[i * 3 + 1].setAttribute("name", `CandidateSkills[` + i + `].CandidateId`);
                document.getElementsByClassName("SkillClickItem")[i * 3 + 2].setAttribute("name", `CandidateSkills[` + i + `].Name`);
            }
        })
    }


    $(document).on("click", ".delete-btn", function (e) {
        e.preventDefault();

        console.log("testing")

        var url = $(this).attr("href")
        console.log(url);

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {

            if (result.isConfirmed) {
                console.log(url);
                fetch(url)
                    .then(response => response.json())
                    .then(data => console.log(data));
                    window.location.reload();
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )

            }


        })
    })
})