using Core.BLL;
using Core.CustomModels;
using Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REGISTER_APIP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IConfiguration _config;
        private readonly UserBLL obj;
        public HomeController(IConfiguration config, UserBLL repository)
        {
            _config = config;
            this.obj = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        [Route("Register")]
        // [Authorize]
        public async Task<IActionResult> PostApiuserdetails(Apiuserdetail apiuserdetails)
        {
            APIUserProfilesContext DB = new APIUserProfilesContext();
            UserDetailsCM objmodel = new UserDetailsCM();
            if (ModelState.IsValid)
            {
                try
                {
                    int usernameexists = await obj.CheckByUserName(apiuserdetails.UserName);
                    if (usernameexists == 0)
                    {
                        var ud = await obj.InsRegistration(apiuserdetails);
                        objmodel.UserDetails.UserID = ud.UserId;
                        if (ud.UserId > 0)
                        {
                            return Ok(objmodel);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    else
                    {
                        return BadRequest("UserName Already Exists");
                    }

                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }
    }
}