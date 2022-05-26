using System;
using System.Collections.Generic;

namespace WW_WPF.BL
{
    public class Slime : Enemy
    {
        public Slime(LevelSystem? level = null) : base(level)
        {
            ImageName = "Slime.png";
            Health = new HealthSystem(30, 30);
        }

        public override List<IItem> GetDrop()
        {
            var items = new List<IItem>();
            if (new Random().Next(1, 101) <= 50)
                items.Add(new IronChestplate());

            if (new Random().Next(1, 101) <= 25)
                items.Add(new HealthPotion((1 + _level.LevelValue) * 5));

            return items;
        }

        public override string GetEntityInfo()
        {
            return "Враг (слизень)";
        }

        // Слизень рассывается с каждым ударом
        public override void Hit(IHitable hitable)
        {
            base.Hit(hitable);
            Health.HealthValue -= 1;
        }
    }
}