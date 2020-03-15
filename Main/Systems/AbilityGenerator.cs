﻿using RogueSharp.SadConsole.Playground.Main.Abilities;
using RogueSharp.SadConsole.Playground.Main.Core;

namespace RogueSharp.SadConsole.Playground.Main.Systems
{
    public static class AbilityGenerator
    {
        public static Pool<Ability> _abilityPool;

        public static Ability CreateAbility()
        {
            if (_abilityPool == null)
            {
                _abilityPool = new Pool<Ability>();
                _abilityPool.Add(new Heal(10), 10);
                _abilityPool.Add(new MagicMissile(2, 80), 10);
                _abilityPool.Add(new RevealMap(15), 10);
                _abilityPool.Add(new Whirlwind(), 10);
                _abilityPool.Add(new Fireball(4, 60, 2), 10);
                _abilityPool.Add(new LightningBolt(6, 40), 10);
            }

            return _abilityPool.Get();
        }
    }
}
