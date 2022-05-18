namespace WW_WPF.BL
{
    public class Wizard : Character
    {
        public Wizard()
        {
            _baseDamage = 10;
            Health = new HealthSystem(75, 75);
            ImageName = "WizardRight.png";
        }

        public override string GetEntityInfo()
        {
            return $"Персонаж (Маг)";
        }

        // Маг высасывает здоровье противника при каждом ударе
        public override void Hit(IHitable hitable)
        {
            if (hitable is Enemy)
            {
                var enemy = (Enemy)hitable;
                var healthBeforeHit = enemy.Health.HealthValue;
                base.Hit(enemy);
                if (healthBeforeHit > enemy.Health.HealthValue)
                    Health.HealthValue += healthBeforeHit - enemy.Health.HealthValue;
            }
            else
            {
                base.Hit(hitable);
            }
        }
    }
}