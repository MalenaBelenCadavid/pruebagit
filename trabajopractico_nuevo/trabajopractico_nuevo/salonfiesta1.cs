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
	/// Description of salonfiesta1.
	/// </summary>
	public class salonfiesta1
	{
		private ArrayList eventos ;
		private ArrayList servicios;
		private ArrayList empleados;
		private string nombre;
		public salonfiesta1(string nombre)
		{
			this.nombre= nombre;
			this.empleados = new ArrayList();
			this.eventos = new ArrayList();
			this.servicios = new ArrayList();
		}
		
		//Propiedad 
		
		public string NOMBRE{
		
			set{nombre = value;}
			get{return nombre;}
		
		}
		
		// Funciones 
		
		public void agregar_eventos( evento1 e){
		
			this.eventos.Add(e);
		
		}
		public void eliminar_evento(evento1 e){
		
			this.eventos.Remove(e);
		}
		public bool existeEventos(DateTime fecha)
		{  bool flag = false;
			foreach (evento1 e in this.eventos)
			{
				if (e.FECHA() == fecha) // Comparando solo la parte de la fecha
				{
					flag = true;
					break;
				}
			}
			return flag;
		}

		
		public evento1 ver_evento(DateTime fecha){
			evento1 resultado = null ;
		foreach (evento1 e in this.eventos) {
				if (e.FECHA() == fecha.Date ) {
				resultado = e;
			}
		}
			return resultado;
		}
		
		
		public ArrayList todos_eventos(){
		
			return this.eventos;
		}
		
		public int cant_eventos(){
		
			return this.eventos.Count;
		}
		public bool esvacio_eventos(){
			bool flag = false;
			int resultado = this.eventos.Count;
		 	if (resultado == 0 ) {
		 	flag = true;
		 	}
			return flag;
		}
		
		
		
		public void agregar_servicio( servicio1 s ){
		
			this.servicios.Add(s);
		
		}
		
		public void eliminar_servicio(servicio1 s){
		
			this.servicios.Remove(s);
		}
		
		public bool existe_servicio(string nombre){
			bool flag = false;
			foreach (servicio1 s in this.servicios) {
				if (s.NOMBRE == nombre) {
					flag = true;
					break;
				}
				
			}	
			return flag;
			}
			
		
		public servicio1 ver_servicio( string nombre){
			servicio1 ser = null ;
			foreach (servicio1 s in this.servicios) {
				if (s.NOMBRE == nombre) {
					ser = s;
					break;
				}
			}
			return ser;
		
		}

		public ArrayList Todos_servicios(){
		
			return this.servicios;
		
		}
        
		public int cant_servicios(){
		
			int resultado = servicios.Count;
			return resultado;
		}
         
		public bool EsVacio_servicio(){
			bool flag = false;
			int resultado = servicios.Count;
			if (resultado == 0) {
				flag = true;
			}
			return flag;
		}

        

		
		
		
		public void agregar_empleado(empleado1 e){
		
			this.empleados.Add(e);
		
		}
		public void eliminar_empleado(empleado1 s){
		
			this.empleados.Remove(s);
		
		}
		public bool exite_empleado(int legajo){
			bool flag = false;
			foreach (empleado1 e in this.empleados) {
			  if (e.LEGAJO == legajo) {
			        flag = true;
			        
			}
		}
			return flag;
		
		}


		public empleado1 ver_empleado(int legajo ){
		
			empleado1 empleado = null;
			foreach (empleado1 e in this.empleados) {
				if (e.LEGAJO == legajo) {
					empleado= e;
					break;
				}
			}
			return empleado;
		}

       
		public ArrayList todos_empleados(){
		
			return this.empleados;
		
		}
        
		public int cant_emleados(){
		
			int resultado = this.empleados.Count;
			return resultado;
		}
        
		public bool esVacio_Empleados(){
			bool flag = false ;
			int resultado = this.empleados.Count;
		if (resultado == 0) {
			flag = true;
		}
		
		return flag ;
		}

        // Remplazan listas
        
		public void Set_empleados(ArrayList e ){
		
			this.empleados = e;
		
		}
        
		public void Set_eventos(ArrayList e){
		
			this.eventos = e;
		}
		public void Set_servicios(ArrayList s){
		
			this.servicios= s;
		
		}






























































		
			
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}

