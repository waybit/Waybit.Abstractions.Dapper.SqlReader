using System;
using System.Reflection;
using NUnit.Framework;
using Shouldly;

namespace Waybit.Abstractions.Dapper.SqlReader.UnitTests
{
	[TestFixture]
	public class EmbeddedResourceSqlReaderFactoryTests
	{
		[Test]
		public void Can_create_embedded_resource_sql_reader_from_assembly_type_containing()
		{
			// Arrange
			Type type = this.GetType();
			
			// Act & assert
			Should.NotThrow(() => new EmbeddedResourceSqlReader(type));
		}

		[Test]
		public void Cannot_create_because_assembly_type_is_null()
		{
			// Arrange
			Type type = null;
			
			// Act & assert
			Should.Throw<ArgumentNullException>(() => new EmbeddedResourceSqlReader(type));
		}

		[Test]
		public void Can_create_embedded_resource_sql_reader_from_assembly()
		{
			// Arrange
			var assembly = Assembly.GetExecutingAssembly();
			
			// Act & assert
			Should.NotThrow(() => new EmbeddedResourceSqlReader(assembly));
		}

		[Test]
		public void Cannot_create_because_assembly_is_null()
		{
			// Arrange
			Assembly assembly = null;
			
			// Act & assert
			Should.Throw<ArgumentNullException>(() => new EmbeddedResourceSqlReader(assembly));
		}
	}
}
