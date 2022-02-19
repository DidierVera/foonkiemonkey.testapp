using Infrastructure.Entities;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.LocalStorage
{
    public class DatabaseRepository
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<DatabaseRepository> Instance = new AsyncLazy<DatabaseRepository>(async () =>
        {
            var instance = new DatabaseRepository();
            CreateTableResult result = await Database.CreateTableAsync<UserEntity>();
            return instance;
        });

        public DatabaseRepository()
        {
            Database = new SQLiteAsyncConnection(GlobalConstants.DatabasePath, GlobalConstants.Flags);
        }
        public Task<List<UserEntity>> GetAsync()
        {
            return Database.Table<UserEntity>().ToListAsync();
        }

        public Task<UserEntity> GetItemByIdAsync(int id)
        {
            return Database.Table<UserEntity>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(UserEntity item)
        {
            return Database.InsertAsync(item);
        }


        public Task<int> DeleteItemAsync(UserEntity item)
        {
            return Database.DeleteAsync(item);
        }
    }
}