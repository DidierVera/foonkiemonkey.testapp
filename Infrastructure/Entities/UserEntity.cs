using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    [Table("tbl_User")]
    public class UserEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Local_Id { get; set; }
        public int ID { get; set; }
        public string Email { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Avatar { get; set; }
    }
}
