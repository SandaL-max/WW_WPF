using System;
using System.Collections.Generic;

namespace WW_WPF.BL
{
    public class Barbarian : Enemy
    {
        public Barbarian(LevelSystem? level = null) : base(level)
        {
            ImageName = "Barbarian.png";
            _baseDamage = 1;
            Health = new HealthSystem(50, 50);
        }

        public override List<IItem> GetDrop()
        {
            var items = new List<IItem>();
            if (new Random().Next(1, 101) <= 50)
                items.Add(new Sword());

            if (new Random().Next(1, 101) <= 25)
                items.Add(new HealthPotion((1 + _level.LevelValue) * 5));

            return items;
        }

        public override string GetEntityInfo()
        {
            return "Враг (варвар)";
        }

        // Варвар увеличивает урон при каждом ударе
        public override void Hit(IHitable hitable)
        {
            base.Hit(hitable);
            _baseDamage++;
        }
    }
}