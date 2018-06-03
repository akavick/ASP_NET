"use strict";
console.log("Hello world");
var User = /** @class */ (function () {
    function User(name, age, money) {
        var _this = this;
        this.info = function () { return "\u0418\u043C\u044F: " + _this.name + " \u0432\u043E\u0437\u0440\u0430\u0441\u0442: " + _this.age + " \u0431\u0430\u0431\u043B\u043E: " + _this.money; };
        this.money = money;
        this.name = name;
        this.age = age;
    }
    return User;
}());
var tom = new User("Том", Math.round(Math.random() * 100), Math.round(Math.random() * 100000) / 100);
console.log(tom.info());
//как тормозить вывод? запускать через дебаг до выяснения 
//# sourceMappingURL=app.js.map