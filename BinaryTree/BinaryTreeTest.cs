using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace BinaryTree
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void InsertMainRoot_RootBecomeHead()
        {
            Student student = new Student() { Name = "Tom", SubjectName = "Biology", TestMark = 34 };
            BinaryTree<Student> binarytree = new BinaryTree<Student>();
            binarytree.Insert_Main_Root(student);
            Assert.AreEqual(student, binarytree.Node);
        }

        [TestMethod]
        public void FindRoot_ShouldReturnTrue()
        {
            Student student = new Student() { Name = "Tom", SubjectName = "Biology", TestMark = 34 };
            BinaryTree<Student> binarytree = new BinaryTree<Student>();
            binarytree.Insert_Main_Root(student);
            var result = binarytree.FindNode(student);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIEnumerator_ShouldBeSorted()
        {
            BinaryTree<Student> binarytree = new BinaryTree<Student>();
            Student student1 = new Student() { Name = "Tom", SubjectName = "Biology", TestMark = 34 };
            Student student2 = new Student() { Name = "Tom", SubjectName = "Biology", TestMark = 80 };
            Student student3 = new Student() { Name = "Tom", SubjectName = "Biology", TestMark = 40 };
            Student student4 = new Student() { Name = "Tom", SubjectName = "Biology", TestMark = 45 };
            Student student5 = new Student() { Name = "Tom", SubjectName = "Biology", TestMark = 100 };

        }


        [TestMethod]
        [ExpectedException (typeof(NullReferenceException))]
        public void InsertRoot_ShouldReturnNullException()
        {
            Student student = null;
            BinaryTree<Student> binarytree = new BinaryTree<Student>();
            binarytree.Insert_Main_Root(student);
            
        }
    }
}
