ko.bindingHandlers.fileUpload = {
    init: function (element, valueAccessor) {
        $(element).after('<div class="progress"><div class="bar"></div><div class="percent">0%</div></div><div class="progressError"></div>');
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {

        $(element).change(function () {
            var instance = this;

            if (element.files.length) {

                fileName = instance.value;

                // this uses jquery.form.js plugin
                $(element.form).ajaxSubmit({
                    url: bindingContext.$root.getView().URI + "/upload/" + bindingContext.$data.getKey(),
                    type: "POST",
                    dataType: "text",
                    headers: { "Content-Disposition": "attachment; filename=" + fileName },
                    beforeSubmit: function () {
                        $(".progress").show();
                        $(".progressError").hide();
                        $(".bar").width("0%")
                        $(".percent").html("0%");
                    },
                    uploadProgress: function (event, position, total, percentComplete) {
                        var percentVal = percentComplete + "%";
                        $(".bar").width(percentVal)
                        $(".percent").html(percentVal);
                    },
                    success: function (data) {
                        $(".progress").hide();
                        $(".progressError").hide();
                        // set viewModel property to filename
                        var parsedData = JSON.parse(data);

                        if (element.form['updateField'] !== null && element.form['updateField'] !== undefined) {

                            if (bindingContext.$data !== null && bindingContext.$data !== undefined) {

                                //extract the field from binding context.
                                var updateField = bindingContext.$data[element.form['updateField'].value];

                                if (updateField !== null && updateField !== undefined) {

                                    if (typeof (updateField) === "function") {

                                        updateField(parsedData.filename);

                                    } else {

                                        updateField = parsedData.filename;
                                    }
                                }
                            }
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        $(".progress").hide();
                        $("div.progressError").html(jqXHR.responseText);
                    }
                });
            }
        });
    }
};