using System;

namespace namecheap_dynamic_dns
{
    public class Profile
    {
        public string Host;
        public string Domain;
        public string DynamicDnsPassword;
        public UpdateIntervalEnum UpdateInterval;
        public string IpAddress;
        public bool AutoDetectIpAddress;
        public DateTime LastSyncTime;

        public Profile()
        {
            LastSyncTime = DateTime.MinValue;
        }

        public string Label
        {
            get
            {
                return Host + "." + Domain;
            }
        }

        public static TimeSpan GetTimeSpanForUpdateInterval(UpdateIntervalEnum updateInterval)
        {
            switch (updateInterval)
            {
                case UpdateIntervalEnum.FIFTEEN_MINUTES:
                    return new TimeSpan(9000000000);
                case UpdateIntervalEnum.THIRTY_MINUTES:
                    return new TimeSpan(18000000000);
                case UpdateIntervalEnum.ONE_HOUR:
                    return new TimeSpan(36000000000);
                case UpdateIntervalEnum.THREE_HOURS:
                    return new TimeSpan(108000000000);
                case UpdateIntervalEnum.SIX_HOURS:
                    return new TimeSpan(216000000000);
                case UpdateIntervalEnum.TWENTY_FOUR_HOURS:
                    return new TimeSpan(864000000000);
                default:
                    throw new Exception();
            }
        }
    }

    public enum UpdateIntervalEnum
    {
        FIFTEEN_MINUTES,
        THIRTY_MINUTES,
        ONE_HOUR,
        THREE_HOURS,
        SIX_HOURS,
        TWENTY_FOUR_HOURS,
    }
}
