namespace WW_WPF.BL
{
    public interface IEquipable : IItem
    {
        int ArmorBonus { get; }
        int DamageBonus { get; }

        void OnEquip(Character character)
        {
            character.Equip(this);
        }

        void IItem.OnUse(Character character)
        {
            OnEquip(character);
        }
    }
}