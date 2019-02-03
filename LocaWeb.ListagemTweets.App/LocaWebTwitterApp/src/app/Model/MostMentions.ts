export class MostMentionsName {
  name: string;
  tweetsMaisMencionados: MostMentions[];
}

export class MostMentions {
  created_at: string;
  followers_count: number;
  screen_name: string;
  profile_link: string;
  link: string;
  retweet_count: number;
  text: string;
  favorite_count: number;
}

