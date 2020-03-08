using System.IO;
using NUnit.Framework;

namespace Waybit.Abstractions.Dapper.SqlReader.UnitTests
{
	public abstract class EmbeddedResourceSqlReaderFixture
	{
		private readonly string _expectedFileFullName;

		protected EmbeddedResourceSqlReaderFixture()
		{
			_expectedFileFullName = Path.Combine(
				TestContext.CurrentContext.TestDirectory,
				"TestData",
				"Query.sql");
		}

		[OneTimeSetUp]
		public void Setup()
		{
			SqlReader = new EmbeddedResourceSqlReader(this.GetType());
		}

		protected ISqlReader SqlReader { get; private set; }

		protected string Text => File.ReadAllText(_expectedFileFullName);
	}
}
