using Newtonsoft.Json;
using SpotifyFinder.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFinder.Data {
    public class HttpGrabber {

        private readonly string BaseAddress = "https://api.spotify.com/v1/";

        public async Task<RootObject> MakeStringGreatAgain( string search ) {
            var data = new RootObject();
            try {
                data = JsonConvert.DeserializeObject<RootObject>(await GetFromStream(search));
            } catch (Exception ex) {
                var a = ex.Message.ToString();
            }
            return data;
        }

        private async Task<string> GetFromStream( string search ) {
            string result = search;
            try {
                var response = await GetRequestAsync(result);
                using (var responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
                    return await responseReader.ReadToEndAsync();
                }
            } catch (Exception ex) {
                string error = ex.Message.ToString();
            }
            return result;
        }

        private async Task<WebResponse> GetRequestAsync( string search ) {
            try {
                var request = HttpWebRequest.CreateHttp(BaseAddress + "search?q=" + search + "&type=playlist");
                request.Method = WebRequestMethods.Http.Get;
                request.ContentType = "application/json; charset=utf-8";
                request.Headers.Add("Authorization", "Bearer BQD77QSrgt4DaLmmdUbx4rZ38QA4ULtgmpnZDZCOW_j2_WErpk1WrOabrraNUQJbZ822xRXPY4mXhaKGFlUZmieyYYV4bAc2A3RItEs2GZLHCdkBtOK-H7FHkv7tqR8_pY7ghA5sN4ZmyvPSrKGfMvIX0JtOsD4LhpKaLyjLf3FUvTM");
                return await request.GetResponseAsync();
            } catch (WebException wex) {
                return wex?.Response as WebResponse;
            } catch (Exception) {
                return null;
            }
        }

    }
}
