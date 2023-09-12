using System;
using System.Collections.Generic;
using System.Linq;

namespace A9_cs
{

    public enum MovieColor
    {
        Colorful,
        BW,
        Ambigous
    }
    public enum ContentRating
    {
        PG_13,
        PG,
        G,
        R,
        NC_17 
    }
    public class MovieData
    {
        public MovieColor? color;
        public string movie_title;
        public string directorName;
        public long? num_critic;
        public long? duration;
        public string actor_1_name;
        public string actor_2_name;
        public string actor_3_name;
        public string[] genres;
        public long? num_voted_users;
        public string[] plot_keywords;
        public long? num_user_for_reviews;
        public string language;
        public string country;
        public ContentRating? content_rating;
        public long? budget;
        public long? year;
        public float? imdb_score;
        public float? aspect_ratio;
        public MovieData(string[] fields)
        {

            // color
            //رنگ آن فیلم را مشخص میکند که یا رنگی است یا سیاه و سفید
            //متاسفانه اطلاعات رنگ بعضی از اطلاعات فیلم ها
            //نابود شده اند.برای آنها مقدار مبهم
            //Ambigous
            // در نظر گرفته شده.

            if (fields[0] == "Color")
                color = MovieColor.Colorful;
            else if (fields[0].ToLower() == "BlackandWhite".ToLower())
                color = MovieColor.BW;
            else
                color = MovieColor.Ambigous;
            directorName = fields[1];
            num_critic = long.Parse(fields[2]);
            duration = long.Parse(fields[3]);
            actor_2_name = fields[6];
            genres = fields[8].Split("|");
            actor_1_name = fields[9];
            movie_title = fields[10];
            num_voted_users = long.Parse(fields[11]);
            actor_3_name = fields[12];
            plot_keywords = fields[14].Split("|");
            num_user_for_reviews = long.Parse(fields[15]);
            language = fields[16];
            country = fields[17];
            if (fields[18] == "G")
                content_rating = ContentRating.G;
            else if (fields[18] == "PG")
                content_rating = ContentRating.PG;
            else if (fields[18] == "R")
                content_rating = ContentRating.R;
            else if (fields[18] == "NC_17")
                content_rating = ContentRating.NC_17;
            else
                content_rating = ContentRating.PG_13;
            budget = long.Parse(fields[19]);
            year = long.Parse(fields[20]);
            imdb_score = float.Parse(fields[21]);
            aspect_ratio = float.Parse(fields[22]);
        }
    }
}