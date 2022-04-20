namespace WW_WPF.BL
{
    /// <summary>
    /// ����� ���������
    /// </summary>
    public class Barricade : IHitable
    {
        // ��������� ���������
        private int _durability = 50;

        public int Durability => _durability;

        public void ApplyDamage(int amount)
        {
            _durability -= amount;
        }
    }
}