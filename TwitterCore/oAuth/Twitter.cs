using System;
using System.Collections.Specialized;
using System.Web;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Beam.TwitterCore.oAuth
{
    public class Twitter : oAuth
    {
        
        public const string REQUEST_TOKEN = "https://api.twitter.com/oauth/request_token";
        public const string AUTHORIZE = "https://api.twitter.com/oauth/authorize";
        public const string ACCESS_TOKEN = "https://api.twitter.com/oauth/access_token";
        public const string USERSTREAM_URI = "https://userstream.twitter.com/1.1/user.json";
        public const string HOMETIMELINE_URI = "https://api.twitter.com/1.1/statuses/home_timeline.json";

        oAuth oAuth = new oAuth();

        public Twitter(string ConsumerKey, string ConsumerSecret)
        {
            this.ConsumerKey = ConsumerKey;
            this.ConsumerKey = ConsumerSecret;
        }

        public Twitter(string ConsumerKey, string ConsumerSecret, string AccessToken, string AccessTokenSecret)
        {
            this.ConsumerKey = ConsumerKey;
            this.ConsumerKey = ConsumerSecret;
            this.AccessToken = AccessToken;
            this.AccessTokenSecret = AccessTokenSecret;
        }
        

        /// <summary>
        /// Get the link to Twitter's authorization page for this application.
        /// </summary>
        /// <returns>The url with a valid request token, or a null string.</returns>
        public string AuthorizationLinkGet()
        {
            string ret = null;

            string response = oAuthRequest(oAuth.Method.GET, REQUEST_TOKEN, String.Empty);
            if (response.Length > 0)
            {
                //response contains token and token secret.  We only need the token.
                NameValueCollection qs = HttpUtility.ParseQueryString(response);
                if (qs["oauth_token"] != null)
                {
                    ret = AUTHORIZE + "?oauth_token=" + qs["oauth_token"];
                }
            }
            return ret;
        }

        /// <summary>
        /// Exchange the request token for an access token.
        /// </summary>
        /// <param name="authToken">The oauth_token is supplied by Twitter's authorization page following the callback.</param>
        public void AccessTokenGet(string authToken, string verifier)
        {
            AccessToken = authToken;
            Verifier = verifier;

            string response = oAuthRequest(oAuth.Method.GET, ACCESS_TOKEN, String.Empty);

            if (response.Length > 0)
            {
                //Store the Token and Token Secret
                NameValueCollection qs = HttpUtility.ParseQueryString(response);
                if (qs["oauth_token"] != null)
                {
                    AccessToken = qs["oauth_token"];
                }
                if (qs["oauth_token_secret"] != null)
                {
                    AccessTokenSecret = qs["oauth_token_secret"];
                }
            }
        }

        

        /// <summary>
        /// Start User Stream
        /// </summary>
        /// <param name="url">The full url, including the querystring.</param>
        /// <returns>The web server response.</returns>
        /*
        public async Task singleUserStream(Action onConnectCallback, Action<string> streamCallback,Action onErrorCallback)
        {
            Method method = Method.GET;
            string outUrl = "";
            string querystring = "";
            string url = USERSTREAM_URI;
            Uri uri = new Uri(USERSTREAM_URI);

            string nonce = this.GenerateNonce();
            string timeStamp = this.GenerateTimeStamp();

            //Generate Signature
            string sig = this.GenerateSignature(uri,
                this.ConsumerKey,
                this.ConsumerSecret,
                this.Token,
                this.TokenSecret,
                this.Verifier,
                method.ToString(),
                timeStamp,
                nonce,
                out outUrl,
                out querystring);

            querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);
            
            if (querystring.Length > 0)
            {
                outUrl += "?";
            }

            url = outUrl + querystring;

            HttpWebRequest webRequest = null;
            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            try {
                //WebResponseGet
                using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                {
                    string json;
                    onConnectCallback();
                    while ((json = await responseReader.ReadLineAsync()) != null)
                    {
                        if (!String.IsNullOrWhiteSpace(json))
                        {
                            Console.WriteLine(json);
                            streamCallback(json);
                        }
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                if (onErrorCallback != null)
                    onErrorCallback();
            }
            webRequest.GetResponse().GetResponseStream().Close();
            webRequest = null;
        } */
        
    }
}
