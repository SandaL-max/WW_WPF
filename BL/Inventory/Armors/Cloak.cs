namespace WW_WPF.BL
{
    /// <summary>
    /// Дефолтная броня
    /// </summary>
    public class Cloak : Armor
    {
        public override int ArmorBonus => 1;

        public override int DamageBonus => 0;

        public override string Name => "Плащ";

        public override string Description => "Обоссаный кусок ткани";
    }
}