window.SamTestCompleted = window.SamTestCompleted || {};
window.SamTestCompleted.Helpers = window.SamTestCompleted.Helpers || {};

window.SamTestCompleted.Helpers.BrowserHelper = window.SamTestCompleted.Helpers.BrowserHelper || (function ()
{
    var module = {};

    module.actions = {};

    module.actions.getPlatform = function ()
    {
        return /iphone|ipad|ipod|android|blackberry|mini|windows\sce|palm/i.test(navigator.userAgent.toLowerCase())
            ? "mobile"
            : "desktop";
    };

    module.actions.getBrowserInfo = function ()
    {
        var result = {};
        var unknown = "unknown";
        var ua = navigator.userAgent;

        var getVersion = function(func)
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
                version: getVersion(function() { return ua.split("Edge")[1].split("/")[1]; })
            },
            "MSIE": {
                name: "Microsoft Internet Explorer",
                version: getVersion(function() { return ua.split("MSIE ")[1].split(";")[0]; })
            },
            "Trident": {
                name: "Microsoft Internet Explorer",
                version: getVersion(function() { return ua.split("; rv:")[1].split(")")[0]; })
            },
            "Firefox": {
                name: "Mozilla Firefox",
                version: getVersion(function() { return ua.split("Firefox/")[1]; })
            },
            "Opera": {
                name: "Opera",
                version: getVersion(function() { return ua.split("Version/")[1]; })
            },
            "OPR": {
                name: "Opera",
                version: getVersion(function() { return ua.split("OPR/")[1]; })
            },
            "YaBrowser": {
                name: "Yandex Browser",
                version: getVersion(function() { return ua.split("YaBrowser/")[1].split(" ")[0]; })
            },
            "Chrome": {
                name: "Google Chrome",
                version: getVersion(function() { return ua.split("Chrome/")[1].split(" ")[0]; })
            },
            "Safari": {
                name: "Safari",
                version: getVersion(function() { return ua.split("Version/")[1].split(" ")[0]; })
            },
            "Maxthon": {
                name: "Maxthon",
                version: getVersion(function() { return ua.split("Maxthon/")[1]; })
            }
        };

        result.name = unknown;
        result.version = unknown;

        for (var key in searchedBrowsers)
        {
            if (searchedBrowsers.hasOwnProperty(key) && ua.search(new RegExp(key)) > -1)
            {
                var found = searchedBrowsers[key];

                result.name = found.name;
                result.version = found.version;

                break;
            }
        }

        return result;
    };

    module.actions.constraintBrowsers = function()
    {
        var curentBrowser = module.actions.getBrowserInfo();
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
    };

    return module;
}());