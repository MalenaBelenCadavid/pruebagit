/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 10/10/2024
 * Time: 14:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trabajopractico_nuevo
{
	/// <summary>
	/// Description of empleado1.
	/// </summary>
	public class empleado1
	{
		protected string nombre;
		protected string apellido;
		protected int dni;
		protected int legajo;
		protected float sueldo ;
		protected string labor;
		
		public empleado1(string nombre , string apellido , int dni , int legajo , float sueldo,string labor )
		{
			this.nombre=nombre;
			this.apellido= apellido;
			this.dni=  dni;
			this.legajo = legajo;
			this.sueldo = sueldo;
			this.labor= labor;
		}
		
		//propiedades
		
		public string NOMBRE{
		
			get{return nombre;}
			set{nombre = value;}
		}
		
		
		public string APELLIDO{
		
			get{return apellido;}
			set{apellido = value;}
		}
		
		public int DNI{
		
			get{return dni;}
			set{dni = value;}
		}
		public int LEGAJO{
		
			get{return legajo ;}
			set{legajo = value;}
		}
		
		public float SUELDO{
		
			get{return sueldo;}
			set{sueldo = value;}
		
		}
		public string LABOR{
		
			get{return labor;}
			set{labor = value;}
		}
		
		
		
		
		
		
		
	}
}
