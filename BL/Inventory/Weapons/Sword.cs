namespace WW_WPF.BL
{
    public class Sword : Weapon
    {
        public override int ArmorBonus => 0;

        public override int DamageBonus => 3;

        public override string Name => "Меч";

        public override string Description => "Эта штука весьма острая";
    }
}