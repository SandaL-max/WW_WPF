namespace WW_WPF.BL
{
    public class Warrior : Character
    {
        public Warrior()
        {
            _baseDamage = 10;
        }

        public override string GetEntityInfo()
        {
            return $"Персонаж (Воин)";
        }

        // Воин увеличивает свой базовый урон при каждом повышении уровня
        public override void OnLevelUp()
        {
            base.OnLevelUp();
            _baseDamage++;
        }
    }
}