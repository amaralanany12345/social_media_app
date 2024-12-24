using Medical.General;
using Medical.Interfaces;
using Medical.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Medical.Services
{
    public class UserService:IUser
    {
        AppDbContext context;
        private readonly JwtClass _jwt;
        public UserService(JwtClass jwt)
        {
            context = new AppDbContext();
            _jwt = jwt;
        }

        public SigningResponse signup(SignUpInfo userInfo)
        {
            var newUser = new User();
            newUser.name = userInfo.name;
            newUser.email= userInfo.email;
            newUser.password = userInfo.password;
            context.users.Add(newUser);
            var userProfile = new Profile();
            userProfile.user = newUser;
            userProfile.userId = newUser.id;
            context.profiles.Add(userProfile);
            context.SaveChanges();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtTokenDiscriptor = new SecurityTokenDescriptor { 
                    Issuer= _jwt.Issuer,
                    Audience= _jwt.Audience,
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SigningKey)),
                    SecurityAlgorithms.HmacSha256Signature),
                    Subject=new ClaimsIdentity(new Claim[]
                    {
                        new (ClaimTypes.Name,newUser.name),
                        new (ClaimTypes.Email,newUser.email),
                        new (ClaimTypes.NameIdentifier,newUser.id.ToString()),
                    }),

            };

            var securityToken = tokenHandler.CreateToken(jwtTokenDiscriptor);
            var accesstoken = tokenHandler.WriteToken(securityToken);
            return new SigningResponse
            {
                token = accesstoken,
                user = newUser,
            };

        }

        public SigningResponse signin(SignInInfo userInfo)
        {
            var user = (from item in context.users where item.email == userInfo.email && item.password == userInfo.password select item).FirstOrDefault();
            if(user== null)
            {
                throw new ArgumentException("user is not found");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor { 
                Issuer= _jwt.Issuer,
                Audience= _jwt.Audience,
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SigningKey)),
                SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new (ClaimTypes.Name,user.name),
                        new (ClaimTypes.Email,user.email),
                        new (ClaimTypes.NameIdentifier,user.id.ToString()),
                    }),
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return new SigningResponse { 
                token=accessToken,
                user=user,
            };


        }

        public ICollection<User> GetAllUsers()
        {
            var users = (from user in context.users select user).ToList();
            return users;
        }

        
    }
}
