using System;

namespace Les9
{
    /*
     * 
    Написать приложение WorldOfTanks. Должен состояться танковый бой 5х5, т.е. 5 русских танков против 5 немецких. 
    Весь бой должен состоять из пяти дуэльных сражений (один-на-один). 
    Победителем боя будет являться танки, которые наберут большее количество очков в пяти сражениях.
	Танк должен быть представлен классом Tank. В нем должны быть определены 4 поля (имя танка, боезапас, уровень брони, уровень маневренности).
    Также в классе должен быть перегружен оператор, например умножение, для имитации дуэльного сражения.
	В дуэльном сражении побеждает тот танк, у которого минимум два параметра из трех (боезапас, уровень брони, уровень маневренности) больше, 
    чем у противника. Общая победа команды зависит от количества очков в дуэльных сражениях.
     */
    class Tank
    {
        public string Name { get; private set; }
        public int Ammo { get; private set; }
        public int Armor { get; private set; }
        public int Speed { get; private set; }
        private static Random rand = new Random();
        public Tank(string name)
        {
            Ammo = rand.Next(0, 10);
            Armor = rand.Next(0, 10);
            Speed = rand.Next(0, 10);
            Name = name;
        }
        public static int operator *(Tank t1, Tank t2)
            => (t1.Ammo > t2.Ammo && t1.Armor > t2.Armor)
                || (t1.Ammo > t2.Ammo && t1.Speed > t2.Speed)
                || (t1.Speed > t2.Speed && t1.Armor > t2.Armor)
                    ? 1 : (t2.Ammo > t1.Ammo && t2.Armor > t1.Armor)
                            || (t2.Ammo > t1.Ammo && t2.Speed > t1.Speed)
                            || (t2.Speed > t1.Speed && t2.Armor > t1.Armor)
                                ? -1 : 0;

        public override string ToString() => $"{Name.PadRight(15)}{Ammo.ToString().PadRight(15)}{Armor.ToString().PadRight(15)}{Speed.ToString().PadRight(15)}";
    }
}