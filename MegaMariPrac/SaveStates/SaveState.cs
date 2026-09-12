namespace MegaMariPrac.SaveStates
{
    internal class SaveState
    {
        public int x { get; set; } public int y { get; set; }
        public float xF { get; set; } public float yF { get; set; }
        public int cameraViewX { get; set; } public int cameraViewY { get; set; }
        public int camera1X { get; set; } public int camera1Y { get; set; }
        public int camera2X { get; set; } public int camera2Y { get; set; }
        public int marisaHP { get; set; } public int aliceHP { get; set; }
        public short character { get; set; } public int characterWeapon { get; set; } public short characterSprite { get; set; }
        public int broomAmmo { get; set; } public int broomFlag { get; set; }
        public int cirnoAmmo { get; set; } public int cirnoFlag { get; set; }
        public int dollAmmo { get; set; } public int dollFlag { get; set; }
        public int eirinAmmo { get; set; } public int eirinFlag { get; set; }
        public int reimuAmmo { get; set; } public int reimuFlag { get; set; }
        public int reisenAmmo { get; set; } public int reisenFlag { get; set; }
        public int remiliaAmmo { get; set; } public int remiliaFlag { get; set; }
        public int sakuyaAmmo { get; set; } public int sakuyaFlag { get; set; }
        public int youmuAmmo { get; set; } public int youmuFlag { get; set; }
        public int yuyukoAmmo { get; set; } public int yuyukoFlag { get; set; }
        public int menuCursor { get; set; } public int tanks { get; set; } public int lives { get; set; }

        public SaveState(int x = 1, int y = 1, float xF = 1, float yF = 1,
                            int cameraViewX = 0, int cameraViewY = 0, int camera1X = 0, int camera1Y = 0, int camera2X = 0, int camera2Y = 0,
                            int marisaHP = 28, int aliceHP = 28, short character = 0, int characterWeapon = 0, short characterSprite = 0,
                            int broomAmmo = 112, int broomFlag = 255, int cirnoAmmo = 112, int cirnoFlag = 255,
                            int dollAmmo = 112, int dollFlag = 255, int eirinAmmo = 112, int eirinFlag = 255,
                            int reimuAmmo = 112, int reimuFlag = 255, int reisenAmmo = 112, int reisenFlag = 255,
                            int remiliaAmmo = 112, int remiliaFlag = 255, int sakuyaAmmo = 112, int sakuyaFlag = 255,
                            int youmuAmmo = 112, int youmuFlag = 255, int yuyukoAmmo = 112, int yuyukoFlag = 255,
                            int menuCursor = 0, int tanks = 0, int lives = 0)
        {
            this.x = x; this.y = y; this.xF = xF; this.yF = yF;
            this.cameraViewX = cameraViewX; this.cameraViewY = cameraViewY;
            this.camera1X = camera1X; this.camera1Y = camera1Y;
            this.camera2X = camera2X; this.camera2Y = camera2Y;
            this.marisaHP = marisaHP; this.aliceHP = aliceHP;
            this.character = character; this.characterWeapon = characterWeapon; this.characterSprite = characterSprite;
            this.broomAmmo = broomAmmo; this.broomFlag = broomFlag;
            this.cirnoAmmo = cirnoAmmo; this.cirnoFlag = cirnoFlag;
            this.dollAmmo = dollAmmo; this.dollFlag = dollFlag;
            this.eirinAmmo = eirinAmmo; this.eirinFlag = eirinFlag;
            this.reimuAmmo = reimuAmmo; this.reimuFlag = reimuFlag;
            this.reisenAmmo = reisenAmmo; this.reisenFlag = reisenFlag;
            this.remiliaAmmo = remiliaAmmo; this.remiliaFlag = remiliaFlag;
            this.sakuyaAmmo = sakuyaAmmo; this.sakuyaFlag = sakuyaFlag;
            this.youmuAmmo = youmuAmmo; this.youmuFlag = youmuFlag;
            this.yuyukoAmmo = yuyukoAmmo; this.yuyukoFlag = yuyukoFlag;
            this.menuCursor = menuCursor; this.tanks = tanks; this.lives = lives;
        }

        public SaveState(string save)
        {
            string[] split = save.Split(',');
            xF = float.Parse(split[0].Trim()); yF = float.Parse(split[1].Trim()); x = int.Parse(split[2]); y = int.Parse(split[3]);
            cameraViewX = int.Parse(split[4]); cameraViewY = int.Parse(split[5]);
            camera1X = int.Parse(split[6]); camera1Y = int.Parse(split[7]);
            camera2X = int.Parse(split[8]); camera2Y = int.Parse(split[9]);
            marisaHP = int.Parse(split[10]); aliceHP = int.Parse(split[11]);
            character = short.Parse(split[12]); characterWeapon = int.Parse(split[13]); characterSprite = short.Parse(split[14]);
            broomAmmo = int.Parse(split[15]); broomFlag = int.Parse(split[16]);
            cirnoAmmo = int.Parse(split[17]); cirnoFlag = int.Parse(split[18]);
            dollAmmo = int.Parse(split[19]); dollFlag = int.Parse(split[20]);
            eirinAmmo = int.Parse(split[21]); eirinFlag = int.Parse(split[22]);
            reimuAmmo = int.Parse(split[23]); reimuFlag = int.Parse(split[24]);
            reisenAmmo = int.Parse(split[25]); reisenFlag = int.Parse(split[26]);
            remiliaAmmo = int.Parse(split[27]); remiliaFlag = int.Parse(split[28]);
            sakuyaAmmo = int.Parse(split[29]); sakuyaFlag = int.Parse(split[30]);
            youmuAmmo = int.Parse(split[31]); youmuFlag = int.Parse(split[32]);
            yuyukoAmmo = int.Parse(split[33]); yuyukoFlag = int.Parse(split[34]);
            menuCursor = int.Parse(split[35]); tanks = int.Parse(split[36]); lives = int.Parse(split[37]);
        }

        public override string ToString()
        {
            return xF.ToString("0.000") + "," + yF.ToString("0.000") + "," + x + "," + y + "," +
                    cameraViewX + "," + cameraViewY + "," +
                    camera1X + "," + camera1Y + "," + camera2X + "," + camera2Y + "," +
                    marisaHP + "," + aliceHP + "," + character + "," + characterWeapon + "," + characterSprite + "," +
                    broomAmmo + "," + broomFlag + "," + cirnoAmmo + "," + cirnoFlag + "," +
                    dollAmmo + "," + dollFlag + "," + eirinAmmo + "," + eirinFlag + "," +
                    reimuAmmo + "," + reimuFlag + "," + reisenAmmo + "," + reisenFlag + "," +
                    remiliaAmmo + "," + remiliaFlag + "," + sakuyaAmmo + "," + sakuyaFlag + "," +
                    youmuAmmo + "," + youmuFlag + "," + yuyukoAmmo + "," + yuyukoFlag + "," +
                    menuCursor + "," + tanks + "," + lives;
        }
    }
}
