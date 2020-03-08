using System;
using System.Reflection;

namespace Waybit.Abstractions.Dapper.SqlReader
{
	/// <summary>
	/// Thrown when trying to access a embedded resource than failed
	/// </summary>
	public class EmbeddedResourceException : Exception
	{
		/// <summary>
		/// Create instance of the class <see cref="EmbeddedResourceException"/>
		/// </summary>
		public EmbeddedResourceException(Assembly assembly, string filename, string message)
			: base(message)
		{
			Assembly = assembly;
			Filename = filename;
		}

		/// <summary>
		/// Execution assembly
		/// </summary>
		public Assembly Assembly { get; }

		/// <summary>
		/// Embedded resource filename
		/// </summary>
		public string Filename { get; }
	}
}
