﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Xml.Linq;

namespace DreamStateMachine
{
    class WorldConfig
    {
        public String worldName;
        public Texture2D texture;
        public int width;
        public int height;
        public int tileSize;

        //Constructor
        public WorldConfig(String worldName, Texture2D worldTexture, int worldWidth, int worldHeight, int tileSize)
        {
            this.worldName = worldName;
            this.texture = worldTexture;
            this.width = worldWidth;
            this.height = worldHeight;
            this.tileSize = tileSize;
        }
    }

}
