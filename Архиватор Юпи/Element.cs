using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Архиватор_Юпи
{
    public class Element
    {
        /// <summary>
     /// Значение элемента.
     /// </summary>
        public byte Value;
        /// <summary>
        /// Кол-во повторений.
        /// </summary>
        public Int64 Chastot;
        /// <summary>
        /// Ссылка на следующий элемент.
        /// </summary>
        public Element Next;
        /// <summary>
        /// Ссылка на предыдущий элемент.
        /// </summary>
        public Element Back;
        /// <summary>
        /// Ссылка на левый элемент.
        /// </summary>
        public Element Left;
        /// <summary>
        /// Ссылка на правый элемент.
        /// </summary>
        public Element Right;
    }
}
