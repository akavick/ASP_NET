window.SamTest = window.SamTest || {};

window.SamTest.errorModule = window.SamTest.errorModule || (function ()
{
    var currentUser = null;
    var postUrl = null;

    function initialize(userParam, postUrlParam)
    {
        currentUser = userParam;
        postUrl = postUrlParam;
        window.addEventListener("error", handleError);
    }

    function handleError(errorEvent)
    {
        var stack = errorEvent.error.stack;
        var message = errorEvent.message;
        var url = errorEvent.filename;
        var user = JSON.stringify(currentUser);

        var msgObj =
        {
            message: message,
            stack: stack,
            url: url,
            user: user
        };

        var req = new XMLHttpRequest();
        req.open("POST", postUrl, true);
        req.setRequestHeader("Content-Type", "application/json");
        req.send(JSON.stringify(msgObj));
    }

    function getBrowser()
    {
        var self = this;
        var unknown = "unknown";
        var ua = navigator.userAgent;
        var getVersion = function (func)
        {
            try
            {
                var result = func();

                return typeof result === "string"
                    ? result
                    : unknown;
            }
            catch (e)
            {
                return unknown;
            }
        };
        var searchedBrowsers =
        {
            "Edge": {
                name: "Microsoft Edge",
                version: getVersion(function () { return ua.split("Edge")[1].split("/")[1]; })
            },
            "MSIE": {
                name: "Microsoft Internet Explorer",
                version: getVersion(function () { return ua.split("MSIE ")[1].split(";")[0]; })
            },
            "Trident": {
                name: "Microsoft Internet Explorer",
                version: getVersion(function () { return ua.split("; rv:")[1].split(")")[0]; })
            },
            "Firefox": {
                name: "Mozilla Firefox",
                version: getVersion(function () { return ua.split("Firefox/")[1]; })
            },
            "Opera": {
                name: "Opera",
                version: getVersion(function () { return ua.split("Version/")[1]; })
            },
            "OPR": {
                name: "Opera",
                version: getVersion(function () { return ua.split("OPR/")[1]; })
            },
            "YaBrowser": {
                name: "Yandex Browser",
                version: getVersion(function () { return ua.split("YaBrowser/")[1].split(" ")[0]; })
            },
            "Chrome": {
                name: "Google Chrome",
                version: getVersion(function () { return ua.split("Chrome/")[1].split(" ")[0]; })
            },
            "Safari": {
                name: "Safari",
                version: getVersion(function () { return ua.split("Version/")[1].split(" ")[0]; })
            },
            "Maxthon": {
                name: "Maxthon",
                version: getVersion(function () { return ua.split("Maxthon/")[1]; })
            }
        };

        self.name = unknown;
        self.version = unknown;
        self.platform = /iphone|ipad|ipod|android|blackberry|mini|windows\sce|palm/i.test(navigator.userAgent.toLowerCase())
            ? "mobile"
            : "desktop";

        for (var key in searchedBrowsers)
        {
            if (searchedBrowsers.hasOwnProperty(key) && ua.search(new RegExp(key)) > -1) 
            {
                var found = searchedBrowsers[key];

                self.name = found.name;
                self.version = found.version;

                break;
            }
        }

        return self;
    }

    function constraintUsingBrowsers()
    {
        var curentBrowser = getBrowser();
        var constraintedBrowsers = ["Microsoft Internet Explorer"]; //дописывать браузеры сюда ["Microsoft Internet Explorer", "Safari", ...]
        var partiallySupportedBrowsers = ["Microsoft Edge"]; //дописывать браузеры сюда ["Microsoft Internet Explorer", "Safari", ...]

        if (constraintedBrowsers.indexOf(curentBrowser.name) !== -1)
        {
            //запретить;
            window.location.replace("/html/errors/BrowserUnsupported.html");
        }

        if (partiallySupportedBrowsers.indexOf(curentBrowser.name) !== -1)
        {
            //предупредить
            alert("Приложение поддерживает используемый браузер лишь частично");
            //document.getElementById("warningMessage").style.display = "block";
        }
    }

    this.init = initialize;
    this.constraintBrowsers = constraintUsingBrowsers;

    return this;

}());