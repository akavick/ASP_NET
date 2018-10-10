(function ()
{
    document
        .querySelector("body")
        .addEventListener("scriptsLoaded", function ()
        {
            const viewModel = {
                stringValue: ko.observable("Hello"),
                passwordValue: ko.observable("mypass"),
                booleanValue: ko.observable(true),
                optionValues: ["Alpha", "Beta", "Gamma"],
                selectedOptionValue: ko.observable("Gamma"),
                multipleSelectedOptionValues: ko.observable(["Alpha"]),
                radioSelectedOptionValue: ko.observable("Beta")
            };

            ko.applyBindings(viewModel, document.getElementById("Ko9"));
        });
})();