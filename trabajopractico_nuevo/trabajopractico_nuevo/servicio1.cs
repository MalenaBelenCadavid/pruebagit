/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 10/10/2024
 * Time: 14:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trabajopractico_nuevo
{
	/// <summary>
	/// Description of servicio1.
	/// </summary>
	public class servicio1
	{
		private string nombre ;
		private int cant_eventos;
		private int cant_empleados;
		private float precio ;
		private string descripcion ;
		private int stock;
		
		public servicio1(string nombre , float precio , string descripcion,int stock)
		{
			this.nombre= nombre;
			this.cant_eventos= 0;
			this.cant_empleados=0;
			this.precio= precio;
			this.descripcion= descripcion;
			this.stock = stock;
		}
		
		//Propiedades
		
		public string NOMBRE{
		
			get{return nombre;}
			set{nombre = value;}
		
		}
		
		public int STOCK{
		
			get{return stock;}
			set{stock = value;}
		
		}
		public float PRECIO{
		
			get{return precio; }
			set{precio = value;}
		}
		
		public string DESCRIPCION{
		
			get {return descripcion;}
			set{descripcion = value;}
		}
		public int CANT_EVENTOS{
		
			get{return cant_eventos;}
			set{cant_eventos = value;}
		
		}
		public int CANT_EMPLEADO{
		
			get{return cant_empleados;}
			set{cant_empleados = value;}
		
		}
		
		// Funciones
		
		public void aumentar_emple(){
		
			cant_empleados ++;
		}
		
		public void aumentar_eventos(){
		
			cant_eventos ++;
		}
		public void disminuir_emple(){
		
			cant_empleados  -- ;
		
		}
		public void disminuir_eventos(){
		
			cant_eventos -- ;
		
		}
		
		
		
		
	}
	
	
	
	
	
}
