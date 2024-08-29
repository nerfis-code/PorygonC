using PorygonC.Pokemons.Domain;
namespace PorygonC.Pokemons.Application
{
    static class TypeOfTypes
    {
        public static float GetDamageMultiplier(TypeKey attackType, TypeKey defType)
        {
            if (attackType == TypeKey.UNKNOWN || defType == TypeKey.UNKNOWN)
            {
                return 1;
            }

            switch (defType)
            {
                case TypeKey.NORMAL:
                    switch (attackType)
                    {
                        case TypeKey.FIGHTING:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FLYING:
                        case TypeKey.POISON:
                        case TypeKey.GROUND:
                        case TypeKey.ROCK:
                        case TypeKey.BUG:
                        case TypeKey.STEEL:
                        case TypeKey.FIRE:
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                        case TypeKey.ELECTRIC:
                        case TypeKey.PSYCHIC:
                        case TypeKey.ICE:
                        case TypeKey.DRAGON:
                        case TypeKey.DARK:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.GHOST:
                        default:
                            return 0;
                    }
                case TypeKey.FIGHTING:
                    switch (attackType)
                    {
                        case TypeKey.FLYING:
                        case TypeKey.PSYCHIC:
                        case TypeKey.FAIRY:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FIGHTING:
                        case TypeKey.POISON:
                        case TypeKey.GROUND:
                        case TypeKey.GHOST:
                        case TypeKey.STEEL:
                        case TypeKey.FIRE:
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                        case TypeKey.ELECTRIC:
                        case TypeKey.ICE:
                        case TypeKey.DRAGON:
                            return 1;
                        case TypeKey.ROCK:
                        case TypeKey.BUG:
                        case TypeKey.DARK:
                            return 0.5f;
                        default:
                            return 0;
                    }
                case TypeKey.FLYING:
                    switch (attackType)
                    {
                        case TypeKey.ROCK:
                        case TypeKey.ELECTRIC:
                        case TypeKey.ICE:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FLYING:
                        case TypeKey.POISON:
                        case TypeKey.GHOST:
                        case TypeKey.STEEL:
                        case TypeKey.FIRE:
                        case TypeKey.WATER:
                        case TypeKey.PSYCHIC:
                        case TypeKey.DRAGON:
                        case TypeKey.DARK:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.FIGHTING:
                        case TypeKey.BUG:
                        case TypeKey.GRASS:
                            return 0.5f;
                        case TypeKey.GROUND:
                        default:
                            return 0;
                    }
                case TypeKey.POISON:
                    switch (attackType)
                    {
                        case TypeKey.GROUND:
                        case TypeKey.PSYCHIC:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FLYING:
                        case TypeKey.ROCK:
                        case TypeKey.GHOST:
                        case TypeKey.STEEL:
                        case TypeKey.FIRE:
                        case TypeKey.WATER:
                        case TypeKey.ELECTRIC:
                        case TypeKey.ICE:
                        case TypeKey.DRAGON:
                        case TypeKey.DARK:
                            return 1;
                        case TypeKey.FIGHTING:
                        case TypeKey.POISON:
                        case TypeKey.BUG:
                        case TypeKey.GRASS:
                        case TypeKey.FAIRY:
                            return 0.5f;
                        default:
                            return 0;
                    }
                case TypeKey.GROUND:
                    switch (attackType)
                    {
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                        case TypeKey.ICE:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FIGHTING:
                        case TypeKey.FLYING:
                        case TypeKey.GROUND:
                        case TypeKey.BUG:
                        case TypeKey.GHOST:
                        case TypeKey.STEEL:
                        case TypeKey.FIRE:
                        case TypeKey.PSYCHIC:
                        case TypeKey.DRAGON:
                        case TypeKey.DARK:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.POISON:
                        case TypeKey.ROCK:
                            return 0.5f;
                        case TypeKey.ELECTRIC:
                        default:
                            return 0;
                    }
                case TypeKey.ROCK:
                    switch (attackType)
                    {
                        case TypeKey.FIGHTING:
                        case TypeKey.GROUND:
                        case TypeKey.STEEL:
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                            return 2;
                        case TypeKey.ROCK:
                        case TypeKey.BUG:
                        case TypeKey.GHOST:
                        case TypeKey.ELECTRIC:
                        case TypeKey.PSYCHIC:
                        case TypeKey.ICE:
                        case TypeKey.DRAGON:
                        case TypeKey.DARK:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.NORMAL:
                        case TypeKey.FLYING:
                        case TypeKey.POISON:
                        case TypeKey.FIRE:
                            return 0.5f;
                        default:
                            return 0;
                    }
                case TypeKey.BUG:
                    switch (attackType)
                    {
                        case TypeKey.FLYING:
                        case TypeKey.ROCK:
                        case TypeKey.FIRE:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.POISON:
                        case TypeKey.BUG:
                        case TypeKey.GHOST:
                        case TypeKey.STEEL:
                        case TypeKey.WATER:
                        case TypeKey.ELECTRIC:
                        case TypeKey.PSYCHIC:
                        case TypeKey.ICE:
                        case TypeKey.DRAGON:
                        case TypeKey.DARK:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.FIGHTING:
                        case TypeKey.GROUND:
                        case TypeKey.GRASS:
                            return 0.5f;
                        default:
                            return 0;
                    }
                case TypeKey.GHOST:
                    switch (attackType)
                    {
                        case TypeKey.GHOST:
                        case TypeKey.DARK:
                            return 2;
                        case TypeKey.FLYING:
                        case TypeKey.GROUND:
                        case TypeKey.ROCK:
                        case TypeKey.STEEL:
                        case TypeKey.FIRE:
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                        case TypeKey.ELECTRIC:
                        case TypeKey.PSYCHIC:
                        case TypeKey.ICE:
                        case TypeKey.DRAGON:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.POISON:
                        case TypeKey.BUG:
                            return 0.5f;
                        case TypeKey.NORMAL:
                        case TypeKey.FIGHTING:
                        default:
                            return 0;
                    }
                case TypeKey.STEEL:
                    switch (attackType)
                    {
                        case TypeKey.FIGHTING:
                        case TypeKey.GROUND:
                        case TypeKey.FIRE:
                            return 2;
                        case TypeKey.GHOST:
                        case TypeKey.WATER:
                        case TypeKey.ELECTRIC:
                        case TypeKey.DARK:
                            return 1;
                        case TypeKey.NORMAL:
                        case TypeKey.FLYING:
                        case TypeKey.ROCK:
                        case TypeKey.BUG:
                        case TypeKey.STEEL:
                        case TypeKey.GRASS:
                        case TypeKey.PSYCHIC:
                        case TypeKey.ICE:
                        case TypeKey.DRAGON:
                        case TypeKey.FAIRY:
                            return 0.5f;
                        case TypeKey.POISON:
                        default:
                            return 0;
                    }
                case TypeKey.FIRE:
                    switch (attackType)
                    {
                        case TypeKey.GROUND:
                        case TypeKey.ROCK:
                        case TypeKey.WATER:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FIGHTING:
                        case TypeKey.FLYING:
                        case TypeKey.POISON:
                        case TypeKey.GHOST:
                        case TypeKey.ELECTRIC:
                        case TypeKey.PSYCHIC:
                        case TypeKey.DRAGON:
                        case TypeKey.DARK:
                            return 1;
                        case TypeKey.BUG:
                        case TypeKey.STEEL:
                        case TypeKey.FIRE:
                        case TypeKey.GRASS:
                        case TypeKey.ICE:
                        case TypeKey.FAIRY:
                            return 0.5f;
                        default:
                            return 0;
                    }
                case TypeKey.WATER:
                    switch (attackType)
                    {
                        case TypeKey.GRASS:
                        case TypeKey.ELECTRIC:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FIGHTING:
                        case TypeKey.FLYING:
                        case TypeKey.POISON:
                        case TypeKey.GROUND:
                        case TypeKey.ROCK:
                        case TypeKey.BUG:
                        case TypeKey.GHOST:
                        case TypeKey.PSYCHIC:
                        case TypeKey.DRAGON:
                        case TypeKey.DARK:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.STEEL:
                        case TypeKey.FIRE:
                        case TypeKey.WATER:
                        case TypeKey.ICE:
                            return 0.5f;
                        default:
                            return 0;
                    }
                case TypeKey.GRASS:
                    switch (attackType)
                    {
                        case TypeKey.FLYING:
                        case TypeKey.POISON:
                        case TypeKey.BUG:
                        case TypeKey.FIRE:
                        case TypeKey.ICE:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FIGHTING:
                        case TypeKey.ROCK:
                        case TypeKey.GHOST:
                        case TypeKey.STEEL:
                        case TypeKey.PSYCHIC:
                        case TypeKey.DRAGON:
                        case TypeKey.DARK:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.GROUND:
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                        case TypeKey.ELECTRIC:
                            return 0.5f;
                        default:
                            return 0;
                    }
                case TypeKey.ELECTRIC:
                    switch (attackType)
                    {
                        case TypeKey.GROUND:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FIGHTING:
                        case TypeKey.POISON:
                        case TypeKey.ROCK:
                        case TypeKey.BUG:
                        case TypeKey.GHOST:
                        case TypeKey.FIRE:
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                        case TypeKey.PSYCHIC:
                        case TypeKey.ICE:
                        case TypeKey.DRAGON:
                        case TypeKey.DARK:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.FLYING:
                        case TypeKey.STEEL:
                        case TypeKey.ELECTRIC:
                            return 0.5f;
                        default:
                            return 0;
                    }
                case TypeKey.PSYCHIC:
                    switch (attackType)
                    {
                        case TypeKey.BUG:
                        case TypeKey.GHOST:
                        case TypeKey.DARK:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FLYING:
                        case TypeKey.POISON:
                        case TypeKey.GROUND:
                        case TypeKey.ROCK:
                        case TypeKey.STEEL:
                        case TypeKey.FIRE:
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                        case TypeKey.ELECTRIC:
                        case TypeKey.ICE:
                        case TypeKey.DRAGON:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.FIGHTING:
                        case TypeKey.PSYCHIC:
                            return 0.5f;
                        default:
                            return 0;
                    }
                case TypeKey.ICE:
                    switch (attackType)
                    {
                        case TypeKey.FIGHTING:
                        case TypeKey.ROCK:
                        case TypeKey.STEEL:
                        case TypeKey.FIRE:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FLYING:
                        case TypeKey.POISON:
                        case TypeKey.GROUND:
                        case TypeKey.BUG:
                        case TypeKey.GHOST:
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                        case TypeKey.ELECTRIC:
                        case TypeKey.PSYCHIC:
                        case TypeKey.DRAGON:
                        case TypeKey.DARK:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.ICE:
                            return 0.5f;
                        default:
                            return 0;
                    }
                case TypeKey.DRAGON:
                    switch (attackType)
                    {
                        case TypeKey.ICE:
                        case TypeKey.DRAGON:
                        case TypeKey.FAIRY:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FIGHTING:
                        case TypeKey.FLYING:
                        case TypeKey.POISON:
                        case TypeKey.GROUND:
                        case TypeKey.ROCK:
                        case TypeKey.BUG:
                        case TypeKey.GHOST:
                        case TypeKey.STEEL:
                        case TypeKey.PSYCHIC:
                        case TypeKey.DARK:
                            return 1;
                        case TypeKey.FIRE:
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                        case TypeKey.ELECTRIC:
                            return 0.5f;
                        default:
                            return 0;
                    }
                case TypeKey.DARK:
                    switch (attackType)
                    {
                        case TypeKey.FIGHTING:
                        case TypeKey.BUG:
                        case TypeKey.FAIRY:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FLYING:
                        case TypeKey.POISON:
                        case TypeKey.GROUND:
                        case TypeKey.ROCK:
                        case TypeKey.STEEL:
                        case TypeKey.FIRE:
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                        case TypeKey.ELECTRIC:
                        case TypeKey.ICE:
                        case TypeKey.DRAGON:
                            return 1;
                        case TypeKey.GHOST:
                        case TypeKey.DARK:
                            return 0.5f;
                        case TypeKey.PSYCHIC:
                        default:
                            return 0;
                    }
                case TypeKey.FAIRY:
                    switch (attackType)
                    {
                        case TypeKey.POISON:
                        case TypeKey.STEEL:
                            return 2;
                        case TypeKey.NORMAL:
                        case TypeKey.FLYING:
                        case TypeKey.GROUND:
                        case TypeKey.ROCK:
                        case TypeKey.GHOST:
                        case TypeKey.FIRE:
                        case TypeKey.WATER:
                        case TypeKey.GRASS:
                        case TypeKey.ELECTRIC:
                        case TypeKey.PSYCHIC:
                        case TypeKey.ICE:
                        case TypeKey.FAIRY:
                            return 1;
                        case TypeKey.FIGHTING:
                        case TypeKey.BUG:
                        case TypeKey.DARK:
                            return 0.5f;
                        case TypeKey.DRAGON:
                        default:
                            return 0;
                    }
                case TypeKey.STELLAR:
                    return 1;
            }
            return 1;
        }
    }
}