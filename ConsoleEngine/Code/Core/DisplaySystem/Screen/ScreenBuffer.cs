﻿using ConsoleEngine.Maths;
using System.Collections.Generic;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenBuffer
    {
        private Texture _total = new Texture();
        private Texture _delta = new Texture();

        #region Constructors
        public ScreenBuffer() { }
        public ScreenBuffer(IEnumerable<KeyValuePair<Vector2Int, Pixel>> pixels, string name = "")
        {
            Total = new Texture(pixels);
            Name = name;
        }
        #endregion

        #region Properties
        public string Name { get; set; } = string.Empty;
        public Texture Total
        {
            get => _total;
            set
            {
                _total = value;
            }
        }
        #endregion

        public Pixel GetPixel(int x, int y) => _buffer[x, y];
        public Pixel GetPixel(Vector2Int position) => _buffer[position.X, position.Y];

        public void Set(Pixel pixel, int x, int y) => _buffer[x, y] = pixel;
        public void Set(Pixel pixel, Vector2Int position) => _buffer[position.X, position.Y] = pixel;

        public void Set(Texture texture)
        {
            foreach (var pixel in texture.Pixels)
                Set(pixel.Value, pixel.Key + texture.Shift);
        }

        public void Clear(Pixel fillingPixel) => Fill(ref _buffer, fillingPixel);

        private Pixel[,] CreateBuffer(int width, int height, Pixel fillingPixel)
        {
            Pixel[,] buffer = new Pixel[width, height];
            Fill(ref buffer, fillingPixel);
            return buffer;
        }

        private void Fill(ref Pixel[,] buffer, Pixel fillingPixel)
        {
            for (int x = 0; x < buffer.GetLength(0); x++)
                for (int y = 0; y < buffer.GetLength(1); y++)
                    buffer[x, y] = fillingPixel;
        }
    }
}
