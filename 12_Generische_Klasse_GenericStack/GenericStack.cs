using System.Diagnostics.CodeAnalysis;

namespace _12_Generische_Klasse_GenericStack
{
    [SuppressMessage("ReSharper", "NotAccessedField.Local")]
    [SuppressMessage("ReSharper", "RedundantDefaultMemberInitializer")]
    [SuppressMessage("ReSharper", "ArrangeAccessorOwnerBody")]
    public class GenericStack<T>
    {
        private readonly int size;
        private readonly T[] elements;
        private int pointer = 0;   // Zeiger auf nächstes Element

        public int Length
        {
            get { return pointer - 1; }
        }

        public GenericStack(int size)
        {
            this.size = size;
            elements = new T[size];
        }

        public void Push(T element)
        {
            elements[pointer] = element;
            pointer++;
        }

        public T Pop()
        {
            T element = elements[--pointer];
            return element;
        }
    }
}