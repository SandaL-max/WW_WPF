namespace WW_WPF.BL
{
    /// <summary>
    /// Дефолтное оружие
    /// </summary>
    public class Knife : Weapon
    {
        public override int ArmorBonus => 0;

        public override int DamageBonus => 1;

        public override string Name => "Нож";

        public override string Description => "Оружие бомжей";
    }
}