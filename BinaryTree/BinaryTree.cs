using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTreeEventArgs<T>:EventArgs
    {
        public BinaryTreeEventArgs(string msg) { Message = msg; }
        public string Message { get; set; }
        public T Data { get; set; }
        public static int Counter { get; set; }
    }

    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public BinaryTree<T> LeftTree { get; private set; }
        public BinaryTree<T> RightTree { get; private set; }

        public delegate void Show(string msg);
        public event Action<object ,BinaryTreeEventArgs<T> > NodeAdd;
        public event Action<object, BinaryTreeEventArgs<T>> NodeFinded;
        public event Action<object, BinaryTreeEventArgs<T>> TreeCreated;
        public T Node { get; private set; }

        public BinaryTree()
        {
            NodeAdd += (object sender, BinaryTreeEventArgs<T> e) => { Console.WriteLine(e.Message + " : " + e.Data); };
            NodeFinded += (object sender, BinaryTreeEventArgs<T> e) => Console.WriteLine(e.Message + " : " + e.Data);
            TreeCreated += (object sender, BinaryTreeEventArgs<T> e) => Console.WriteLine(e.Message + " : " + e.Data);
        }

        public BinaryTree(T node)
        {
            NodeAdd += (object sender, BinaryTreeEventArgs<T> e) => Console.WriteLine(e.Message + " : " + e.Data);
            NodeFinded += (object sender, BinaryTreeEventArgs<T> e) => Console.WriteLine(e.Message + " : " + e.Data);
            TreeCreated += (object sender, BinaryTreeEventArgs<T> e) => Console.WriteLine(e.Message + " : " + e.Data);
            Node = node;
        }

        public void Insert_Main_Root(T node)
        {
            Node = node;
            if (Node == null) throw new NullReferenceException();
            TreeCreated?.Invoke(this, new BinaryTreeEventArgs<T>("Tree Created") { Data = node });

        }

        public void Insert(T node)
        {
            if (this.Node.CompareTo(node) > 0)
            {
                if (this.LeftTree == null) this.LeftTree = new BinaryTree<T>(node);
                else this.LeftTree.Insert(node);
            }
            else
            {
                if (this.RightTree == null) this.RightTree = new BinaryTree<T>(node);
                else this.RightTree.Insert(node);
            }
            NodeAdd?.Invoke(this,new BinaryTreeEventArgs<T>("Node add") { Data = node});
            
        }

        public bool FindNode(T node)
        {
            foreach (var i in this)
            {
                if (i.CompareTo(this.Node) == 0)
                {
                    NodeFinded?.Invoke(this,new BinaryTreeEventArgs<T>("Node has been founded:") { Data = node} );
                    return true;
                }
            }
            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (this.LeftTree != null)
            {
                foreach (T i in LeftTree)
                {
                    yield return i;
                }
            }

            yield return Node;

            if (this.RightTree != null)
            {
                foreach (T i in this.RightTree)
                {
                    yield return i;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }

    public class Student : IComparable<Student>
    {
        public int TestMark { get; set; }
        public string Name { get; set; }
        public string SubjectName { get; set; }

        public int CompareTo(Student student)
        {
            if (this.TestMark > student.TestMark) return 1;
            if (this.TestMark == student.TestMark) return 0;
            if (this.TestMark < student.TestMark) return -1;
            throw new Exception("Invalid parametrs");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name} Subject: {SubjectName} Mark:{ TestMark}");
        }
    }
}
