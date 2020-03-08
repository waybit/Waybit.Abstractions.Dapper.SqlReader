using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace Waybit.Abstractions.Dapper.SqlReader.UnitTests
{
	[TestFixture]
	public class EmbeddedResourceSqlReaderTests : EmbeddedResourceSqlReaderFixture 
	{
		[Test]
		public async Task Can_read_embedded_resource()
		{
			// Arrange
			const string filename = "query.sql";
	
			// Act
			string query = await SqlReader.ReadAsync(filename);
			
			// Assert
			query.ShouldNotBeNull();
			query.ShouldBe(Text);
		}
		
		[Test]
		public async Task Can_read_embedded_resource_different_case()
		{
			// Arrange
			const string filename = "QuErY.sql";
	
			// Act
			string query = await SqlReader.ReadAsync(filename);
			
			// Assert
			query.ShouldNotBeNull();
			query.ShouldBe(Text);
		}
				
		[Test]
		public async Task Cannot_read_file_not_found()
		{
			// Arrange
			const string filename = "not_found.sql";
	
			// Act & Assert
			await Should.ThrowAsync<EmbeddedResourceException>(
				() => SqlReader.ReadAsync(filename));
		}
	}
}
