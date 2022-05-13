namespace WW_WPF.BL
{
    public class HealthPotion : IItem
    {
        private int _healAmount;

        public HealthPotion(int healAmount = 0)
        {
            _healAmount = healAmount;
        }

        public string Name => "Зелье лечения";

        public string Description => "Лечит немного здоровья";

        public void OnUse(Character character)
        {
            character.Health.HealthValue += _healAmount;
        }
    }
}