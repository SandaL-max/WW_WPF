namespace WW_WPF.BL
{
    public class Barbarian : Enemy
    {
        public Barbarian(LevelSystem level = null) : base(level)
        {

            ImageName = "pngwing.com(3).png";
            _baseDamage = 1;
            Health = new HealthSystem(50, 50);
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