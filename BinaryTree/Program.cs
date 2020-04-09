using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student
            {
                Name = "Mark",
                SubjectName = "Biology",
                TestMark = 40
            };
            Student student2 = new Student
            {
                Name = "Kostya",
                SubjectName = "Chemestry",
                TestMark = 30
            };
            Student student3 = new Student
            {
                Name = "denis",
                SubjectName = "Math",
                TestMark = 50
            };
            Student student4 = new Student
            {
                Name = "Sick",
                SubjectName = "Drugs",
                TestMark = 45
            };

            Console.WriteLine("Menu. Enter number to continue:");
            Console.WriteLine("1.Create Binary Tree");
            Console.WriteLine("2.Insert Data to Binary Tree:");
            Console.WriteLine("3.Display Tree");
            Console.WriteLine("4.Find element by value");

            BinaryTree<Student> binaryTree = new BinaryTree<Student>();
            while (true)
            {
                int number = Convert.ToInt16(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        binaryTree.Insert_Main_Root(student1);
                        break;
                    case 2:
                        binaryTree.Insert(student2);
                        binaryTree.Insert(student3);
                        binaryTree.Insert(student4);
                        break;
                    case 3:
                        foreach (var i in binaryTree)
                        {
                            i.DisplayInfo();
                        }
                        break;
                    case 4:
                        binaryTree.FindNode(student4);
                        break;

                }
            }
        }


    }
    public static class Extensions
    {
        public static void InsertItems<T>(BinaryTree<T> tree, params T[] items) where T : IComparable<T>
        {
            foreach (T item in items)
            {
                tree.Insert(item);
            }
        }
    }
}

