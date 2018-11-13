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
            var url = window.location;
            var fileName = errorEvent.filename;
            var user = module.options.currentUser;
            var userName = "unknown";
            var userIsAuthenticated = false;
            var userAuthenticationType = "unknown";

            if (user)
            {
                userName = user.name;
                userIsAuthenticated = user.isAuthenticated;
                userAuthenticationType = user.authenticationType;
            }

            var msgObj =
            {
                message: message,
                stack: stack,
                url: url,
                fileName: fileName,
                userName: userName,
                userIsAuthenticated: userIsAuthenticated,
                userAuthenticationType: userAuthenticationType
            };

            var req = new XMLHttpRequest();
            req.open("POST", module.options.postUrl, true);
            req.setRequestHeader("Content-Type", "application/json");
            req.send(JSON.stringify(msgObj));
        });
    };

    return module;
}());