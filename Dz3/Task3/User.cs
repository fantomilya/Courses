using System;

namespace Dz3
{
    /*3)	
     * На сайте есть группа пользователей, каждый из них принадлежит к определённой группе, например это администратор, редактор и гость. 
     * Каждая группа имеет свои особенности. 
     * Администраторы могут добавлять материал, удалять материал, редактировать и читать. 
     * Редакторы могут только редактировать и читать. 
     * А гости только читать. 
     * Все пользователи могут читать материал на сайте, это общая возможность для всех пользователей, остальные же возможности зависят от вида пользователя. 
     * Реализовать приложение имитирующее деятельность пользователей на сайте (попытки производить различные действия). 
     * (Рекомендуется использовать изученные паттерны проектирования.)
     */
    public abstract class User
    {
        public Action AddMaterial { get; }
        public Action DeleteMaterial { get; }
        public Action EditMaterial { get; }
        public Action ReadMaterial { get; }

        protected User(Action addMaterial, Action deleteMaterial, Action editMaterial, Action readMaterial)
        {
            AddMaterial = addMaterial;
            DeleteMaterial = deleteMaterial;
            EditMaterial = editMaterial;
            ReadMaterial = readMaterial;
        }
    }
}
