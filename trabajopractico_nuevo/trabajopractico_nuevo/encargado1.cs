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
	/// Description of encargado1.
	/// </summary>
	public class encargado1 : empleado1
{
    private float plus_sueldo;
    private int cant_eventos;

    
    public encargado1(string nombre, string apellido, int dni, int legajo, float sueldo, string labor, float plus_sueldo) 
        : base(nombre, apellido, dni, legajo, sueldo, labor)
    {
        this.plus_sueldo = plus_sueldo;
        this.cant_eventos= 0;
    }

    //propiedades
    public float PLUS_SUELDO
    {
        set { plus_sueldo = value; }
        get { return plus_sueldo; }
    }
    public int CANT_EVENTOS{
    
    	set{cant_eventos = value;}
    	get{return cant_eventos;}
    
    }
    
    public float CalcularSueldoTotal()
    {
        return this.sueldo + this.plus_sueldo;
    }
    
    public void aumentar_eventos(){
    
    	cant_eventos ++ ;
    }
    
    public void disminuir_eventos(){
    
    	cant_eventos --;
    }
    
}

}
