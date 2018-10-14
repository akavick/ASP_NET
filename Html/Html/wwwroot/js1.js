"use strict";

//alert, prompt, confirm

/*
 
var undef; // переменная не присвоена, т.е. равна undefined
var zero = 0;
var emptyStr = "";
var msg = "Привет!";

var result = undef || zero || emptyStr || msg || 0;

alert( result ); // выведет "Привет!" - первое значение, которое является true
Если все значения «ложные», то || возвратит последнее из них:

 alert( undefined || '' || false || 0 ); // 0

---

возвратится первое «ложное» (на котором остановились вычисления), а если его нет – то последнее:

 alert( 1 && 2 && null && 3 ); // null

---

двойное НЕ используют для преобразования значений к логическому типу:

 alert( !!"строка" ); // true
alert( !!null ); // false





alert( String(null) === "null" ); // true

var a = +"123"; // 123
var a = Number("123"); // 123, тот же эффект

alert( +true ); // 1
alert( +false ); // 0

Сравнение разных типов – значит численное преобразование:

 alert( "\n0 " == 0 ); // true

Значение	Преобразуется в...
undefined	NaN
null	0
true / false	1 / 0
Строка	Пробельные символы по краям обрезаются.
Далее, если остаётся пустая строка, то 0, иначе из непустой строки "считывается" число, при ошибке результат NaN.


"" + 1 + 0 = "10" // (1)
"" - 1 + 0 = -1 // (2)
true + false = 1
6 / "3" = 2
"2" * "3" = 6
4 + 5 + "px" = "9px"
"$" + 4 + 5 = "$45"
"4" - 2 = 2
"4px" - 2 = NaN
7 / 0 = Infinity
" -9\n" + 5 = " -9\n5"
" -9\n" - 5 = -14
5 && 2 = 2
2 && 5 = 5
5 || 0 = 5
0 || 5 = 5
null + 1 = 1 // (3)
undefined + 1 = NaN // (4)
null == "\n0\n" = false // (5)
+null == +"\n0\n" = true // (6)






---

outer: for (var i = 0; i < 3; i++) {

  for (var j = 0; j < 3; j++) {

    var input = prompt('Значение в координатах '+i+','+j, '');

    // если отмена ввода или пустая строка -
    // завершить оба цикла
    if (!input) break outer; // (*)

  }
}

---

функции, объявленные как Function Declaration, создаются интерпретатором до выполнения кода.

---


var sum = new Function('a,b', ' return a+b; ');
var result = sum(1, 2);

---

var f = function sayHi(name) {
  alert( sayHi ); // изнутри функции - видно (выведет код функции)
};

alert( sayHi ); // снаружи - не видно (ошибка: undefined variable 'sayHi')

var f = function factorial(n) {
  return n ? n*factorial(n-1) : 1;
};

var g = f;  // скопировали ссылку на функцию-факториал в g
f = null;

alert( g(5) ); // 120, работает!


---

function pow(x, n) {
  ...
  debugger; // <-- отладчик остановится тут
  ...
}

---


Math.floor
Округляет вниз
Math.ceil
Округляет вверх
Math.round
Округляет до ближайшего целого

Округление битовыми операторами
Битовые операторы делают любое число 32-битным целым, обрезая десятичную часть.
В результате побитовая операция, которая не изменяет число, например, двойное битовое НЕ – округляет его:

 alert( ~~12.3 ); // 12
Любая побитовая операция такого рода подойдет, например XOR (исключающее ИЛИ, "^") с нулем:

 alert( 12.3 ^ 0 ); // 12
alert( 1.2 + 1.3 ^ 0 ); // 2, приоритет ^ меньше, чем +
Это удобно в первую очередь тем, что легко читается и не заставляет ставить дополнительные скобки как Math.floor(...):

var x = a * b / c ^ 0; // читается как "a * b / c и округлить"

Округление до заданной точности
Для округления до нужной цифры после запятой можно умножить и поделить на 10 с нужным количеством нулей. Например, округлим 3.456 до 2-го знака после запятой:

 var n = 3.456;
alert( Math.round(n * 100) / 100 ); // 3.456 -> 345.6 -> 346 -> 3.46

alert( 12..toFixed(1) ); // 12.0


---
WARNING!
alert( 0.1 + 0.2 ); // 0.30000000000000004

alert( (0.1 * 10 + 0.2 * 10) / 10 ); // 0.3

var result = 0.1 + 0.2;
alert( +result.toFixed(10) ); // 0.3
---


Math.МНОГОФУНКЦИЙ
Math.random() 
Number.МНОГОФУНКЦИЙ


var number = 123456789;
alert( number.toLocaleString() ); // 123 456 789


 проверка if ( ~str.indexOf(...) ) означает, что результат indexOf отличен от -1, т.е. совпадение есть.
 */



//в JavaScript есть обычные числа и три специальных числовых значения: NaN, Infinity и -Infinity.

console.log(2..toString(2));
console.log(parseInt("100", 2));
console.log(1 / 0);

console.log(isFinite(3));
console.log(isFinite(NaN));
console.log(isFinite(1 / 0));

console.log(isNaN(3));
console.log(isNaN(1 / 0));
console.log(isNaN(NaN));

// правильная проверка на число 
function isNumeric(n)
{
    return !isNaN(parseFloat(n)) && isFinite(n);
}


/**
 * Возвращает x в степени n, только для натуральных n
 *
 * @param {number} x Число для возведения в степень.
 * @param {number} n Показатель степени, натуральное число.
 * @return {number} x в степени n.
 */
function pow(x, n)
{
    //http://usejsdoc.org/
    return 0;
}


