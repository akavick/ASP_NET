(function ()
{
    document
        .querySelector("body")
        .addEventListener("scriptsLoaded", function ()
        {
            const ClickCounterViewModel = function ()
            {
                this.numberOfClicks = ko.observable(0);

                this.registerClick = function ()
                {
                    this.numberOfClicks(this.numberOfClicks() + 1);
                };

                this.resetClicks = function ()
                {
                    this.numberOfClicks(0);
                };

                this.hasClickedTooManyTimes = ko.computed(function ()
                {
                    return this.numberOfClicks() >= 3;
                }, this);
            };

            ko.applyBindings(new ClickCounterViewModel(), document.getElementById("Ko2"));
        });
})();