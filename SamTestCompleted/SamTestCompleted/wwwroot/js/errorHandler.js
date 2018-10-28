window.SamTestCompleted = window.SamTestCompleted || {};

window.SamTestCompleted.ErrorModule = window.SamTestCompleted.ErrorModule || (function ()
{
    var module = {};

    module.options = {};
    module.options.currentUser = null;
    module.options.postUrl = null;

    module.actions = {};
    module.actions.initialize = function (userParam, postUrlParam)
    {
        module.options.currentUser = userParam;
        module.options.postUrl = postUrlParam;
        window.addEventListener("error", function (errorEvent)
        {
            var stack = errorEvent.error.stack;
            var message = errorEvent.message;
            var url = errorEvent.filename;
            var user = JSON.stringify(module.options.currentUser);

            var msgObj =
            {
                message: message,
                stack: stack,
                url: url,
                user: user
            };

            var req = new XMLHttpRequest();
            req.open("POST", module.options.postUrl, true);
            req.setRequestHeader("Content-Type", "application/json");
            req.send(JSON.stringify(msgObj));
        });
    };

    return module;
}());