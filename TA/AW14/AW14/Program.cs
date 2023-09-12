using System;
using System.Collections.Generic;
using System.Linq;

namespace AW14
{
    public class Student
    {
        public int Grade;
        public string firstname;
        public string lastname;
        public Student(string name,int grade){
            firstname=name;
            Grade=grade;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Student[] students=new Student[3];
            students[0] =new Student("Jack",16);
            students[1] =new Student("Zack",17);
            students[2] =new Student("David",12);

            var t = students.Where(data=>data.Grade>14);
            List<Student> listOfStudents=students.ToList();
            listOfStudents.ForEach(data=>System.Console.WriteLine(data.firstname));
            students.Select(stu=>new Student("aaa",20));
            students.GroupBy(stu=>stu.Grade);
            long total=students.Sum(data=>data.Grade);
        }
    }
}
