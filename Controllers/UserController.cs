using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jopp_lunch.Controllers
{
    public class UserController : Controller
    {
        private readonly Data.CanteenContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;
        private readonly ILogger<UserController> _logger;
        private readonly IEmailSender _emailSender;

        public UserController(Data.CanteenContext context, 
            SignInManager<User> signInManager, 
            UserManager<User> userManager,
            IUserStore<User> userStore,
            ILogger<UserController> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _emailStore = GetEmailStore();
            _logger = logger;
            _emailSender = emailSender;
            _context = context;

        }

        private string AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            else if(_signInManager.UserManager.Users.Contains(user)) { throw new DuplicateWaitObjectException(user.Id); }
            return "password";
        }

        public async Task LoadCSV()
        {
            FileStream file = new FileStream(@"C:\Users\zedni\Documents\zames_jopp.csv",
                      FileMode.Open, FileAccess.Read, FileShare.Read);
            using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding(1250)))
            {
                var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(sr);
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(new string[] { ";" });

                while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    if (row != null)
                    {
                        InputModel usr = new InputModel();
                        string longname = row[0];
                        string[] strings = longname.Split(' ');
                        if(longname != null && longname.Length>1 && strings.Count()>1)
                        {
                            usr.prijmeni = strings[0];
                            if (strings.Count() > 2)
                            {
                                usr.prijmeni += " " + strings[2];
                            }
                            usr.jmeno = strings[1];
                            usr.osobni_cislo = Int32.Parse(row[1]);
                            usr.Email = row[2];
                            usr.Password = row[3];
                            usr.ConfirmPassword = row[3];
                            await CreateUser(usr);
                            ModelState.Clear();
                        }                      
                    }
                }
            }
        }

        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// 

            [Required]
            [Display(Name = "Jméno")]
            public string jmeno { get; set; }

            [Required]
            [Display(Name = "Příjmení")]
            public string prijmeni { get; set; }

            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Osobní číslo")]
            public int osobni_cislo { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task CreateUser(InputModel Input)
        {
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    osobni_cislo = Input.osobni_cislo,
                    jmeno = Input.jmeno,
                    prijmeni = Input.prijmeni,
                    UserName = Input.osobni_cislo.ToString(),
                    Email = Input.Email
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //set user role
                    await _userManager.AddToRoleAsync(user, "employee");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }

        private User CreateUser()
        {
            try
            {
                return Activator.CreateInstance<User>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(User)}'. " +
                    $"Ensure that '{nameof(User)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<User>)_userStore;
        }
    }
}
