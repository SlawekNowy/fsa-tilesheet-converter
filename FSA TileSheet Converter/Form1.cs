using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FSA_TileSheet_Converter
{
    public partial class Form1 : Form
    {

        Bitmap tileSheet;
        byte[] tileSource;
        byte[] tileMap;
        byte[] tileBaseBG;
        byte[] paletteData;
        public int palette;

        public Form1()
        {
            InitializeComponent();

            tileSheet = new Bitmap(256, 1024);

            //Load the 8x8 tile data
            tileSource = File.ReadAllBytes("Resources/SpriteSheet.raw");

            //Load the "base" tile data
            tileBaseBG = File.ReadAllBytes("Resources/bg_base_sch.raw");

            //Load the palette data
            paletteData = File.ReadAllBytes("Resources/0.rarc");

            //Load the tile map data
            tileMap = File.ReadAllBytes("Resources/Tile map.spl");

            destPicBox.Image = tileSheet;


        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            int tileCounter = 0;

            //Go through each tile entry in the map
            for (int i = 0; i < 8192; i += 2)
            {
                palette = tileMap[i + 1] >> 4;

                int modifier = 0;
                int tileHiNibble = (tileMap[i + 1] & 0xF);
                while (tileHiNibble > 3)
                {
                    tileHiNibble -= 4;
                    modifier++;
                }

                int tile = tileMap[i] + (tileHiNibble << 8);

                DrawTile(tile, palette,i,tileCounter,modifier);

                progressBar1.Value = i;

                tileCounter += 1;
                if (tileCounter > 3)
                    tileCounter = 0;
            }

            progressBar1.Value = 0;
            destPicBox.Refresh();
            tileSheet.Save("C:\\bla.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void DrawTile(int tile, int palette, int mapEntry, int tilePart,int modifier)
        {
            int x = 0;
            int y = 0;

            switch (tilePart)
            {
                case 0:
                    x = 0;
                    y = 0;
                    break;
                case 1:
                    x = 8;
                    y = 0;
                    break;
                case 2:
                    x = 0;
                    y = 8;
                    break;
                case 3:
                    x = 8;
                    y = 8;
                    break;
            }

            int destTile = mapEntry / 8;
            int destX = destTile % 16;
            int destY = destTile / 16;
            x = x + (destX * 16);
            y = y + (destY * 16);

            tile = (((tile / 16) * 1024) + (tile - ((tile / 16) * 16)) * 8);

            switch (modifier)
            {
                case 0:
                    //Do each of the 8 rows for this tile
                    for (int row = 0; row < 8; row++)
                    {
                        //Do each of the 8 pixels for this row
                        for (int column = 0; column < 8; column++)
                        {
                            //get array ready
                            byte[] arrayA;

                            int sourceByte = (tile) + column + (row * 128);
                            //If the tile we need is outside of the main tilesource
                            if (sourceByte > 49151)
                            {
                                //then use tileBaseBG
                                arrayA = tileBaseBG;
                                sourceByte -= 49152;
                                if (sourceByte > 8191)
                                    sourceByte = 16;
                            }
                            else
                                arrayA = tileSource;

                            setThatPixel(sourceByte, column, row, x, y, arrayA);
                        }
                    }
                    break;
                case 1:
                    //Do each of the 8 rows for this tile
                    for (int row = 0; row < 8; row++)
                    {
                        int xx = 0;
                        //Do each of the 8 pixels for this row
                        for (int column = 7; column >= 0; column--)
                        {

                            //get array ready
                            byte[] arrayA;

                            int sourceByte = (tile) + column + (row * 128);
                            //If the tile we need is outside of the main tilesource
                            if (sourceByte > 49151)
                            {
                                //then use tileBaseBG
                                arrayA = tileBaseBG;
                                sourceByte -= 49152;
                                if (sourceByte > 8191)
                                    sourceByte = 16;
                            }
                            else
                                arrayA = tileSource;

                            setThatPixel(sourceByte, xx, row, x, y, arrayA);
                            xx++;
                        }
                    }
                    break;
                case 2:
                    int yy = 0;
                    //Do each of the 8 rows for this tile
                    for (int row = 7; row >= 0; row--)
                    {
                        //Do each of the 8 pixels for this row
                        for (int column = 7; column >= 0; column--)
                        {

                            //get array ready
                            byte[] arrayA;

                            int sourceByte = (tile) + column + (row * 128);
                            //If the tile we need is outside of the main tilesource
                            if (sourceByte > 49151)
                            {
                                //then use tileBaseBG
                                arrayA = tileBaseBG;
                                sourceByte -= 49151;
                                if (sourceByte > 8191)
                                    sourceByte = 16;
                            }
                            else
                                arrayA = tileSource;

                            setThatPixel(sourceByte, column, yy, x, y, arrayA);
                        }
                        yy++;
                    }
                    break;
                case 3:
                    //Do each of the 8 rows for this tile
                    int u = 0;
                    for (int row = 7; row >= 0; row--)
                    {
                        int xx = 0;
                        //Do each of the 8 pixels for this row
                        for (int column = 7; column >= 0; column--)
                        {

                            //get array ready
                            byte[] arrayA;

                            int sourceByte = (tile) + column + (row * 128);
                            //If the tile we need is outside of the main tilesource
                            if (sourceByte > 49151)
                            {
                                //then use tileBaseBG
                                arrayA = tileBaseBG;
                                sourceByte -= 49151;
                                if (sourceByte > 8191)
                                    sourceByte = 16;
                            }
                            else
                                arrayA = tileSource;

                            setThatPixel(sourceByte, xx, u, x, y, arrayA);
                            xx++;
                        }
                        u++;
                    }
                    break;
                case 4 :
                    textBoxDebug.AppendText("Case 4 has been used!");
                    break;
            }
            
        }

        private void setThatPixel(int sourceByte, int column, int row, int x, int y, byte[] tileData)
        {
            //int color = (int)(tileData[sourceByte] + (tileData[sourceByte] << 8) + (tileData[sourceByte] << 16) + 0xFF000000);
            int pixel = tileData[sourceByte] >> 4;
            byte[] color = PaletteColor(palette, pixel);
            tileSheet.SetPixel((column + x), (row + y), Color.FromArgb(color[3],color[2],color[1],color[0]));
        }

        private byte[] PaletteColor(int palette, int pixel)
        {
            byte[] color = new byte[4];

            palette = palette * 32;
            pixel = pixel * 2;

            if (pixel == 0)
                color[0] = 0;
            else
            {
                int rawColorData = paletteData[palette + pixel] + (paletteData[palette + pixel + 1] << 8);
                color[0] = (byte)(((rawColorData & 0x7C00) >> 10) * 8);
                color[1] = (byte)(((rawColorData & 0x3E0) >> 5) * 8);
                color[2] = (byte)((rawColorData & 0x1F) * 8);
                color[3] = 0xff;
            }




            return color;
        }

    }
}
