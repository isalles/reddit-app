namespace Reddit.Framework.Utility.Time
{
    public class UtcConvert : TimeConvert
    { 
        public override long ConvertToSeconds(DateTime dateTime)
        {
            return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
        }

        public override DateTime ParseDateFromSeconds(long seconds)
        {
            return DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime;
        }
    }
}