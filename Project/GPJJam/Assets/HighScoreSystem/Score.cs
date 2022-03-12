namespace ColorInc.HighScore
{
    public class Score
    {
        public string User { get; set; }
        public int Money { get; set; }

        public Score(string user, int money)
        {
            User = user;
            Money = money;
        }
    }
}