namespace WW_WPF.BL
{
    public abstract class Weapon : IEquipable
    {
        public abstract int ArmorBonus { get; }

        public abstract int DamageBonus  { get; }

        public abstract string Name { get; }

        public abstract string Description  { get; }

        public virtual void OnHit(Enemy enemy) { }
    }
}