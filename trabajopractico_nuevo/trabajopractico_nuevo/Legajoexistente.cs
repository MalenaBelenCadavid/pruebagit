/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 20/10/2024
 * Time: 21:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trabajopractico_nuevo
{
	/// <summary>
	/// Description of Legajoexistente.
	/// </summary>
	public class Legajoexistente :Exception
	{
		public string motivo ;
		public Legajoexistente(string motivo)
		{
			this.motivo= motivo;
		}
	}
}
