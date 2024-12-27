using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application
{
    public class CurrentUser: ICurrentUser
    {
        public string Id => "99";

        public string Name => "Test User";

        public string Email => "test_user@example.com";
    }
}
