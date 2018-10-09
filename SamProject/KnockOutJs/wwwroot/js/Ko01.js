let f1 = (function()
{
    var ViewModel = function (firstName, lastName) 
    {
        this.firstName = ko.observable(firstName);
        this.lastName = ko.observable(lastName);

        this.fullName = ko.computed(function () 
        {
            // Knockout tracks dependencies automatically. It knows that fullName depends on firstName and lastName, because these get called when evaluating fullName.
            return this.firstName() + " " + this.lastName();
        }, this);
    };

    ko.applyBindings(new ViewModel("write", "something"), document.getElementById("Ko01")); // This makes Knockout get to work
})();