using System.Text;
using Microsoft.IdentityModel.Tokens;
namespace TODO {
    public class AuthOptions {
        public const string ISSUER = "AuthServer";
        public const string AUDIENCE = "AuthClient";
        const string KEY = "J6qVbHV4R}=-UM/nQf?b;q{yz|RDCmo4~_QV&p3x1?RpjU%KX3L3de-KIjn=I5d";
        public static  SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}