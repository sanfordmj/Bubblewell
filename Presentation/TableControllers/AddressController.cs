using Asp.Versioning;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Datasync.InMemory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Services;
using Presentation.TableEntities;
using System;


namespace Presentation.TableControllers
{
    [AllowAnonymous]    
    [Route("tables/[Controller]")]    
    public class AddressController : TableController<AddressSync>
    {
        public AddressController(IRepository<AddressSync> repository):base(repository) 
        {

        }
    }
}
