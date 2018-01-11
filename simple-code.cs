/*
 * Created by SharpDevelop.
 * User: Meysam
 * Date: 1/11/2018
 * Time: 12:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
namespace simple_code
{
	// dynamic overloading (abstract classes and inheritance)
	// abstract class as well
	abstract class Person : Object
	{
		// encapsulation: isolating inside class utility from outside world
		// private as well
		private string firstName, lastName;
		
		
		
		
		// protected
		protected Person(string firstName = "", string lastName= "")
		{
			this.firstName = firstName;
			this.lastName = lastName;
		}
		
		
		// public
		public override string ToString()
		{
			return String.Format("Name: {0} {1}\n", this.firstName, this.lastName);
		}
		// abstract method
		protected abstract void dummy_method();
	}
	class Student : Person
	{
		
		// static field
		static int count = 0;
		
		// static method
		public static void static_function()
		{
			return;
		}
		
		
		
		private int studentID, grade;
		
		
		// property
		public int StudentID
		{
			get
			{
				return this.studentID;
			}
			set
			{
				if (value > 0)
					this.studentID = value;
				else
					Console.WriteLine("Enter positive integers!");
			}
		}
		
		// constructor
		// optional parameters as well
		public Student(int studentID = 0, string firstName = "", string lastName= "", int grade = 0) :
			base(firstName, lastName)
		{
			
			this.studentID = studentID;
			this.grade = grade;
			
		}
		// static polymorphism (operator overloading)
		// for more info refer to "https://www.tutorialspoint.com/csharp/csharp_polymorphism.htm"
		public override string ToString()
		{
			return String.Format("{0}\nStudent ID: {1}\nGrade: {2}\n", base.ToString(), this.studentID, this.grade);
		}
		protected override void dummy_method()
		{
			Console.WriteLine("dummy_method Student");
		}
		
		public void dummy_function0(out int i)
		{
			i = 5;
		}
		public void dummy_function1(ref int i)
		{
			i = 5;
		}
		public void dummy_function2(int i, int j = 0, int k = 0)
		{
			return;
		}
		
		public void dummy_function3(dynamic i)
		{
			return;
		}
		
		public void dummy_function4(int a, int b)
		{
			return;
		}
		
		public void dummy_function5(params int[] dummy_parameter)
		{
			return;
		}
	}
	// Inheritance
	class MasterStudent : Student
	{
		private string orientation;
		public MasterStudent(int studentID = 0, string firstName = "", string lastName= "",
		                     int grade = 0, string orientation = "") : base(studentID, firstName, lastName, grade)
		{
			this.orientation = orientation;
		}
		
		
		
		// start of static polymorphism
		void dummy_print(string s1)
		{
			Console.WriteLine("Static polymorphism (function overloading) : {0}", s1);
		}
		void dummy_print(string s1, string s2)
		{
			Console.WriteLine("Static polymorphism (function overloading) : {0} {1}", s1, s2);
		}
		// end of static polymorphism
		public override string ToString()
		{
			return String.Format("{0}\nOrientation: {1}\n", base.ToString(), this.orientation);
		}
		protected override void dummy_method()
		{
			Console.WriteLine("dummy_method Master Student");
		}
		
	}
	
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			
			// non generic collection
			ArrayList a = new ArrayList();
			a.Add(2);
			
			// generic collection
			List<float> b = new List<float>(4);
			b.Add(2.0f);
			
			// different types of method parameters
			// named parameter
			Student std0 = new Student(firstName: "ali", grade: 14);
			
			// ref parameter
			int i;
			std0.dummy_function0(out i);
			
			// out parameter
			std0.dummy_function1(ref i);
			
			// optional parameter
			std0.dummy_function2(i);
			
			// dynamic parameter
			std0.dummy_function3(4);
			std0.dummy_function3("4");
			
			// value type parameter
			std0.dummy_function4(4, 5);

			// params
			std0.dummy_function5(1);
			std0.dummy_function5(1, 2);
			std0.dummy_function5(1, 2, 3);
			std0.dummy_function5(1, 2, 3, 4);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
