function ($) {

    $(document).ready(function () {

        var pageController = {
            initialize: function () {
                this.hideCreatePersonFormDisplay();
                this.hideListPersonFormDisplay();
                this.applyBindings();
            },
            applyBindings: function () {
                this.bindCreatePersonLinkClick();
                this.bindCreatePersonButtonClick();
            },
            hideCreatePersonFormDisplay: function () {
                $("#personCreationBox").hide();
            },
            showCreatePersonFormDisplay: function () {
                $("#personCreationBox").show();
            },
            hideListPersonFormDisplay: function () {
                $("#personListBox").hide();
            },

            showListPersonFormDisplay: function () {
                $("#personListBox").show();
            },

            applyBindings: function () {
                this.bindCreatePersonLinkClick();
                this.bindCreatePersonButtonClick();
            },

            bindCreatePersonLinkClick: function () {
                $("#createnewlink").on("click", function () {
                    pageController.showCreatePersonFormDisplay();
                    pageController.hideListPersonFormDisplay();
                });
            },
            bindCreatePersonButtonClick: function () {
                $("#submitbutton").on("click", function () {
                    var postData = {
                        name: $("#Name").val(),
                        surname: $("#Surname").val(),
                        dob: $("#DoB").val(),
                    };

                    $.post("/api/personservice", postData)
                        .done(function () {
                            pageController.fetchPersonData();
                            pageController.hideCreatePersonFormDisplay();
                            pageController.showListPersonFormDisplay();
                        });
                    return false;
                });
            },

            fetchPersonData: function () {
                var personListBox = $("#personListBox");
                personListBox.find("*").remove();
                $.get("/api/personservice")
                    .done(function (response) {
                        $.each(response, function () {
                            var personDataRow = $("<tr>");
                            var nameCell = $("<td>").html(this.Name);
                            var surnameCell = $("<td>").html(this.Surname);
                            var dobCell = $("<td>").html(this.DoB);

                            personDataRow
                                .append(nameCell)
                                .append(surnameCell)
                                .append(dobCell);
                            personListBox.append(personDataRow);
                        });
                    });
            },

        };
        pageController.initialize();
        pageController.applyBindings();
    });

}) (jQuery);