namespace WW_WPF.BL
{
    public class IronChestplate : Armor
    {
        public override int ArmorBonus => 3;

        public override int DamageBonus => 0;

        public override string Name => "Железный нагрудник";

        public override string Description => "Неплохо защищает зад, но сука тяжелый";
        public override string ImageName => "Chestplate.png";
    }
}