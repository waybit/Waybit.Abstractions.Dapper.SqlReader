using System.Threading.Tasks;

namespace Waybit.Abstractions.Dapper.SqlReader
{
	/// <summary>
	/// Sql reader
	/// </summary>
	public interface ISqlReader
	{
		/// <summary>
		/// Read sql text from file
		/// </summary>
		/// <param name="filename">File name</param>
		Task<string> ReadAsync(string filename);
	}
}
