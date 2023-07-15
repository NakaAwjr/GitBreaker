namespace Assets.MyAssets.Field.Scripts.Damages
{
    /// <summary>
    /// ダメージを受けられることを表すインターフェース
    /// </summary>
    public interface IDamageable
    {
        void DealDamage(Damage damage);
    }
}