namespace MegaMariPrac.Dictionnaries
{
    /// <summary>Contains classes of constants used for setting or retrieving data</summary>
    public static class Constants
    {
        #region Character, HP, ammo

        public const int FULL_HP = 28,
            FULL_AMMO = 112,
            MARISA = 0,
            ALICE = 1;

        #endregion


        #region Stages-related

        /// <summary>Stages</summary>
        public class Stages
        {
            public const int REIMU = 0,
                CIRNO = 1,
                SAKUYA = 2,
                REMILIA = 3,
                YOUMU = 4,
                YUYUKO = 5,
                REISEN = 6,
                EIRIN = 7,
                PATCHY_1 = 8,
                PATCHY_2 = 9,
                PATCHY_5 = 10,
                PATCHY_6 = 11,
                PATCHY_3 = 12,
                PATCHY_4 = 13,
                CREDITS = 15,
                ELSEWHERE = 255;
        }

        /// <summary>Game screens (outside of stages)</summary>
        public class Screens
        {
            public const int TITLE_SCREEN = 0,
                STAGE_SELECT = 1,
                STAGE_LOADING = 2,
                STAGE = 3,
                WEAPON_GET = 4,
                GAME_OVER = 6,
                CONTINUE = 8;
        }

        /// <summary>Current stage checkpoints</summary>
        public class Checkpoints
        {
            public const int START = 0,
                CHECKPOINT = 1,
                BOSS = 2;
        }

        #endregion


        #region Game states

        /// <summary>Game states</summary>
        public class GameStates
        {
            public const int READY = 0,
                PLAYING = 1,
                TRANSITION_LEFT = 2,
                TRANSITION_UP = 4,
                TRANSITION_DOWN = 5,
                TRANSITION_RIGHT = 14,
                WIN_FANFARE = 6,
                WIN_NO_FANFARE_TELEPORT = 7,
                WIN_NO_FANFARE_NO_TELEPORT = 8,
                REFILL_FULL_HP = 9,
                REFILL_FULL_AMMO = 9,
                MENU = 11,
                DEAD = 12;
        }

        #endregion


        #region Weapons & E-Tanks

        /// <summary>Unlockable weapons</summary>
        public static class Weapons
        {
            public const int NORMAL = 0,
                REIMU = 1,
                REMILIA = 2,
                YOUMU = 3,
                REISEN = 4,
                CIRNO = 5,
                SAKUYA = 6,
                YUYUKO = 7,
                EIRIN = 8,
                SPECIAL = 9;
        }

        /// <summary>Indicate which character a boss weapon is enabled on</summary>
        public static class BossWeaponOn
        {
            public const int MARISA = 0,
                ALICE = 1,
                NOBODY = 255;
        }

        /// <summary>Indicate if special weapons are enabled (Broom, Doll)</summary>
        public static class SpecialWeapon
        {
            public const int ON = 0,
                OFF = 255;
        }

        /// <summary>E-Tanks</summary>
        public class Etanks
        {
            public const int NO_TANK = 0,
                ETANK = 1,
                STAR_TANK = 2,
                DOUBLE_ETANK = 3;
        }

        #endregion


        #region Sprites

        /// <summary>Character sprites</summary>
        public class Sprites
        {
            // Marisa
            public const short MARISA_NORMAL = 3376,
                MARISA_BROOM = 4096,
                MARISA_REIMU = 3456,
                MARISA_REMILIA = 3536,
                MARISA_YOUMU = 3616,
                MARISA_REISEN = 3696,
                MARISA_CIRNO = 3776,
                MARISA_SAKUYA = 3856,
                MARISA_YUYUKO = 3936,
                MARISA_EIRIN = 4016,

            // Alice
                ALICE_NORMAL = 4176,
                ALICE_DOLL = 4896,
                ALICE_REIMU = 4256,
                ALICE_REMILIA = 4336,
                ALICE_YOUMU = 4416,
                ALICE_REISEN = 4496,
                ALICE_CIRNO = 4576,
                ALICE_SAKUYA = 4656,
                ALICE_YUYUKO = 4736,
                ALICE_EIRIN = 4816;
        }

        #endregion
    }
}
