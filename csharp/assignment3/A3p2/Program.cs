<<<<<<< HEAD
﻿using System;

class Student
{
    public int RollNumber { get; set; }
    public string FullName { get; set; }
    public string ClassName { get; set; }
    public int Semester { get; set; }
    public string BranchName { get; set; }
    private int[] SubjectMarks = new int[5];

    public Student(int rollNo, string name, string className, int semester, string branch)
    {
        RollNumber = rollNo;
        FullName = name;
        ClassName = className;
        Semester = semester;
        BranchName = branch;
    }

    public void GetMarks(int[] marks)
    {
        if (marks.Length == 5)
        {
            for (int i = 0; i < 5; i++)
            {
                SubjectMarks[i] = marks[i];
            }
        }
        else
        {
            Console.WriteLine("Please provide marks for exactly 5 subjects.");
        }
    }

    public void DisplayResult()
    {
        bool hasFailedSubject = false;
        int total = 0;

        foreach (var mark in SubjectMarks)
        {
            if (mark < 35)
            {
                hasFailedSubject = true;
            }
            total += mark;
        }

        double average = total / 5.0;

        if (hasFailedSubject || (average < 50))
        {
            Console.WriteLine("Result: Failed");
        }
        else
        {
            Console.WriteLine("Result: Passed");
        }
    }

    public void DisplayData()
    {
        Console.WriteLine($"Roll No: {RollNumber}");
        Console.WriteLine($"Name: {FullName}");
        Console.WriteLine($"Class: {ClassName}");
        Console.WriteLine($"Semester: {Semester}");
        Console.WriteLine($"Branch: {BranchName}");
        Console.Write("Marks: ");
        foreach (var mark in SubjectMarks)
        {
            Console.Write(mark + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Student student1 = new Student(101, "Rajesh Kumar", "BSc", 3, "Physics");

        student1.GetMarks(new int[] { 45, 60, 78, 90, 33 });
        student1.DisplayData();
        student1.DisplayResult();

        Console.WriteLine();

        Student student2 = new Student(102, "Sneha Sharma", "BSc", 3, "Chemistry");

        student2.GetMarks(new int[] { 40, 42, 48, 52, 49 });
        student2.DisplayData();
        student2.DisplayResult();
        Console.Read();
    }
}
=======
﻿using System;

class Student
{
    public int RollNumber { get; set; }
    public string FullName { get; set; }
    public string ClassName { get; set; }
    public int Semester { get; set; }
    public string BranchName { get; set; }
    private int[] SubjectMarks = new int[5];

    public Student(int rollNo, string name, string className, int semester, string branch)
    {
        RollNumber = rollNo;
        FullName = name;
        ClassName = className;
        Semester = semester;
        BranchName = branch;
    }

    public void GetMarks(int[] marks)
    {
        if (marks.Length == 5)
        {
            for (int i = 0; i < 5; i++)
            {
                SubjectMarks[i] = marks[i];
            }
        }
        else
        {
            Console.WriteLine("Please provide marks for exactly 5 subjects.");
        }
    }

    public void DisplayResult()
    {
        bool hasFailedSubject = false;
        int total = 0;

        foreach (var mark in SubjectMarks)
        {
            if (mark < 35)
            {
                hasFailedSubject = true;
            }
            total += mark;
        }

        double average = total / 5.0;

        if (hasFailedSubject || (average < 50))
        {
            Console.WriteLine("Result: Failed");
        }
        else
        {
            Console.WriteLine("Result: Passed");
        }
    }

    public void DisplayData()
    {
        Console.WriteLine($"Roll No: {RollNumber}");
        Console.WriteLine($"Name: {FullName}");
        Console.WriteLine($"Class: {ClassName}");
        Console.WriteLine($"Semester: {Semester}");
        Console.WriteLine($"Branch: {BranchName}");
        Console.Write("Marks: ");
        foreach (var mark in SubjectMarks)
        {
            Console.Write(mark + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Student student1 = new Student(101, "Rajesh Kumar", "BSc", 3, "Physics");

        student1.GetMarks(new int[] { 45, 60, 78, 90, 33 });
        student1.DisplayData();
        student1.DisplayResult();

        Console.WriteLine();

        Student student2 = new Student(102, "Sneha Sharma", "BSc", 3, "Chemistry");

        student2.GetMarks(new int[] { 40, 42, 48, 52, 49 });
        student2.DisplayData();
        student2.DisplayResult();
        Console.Read();
    }
}
>>>>>>> 68a266f (sqlassignment)
