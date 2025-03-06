/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 13/10/2024
 * Time: 22:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trabajopractico_nuevo
{
	/// <summary>
	/// Description of excepcionFecha.
	/// </summary>
	public class excepcionFecha : Exception
	{
		public string motivo ;
		
		public excepcionFecha(string m)
		{
			motivo=m;
		}
	}
}
