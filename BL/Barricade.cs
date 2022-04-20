namespace WW_WPF.BL
{
    /// <summary>
    /// Класс баррикады
    /// </summary>
    public class Barricade : IHitable
    {
        // Прочность баррикады
        private int _durability = 50;

        public int Durability => _durability;

        public void ApplyDamage(int amount)
        {
            _durability -= amount;
        }
    }
}