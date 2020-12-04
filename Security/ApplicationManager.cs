using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;

namespace Security
{
    public class ApplicationManager : IApplicationManager
    {
        public virtual Application CreateApplication()
        {
            var application = new Application();
            application.Name = "Produtos";
            application.SecretWord = "senha";
            application.SecretWord = CalculateMd5Hash(application.SecretWord);
            application.SecondsToExpire = TimeSpan.FromHours(1).Seconds; //60 seconds
            return application;
        }
        public virtual string CreateToken(string application, string secretword, string username)
        {
            return CreateToken(application, secretword, username, string.Empty);
        }

        public virtual string CreateToken(string application, string secretword, string username, string data)
        {
            var unencodedMessage = $"user={username}";
            var epochTimeSpan = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            unencodedMessage += "&dt=" + epochTimeSpan;
            unencodedMessage += "&app=" + application;

            if (data != null && data != "")
            {
                unencodedMessage += "&data=" + data;
            }

            var messageToEncode = unencodedMessage + "&" + secretword;
            var md5HashString = CalculateMd5Hash(messageToEncode);
            var md5MessageString = unencodedMessage + "&md5=" + md5HashString;
            var base64MessageString = Base64Encode(md5MessageString);

            return base64MessageString;
        }

        public virtual string ValidateToken(string token)
        {
            var application = this.CreateApplication();
            if (application == null)
            {
                throw new UserFriendlyException(404, "ApplicationDoesNotExists");
            }

            return ValidateToken(token, application.SecretWord, application.SecondsToExpire);
        }

        public virtual string ValidateToken(string token, string secretword, int secondstoexpire)
        {
            var dictionary = ConvertTokenToDictionary(token);

            var md5HashToken = dictionary["md5"];

            var unencodedMessage = Base64Decode(token);

            var messageToEncode = unencodedMessage.Replace($"&md5={md5HashToken}", string.Empty) + $"&{secretword}";

            var md5HashString = CalculateMd5Hash(messageToEncode);

            if (md5HashToken != md5HashString)
            {
                throw new UserFriendlyException(403, "MD5InvalidToken");
            }

            var actualTimeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            var epochTimeSpan = TimeSpan.FromSeconds(Convert.ToInt32(dictionary["dt"]));

            if ((actualTimeSpan - epochTimeSpan).TotalSeconds > secondstoexpire)
            {
                throw new UserFriendlyException(403, "TokenHasExpired");
            }

            return dictionary.ContainsKey("data") ? $"user={dictionary["user"]}&data={dictionary["data"]}" : dictionary["user"];
        }

        #region Auxiliary Functions

        protected static string CalculateMd5Hash(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            const char padding = '0';

            var md5 = new MD5CryptoServiceProvider();
            var hashBytes = md5.ComputeHash(bytes);

            var hashString = hashBytes.Aggregate(string.Empty, (current, t) => current + Convert.ToString(t, 16).PadLeft(2, padding));

            return hashString.PadLeft(32, padding);
        }

        protected static Dictionary<string, string> ConvertTokenToDictionary(string token)
        {
            var unencodedMessage = Base64Decode(token);

            return unencodedMessage.Split('&').ToDictionary(x => x.Split('=')[0], x => x.Split('=')[1]);
        }

        public static string Base64Encode(string value)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string value)
        {
            var base64EncodedBytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        #endregion
    }
}
