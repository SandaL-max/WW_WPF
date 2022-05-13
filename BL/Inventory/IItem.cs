namespace WW_WPF.BL
{
    public interface IItem
    {
        string Name { get; }
        string Description { get; }
        void OnUse(Character character);
    }
}