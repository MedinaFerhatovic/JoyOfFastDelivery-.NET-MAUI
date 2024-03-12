
using SQLite;
using JoyOfFastDelivery.Common;
using JoyOfFastDelivery.Services;
using JoyOfFastDelivery.Models;

[assembly: Dependency(typeof(DatabaseService))]
namespace JoyOfFastDelivery.Services
{
    public class DatabaseService : IDatabaseService
    {
        private SQLiteAsyncConnection _connection;

        public async Task InitializeAsync()
        {
            if (_connection == null)
            {
                var databasePath = GetDatabasePath();
                _connection = new SQLiteAsyncConnection(databasePath);
                Console.WriteLine($"Database path: {databasePath}");
               

                await TryUpdateSchema();
                await _connection.CreateTableAsync<User>();
            }
        }

        private async Task TryUpdateSchema()
        {
            try
            {
                var tableInfo = await _connection.GetTableInfoAsync("User");
                if (!tableInfo.Any(c => c.Name == "Name"))
                {
                    await _connection.ExecuteAsync("ALTER TABLE User ADD COLUMN Name TEXT;");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating schema: {ex.Message}");
            }
        }


        public async Task<User> GetUserAsync(string email)
        {
            await InitializeAsync();
            return await _connection.Table<User>().Where(e => e.Email == email).FirstOrDefaultAsync();
        }

        public async Task<int> AddUserAsync(User user)
        {
            await InitializeAsync();
            return await _connection.InsertAsync(user);
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            await InitializeAsync();
            return await _connection.UpdateAsync(user);
        }

        public async Task<int> DeleteUserAsync(User user)
        {
            await InitializeAsync();
            return await _connection.DeleteAsync(user);
        }

        private string GetDatabasePath()
        {
            var databaseName = DatabaseConstants.DatabaseName;
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath = Path.Combine(documentsPath, databaseName);
            return databasePath;
        }
    }
}
