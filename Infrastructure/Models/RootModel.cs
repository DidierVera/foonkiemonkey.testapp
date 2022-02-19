using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class RootModel
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<UserModel> Data { get; set; }
        public SupportModel Support { get; set; }
    }
}
