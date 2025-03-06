/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 10/10/2024
 * Time: 14:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace trabajopractico_nuevo
{
	class Program
	{
		
		
		
		public static void Main(string[] args)
		{
			salonfiesta1 LosAncos= new salonfiesta1(" LosAncos ");
			
			//se agregan los servicios al salon de fiesta 
			
			servicio1 catering = new servicio1("catering" ,1000,"bebidas comidas ",2);
			servicio1 CamaElastica = new servicio1("cama elastica" , 200 , "2 mt x 2 mt" , 2);
			servicio1 Ser_Camareros= new servicio1("atencion al cliente" , 700, "Disponibilidad en todo el evento " , 2);
			servicio1 DJ = new servicio1("hermanos DJ" , 800 , "musica electronica ", 1);
			servicio1 iluminacion = new servicio1("Dia" , 400 , "luces tenues " , 2);
			LosAncos.agregar_servicio(catering);
			LosAncos.agregar_servicio(CamaElastica);
			LosAncos.agregar_servicio(Ser_Camareros);
			LosAncos.agregar_servicio(DJ);
			LosAncos.agregar_servicio(iluminacion);
			
			// Para ejecutar la funcion reservar evento se necesita tener un encargado ya a disposicion 
			
			
			Console.WriteLine("BIENVENIDO AL SALOS : LOS ANCOS ");
			Console.WriteLine("ingrese una opcion del menu ofreciso a continuacion : " );
			Console.WriteLine("opcion 0 : para terminar ");
			Console.WriteLine("opcion 1 : reservar evento ");
			Console.WriteLine("opcion 2 : eliminar evento ");
			Console.WriteLine("opcion 3 : dar de alta emleado/encargado " );
			Console.WriteLine("opcion 4 : dar de baja empleado/ encargado " );
			Console.WriteLine("opcion 5 : eliminar servicio a evento o salon ");
			Console.WriteLine("opcion 6 : agregar servicio a evento o salon " );
			Console.WriteLine("opcion 7 : listados del evento ");
			Console.WriteLine("opcion 8 : reasignar labor de empleado o eventos de encargado / cambiar de empleado a encarago o viceverza " );
			Console.WriteLine("/ reasignar todos los empleados de un servicio ");
			Console.WriteLine("-------------------------------------------");
			Console.WriteLine("Para reservar evento agregue un encargado almenos ");
			
			int opcion = int.Parse(Console.ReadLine());
			while(opcion != 0 ){
			switch (opcion) {
				
				case 1 :
					Console.WriteLine("Ingrese una fecha (formato: dd/MM/yyyy):");
					// Leer la entrada del usuario
					string entrada = Console.ReadLine();
					// Variable para almacenar la fecha
					DateTime fecha;
					// Intentar convertir la entrada a un objeto DateTime
					if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha))
					{
						// Si la conversión es exitosa, mostrar la fecha
						Console.WriteLine("Fecha ingresada correctamente: " + fecha.ToShortDateString());
						bool flag= false;
						foreach (evento1 eve in LosAncos.todos_eventos()) {
							if(eve.FECHA()== fecha){
								flag = true;
								break;
							}
						}
						if (flag == true){
						
						try {    // si ya existe evento lanza una excepcion
								throw new excepcionFecha(" Ya existe un evento es una fecha ");
						} catch (excepcionFecha e) {
							
								Console.WriteLine( e.motivo);
						}
						
						}
						else  //si no coinside con ningun evento entra en la funcion
							reservar_evento(ref LosAncos,ref fecha);
						
					}
				   else
					
						// Si la conversión falla, mostrar un mensaje de error
				   	Console.WriteLine("Fecha inválida. Asegúrese de usar el formato dd/MM/yyyy.");
					
				   break;
					
				case 2 :
				   cancelar_evento(ref LosAncos);
				   break;
				   
				case 3 :
				   Dar_de_alta_empleado_encargado(ref LosAncos);
				   break;
				   
				case 4: 
				   Dar_de_baja_empleado(ref  LosAncos);
				   break;
				   
			    case 5 :
				   eliminar_servicio(ref  LosAncos );
				   break;
				   
				  case 6 :
				   Agregar_servicio(ref  LosAncos);
				   break;
				   
				  case 7 :
				   listados_eventos( ref LosAncos);
				   break;
				   
				  case 8 :
				   reasignar_labor_empleado_encargado(ref LosAncos );
				   break;
				   
			}
				
			Console.WriteLine("BIENVENIDO AL SALOS : LOS ANCOS ");
			Console.WriteLine("ingrese una opcion del menu ofreciso a continuacion : " );
			Console.WriteLine("opcion 0 : para terminar ");
			Console.WriteLine("opcion 1 : reservar evento ");
			Console.WriteLine("opcion 2 : eliminar evento ");
			Console.WriteLine("opcion 3 : dar de alta emleado/encargado " );
			Console.WriteLine("opcion 4 : dar de baja empleado/ encargado " );
			Console.WriteLine("opcion 5 : eliminar servicio a evento o salon ");
			Console.WriteLine("opcion 6 : agregar servicio a evento o salon " );
			Console.WriteLine("opcion 7 : listados del evento ");
			Console.WriteLine("opcion 8 : reasignar labor de empleado o eventos de encargado / cambiar de empleado a encarago o viceverza " );
			Console.WriteLine("/ reasignar todos los empleados de un servicio ");
			Console.WriteLine("----------------------------------------------------");
			opcion = int.Parse(Console.ReadLine());
			                 
			}
			Console.WriteLine(" Finalizacion de programa " );
			Console.ReadKey(true);
		}
		
		
		
		public static void Agregar_servicio( ref salonfiesta1 s ){
		
			Console.WriteLine ( "ingrese nombre del servicio : " );
			string nombre = Console.ReadLine();
			Console.WriteLine("para agregar servicio a un evento: 1");
			Console.WriteLine("para agregar servicio a salon de fiesta: 2 ");
			int respuesta = int.Parse(Console.ReadLine());
			switch (respuesta) {
				
				case 1 :
					bool condicion = s.existe_servicio(nombre);
					if (condicion == true) {
						
					Console.WriteLine("Ingresa la fecha del evento (formato: dd/MM/yyyy):");
					string inputFecha = Console.ReadLine();
					DateTime fechaEvento;
					//lo que hace esta linea es forzar al sistema que el formato de la fecha no sea interpretada por el sistema y ahaga exactamente la forma de 
					//fecha que le pedimos , a su vez si esta coincide con el formato del string lo que va a ser es devolver true al inspecionar que coincida sino false
					bool esValida = DateTime.TryParseExact(inputFecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaEvento);
					if (esValida)
					{
						Console.WriteLine("Fecha ingresada correctamente: " + fechaEvento.ToString("dd/MM/yyyy"));
						bool respuesta2 = s.existeEventos(fechaEvento);//fija si existe evento en salon
						if (respuesta2== true){
							
							
							evento1 evento = s.ver_evento(fechaEvento);
							
							int stock = s.ver_servicio(nombre) .STOCK;
							// si se le quiere sumar un servcio se tiene que comprobar que la cantidad de servicios en el arraylist del evento no supere con la nueva suma el stock 
							// del objeto servicio de ese tipo
							if (evento.cant_PorServecio(nombre) + 1 <= stock) {
								                               
								s.ver_evento(fechaEvento).agregar_servicios(nombre);//agrega servicio en el evento directamente en el salon
								Console.WriteLine ("Se pudo Agregar servicio Exitosamente ");
								servicio1 servicioo = s.ver_servicio(nombre);
								servicioo.aumentar_eventos();//aumenta los eventos en el servcio elegido
								
								evento.PRECIO_TOTAL = evento.PRECIO_TOTAL + servicioo.PRECIO;//asigna al evento el total en base a lo que se va cargando
								float porecentaje = (float)0.10;
								evento.SENIA= (evento.PRECIO_TOTAL*porecentaje);//asigna senia al evento en base a lo que se va cargando
								Console.WriteLine("Nuevo precio es : " + evento.PRECIO_TOTAL );
								Console.WriteLine("Nueva senia es : "+ evento.SENIA);
								Console.WriteLine("------------------------------------------");
								
								
								}
							else{
								
								Console.WriteLine (" Se supera la cantidad de stock del servicio " );
								Console.WriteLine("------------------------------------------------");
							}
						}
						else{
						Console.WriteLine(" No existe evento para esa fecha ");
						Console.WriteLine("---------------------------------");
						}
					}
					else
					{
						Console.WriteLine("La fecha ingresada no es válida. Asegúrate de usar el formato dd/MM/yyyy.");
						Console.WriteLine("--------------------------------------------------------------------------");
					}
					}
					else{
						Console.WriteLine("No existe el servicio ");
						Console.WriteLine("----------------------");
					}
					break;
					
					
				case 2 :
					//crea objeto tipo servicio1
					Console.WriteLine("Ingrese nombre del servicio " );
					string nombre1 = Console.ReadLine();
					Console.WriteLine("Ingrese stock del servicio : ");
					int cantidad  = int.Parse(Console.ReadLine());
					Console.WriteLine("Ingrese descripcion del servico ");
					string descripcion = Console.ReadLine();
					Console.WriteLine("Ingrese costo unitario : ");
					float precio = float.Parse(Console.ReadLine());
					
					servicio1 n = new servicio1(nombre1,precio,descripcion,cantidad);
					s.agregar_servicio(n);//agrega en el salon
					Console.WriteLine("Servicio cargado exitosamente ");
					Console.WriteLine("--------------------------------");
					
					break;
					    
			}
			                          

		
		 }
		
		
		
		
		
		public static void eliminar_servicio (  ref salonfiesta1 s){
		
			Console.WriteLine("Para eliminar servicio de evento opcion : 1 ");
			 Console.WriteLine("Para elimar servicio de el salon : 2 " );
		    
		int respuesta3 = int.Parse(Console.ReadLine());
		Console.WriteLine("Ingrese nombre del servicio " );
		string nombre = Console.ReadLine();
		if(s.existe_servicio(nombre)){ // si existe servcio
		switch (respuesta3) {
			
			case 1:
				
				Console.WriteLine("Ingresa la fecha del evento (formato: dd/MM/yyyy):");
				string inputFecha = Console.ReadLine();
				DateTime fechaEvento;
				// Intenta convertir la cadena con un formato específico
				bool esValida = DateTime.TryParseExact(inputFecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaEvento);
				if (esValida)
				{  // si es valida fecha
					Console.WriteLine("Fecha ingresada correctamente: " + fechaEvento.ToString("dd/MM/yyyy"));
					bool res3 = s.existeEventos(fechaEvento);
					
					if (res3 == true) { // si existe evento
						
						if(s.ver_evento(fechaEvento).Es_VacioServicios() == false){// si la lista de servicios del evento no es vacia 
						  
						s.ver_evento(fechaEvento).eliminar_servicios(nombre);//elimina servcio del evento
						s.ver_servicio(nombre).disminuir_eventos();// disminuye eventos de el servicio elegido
						s.ver_evento(fechaEvento).PRECIO_TOTAL =s.ver_evento(fechaEvento).PRECIO_TOTAL - (s.ver_servicio(nombre).PRECIO);//le resta al precio total del evento el costo unitario del servcio
						if(s.ver_evento(fechaEvento).PRECIO_TOTAL > 0){ //el precio va a tener que ser mayor a 0 para que se calcule una nueva senia , no va a calcular en base a 0
						float porcentaje = (float) 0.10 ;
						s.ver_evento(fechaEvento).SENIA =( s.ver_evento(fechaEvento).PRECIO_TOTAL*porcentaje);
						}
						else{
							s.ver_evento(fechaEvento).SENIA = 0 ;//si es precio es 0 la senia va a ser de 0
						}
						Console.WriteLine("Se pudo eliminar exitosamente servicio ");
						Console.WriteLine("nuevo precio es : " + s.ver_evento(fechaEvento).PRECIO_TOTAL);
						Console.WriteLine("nueva senia es de : " + s.ver_evento(fechaEvento).SENIA);
						Console.WriteLine("-----------------------------------------------------------");
						
					}
					else{
						Console.WriteLine("La lista de servicios es vacia ");
						Console.WriteLine("---------------------------------");
						}
					}
					else{
						Console.WriteLine("No existe evento ");
						Console.WriteLine("-------------------");
					}

				}
				else
				{
					Console.WriteLine("La fecha ingresada no es válida. Asegúrate de usar el formato dd/MM/yyyy.");
					Console.WriteLine("--------------------------------------------------------------------------");
				}
				break;
				
			case 2 :
				
				bool flag = s.existe_servicio(nombre);//si existe evento 
				if (flag == true) {
					
					if(s.ver_servicio(nombre).CANT_EVENTOS == 0){// se fija que cantidad de eventos en servicio tiene q ser 0 
					
						if (s.ver_servicio(nombre).CANT_EMPLEADO== 0) {// se fija que cantidad de empleados en servicio tiene ques ser 0
							
							s.eliminar_servicio(s.ver_servicio(nombre));// si cumple con todas las condiciones se puede eliminar
							Console.WriteLine("Se pudo eliminar exitosamente servicio ");
							Console.WriteLine("---------------------------------------");
						}
					else{
						Console.WriteLine("No se puede elimnar servicio por que tiene empleados asignados ");
						Console.WriteLine("----------------------------------------------------------------");
						}
					}
					else{
						Console.WriteLine("No se puede eliminar por q hay contratos con este servicio ");
						Console.WriteLine("---------------------------------------------------------");
					}
				}
				
				else{
					Console.WriteLine("No existe el servicio");// sino
					Console.WriteLine("----------------------");
				}
				break;
				
			default:
			Console.WriteLine("Opcion incorrecta " );
			Console.WriteLine("------------------");
		     break;
		     
		     
		     
		}
		}
		else{
			Console.WriteLine("No existe servicio , pruebe denuevo ");
			Console.WriteLine("-------------------------------------");
		}
		}
		
		
		
		public static void Dar_de_baja_empleado( ref  salonfiesta1 s){
		
		Console.WriteLine("Ingrese el legajo o encargado : ");// pide legajo del empleado/encargado
		int legajo = int.Parse(Console.ReadLine());
		bool flag = s.exite_empleado(legajo);// se fija si existe empleado/encargado
		
		if(flag  ){// comprueba
		bool encargado = false;
		foreach (empleado1 emple in s.todos_empleados()) {//compueba que el legajo ingresado sea de un encargado o empleado
			if ((emple.LABOR == "encargado" )&& ( emple.LEGAJO == legajo)) {
				    encargado = true;
				   break;
			}
		}
		
		if (encargado) {// si es encargado
			var Encargado = (encargado1 )(s.ver_empleado(legajo));
			if (Encargado.CANT_EVENTOS == 0) {// si encargado tiene una cantidad de eventos 0 se elimina , sino se va a tener que reasignar las laboress del mismo para borrarlo
				s.eliminar_empleado(Encargado);
				Console.WriteLine("Se pudo borrar legajo de encargado ");
				Console.WriteLine("--------------------------------------");
			}
			else{
				Console.WriteLine("No se puede eliminar encargado , tiene eventos a cargo ");
			     Console.WriteLine("Reasigne los eventos del encargado y se podra borrar registro del encargado ");
			     Console.WriteLine("----------------------------------------------------------------------------");
			}
			
		}	              
		if(!encargado){
			// si no es encargdo no hay problema en borrarlo ya que no hay una activida que dependeda exclusivamente de este
		    //borrar el empleado sin que dependla de la cantidad de emple en el servicio nos permite mas fluides en la ejecucion del programa
		
			string labor= (s.ver_empleado(legajo).LABOR);
			s.ver_servicio(labor).disminuir_emple();// disminuye cantidad de empleados en el servicio 
			s.eliminar_empleado(s.ver_empleado(legajo));
			Console.WriteLine("Se pudo borrar legajo de empleado");
			Console.WriteLine("-----------------------------------");
		
		}

			
		}
		else{
			Console.WriteLine("No existe empleado /empledo");
			Console.WriteLine("-----------------------------");
		}
		
		
		}
		
		
		
		
		
		
		public static void Dar_de_alta_empleado_encargado( ref salonfiesta1 s){
		
			Console.WriteLine("Para contratar empleado  ingrese opcion : 1 ");
			Console.WriteLine("Para contratar encargado ingrese opcion : 2" );
		
		int respuesta= int.Parse(Console.ReadLine());
		
		
		switch (respuesta) {
				
			case 1 :
				Console.WriteLine("Ingrese nombre del empleado : ");
				string nombre = Console.ReadLine();
				Console.WriteLine("Ingrese apellido del empleado : ");
				string apellido = Console.ReadLine();
				Console.WriteLine("Ingrese legajo del empleado : " );
				int legajo = int.Parse(Console.ReadLine());
				bool flag = s.exite_empleado(legajo);// verifica que exita empleado
				if (flag == true){
						
						try {
								throw new Legajoexistente(" Ya existe empleado con ese legajo , intente con otro ");// si existe un legajo igual en otro empleado erroja excepcion
						} catch (Legajoexistente e) {
							
								Console.WriteLine( e.motivo);
						}
						
						}
				if(flag == false){// si no
				Console.WriteLine("Ingrese DNI del empleado : ");
				int dni = int.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese sueldo del empleado " );
				float sueldo = float.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese la labor al q se va a dedicar : ");
				foreach (servicio1 ese in s.Todos_servicios()) {//muestra servcicos para asignar al empleados
					Console.WriteLine("Nombre : "+ ese.NOMBRE);
					Console.WriteLine("Empleados ya signados en el servicio : "+ ese.CANT_EMPLEADO);
					Console.WriteLine("-----------------------------------------------------------");
					
				}
				Console.WriteLine("-----------------------------");
				string labor = Console.ReadLine();
				s.ver_servicio(labor).aumentar_emple();//aumento empleados en el servcio elegido
				empleado1 empleado = new empleado1(nombre,apellido,dni,legajo,sueldo,labor);
				s.agregar_empleado(empleado);//se agrega el empleado
				Console.WriteLine("Empleado cargado exitosamente  ");
				Console.WriteLine("--------------------------------");
				}
				break;
				
				
			case 2 :
				
				Console.WriteLine("Ingrese nombre del encargado : ");
				string nombre2 = Console.ReadLine();
				Console.WriteLine("Ingrese apellido del encargado : ");
				string apellido2 = Console.ReadLine();
				Console.WriteLine("Ingrese legajo del encargado : " );
				int legajo2 = int.Parse(Console.ReadLine());
				bool flag2 = s.exite_empleado(legajo2);
				if (flag2 == true){
						
						try {
								throw new Legajoexistente(" Ya existe empleado con ese legajo, intente con otro"); // si ya existe lejago arroja excepcion
						} catch (Legajoexistente e) {
							
								Console.WriteLine( e.motivo);
						}
						
						}
				if(flag2 == false){//sino
				Console.WriteLine("Ingrese DNI del encargado : ");
				int dni2 = int.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese sueldo del encargado " );
				float sueldo2 = float.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese plus del sueldo ");
				float plus2 = float.Parse(Console.ReadLine());
				
				encargado1 encargado = new encargado1 (nombre2,apellido2,dni2,legajo2,sueldo2,"encargado",plus2);
				s.agregar_empleado(encargado);//agrega encargado
				Console.WriteLine("Encargado cargado exitosamente ");
				Console.WriteLine("-------------------------------");
				}
				break;
				
			default:
				Console.WriteLine("Opcion incorrecta intente denuevo " );
				Console.WriteLine("-----------------------------------");
				break;
			
		}
		
		
		}
		
		
		public static void reservar_evento( ref salonfiesta1 s,ref DateTime f){
		    
			bool flag1 = false;
			foreach (empleado1 element in s.todos_empleados()) { // se fija que antes de emppezar la reserva halla un encargado disponible
				if (element.LABOR == "encargado") {
					flag1 = true;
				}
			}
			if(flag1 == true){
			Console.WriteLine("ingrese nombre del cliente : " );
			string nombre = Console.ReadLine();
			Console.WriteLine("ingrese dni del cliente : " );
			int dni = int.Parse(Console.ReadLine());
			Console.WriteLine("ingrese legajo del encargado a eleccion : ");	
			foreach (empleado1 E in s.todos_empleados()) {
				if (E.LABOR == "encargado") { // muestra los encargados dispibles
					Console.WriteLine("nombre : " + E.NOMBRE +" . " +E.APELLIDO);
					Console.WriteLine("legajo : " +E.LEGAJO);
				}
				
			}
			int legajo = int.Parse(Console.ReadLine()); 
			
			ArrayList nueva = new ArrayList();// lista a la que se le van a ir asignando los servcios
			Console.WriteLine("ingrese tipo de evento " );
			string tipo = Console.ReadLine();
			evento1 nuevo1 = new evento1(nombre,dni,f,tipo,legajo);
			float precio  = 0;
			if(s.EsVacio_servicio() == false){ // si no la lista no es vacia
			Console.WriteLine("Toque 1 para cargar servicio y para terminar opcion 0 : " );
			int respuestar4 = int.Parse(Console.ReadLine());
		    while (respuestar4 != 0) {
				foreach (servicio1 ese in s.Todos_servicios()) {// se imprimen los servcios disponibles
					Console.WriteLine(" nombre : "+ ese.NOMBRE);
					Console.WriteLine("precio : " + ese.PRECIO);
					Console.WriteLine("stock : " + ese.STOCK);
		    	}
				Console.WriteLine("Ingrese el nombre del servicio " );
				string servicio = Console.ReadLine();
				servicio1 ser = (servicio1) s.ver_servicio(servicio);
				
				if (ser.STOCK >= 1 + cant_PorServecio(servicio,nueva)) {// compruba que el stock de el servcio en el arraylist no sea mayor que el del objeto
					ser.aumentar_eventos();// se aumenta evento al servcio elegido
					nueva.Add(servicio);// lo agrega en la lista
					precio = ser.PRECIO + precio;//va calculando el precio total del salon
				}
				else{
					Console.WriteLine("supera el stock " );
					Console.WriteLine("elija otro servicio " );
					Console.WriteLine("---------------------");
				}
				   
			Console.WriteLine("Toque 1 para cargar servicio y para terminar opcion 0 : " );
			respuestar4 = int.Parse(Console.ReadLine());	   
		    }
			}
			else 
				Console.WriteLine(" No hay servicios en el salon, pero su evento se guardo correctamente ,elija la opcion cargar servicios a salon y luego agreguelo al evento  ");
			    
			nuevo1.PRECIO_TOTAL= precio;// se le asigan en el caso de no a ver servcios 0 al igaul que a la senia
			float porcentaje =(float) 0.10 ;
			nuevo1.SENIA= (precio * porcentaje);
			nuevo1.remplazar_lista(nueva);// se guarda la lista de servicios
		
			s.agregar_eventos(nuevo1);
			encargado1 asignado = (encargado1 )s.ver_empleado(nuevo1.LEGAJO_ENCARGADO);
			asignado.aumentar_eventos();//al encargado elegido se le aumentan los eventos
			Console.WriteLine("Evento reservado exitosamente ");
			Console.WriteLine("-------------------------------");
		
		}
			else{
			Console.WriteLine("No hay encargado , porfavor cargue un encargado y pruebe denuevo " );
			Console.WriteLine("------------------------------------------------------------------");
			}
		}
		
		
		public static int cant_PorServecio(string nombre,ArrayList n){
		// nos va a ayudar a contar cuantos servcios hay en la arraylsit que se va a remplazar en el objeto , nos ayuda a no pasarnos del stock
			int cantidad =0;
		foreach (string s in n) {
				if (s == nombre) {
					cantidad ++;
				}
				
		}
		
			return cantidad;
		
		}
		
		
		
		
		
		public static void cancelar_evento( ref salonfiesta1 s){
		
		Console.WriteLine("Ingresa la fecha del evento (formato: dd/MM/yyyy):");
        string inputFecha = Console.ReadLine();

        DateTime fechaEvento;

        // Intenta convertir la cadena con un formato específico
        bool esValida = DateTime.TryParseExact(inputFecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaEvento);

        if (esValida)
        {
            Console.WriteLine("Fecha ingresada correctamente: " + fechaEvento.ToString("dd/MM/yyyy"));
       
            bool resultado = s.existeEventos(fechaEvento);//comprobar si existe evento
            
            if (resultado == true) {
            	
            		
            	if(((s.ver_evento(fechaEvento).FECHA()) - DateTime.Now).Days > 30){// compruba si se cancela en menos de un mes
            			Console.WriteLine("Retencion de senia por cancelacion ");
            	}
            	else {
            		Console.WriteLine("tiene una deuda de : " + s.ver_evento(fechaEvento).PRECIO_TOTAL);
            	}
            	Console.WriteLine(" Desea cancelar evento para SI oprima 1 , NO oprima 0 :");
            	int respuesta = int.Parse(Console.ReadLine());
            	if(respuesta == 1 ){
            	for (int i = 0; i <s.ver_evento(fechaEvento).cant_servicios() ; i++) {
            		// se va recorrer la lista de servcios del evento y se va a ir reformando la cantidades de los ervcios asigandos
            			string var =(string) s.ver_evento(fechaEvento).todos_servicio()[i];
            			s.ver_servicio(var).disminuir_eventos();
            	    }
            	
            		encargado1 encargado = (encargado1)s.ver_empleado(s.ver_evento(fechaEvento).LEGAJO_ENCARGADO);
            		encargado.disminuir_eventos();// disminuye cantidad de servicios al encargado asignaddo
            		s.eliminar_evento(s.ver_evento(fechaEvento));//eleimina el evento
            		Console.WriteLine("Se elimino exitosamente evento " );
            		Console.WriteLine("-------------------------------");
            		

            	}
            	else{
            		Console.WriteLine("Negacion de cancelacion exitosa ");
            		Console.WriteLine("---------------------------------");
            	}
            }
            else{
            	Console.WriteLine("No existe evento ");
            	Console.WriteLine("------------------");
            }

        }
        else
        {
            Console.WriteLine("La fecha ingresada no es válida. Asegúrate de usar el formato dd/MM/yyyy.");
            Console.WriteLine("-------------------------------------------------------------------------");
        }
		
	
		
		
		}
			
			
			
		
		
  	public static void listados_eventos( ref salonfiesta1 s){
		
		 Console.WriteLine("elija una opcion : ");
		 Console.WriteLine( " opcion 1 : listado de eventos " );
		 Console.WriteLine(" opcion 2 : listado de clientes " );
		 Console.WriteLine(" opcion 3 : listado de empleados " );
		 Console.WriteLine(" Opcion 4 : listados_eventos  de un mes determinado ");
		 Console.WriteLine("opcion 5 : Listado de servicios del salon ");
		 int respuesta4 = int.Parse(Console.ReadLine());
		switch (respuesta4 ) {
			
		 		case 1 :
		 		if(s.esvacio_eventos() == false){
		 			foreach (evento1 E in s.todos_eventos()) {
		 			
		 			Console.WriteLine("Nombre cliente: " + E.NOM_CLIENTE);
                Console.WriteLine("DNI del cliente: " + E.DNI_CLIENTE);
                Console.WriteLine("Precio total: " + E.PRECIO_TOTAL);
                Console.WriteLine("Precio señia: " + E.SENIA);
                Console.WriteLine("legajo encargado : "+E.LEGAJO_ENCARGADO);
                Console.WriteLine("Tipo de evento: " + E.TIPO_EVENTO);
                Console.WriteLine("Servicios: ");
                if(!E.Es_VacioServicios()){

                // Usamos un diccionario para contar la cantidad de cada servicio
                Dictionary<string, int> servicioContador = new Dictionary<string, int>();

                foreach (string servicio in E.todos_servicio())
                {
                    if (servicioContador.ContainsKey(servicio))
                    {
                        servicioContador[servicio]++;
                    }
                    else
                    {
                        servicioContador[servicio] = 1;
                    }
                }

                // Mostramos los servicios y sus cantidades
                foreach (var servicio in servicioContador)
                {
                    Console.WriteLine("Servicio: " + servicio.Key + " - Cantidad: " + servicio.Value);
                }

					 
					 Console.WriteLine("-----------------------------------------");
		 		}
		 		
                else{
                	Console.WriteLine("no hay servicios en la lista ");
                	Console.WriteLine("-----------------------------");
                }
		 		}
		 		}
		 		else
		 			Console.WriteLine("La lista de eventos esta vacia " );
		 		    Console.WriteLine("-------------------------------------");
		 		break;
		 		
		 	case 2:
		 		
		 		if( s.esvacio_eventos() == false){
		 			foreach (evento1 eve in s.todos_eventos()) {
		 				Console.WriteLine("Nombre : "+ eve.NOM_CLIENTE);
		 				Console.WriteLine("DNI del cliente : " +eve.DNI_CLIENTE);
		 				Console.WriteLine("----------------------------------");
		 			}
		 		}
		 		else
		 			Console.WriteLine("La lista de clientes actuales es vacia ");
		 		Console.WriteLine("---------------------------------------");
		 		
		 		break;
		 		
		 	case 3 :
		 		if (s.esVacio_Empleados()== false) {
		 			
		 			foreach (empleado1 emple in s.todos_empleados()) {
		 				Console.WriteLine(" Nombre : "+ emple.NOMBRE);
		 				Console.WriteLine("Apellido : "+ emple.APELLIDO);
		 				Console.WriteLine("Legajo : " + emple.LEGAJO);
		 				Console.WriteLine("Sueldo : " + emple.SUELDO);
		 				Console.WriteLine("Labor : " + emple.LABOR);
		 				if (emple.LABOR == "encargado") {
		 					encargado1 encargado = (encargado1)emple;
		 					Console.WriteLine("Cantidad de eventos a cargo : " + encargado.CANT_EVENTOS);
		 					Console.WriteLine("Plus a cobrar es : " + encargado.PLUS_SUELDO);
		 				}
		 				Console.WriteLine("--------------------------------------");
		 			}
		 		}
		 		else
		 			Console.WriteLine("La lista de empleados esta vacia " );
		 		Console.WriteLine(" --------------------------------------");
		 		
		 		break;
		 		
		 	case 4:
		 		if(s.esvacio_eventos() == false){
		 		Console.WriteLine("Ingrese el mes (1-12) que desea filtrar:");
		 		int mes = int.Parse(Console.ReadLine());
		 		// Validar el mes ingresado
		 		if (mes < 1 || mes > 12)
		 		{
		 			Console.WriteLine("Mes inválido. Debe estar entre 1 y 12.");
		 			return;
		 		}
		 		// Filtrar eventos por el mes ingresado 
		 		bool hayEventos = false; // Variable para controlar si hay eventos en el mes
		 		
		 		Console.WriteLine("Eventos en el mes : "+ mes );
		 		for (int i = 0; i < s.cant_eventos(); i++)
		 		{
		 			if (((evento1)s.todos_eventos()[i]).FECHA().Month == mes)
		 			{
		 				hayEventos = true; // Cambiamos a verdadero si encontramos un evento
		 				Console.WriteLine("si hay evento/s ");
		 				
		 			}
		 		}
		 		// Si no hay eventos, informar al usuario
		 		if (!hayEventos)
		 		{
		 			Console.WriteLine("No hay eventos para el mes :"+ mes);
		 		}
		 		if (hayEventos) {// si hay eventos
		 			foreach (evento1 E in s.todos_eventos()) {
		 				if (E.FECHA().Month == mes) {
		 					Console.WriteLine("nombre cliente : "+E.NOM_CLIENTE);
		 			Console.WriteLine("DNI del cliente : " +E.DNI_CLIENTE);
		 			Console.WriteLine("legajo del encargado : "+E.LEGAJO_ENCARGADO);
		 			Console.WriteLine("precio total : "+E.PRECIO_TOTAL);
		 			Console.WriteLine("precio senia : " +E.SENIA);
		 			Console.WriteLine("tipo de evento : " +E.TIPO_EVENTO); 
		 			Console.WriteLine("servicios : ");
		 			ArrayList servicioscontados = new ArrayList();
		 			foreach (string servicio in E.todos_servicio()) {// recorre lista de servcios del evento
		 				
		 				if (!servicioscontados.Contains(servicio)) {// verifica si la palabra servcio ya se encentra contada en la arraylist de servcios contados
		 					
		 					int contador = 0 ;
		 					
		 					// se recorre la lista contando los servcios de ese nombre
		 					foreach (string  se in E.todos_servicio()) {
		 						if (se == servicio) {
		 							contador ++ ;
		 						}
		 					}
		 					
		 					Console.WriteLine(" servicio " + servicio + " = cantidad " + contador);// imprime el servcio con la cantidad contada
		 					servicioscontados.Add(servicio);// y la agrega en ls lista de servicios contados
		 				}
		 			}
					 
					 Console.WriteLine("-----------------------------------------");
		 				}
		 			}
		 		}
		 		}
		 		else
		 			Console.WriteLine("La lista de eventos esta vacia " );
		 		Console.WriteLine("---------------------------------");
		 		
		 		break;
		 		
		 	case 5 :
		 		if (s.EsVacio_servicio()== false) {
		 			
		 			foreach (servicio1 ser  in s.Todos_servicios()) {
		 				Console.WriteLine(" Nombre : " + ser.NOMBRE);
		 				Console.WriteLine(" Stock : " + ser.STOCK);
		 				Console.WriteLine(" Precio unitario : " + ser.PRECIO);
		 				Console.WriteLine(" Cantidad de solicitudes : " + ser.CANT_EVENTOS);
		 				Console.WriteLine(" Cantidad de empleados : " + ser.CANT_EMPLEADO);
		 				Console.WriteLine("----------------------------------------------------");
		 			}
		 			
		 		}
		 		else{
		 			Console.WriteLine("La lista de servicios esta vacia " );
		 			Console.WriteLine("---------------------------------");
		 		}
		 		break;
		 		
		 	default:
		   	Console.WriteLine("elijio una opcion incorrecta " );
		   	Console.WriteLine("-----------------------------");
		   	break;
		 }
		
		
		
		 }
		
		
		
		public static void reasignar_labor_empleado_encargado (ref salonfiesta1 s){
		
			Console.WriteLine("Opcion 1 : Para reasignar labor a empleado o derivar eventos de encargado ." );
			Console.WriteLine("Opcion 2 : Para reasignar todos los empleados de un servicio ");
			Console.WriteLine("opcion 3 : Para cambiar de empleado a encaragdo o viceversa " );
			int respuesta = int.Parse(Console.ReadLine());
			switch (respuesta) {
				
				case 1 :
					Console.WriteLine("ingrese legajo de empleado/ encargado : ");
					int leg = int.Parse(Console.ReadLine());
					bool existe = s.exite_empleado(leg);// si exite empleado
					if(existe == true){
					bool encargado = false ;
					foreach (empleado1 emple  in s.todos_empleados()) {// verifica si es empleado o encargado
						if ((emple.LEGAJO == leg)&&(emple.LABOR == "encargado")) {
							encargado = true;
							break;
						}
					}
					if (encargado == true) {// si es encargado
						encargado1 encargadoN = (encargado1) s.ver_empleado(leg);
						
						if(encargadoN.CANT_EVENTOS != 0){// si su cantidad de eventos es igual a 0 ,puede pasar a ser empleado
						int cantidad = 0 ;
						foreach (empleado1 ele in s.todos_empleados()) {// cuenta si hay mas de un encargado para derivar eventos
							if (ele.LABOR == "encargado") {
								cantidad++;
							}
						}
						if(cantidad > 1){//si es mayor avanza 
						
						
						
						for (int i = 0; i < s.cant_eventos(); i++) {//recorre la lista de eventos 
							
							evento1 var= (evento1)s.todos_eventos()[i];//no uso el metodo ver evento por es por fecha y al ser for no tengo que castear primero
							
							if (var.LEGAJO_ENCARGADO == leg) { // si el legajo es igaula al de el encargado
							    Console.WriteLine("fecha : "+ var.FECHA());
							    Console.WriteLine("tipo evento : "+ var.TIPO_EVENTO);
								encargado1 encargadoo = (encargado1)(s.ver_empleado(var.LEGAJO_ENCARGADO));
								encargadoo.disminuir_eventos();// disminuye eventos de el encargado q ya no esta a cargo
								Console.WriteLine("ingrese legajo de  encargado remplazante  : ");
								foreach (empleado1 se in s.todos_empleados()) {
									if (se.LABOR == "encargado") {
										Console.WriteLine("nombre : " + se.NOMBRE + se.APELLIDO);
										Console.WriteLine(" legajo : " + se.LEGAJO);
									}
								}
								int legajo = int.Parse(Console.ReadLine());
						
								encargado1 en = (encargado1)(s.ver_empleado(legajo));
								en.aumentar_eventos();// se le aumenta eventos al encargado remplazante
							
								evento1 nuevo1 =(evento1) s.todos_eventos()[i];
								nuevo1.LEGAJO_ENCARGADO = legajo;//se le asigna al evento el encargado remplazante
							
							}
							
						}
						
						
						Console.WriteLine("Cambios ejecutados correctamente ");
						Console.WriteLine("---------------------------------");
					}
						else{
							Console.WriteLine("Debe tener mas de un encargado para cambiar derivar eventos  " );
							Console.WriteLine("--------------------------------------------------------------");
						}
					}
						else{ Console.WriteLine("El encargado no tiene  a cargo eventos ");
							Console.WriteLine("------------------------------------------");
						}
					}
					
					
					if( encargado == false){// si no es encargado
					
						Console.WriteLine("Ingrese nombre de la nueva labor " );
						foreach (servicio1 ser in s.Todos_servicios()) {
							
							
							Console.WriteLine("Nombre : " + ser.NOMBRE);
							Console.WriteLine("Cantidad de empleados asiganados en la labor : " + ser.CANT_EMPLEADO);
							                  
						}
						string ser_nuevo = Console.ReadLine();// se elige nueva labor para el empleado
						s.ver_servicio(s.ver_empleado(leg).LABOR).disminuir_emple();//se le disminuye cantidad al labor vieja
						s.ver_empleado(leg).LABOR = ser_nuevo;// se le asigan nueva labor
						s.ver_servicio(ser_nuevo).aumentar_emple();// se le aumenta empleados a la labor nueva
						Console.WriteLine(" Cambios ejecutados correctamente ");
						Console.WriteLine("----------------------------------");
					}
					}
					else{
						Console.WriteLine("No existe empleado / encargado ");
						Console.WriteLine("-------------------------------");
					
					}
					break;
					
					
				case 2 :
					
					Console.WriteLine("Ingrese nombre del servicio : ");
					string servicio = Console.ReadLine();
					if(s.existe_servicio(servicio)){ //verifica que servcio exista
						if(s.ver_servicio(servicio).CANT_EMPLEADO != 0){//verifica que la cantidad de empleados sea distinta a 0,para poder reasignar los empleaados
					ArrayList nueva = new ArrayList();
					foreach (empleado1 E in s.todos_empleados()) {
						
						if (E.LABOR== servicio) {
							
							s.ver_servicio(servicio).disminuir_emple();//se disminuye la cantidad de empleados del servcio viejo
							Console.WriteLine("Ingrese labor :");
							foreach (servicio1 se in s.Todos_servicios()) {// se muestran servcios para reasignar el empleado E
								Console.WriteLine("Nombre : "+se.NOMBRE);
							}
							string nuevo = Console.ReadLine();
							E.LABOR = nuevo;// una vez que se eligio se le asigna al empleado
							nueva.Add(E);
							s.ver_servicio(nuevo).aumentar_emple();//se le aumenta a la cantidad de empledos al servcio nuevo
						}
						else
							nueva.Add(E);
						
					}
					s.Set_empleados(nueva);//una vez que se termina de reasignar se remplaza la lista
					}
					else{ Console.WriteLine("No tiene empleados a cargo ");
							Console.WriteLine("------------------------------");}
			       }
					else {Console.WriteLine(" No existe servicio ");
						Console.WriteLine("--------------------");}
					break;
					
				case 3 :
					Console.WriteLine("Ingrese numero de legajo del encargado : ");
					int LEG = int.Parse(Console.ReadLine());
					if (s.exite_empleado(LEG) == true ) {// si existe empleado
						
						bool flag = false;
						foreach (empleado1 ele in s.todos_empleados()) { //verifica si es encargado o empleado
							if ((ele.LABOR == "encargado")&&(ele.LEGAJO == LEG)){
								flag = true;
							}
						}
						
						if(flag == false){// si no lo es
							s.ver_servicio(s.ver_empleado(LEG).LABOR).disminuir_emple();
							Console.WriteLine("Ingrese plus de sueldo ");
							float plus = float.Parse(Console.ReadLine());
							//se pide el dato faltante par crear encargado
							encargado1 nuevo = new encargado1(s.ver_empleado(LEG).NOMBRE , s.ver_empleado(LEG).APELLIDO, s.ver_empleado(LEG).DNI,s.ver_empleado(LEG).LEGAJO,s.ver_empleado(LEG).SUELDO,"encargado",plus);
							s.eliminar_empleado(s.ver_empleado(LEG));	// se elimina el objeto empleado
							s.agregar_empleado(nuevo);// se agrega el objeto encargado
							Console.WriteLine("Se pudo cambiar exitosamente de empleado a encargado ");
							Console.WriteLine("-----------------------------------------------------");
						}
						if (flag == true) {//si es
							encargado1 viejo = (encargado1) s.ver_empleado(LEG);
							
							if(viejo.CANT_EVENTOS == 0){// verifico que no tenga eventos a cargo
								s.eliminar_empleado(viejo);// se elimina el objeto encargado
								foreach (servicio1 element in s.Todos_servicios()) { // muestran los servicios 
									Console.WriteLine(element.NOMBRE);
									Console.WriteLine(element.DESCRIPCION);
									Console.WriteLine(element.CANT_EMPLEADO);
								}
								Console.WriteLine("ingrese la labor a eleccion : ");
								string eleccion = Console.ReadLine();//se elige labor
								empleado1 nuevoE= new empleado1(viejo.NOMBRE,viejo.APELLIDO,viejo.DNI,viejo.LEGAJO,viejo.SUELDO,eleccion );// se crea empleado
								s.ver_servicio(eleccion).aumentar_emple();// se busca el servcio elegido y se le aumenta la cantidad de empleados
								s.agregar_empleado(nuevoE);// se agrega empleado
								Console.WriteLine(" Se pudo cambiar exitosamente de encargado a empleado ");
								Console.WriteLine("------------------------------------------------------");
							}
							else{
								Console.WriteLine("Primero debe reasignar los eventos de el encargado para cambiar a empleado " );
								Console.WriteLine("----------------------------------------------------------------------------");
							}
						}
					}
					else{
						Console.WriteLine(" No existe empleado  " );
						Console.WriteLine("----------------------");
					}
					break;
					
				default:
					
					Console.WriteLine("opcion incorrecta " );
					Console.WriteLine("-------------------");
					break;
							
			}

		
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		 
		
		
	}
}