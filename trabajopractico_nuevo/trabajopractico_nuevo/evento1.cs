/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 10/10/2024
 * Time: 14:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace trabajopractico_nuevo
{
	/// <summary>
	/// Description of evento1.
	/// </summary>
	public class evento1
	{
		private string nom_cliente ;
		private int dni_cliente ;
		private DateTime fecha;
		private string tipo_evento;
		private int legajo_encargado;
		private float precio_total ;
		private float senia;
		private ArrayList servicios;
		public evento1(string nom_cliente , int dni_cliente , DateTime fecha ,string tipo_evento, int legajo_encargado )
		{   
			this.precio_total = 0;
			this.senia = 0;
			this.nom_cliente= nom_cliente;
			this.dni_cliente= dni_cliente;
			this.fecha= fecha;
			this.tipo_evento= tipo_evento;
			this.legajo_encargado= legajo_encargado;
			this.servicios = new ArrayList();
				
		}
		
		//Propiedades
		
		public string NOM_CLIENTE{
		
			get{ return nom_cliente ; }
			set{nom_cliente = value;}
		
		}
		
		public int DNI_CLIENTE{
			
			get{return dni_cliente;}
			set{dni_cliente = value;}
				
		}
		public string TIPO_EVENTO{
			
			get{return tipo_evento;}
			set{tipo_evento = value;}
		
		}
		
		public int LEGAJO_ENCARGADO{
		
			get{return legajo_encargado;}
			set{legajo_encargado= value;}
		
		}
		public ArrayList SERVICIOS{
		
			get{return servicios;}
		
		}
		//Funcion
		
		public DateTime  FECHA(){
		
			return fecha;
		
		}
		//Propiedades
		public float PRECIO_TOTAL{
		
			get{ return precio_total;}
			set{precio_total = value ;}
		
		}
		
		public float SENIA {
		
			get{return senia ;}
			set{senia = value;}
		
		}
		
		//Funciones
		
		public void agregar_servicios(string servicio){
		
			this.servicios.Add(servicio);
		
		}
		
		public void eliminar_servicios(string servicio){
		
			this.servicios.Remove(servicio);
		
		}
		
		public bool existe_servicios(string servicio){
			bool flag = false;
		foreach (string i in servicios) {
				if (i == servicio) {
					flag= true;
				}
		}
			return flag;
		
		}
		public ArrayList todos_servicio ( ){
		
			return this.servicios;
		}
		
		public int cant_servicios(){
		
			return servicios.Count;
		
		}
		
		public int cant_PorServecio(string nombre){
			int cantidad =0;
		foreach (string s in this.servicios) {
				if (s == nombre) {
					cantidad ++;
				}
				
		}
		
			return cantidad;
		
		}
		public void remplazar_lista( ArrayList servicios){
		
			this.servicios = servicios ;
		
		}
		
		public bool Es_VacioServicios(){
			bool flag = false;
			int cant = this.servicios.Count;
			if (cant == 0) {
				flag = true;
			}
			return flag;
		}
		
		
		
	}
}
