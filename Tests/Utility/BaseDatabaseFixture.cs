using Microsoft.Data.Sqlite;
using System;

namespace Tests.Utility
{
    public abstract class BaseDatabaseFixture : IDisposable
    {
        private bool isDisposed;

        public BaseDatabaseFixture()
        {
            Db = new SqliteConnection("DataSource=:memory:");
            Db.Open();

            // Create the schema in the database
            using var context = DbContextFactory.CreateContext(Db);

            context.Database.EnsureCreated();
        }

        public SqliteConnection Db { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Override and create the data for these tests.
        /// </summary>
        public abstract void SetupData();

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (disposing)
            {
                // free managed resources
                Db.Close();
            }

            isDisposed = true;
        }
    }
}