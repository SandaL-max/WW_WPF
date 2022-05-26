using System.Windows.Media.Imaging;

namespace WW_WPF.BL
{
    public interface IItem
    {
        string Name { get; }
        string Description { get; }
        string ImageName { get; }
        
        TransformedBitmap ImageObj 
        {
            get
            {
                return AppState.GetImageFromSources(ImageName);
            }
        }

        void OnUse(Character character);
    }
}