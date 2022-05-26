namespace WW_WPF.BL
{
    public interface IItem
    {
        string Name { get; }
        string Description { get; }
        string ImageName { get; }
        
        void OnUse(Character character);
    }
}