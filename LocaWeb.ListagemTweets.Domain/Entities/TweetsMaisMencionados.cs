namespace LocaWeb.ListagemTweets.Domain.Entities
{

   
    public class TweetsMaisMencionadosName
    {
        public string name { get; set; }
        public TweetsMaisMencionados tweetsMaisMencionados { get; set; }
    }

  


    public class TweetsMaisMencionados
    {

        public string created_at { get; set; }
        public string profile_link { get; set; }
        public int favorite_count { get; set; }
        public string screen_name { get; set; }
        public int followers_count { get; set; }
        public string link { get; set; }
        public string text { get; set; }
        public int retweet_count { get; set; }
       
       
       
       
       
    }
}
