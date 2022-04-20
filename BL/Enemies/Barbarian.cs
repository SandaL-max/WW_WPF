namespace WW_WPF.BL
{
    public class Barbarian : Enemy
    {
        public Barbarian(LevelSystem level = null) : base(level)
        {
            _baseDamage = 0;
            Health = new HealthSystem(20, 20);
        }

        public override string GetEntityInfo()
        {
            return "Враг (варвар)";
        }

        // Варвар увеличивает урон при каждом ударе
        public override void Hit(IHitable hitable)
        {
            base.Hit(hitable);
            _baseDamage++;
        }
    }
}