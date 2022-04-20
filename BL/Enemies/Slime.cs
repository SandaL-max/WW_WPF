namespace WW_WPF.BL
{
    public class Slime : Enemy
    {
        public Slime(LevelSystem level = null) : base(level)
        {
            Health = new HealthSystem(30, 30);
        }

        public override string GetEntityInfo()
        {
            return "Враг (слизень)";
        }

        // Слизень рассывается с каждым ударом
        public override void Hit(IHitable hitable)
        {
            base.Hit(hitable);
            Health.HealthValue -= 1;
        }
    }
}