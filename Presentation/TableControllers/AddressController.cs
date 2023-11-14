using Application.Addresses.Commands.CreateAddress;
using Asp.Versioning;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Datasync.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.Services;
using Presentation.TableEntities;
using System.Threading;

namespace Presentation.TableControllers
{
    [AllowAnonymous]    
    [Route("tables/[Controller]")]    
    public class AddressController : TableController<AddressSync>
    {
       

        public AddressController(IRepository<AddressSync> repository) :base(repository) 
        {
           
        }

    }
}
