/*
 * Created by Leonardo Martin
 * Created 3/11/2022 2:19:32 PM
 */

namespace ColorInc.HighScore
{
    /// <summary>  
    /// Score Model Class. Holds the score data for upload and download.
    /// </summary>
    public class Score
    {
        public string User { get; }
        public int Money { get; }

        public Score(string user, int money)
        {
            User = user;
            Money = money;
        }
    }
}