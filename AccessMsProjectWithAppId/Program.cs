using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;
using System;
using System.Linq;
using System.Security;

namespace AccessMsProjectWithAppId
{
    public class Program
    {
        private static ProjectContext context;

        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            Uri site = new Uri("https://itstaskforce.sharepoint.com/sites/pwa");
            string user = "tareqshahriar@itstaskforce.onmicrosoft.com";
            string _password = "Task.Force";
            SecureString password = new SecureString();
            _password.ToCharArray().ToList().ForEach(x => password.AppendChar(x));

            // Note: The PnP Sites Core AuthenticationManager class also supports this
            using (var authenticationManager = new AuthenticationManager())
            using (var context = authenticationManager.GetContext(site, user, password))
            {
                context.Load(context.Web, p => p.Title);
                await context.ExecuteQueryAsync();
                Console.WriteLine($"Title: {context.Web.Title}");
            }
        }

        //public static ClientContext GetContext(Uri web, string userPrincipalName, SecureString userPassword)
        //{
        //    context.ExecutingWebRequest += (sender, e) =>
        //    {
        //        // Get an access token using your preferred approach
        //        string accessToken = MyCodeToGetAnAccessToken(new Uri($"{web.Scheme}://{web.DnsSafeHost}"), userPrincipalName, new System.Net.NetworkCredential(string.Empty, userPassword).Password);
        //        // Insert the access token in the request
        //        e.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + accessToken;
        //    };

        //    return context;
        //}
    }
}