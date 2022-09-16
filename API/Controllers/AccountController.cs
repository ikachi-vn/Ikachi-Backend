using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using API.Models;
using API.Providers;
using API.Results;
using System.Linq;
using DTOModel;
using BaseBusiness;
using System.Web.Security;
using System.Web.Http.Description;
using System.Net;
using RazorEngine;
using RazorEngine.Templating;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;
using System.Web.Http.Cors;

namespace API.Controllers
{
    
    [RoutePrefix("api/v1/Account")]
    public class AccountController : CustomApiController
    {
        private const string LocalLoginProvider = "Local";
        private string domain = "http://art.appcenter.vn/";

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            //UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        

        [Route("UserName")]
        public string GetUserName()
        {
            return Username;
        }

        [Route("UserInfo")]
        [AllowAnonymous]
        public DTO_APP_UserInfo GetUserInfo()
        {
            DTO_APP_UserInfo result = new DTO_APP_UserInfo();
            result.Id = "";
            result.Branchs = new List<int>();
            result.JobTitles = new List<int>();
            result.BranchList = new List<DTO_BRA_Branch>();
            result.StaffID = 0;
            result.SysRoles = new List<string>() { "GUEST" };

            if (User.Identity.IsAuthenticated)
            {
                result.IDBranch = IDBranch;
                ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);

                if(user != null)
                {
                    result.Id = user.Id;
                    result.UserName = user.UserName;
                    result.Email = user.Email;
                    result.StaffID = user.StaffID;
                    result.Avatar = user.Avatar;
                    result.SysRoles = UserManager.GetRoles(result.Id).ToList();

                    var staff = db.tbl_HRM_Staff.Find(result.StaffID);
                    if (staff != null && !staff.IsDeleted && !staff.IsDisabled)
                    {
                        result.StaffID = staff.Id;
                        result.FullName = staff.FullName;

                        if (IDBranch == 0)
                        {
                            result.IDBranch = staff.IDDepartment.GetValueOrDefault();
                        }

                        //Get branch + concurrent position
                        result.Branchs.Add(staff.IDDepartment.GetValueOrDefault());
                        result.Branchs.AddRange(staff.tbl_HRM_Staff_ConcurrentPosition.Where(d=>d.IsDeleted==false && d.IsDisabled==false).Select(s => s.IDDepartment));

                        result.JobTitles.Add(staff.IDJobTitle.GetValueOrDefault());
                        result.JobTitles.AddRange(staff.tbl_HRM_Staff_ConcurrentPosition.Where(d => d.IsDeleted == false && d.IsDisabled == false).Select(s => s.IDJobTitle.GetValueOrDefault()));

                        List<int> queryBranch = new List<int>();
                        //queryBranch.AddRange(result.JobTitles);
                        queryBranch.AddRange(result.Branchs);

                        result.BranchList = BS_BRA_Branch.getUserBranch(db, queryBranch).ToList();
                        result.UserSetting = BS_SYS_UserSetting.toDTO(db.tbl_SYS_UserSetting.Where(d => d.IsDeleted == false && d.IDUser == result.Id));
                    }
                 
                }
            }
            
            if (QueryStrings.Any(d => d.Key == "GetMenu"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "GetMenu").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                {

                    result.Forms = cm.getPermissionByPositionAndRole(result.JobTitles, result.SysRoles);
                        //BS_SYS_Form.get_SYS_Form(db, result.JobTitles, result.SysRoles);
                }
            }
            
            return result;
        }

        
        [Route("ApplicationUsers")]
        public List<UserInfoViewModel> GetApplicationUsers()
        {
            var context = new ApplicationDbContext();
            var userList = context.Users.Select(s => new UserInfoViewModel()
            {
                Id = s.Id,
                Email = s.Email,
                Avatar = s.Avatar,
                CreatedBy = s.CreatedBy,
                CreatedDate = s.CreatedDate,
                PhoneNumber = s.PhoneNumber,
                UserName = s.UserName,
                IDBranch = s.IDBranch,
                CustomerId = s.CustomerId,
                StaffID = s.StaffID,
                LockoutEnabled = s.LockoutEnabled,

                Roles = s.Roles.Select(ss => new Role() { RoleId = ss.RoleId }).ToList()

            }).ToList();

            return userList;
        }

