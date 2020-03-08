using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Waybit.Abstractions.Dapper.SqlReader
{
	/// <summary>
	/// Implementation for embedded resources
	/// </summary>
	public class EmbeddedResourceSqlReader : ISqlReader
	{
		private readonly Assembly _assembly;

		/// <summary>
		/// Create instance of the class <see cref="EmbeddedResourceSqlReader"/>
		/// </summary>
		public EmbeddedResourceSqlReader(Type queryType)
		{
			if (queryType == null)
			{
				throw new ArgumentNullException(nameof(queryType));
			}

			_assembly = queryType.Assembly;
		}

		/// <summary>
		/// Create instance of the class <see cref="EmbeddedResourceSqlReader"/>
		/// </summary>
		public EmbeddedResourceSqlReader(Assembly assembly)
		{
			_assembly = assembly 
				?? throw new ArgumentNullException(nameof(assembly));
		}

		/// <inheritdoc />
		public async Task<string> ReadAsync(string filename)
		{
			string[] embeddedResourceNames = _assembly.GetManifestResourceNames();

			string embeddedResourceName = embeddedResourceNames
				.SingleOrDefault(r => r.ToLowerInvariant().EndsWith(filename.ToLowerInvariant()));

			if (embeddedResourceName is null)
			{
				throw new EmbeddedResourceException(
					assembly: _assembly,
					filename: filename,
					message: $"Not found filename {filename}");
			}

			await using (Stream embeddedResourceStream = _assembly
				.GetManifestResourceStream(embeddedResourceName))
			using (var reader = new StreamReader(embeddedResourceStream))
			{
				return await reader.ReadToEndAsync();
			}
		}
	}
}
