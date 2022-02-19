using Infrastructure.Entities;
using Infrastructure.LocalStorage;
using Infrastructure.Models;
using Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.ViewModel
{
    public class UserViewModel
    {
        private RefitService service;
        private DatabaseRepository database;
        public UserViewModel()
        {
            service = new RefitService();
            InitializeDatabase();
        }

        private async void InitializeDatabase()
        {
            database = await DatabaseRepository.Instance;
        }

        public async Task<RootModel> GetUsers(int page)
        {
            try
            {
                var result = await service.GetUsersByPage(page);
                foreach (var item in result.Data)
                {
                    item.FullName = item.First_name + " " + item.Last_name;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> ClearDatabase()
        {
            var items = database.GetAsync();
            var noDeleted = 0;
            if (items != null && items.Result.Count > 0)
            {
                foreach (var item in items.Result)
                {
                    try
                    {
                        await database.DeleteItemAsync(item);
                    }
                    catch (Exception)
                    {
                        noDeleted++;
                    }
                }
            }
            if (noDeleted == 0)
            {
                return 0;
            }
            Console.WriteLine("Se eliminaron " + (items.Result.Count - noDeleted) + " de " + items.Result.Count);
            return 500;
        }

        public async Task<string> SaveInDatabase(List<UserModel> data)
        {
            try
            {
                foreach (var item in data)
                {
                    var entity = new UserEntity
                    {
                        ID = item.Id,
                        First_name = item.First_name,
                        Last_name = item.Last_name,
                        Email = item.Email,
                        Avatar = item.Avatar
                    };
                    var restul = await database.SaveItemAsync(entity);
                    Console.WriteLine(restul);  
                }
                return "Se han guardado todos los datos exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<UserModel> GetItemsFromDatabase()
        {
            var storageData = database.GetAsync();
            var result = new List<UserModel>();
            foreach (var item in storageData.Result)
            {
                var user = new UserModel
                {
                    Id = item.ID,
                    First_name = item.First_name,
                    Last_name = item.Last_name,
                    Email = item.Email,
                    Avatar = item.Avatar,
                    FullName = item.First_name + " " + item.Last_name
                };
                result.Add(user);
            }
            return result;
        }

        public async Task<UserModel> GetItemById(int Id)
        {
            var item = await database.GetItemByIdAsync(Id);
            if (item != null)
            {
                var user = new UserModel
                {
                    Id = item.ID,
                    First_name = item.First_name,
                    Last_name = item.Last_name,
                    Email = item.Email,
                    Avatar = item.Avatar,
                    FullName = item.First_name + " " + item.Last_name
                };
                return user;
            }
            return null;
        }
    }
}
