using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZawajApp.api.Data;
using ZawajApp.api.Dtos;

namespace ZawajApp.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IZawajRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IZawajRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var userToReturn = _mapper.Map<UserForDetailsDto>(user);
            return Ok(userToReturn);
        }
         [HttpPut("{id}")]
         public async Task<IActionResult> UpdateUser(int id,UserForUpdateDto userForUpdateDto){
             if(id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
             return Unauthorized();
             var userFromRepo = await _repo.GetUser(id);
             _mapper.Map(userForUpdateDto,userFromRepo);
             if(await _repo.SaveAll()){
                 return NoContent();
             }
             throw new Exception($"حدثت مشكلة في تعديل البيانات{id}");
         }

    }
}