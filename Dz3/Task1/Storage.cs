﻿using System.Linq;

namespace Dz3
{
    /*
    1) Цель: произвести расчет необходимого количества внешних носителей информации при переносе за один раз важной информации (565 Гб, файлы по 780 Мб) с рабочего компьютера на домашний компьютер и затрачиваемое на данный процесс время. Вы имеете в распоряжении следующие типы носителей информации: 
        • Flash-память, 
        • DVD - диск, 
        • съемный HDD. 
        Кроме того, каждый из производных классов дополняется следующими полями:
        - класс DVD - диск: скорость чтения / записи, тип (односторонний (4.7 Гб) /двусторонний (9 Гб));
        - класс съемный HDD: скорость USB 2.0, количество разделов, объем разделов.
        Работа с объектами соответствующих классов производится через ссылки на базовый класс («Storage»), которые хранятся в массиве.
        Приложение должно предоставлять следующие возможности:
        • расчет общего количества памяти всех устройств;
        • копирование информации на устройства;
        • расчет времени необходимого для копирования;
        • расчет необходимого количества носителей информации представленных типов для переноса информации.
        Емкость носителей информации должна быть указана в Гб, скорость копирования в Кб.
     */
    abstract class Storage
    {
        string Name { get; set; }
        string Model { get; set; }
        public abstract double GetCapacity();
        public abstract double Copy(params File[] files);
        public abstract double GetFreeMemory();
        public abstract string GetInfo();
        public abstract double CalcTime(double size);
        public abstract void Clear();
    }
}
