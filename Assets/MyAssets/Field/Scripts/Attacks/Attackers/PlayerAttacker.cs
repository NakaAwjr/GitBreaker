using Assets.MyAssets.Field.Scripts.Players;

namespace Assets.MyAssets.Field.Scripts.Attacks.Attackers
{
    public struct PlayerAttacker : IAttacker
    {
        public PlayerId PlayerId { get; private set; }

        public PlayerAttacker(PlayerId playerId) : this()
        {
            PlayerId = playerId;
        }
    }
}