        [Route("ApplicationUsers/{id}", Name = "get_ApplicationUsers")]
        public UserInfoViewModel GetApplicationUsers(string id)
        {
            var context = new ApplicationDbContext();
            var userList = context.Users.Where(d=>d.Email==id || d.Id == id).Select(s => new UserInfoViewModel()
            {
                Id = s.Id,
                Email = s.Email,
                Avatar = s.Avatar,
                CreatedBy = s.CreatedBy,
                CreatedDate = s.CreatedDate,
                PhoneNumber = s.PhoneNumber,
                UserName = s.UserName,
                IDBranch = s.IDBranch,
                CustomerId = s.CustomerId,
                StaffID = s.StaffID,
                LockoutEnabled = s.LockoutEnabled,

                Roles = s.Roles.Select(ss => new Role() { RoleId = ss.RoleId }).ToList()

            }).ToList();

            return userList.FirstOrDefault();
        }


        [Route("ApplicationUsers/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplicationUsers(string id, UserInfoViewModel u)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != u.Id)
                return BadRequest();

            var context = new ApplicationDbContext();
            var dbUser = context.Users.FirstOrDefault(d => d.Id == id);

            if (dbUser == null)
            {
                return BadRequest("Not found user with Id: " + id);
            }
            dbUser.UserName = dbUser.Email = string.IsNullOrEmpty( u.Email) ? null : u.Email.ToLower();
            
            dbUser.Avatar = u.Avatar;
            dbUser.PhoneNumber = u.PhoneNumber;
            dbUser.StaffID = u.StaffID;
            dbUser.IDBranch = u.IDBranch;

            dbUser.LockoutEnabled = u.LockoutEnabled;
            
            try
            {
                context.SaveChanges();


                #region Update roles
                if (User.IsInRole("HOST"))
                {
                    var user = UserManager.FindById(dbUser.Id);
                    UserManager.RemoveFromRoles(dbUser.Id, UserManager.GetRoles(dbUser.Id).ToArray());
                    foreach (var r in u.Roles)
                    {
                        UserManager.AddToRole(dbUser.Id, r.RoleId);
                    }
                    UserManager.Update(user);
                }
                #endregion

                //if ( dbUser.StaffID!=0 || u.Roles.Any(d => d.RoleId == "ThuKy" || d.RoleId == "BacSi") && (User.IsInRole("ThuKy") || User.IsInRole("Admin")))
                //{
                //     DTO_HRM_Staff i = BS_HRM_Staff.get_HRM_Staff(db, dbUser.StaffID, dbUser.Email);
                //    if (i == null)
                //        i = new DTO_HRM_Staff();
                //    //i.Username = dbUser.UserName;
                //    i.FullName = dbUser.FullName;
                //    var names = i.FullName.Split(' ');
                //    //i.FirstName = names[names.Length - 1];
                //    //i.LastName = i.FullName.Substring(0, i.FullName.Length - i.FirstName.Length).Trim();
                //    //i.Gender = dbUser.Gender;
                //    //i.DOB = dbUser.DOB;
                //    //i.PhoneNumber = dbUser.PhoneNumber;
                //    //i.EmailAddress = dbUser.Email;

                //    if ( i.Id != 0)
                //    {
                //        BS_HRM_Staff.put_LIST_Staff(db, IDBranch, i.Id, i, Username);
                //    }
                //    else
                //    {
                //        dbUser.StaffID = BS_HRM_Staff.post_LIST_Staff(db, IDBranch, i, Username).Id;
                //        context.SaveChanges();
                //    }
                //}
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                log.Error("PutApplicationUsers", ex);
                throw;
            }
        }

        [HttpPost]
        [Route("ApplicationUsers")]
        public async Task<IHttpActionResult> PostApplicationUsers(UserInfoViewModel u)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var context = new ApplicationDbContext();
            ApplicationUser dbUser = context.Users.FirstOrDefault(d => d.Email == u.Email);
            string activeLink = "";
            string password = u.UserName;


            if (dbUser == null)
            {
                dbUser = new ApplicationUser();
                var user = new ApplicationUser() { UserName = u.Email, Email = u.Email };
                user.CreatedDate = DateTime.UtcNow;
                user.CreatedBy = Username;
                user.StaffID = u.StaffID;
                IdentityResult result = await UserManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                else
                {
                    string code = UserManager.GenerateEmailConfirmationToken(user.Id);
                    activeLink = string.Format(domain + "Home/ConfirmEmail/?userId={0}&code={1}", user.Id, code);
                }

                dbUser = context.Users.FirstOrDefault(d => d.Email == u.Email);
            }
            else
            {
                return BadRequest("Account with email is exits: " + u.Email);
            }

            #region Update roles
            if (User.IsInRole("HOST"))
            {
                var user = UserManager.FindById(dbUser.Id);
                UserManager.RemoveFromRoles(dbUser.Id, UserManager.GetRoles(dbUser.Id).ToArray());
                if (u.Roles != null)
                {
                    foreach (var r in u.Roles)
                    {
                        UserManager.AddToRole(dbUser.Id, r.RoleId);
                    }
                }
                UserManager.Update(user);
            }
            #endregion

            dbUser.UserName = dbUser.Email = string.IsNullOrEmpty(u.Email) ? null : u.Email.ToLower();

            
            dbUser.Avatar = u.Avatar;
            dbUser.PhoneNumber = u.PhoneNumber;
            dbUser.StaffID = u.StaffID;
            dbUser.IDBranch = u.IDBranch;

            dbUser.LockoutEnabled = u.LockoutEnabled;

            try
            {
                context.SaveChanges();

                string body = string.Empty;
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Uploads/FileTemplate/email-template/createAccount.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{AppName}", "ART Distribution");
                body = body.Replace("{FullName}", "");
                body = body.Replace("{Email}", dbUser.Email);
                body = body.Replace("{Password}", password);
                body = body.Replace("{Domain}", "www.artdistribution.vn");
                body = body.Replace("{URL}", "http://art.appcenter.vn/");

                
                new Thread(() =>{
                    EmailService emailService = new EmailService();
                    emailService.Send(new IdentityMessage() { Subject = "[ART-DMS] Thông tin tài khoản", Destination = dbUser.Email, Body = body });
                }).Start();

                var staff = db.tbl_HRM_Staff.Find(dbUser.StaffID);
                if(staff != null)
                {
                    staff.Email = dbUser.Email;
                    db.SaveChanges();
                }
                return Ok(dbUser.Id);
            }
            catch (Exception ex)
            {
                log.Error("PostApplicationUsers", ex);
                throw;
            }
        }


        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            SecurityHelper.GetLoggedInUsers().Remove(User.Identity.Name);
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);

            return Ok();
        }

        // GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
        [Route("ManageInfo")]
        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }

            List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

            foreach (IdentityUserLogin linkedAccount in user.Logins)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = linkedAccount.LoginProvider,
                    ProviderKey = linkedAccount.ProviderKey
                });
            }

            if (user.PasswordHash != null)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = LocalLoginProvider,
                    ProviderKey = user.UserName,
                });
            }

            return new ManageInfoViewModel
            {
                LocalLoginProvider = LocalLoginProvider,
                Email = user.UserName,
                Logins = logins,
                ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
            };
        }

        // POST api/Account/ChangePassword
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
                model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/SetPassword
        [Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string Id = string.IsNullOrEmpty(model.UserId) ? User.Identity.GetUserId() : model.UserId;
            UserManager.RemovePassword(Id);

            IdentityResult result = await UserManager.AddPasswordAsync(Id, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/AddExternalLogin
        [Route("AddExternalLogin")]
        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            AuthenticationTicket ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

            if (ticket == null || ticket.Identity == null || (ticket.Properties != null
                && ticket.Properties.ExpiresUtc.HasValue
                && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
            {
                return BadRequest("External login failure.");
            }

            ExternalLoginData externalData = await ExternalLoginData.FromIdentity(ticket.Identity);

            if (externalData == null)
            {
                return BadRequest("The external login is already associated with an account.");
            }

            IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(),
                new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/RemoveLogin
        [Route("RemoveLogin")]
        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result;

            if (model.LoginProvider == LocalLoginProvider)
            {
                result = await UserManager.RemovePasswordAsync(User.Identity.GetUserId());
            }
            else
            {
                result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(),
                    new UserLoginInfo(model.LoginProvider, model.ProviderKey));
            }

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }
        
        // GET api/Account/ExternalLogin
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            string redirectUri = string.Empty;

            if (error != null)
            {
                return BadRequest(Uri.EscapeDataString(error));
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            var redirectUriValidationResult = ValidateClientAndRedirectUri(this.Request, ref redirectUri);

            if (!string.IsNullOrWhiteSpace(redirectUriValidationResult))
            {
                return BadRequest(redirectUriValidationResult);
            }

            ExternalLoginData externalLogin = await ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey));
            bool hasRegistered = user != null;

            //Tự động tạo account cho user nếu chưa đăng ký
            if (!hasRegistered)
            {
                
                user = await UserManager.FindByEmailAsync(externalLogin.Email);

                if (user == null)
                {
                    user = new ApplicationUser() { UserName = externalLogin.Email, Email = externalLogin.Email, Avatar = externalLogin.Picture };
                    user.CreatedDate = DateTime.UtcNow;
                    user.CreatedBy = externalLogin.LoginProvider + "Register";

                    var resultCreated = await UserManager.CreateAsync(user);
                    if (!resultCreated.Succeeded)
                    {
                        return GetErrorResult(resultCreated);
                    }
                }
                else
                {
                    //Update User
                    var context = new ApplicationDbContext();
                    var dbUser = context.Users.FirstOrDefault(d => d.Id == user.Id);
                    dbUser.Avatar = externalLogin.Picture;
                    context.SaveChanges();

                }

              
                
                var info = new ExternalLoginInfo()
                {
                    DefaultUserName = externalLogin.Email,
                    Login = new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey)
                };

                var result = await UserManager.AddLoginAsync(user.Id, info.Login);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                hasRegistered = true; 
            }



            redirectUri = string.Format("{0}#external_access_token={1}&provider={2}&haslocalaccount={3}&external_user_name={4}",
                                            redirectUri,
                                            externalLogin.ExternalAccessToken,
                                            externalLogin.LoginProvider,
                                            hasRegistered.ToString(),
                                            externalLogin.UserName);

            return Redirect(redirectUri);
            
            

            //if (hasRegistered)
            //{
            //    Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            //    ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
            //       OAuthDefaults.AuthenticationType);
            //    ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
            //        CookieAuthenticationDefaults.AuthenticationType);

            //    AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user);
            //    Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            //}
            //else
            //{
            //    IEnumerable<Claim> claims = externalLogin.GetClaims();
            //    ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
            //    Authentication.SignIn(identity);
            //}

            //return Ok();
        }
        

        private string ValidateClientAndRedirectUri(HttpRequestMessage request, ref string redirectUriOutput)
        {

            Uri redirectUri;

            var redirectUriString = GetQueryString(Request, "redirect_uri");

            if (string.IsNullOrWhiteSpace(redirectUriString))
            {
                return "redirect_uri is required";
            }

            bool validUri = Uri.TryCreate(redirectUriString, UriKind.Absolute, out redirectUri);

            if (!validUri)
            {
                return "redirect_uri is invalid";
            }

            var clientId = GetQueryString(Request, "client_id");

            if (string.IsNullOrWhiteSpace(clientId))
            {
                return "client_Id is required";
            }
            
            redirectUriOutput = redirectUri.AbsoluteUri;

            return string.Empty;

        }

        private string GetQueryString(HttpRequestMessage request, string key)
        {
            var queryStrings = request.GetQueryNameValuePairs();

            if (queryStrings == null) return null;

            var match = queryStrings.FirstOrDefault(keyValue => string.Compare(keyValue.Key, key, true) == 0);

            if (string.IsNullOrEmpty(match.Value)) return null;

            return match.Value;
        }



        // GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        [AllowAnonymous]
        [Route("ExternalLogins")]
        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        {
            IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
            List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

            string state;

            if (generateState)
            {
                const int strengthInBits = 256;
                state = RandomOAuthStateGenerator.Generate(strengthInBits);
            }
            else
            {
                state = null;
            }

            foreach (AuthenticationDescription description in descriptions)
            {
                ExternalLoginViewModel login = new ExternalLoginViewModel
                {
                    Name = description.Caption,
                    Url = Url.Route("ExternalLogin", new
                    {
                        provider = description.AuthenticationType,
                        response_type = "token",
                        client_id = Startup.PublicClientId,
                        redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
                        state = state
                    }),
                    State = state
                };
                logins.Add(login);
            }

            return logins;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ObtainLocalAccessToken")]
        public async Task<IHttpActionResult> ObtainLocalAccessToken(string provider, string externalAccessToken)
        {

            if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(externalAccessToken))
            {
                return BadRequest("Provider or external access token is not sent");
            }

            var verifiedAccessToken = await VerifyExternalAccessToken(provider, externalAccessToken);
            if (verifiedAccessToken == null)
            {
                return BadRequest("Invalid Provider or External Access Token");
            }

            ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(provider, verifiedAccessToken.user_id));

            bool hasRegistered = user != null;

            if (!hasRegistered)
            {
                ExternalLoginData externalLogin = await ExternalLoginData.FromToken(provider, externalAccessToken);
                if (externalLogin == null)
                {
                    return InternalServerError();
                }
                
                user = await UserManager.FindByEmailAsync(externalLogin.Email);

                if (user == null)
                {
                    user = new ApplicationUser() { UserName = externalLogin.Email, Email = externalLogin.Email, Avatar = externalLogin.Picture };
                    user.CreatedDate = DateTime.UtcNow;
                    user.CreatedBy = externalLogin.LoginProvider + "Register";

                    var resultCreated = await UserManager.CreateAsync(user);
                    if (!resultCreated.Succeeded)
                    {
                        return GetErrorResult(resultCreated);
                    }
                }
                else
                {
                    //Update User
                    var context = new ApplicationDbContext();
                    var dbUser = context.Users.FirstOrDefault(d => d.Id == user.Id);
                    dbUser.Avatar = externalLogin.Picture;
                    context.SaveChanges();

                }



                var info = new ExternalLoginInfo()
                {
                    DefaultUserName = externalLogin.Email,
                    Login = new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey)
                };

                var result = await UserManager.AddLoginAsync(user.Id, info.Login);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                hasRegistered = true;
            }

            //generate access token response
            var accessTokenResponse = GenerateLocalAccessTokenResponse(user.UserName);

            return Ok(accessTokenResponse);

        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
            try
            {

                user.CreatedDate = DateTime.UtcNow;
                user.CreatedBy = "Register";
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                else
                {
                    //Update account info
                    
                    user.PhoneNumber = model.PhoneNumber;

                    //user.StaffID = model.StaffID;

                    // Associate the role with the new user 
                    //await UserManager.AddToRoleAsync(user.Id, "BenhNhan");
                    UserManager.Update(user);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    string code = UserManager.GenerateEmailConfirmationToken(user.Id);

                    var callbackUrl = string.Format(domain + "Home/ConfirmEmail/?userId={0}&code={1}", user.Id, code);
                    UserManager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                ClassLibrary.errorLog.logMessage("api/Account/Register", e);
            }

            return Ok();
        }

        // POST api/Account/RegisterExternal
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var verifiedAccessToken = await VerifyExternalAccessToken(model.Provider, model.ExternalAccessToken);
            if (verifiedAccessToken == null)
            {
                return BadRequest("Invalid Provider or External Access Token");
            }

            ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(model.Provider, verifiedAccessToken.user_id));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                return BadRequest("External user is already registered");
            }

            user = new ApplicationUser() { UserName = model.UserName };

            IdentityResult result = await UserManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            var info = new ExternalLoginInfo()
            {
                DefaultUserName = model.UserName,
                Login = new UserLoginInfo(model.Provider, verifiedAccessToken.user_id)
            };

            result = await UserManager.AddLoginAsync(user.Id, info.Login);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            //generate access token response
            var accessTokenResponse = GenerateLocalAccessTokenResponse(model.UserName);

            return Ok(accessTokenResponse);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("ForgotPassword")]
        public async Task<IHttpActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                // If user has to activate his email to confirm his account, the use code listing below
                //if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                //{
                //    return Ok();
                //}
                if (user == null)
                {
                    return NotFound();
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = string.Format(domain + "Home/ResetPassword?userId={0}&token={1}", user.Id, code);

                await UserManager.SendEmailAsync(user.Id, "TOOL - Yêu cầu đổi mật khẩu",
                    $"TOOL đã nhận được yêu cầu đổi mật khẩu của bạn.<br>" +
                    $"Vui lòng <b><a href='{callbackUrl}'>bấm vào đây để thay đổi mật khẩu</a></b>.<br>" +
                    $"Nếu bạn không yêu cầu thay đổi mật khẩu, vui lòng bỏ qua email này.<br>" +
                    $"---<br>" +
                    $"TOOL - Trân trọng!");

                return Ok();
            }

            // If we got this far, something failed, redisplay form
            return BadRequest(ModelState);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return NotFound();
            }

            IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> ResetPassword(string userId, string token, string newPassword)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token) || string.IsNullOrEmpty(newPassword))
            {
                return NotFound();
            }

            IdentityResult result = await UserManager.ResetPasswordAsync(userId, token, newPassword);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Helpers

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
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
                        ModelState.AddModelError("", error);
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

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string ExternalAccessToken { get; set; }

            public string Picture { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static async Task<ExternalLoginData> FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                //return new ExternalLoginData
                //{
                //    LoginProvider = providerKeyClaim.Issuer,
                //    ProviderKey = providerKeyClaim.Value,
                //    UserName = identity.FindFirstValue(ClaimTypes.Name),
                //    ExternalAccessToken = identity.FindFirstValue("ExternalAccessToken"),
                //    Email = providerKeyClaim.Issuer=="Google"? identity.FindFirstValue(ClaimTypes.Email) : identity.FindFirstValue("Email"),
                //};

                return await FromToken(providerKeyClaim.Issuer, identity.FindFirstValue("ExternalAccessToken"));
            }

            public static async Task<ExternalLoginData> FromToken(string provider, string accessToken)
            {
                if (provider == "Facebook")
                {
                    string graphInfoURL = "https://graph.facebook.com/me?fields=id,name,email&access_token=" + accessToken;
                    var client = new HttpClient();
                    var uri = new Uri(graphInfoURL);
                    var response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                        
                        if (provider == "Facebook")
                        {
                            //parsedToken.user_id = jObj["data"]["user_id"];

                            return new ExternalLoginData
                            {
                                LoginProvider = provider,
                                ProviderKey = jObj["id"],
                                UserName = jObj["name"],
                                ExternalAccessToken = accessToken,
                                Email = jObj["email"],
                                Picture = "https://graph.facebook.com/" + jObj["id"] + "/picture?type=large&width=720&height=720"
                            };

                        }
                    }
                }
                else if (provider == "Google")
                {

                    //string graphInfoURL = "https://www.googleapis.com/oauth2/v1/tokeninfo?access_token=" + accessToken;
                    string graphInfoURL = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + accessToken;
                    
                    var client = new HttpClient();
                    var uri = new Uri(graphInfoURL);
                    var response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                        if (provider == "Google")
                        {
                            //parsedToken.user_id = jObj["data"]["user_id"];

                            return new ExternalLoginData
                            {
                                LoginProvider = provider,
                                ProviderKey = jObj["id"],
                                UserName = jObj["name"],
                                ExternalAccessToken = accessToken,
                                Email = jObj["email"],
                                Picture = jObj["picture"]
                            };

                        }
                    }
                }
                
                return null;
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                byte[] data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        private async Task<ParsedExternalAccessToken> VerifyExternalAccessToken(string provider, string accessToken)
        {
            ParsedExternalAccessToken parsedToken = null;

            var verifyTokenEndPoint = "";

            if (provider == "Facebook")
            {
                //More about debug_tokn here: http://stackoverflow.com/questions/16641083/how-does-one-get-the-app-access-token-for-debug-token-inspection-on-facebook
                //Lấy facebook appToken: https://developers.facebook.com/tools/accesstoken/
                //For Test
                //var appToken = "303718803111111|i88w453O-ax9X6t_2WB9cFbiyXM";

                var appToken = "2266009516804148|YLQPMUXIwip-waNcBhABqm4NqOg";
                if (Startup.IsDebug)
                {
                    appToken = "303718803111111|i88w453O-ax9X6t_2WB9cFbiyXM";
                }

                verifyTokenEndPoint = string.Format("https://graph.facebook.com/debug_token?input_token={0}&access_token={1}", accessToken, appToken);
            }
            else if (provider == "Google")
            {
                verifyTokenEndPoint = string.Format("https://www.googleapis.com/oauth2/v1/tokeninfo?access_token={0}", accessToken);
            }
            else
            {
                return null;
            }

            var client = new HttpClient();
            var uri = new Uri(verifyTokenEndPoint);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                parsedToken = new ParsedExternalAccessToken();

                if (provider == "Facebook")
                {
                    parsedToken.user_id = jObj["data"]["user_id"];
                    parsedToken.app_id = jObj["data"]["app_id"];

                    if (!string.Equals(Startup.facebookAuthOptions.AppId, parsedToken.app_id, StringComparison.OrdinalIgnoreCase))
                    {
                        return null;
                    }
                }
                else if (provider == "Google")
                {
                    parsedToken.user_id = jObj["user_id"];
                    parsedToken.app_id = jObj["audience"];

                    string iosAppID = "547336805419-o1q3k6mnff23urc4kklan49r9djtgu0s.apps.googleusercontent.com";
                    string androidAppID = "547336805419-rvcgfnl9jkom49kso67i8dg8hg8mgcin.apps.googleusercontent.com";

                    if (! (
                        string.Equals(Startup.googleAuthOptions.ClientId, parsedToken.app_id, StringComparison.OrdinalIgnoreCase) 
                        || string.Equals(iosAppID, parsedToken.app_id, StringComparison.OrdinalIgnoreCase)
                        || string.Equals(androidAppID, parsedToken.app_id, StringComparison.OrdinalIgnoreCase)
                        ))
                    {
                        return null;
                    }

                }

            }

            return parsedToken;
        }

        private JObject GenerateLocalAccessTokenResponse(string userName)
        {

            var tokenExpiration = TimeSpan.FromDays(365);

            ClaimsIdentity identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, userName));
            identity.AddClaim(new Claim("role", "user"));

            var props = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
            };

            var ticket = new AuthenticationTicket(identity, props);

            var accessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);

            JObject tokenResponse = new JObject(
                                        new JProperty("userName", userName),
                                        new JProperty("access_token", accessToken),
                                        new JProperty("token_type", "bearer"),
                                        new JProperty("expires_in", tokenExpiration.TotalSeconds.ToString()),
                                        new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                                        new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString())
        );

            return tokenResponse;
        }

        #endregion
    }
}
