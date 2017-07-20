using HotelManagement.Business.BLL;
using HotelManagement.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace KiddyShop.WebApp.Controllers
{
    public class AccountApiController: ApiController
    {
        #region Members
        

        #endregion Members

        #region Constructor
        public AccountApiController()
        {
        }

        

        #endregion Constructor

        #region APIs

        
        [AllowAnonymous]
        [HttpPost]
        public bool IsCookieAuth()
        {
            return User.Identity.IsAuthenticated;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> Signin(Signin model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Username hoặc password không hợp lệ");
            }
            if (model == null)
            {
                return BadRequest();
            }
            bool result = new System_UserBLL().Login(model.UserName,model.Password);
            switch (result)
            {
                case true:
                    {
                        //return Ok(_accountService.LoginReturnToken(model));
                        return Ok();
                    }
                case false:
                default:
                    return BadRequest("Username hoặc password không đúng");
            }
        }

        [Authorize]
        [HttpPost]
        public bool Signout()
        {
            try
            {
                HttpContext.Current.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        string normalizedErrorMessage = this.NormalizeErrorMessage(error);
                        ModelState.AddModelError("", normalizedErrorMessage);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        private string NormalizeErrorMessage(string errorMessage)
        {
            string normalizedErrorMessage = errorMessage;
            string pattern_pre = @"Name";
            string pattern_post = @"is already taken";
            string pattern = string.Format(@"{0} \w+ {1}", pattern_pre, pattern_post);

            Match m = Regex.Match(normalizedErrorMessage, pattern);

            string userName = string.Empty;

            if (m.Success)
            {
                string msg = m.Value;
                msg = msg.Remove(0, pattern_pre.Length);
                msg = msg.Replace(pattern_post, "");

                userName = msg.Trim();
                normalizedErrorMessage = string.Format("Username {0} is already taken", userName);
            }

            return normalizedErrorMessage;
        }

        #endregion APIs
    }
}
