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
	abstract class Building : Object
	{
		// encapsulation: isolating inside class utility from outside world
		// private as well
		private string name, location;
		
		
		
		
		// protected
		protected Building(string name = "", string location= "")
		{
			this.name = name;
			this.location = location;
		}
		
		
		// public
		public override string ToString()
		{
			return String.Format("Name: {0}\nLocation: {1}\n", this.name, this.location);
		}
		// abstract method
		protected abstract void dummy_method();
	}
	class Cinema : Building
	{
		
		// static field
		static int count = 0;
		
		// static method
		public static void static_function()
		{
			return;
		}
		
		
		
		private int cinemaID, cinemaRate;
		
		
		// property
		public int CinemaID
		{
			get
			{
				return this.cinemaID;
			}
			set
			{
				if (value > 0)
					this.cinemaID = value;
				else
					Console.WriteLine("Enter positive integers!");
			}
		}
		
		// constructor
		// optional parameters as well
		public Cinema(int cinemaID = 0, string name = "", string location= "", int cinemaRate = 0) :
			base(name, location)
		{
			
			this.cinemaID = cinemaID;
			this.cinemaRate = cinemaRate;
			
		}
		// static polymorphism (operator overloading)
		// for more info refer to "https://www.tutorialspoint.com/csharp/csharp_polymorphism.htm"
		public override string ToString()
		{
			return String.Format("{0}\nCinema ID: {1}\nCinema Rate: {2}\n", base.ToString(), this.cinemaID, this.cinemaRate);
		}
		protected override void dummy_method()
		{
			Console.WriteLine("dummy_method Cinema");
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
	class CinemaFajr : Cinema
	{
		private string manager;
		public CinemaFajr(int cinemaID = 0, string name = "", string location= "",
		                     int cinemaRate = 0, string manager = "") : base(cinemaID, name, location, cinemaRate)
		{
			this.manager = manager;
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
			return String.Format("{0}\nOrientation: {1}\n", base.ToString(), this.manager);
		}
		protected override void dummy_method()
		{
			Console.WriteLine("dummy_method CinemaFajr");
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
			Cinema std0 = new Cinema(name: "ali", cinemaRate: 14);
			
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
