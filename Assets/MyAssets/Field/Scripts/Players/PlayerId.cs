using System;

namespace Assets.MyAssets.Field.Scripts.Players
{
    public enum PlayerId
    {
        Player1 = 1,
        Player2 = 2,
        Player3 = 3,
        Player4 = 4     
    }
    
    static class PlayerIdUtility
    {
        public static PlayerId GetIDFromPlayerName(string playerName)
        {
            switch (playerName)
            {
                case "1P":
                    return PlayerId.Player1;
                case "2P":
                    return PlayerId.Player2;
                case "3P":
                    return PlayerId.Player3;
                case "4P":
                    return PlayerId.Player4;
                default:
                    throw new ArgumentOutOfRangeException("PlayerName", playerName, null);
            }
        }
    }
}
