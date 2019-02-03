using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LocaWeb.ListagemTweets.Domain.Entities;
using LocaWeb.ListagemTweets.Web.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LocaWeb.ListagemTweets.Web.Servicos
{
    public class TweetsServico : ITweets
    {
        private readonly IMemoryCache _cache;

        private readonly IConfiguration _configuration;


        public TweetsServico(IConfiguration configuration, IMemoryCache cache)
        {
            _configuration = configuration;
            _cache = cache;
        }

       

        public async Task<string> TwittersLocaweb()
        {

            if (!_cache.TryGetValue("ListTwitters", out string jsonString))
            {

                var uri = _configuration.GetValue<string>("LocaWebSettings:HTTP_USERNAME");

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Username", "fabiogalantemans@gmail.com");

                    using (var response = await client.GetAsync(uri))
                    {
                        if (response.IsSuccessStatusCode) jsonString = await response.Content.ReadAsStringAsync();

                    }
                }


                _cache.Set("ListTwitters", jsonString, TimeSpan.FromSeconds(30));
            }


            return jsonString;

        }

        

        public async Task<IEnumerable<TweetsMaisRelevantes>> ObterMaisRelevantes()
        {
            const int idLocaWeb = 42;

            var json = await TwittersLocaweb();

            var tweetsJson = JsonConvert.DeserializeObject<RootObject>(json);

            var relevantes = tweetsJson.statuses
                .Where(l => l.in_reply_to_user_id != idLocaWeb && l.text.Contains("@locaweb"))
                .OrderByDescending(u => u.user.followers_count)
                .ThenByDescending(u => u.retweet_count)
                .ThenByDescending(u => u.favorite_count)
                .Select(t =>
                    new TweetsMaisRelevantes
                    {
                        followers_count = t.user.followers_count,
                        screen_name = t.user.screen_name,
                        profile_link = t.user.entities.url.urls[0].url,
                        created_at = t.created_at,
                        link = t.source,
                        retweet_count = t.user.statuses_count,
                        text = t.text,
                        favorite_count = t.favorite_count
                    })
                .ToList();

            

            return relevantes;
        }

        public async Task<IEnumerable<TweetsMaisMencionadosName>> ObterMaisMencionados()
        {
            const int idLocaWeb = 42;

            var json = await TwittersLocaweb();

            var tweetsJson = JsonConvert.DeserializeObject<RootObject>(json);

            var mencionados = tweetsJson.statuses
                .Where(l => l.in_reply_to_user_id != idLocaWeb && l.text.Contains("@locaweb"))
                .OrderByDescending(u => u.user.followers_count)
                .ThenByDescending(u => u.retweet_count)
                .ThenByDescending(u => u.favorite_count)
                .Select(t =>
                    new TweetsMaisMencionadosName
                    {
                        name = t.user.screen_name,
                        tweetsMaisMencionados = new TweetsMaisMencionados
                        {
                            followers_count = t.user.followers_count,
                            screen_name = t.user.screen_name,
                            profile_link = t.user.entities.url.urls[0].url,
                            created_at = t.created_at,
                            link = t.source,
                            retweet_count = t.user.statuses_count,
                            text = t.text,
                            favorite_count = t.favorite_count
                        }
                    }).ToList();



            return mencionados;
        }
    }
}
