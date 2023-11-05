using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Import_AVL
{
    public class Node
    {
        public int Value { get; set; } = 0;
        public Node LeftChild { get; set; } = null;
        public Node RightChild { get; set; } = null;
        
        public Node(int value, Func<int, int, CompareResult> compDel)
        {
            this.Value = value;
            this.compDel = compDel;
        }

        //Delegate
        private Func<int, int, CompareResult> compDel = null;

        //Füge eine neue Node hinzu
        public void Add(int value)
        {
            //Füge die neue Node als rechtes Child ein, sollte der Wert größer sein
            if (compDel(value, Value) == CompareResult.Bigger ||
                compDel(value, Value) == CompareResult.Equal)
            {
                if (RightChild == null) RightChild = new Node(value, compDel);
                else RightChild.Add(value);
            }
            //Füge die neue Node als linkes Child ein, sollte der Wert kleiner sein
            else
            {
                if (LeftChild == null) LeftChild = new Node(value, compDel);
                else LeftChild.Add(value);
            }
        }
    }
}
