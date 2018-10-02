using System;

namespace Dz11
{
    class MyObsoleteClass
    {
        [Obsolete("Данный метод устарел")]
        public void LightObsoleteMethod() { }
        [Obsolete("Данный метод очень устарел", true)]
        public void VeryObsoleteMethod() { }
    }
}
