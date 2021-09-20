using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagination_Implemention.Models;
using Pagination_Implemention.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination_Implemention.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<User> users;
        public UserController()
        {
            users = new List<User>()
            {
                new User(){Id = 1,Name="User-1",Password="password-1"},
                new User(){Id = 2,Name="User-2",Password="password-2"},
                new User(){Id = 3,Name="User-3",Password="password-3"},
                new User(){Id = 4,Name="User-4",Password="password-4"},
                new User(){Id = 5,Name="User-5",Password="password-5"},
                new User(){Id = 6,Name="User-6",Password="password-6"},
                new User(){Id = 7,Name="User-7",Password="password-7"},
                new User(){Id = 8,Name="User-8",Password="password-8"},
                new User(){Id = 9,Name="User-9",Password="password-9"},
                new User(){Id = 10,Name="User-10",Password="password-10"},
                new User(){Id = 11,Name="User-11",Password="password-11"},
                new User(){Id = 12,Name="User-12",Password="password-12"},
                new User(){Id = 13,Name="User-13",Password="password-13"},
                new User(){Id = 14,Name="User-14",Password="password-14"},


            };
        }

        [HttpGet]
        public ActionResult<PagedList<User>> Get([FromQuery]PaginationUserParams @params)
        {
            var userList = GetUsers(@params);
            var headerParams = new PaginationHeaderParams(@params.PageNumber, @params.PageSize, userList.TotalCount, userList.TotalPages);
            Response.AddPaginationHeader(headerParams);
            return userList;
        }


        private PagedList<User> GetUsers(PaginationUserParams userParams)
        {

            return PagedList<User>.Create(users, userParams.PageNumber, userParams.PageSize);
        }
    }
}
