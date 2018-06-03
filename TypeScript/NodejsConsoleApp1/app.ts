console.log("Hello world");

class User
{
    private name: string;
    private age: number;
    private money: number;

    constructor(name: string, age: number, money: number)
    {
        this.money = money;
        this.name = name;
        this.age = age;
    }

    public info = (): string => `Имя: ${this.name} возраст: ${this.age} бабло: ${this.money}`;
}


var tom: User = new User("Том", Math.round(Math.random() * 100), Math.round(Math.random() * 100000) / 100);

console.log(tom.info());

//как тормозить вывод? запускать через дебаг до выяснения