﻿using Engine.Core;
using Engine.InputSystem;
using System;

namespace Engine.Editors
{
    public partial class Editor
    {
        private const string _mainTitle = "Engine.Editor";
        private readonly Core.Engine _engine;
        private Mode _currentMode;

        #region Base
        public Editor(Core.Engine engine)
        {
            _engine = engine;
        }

        public void Start()
        {
            SetMode(Mode.Main);

            while (_currentMode != Mode.Exit)
                CheckInput();

            Exit();
        }

        private void Exit()
        {
            _engine.SetMode(Core.Engine.Mode.Main);
        }
        #endregion

        public void SetMode(Mode mode)
        {
            _currentMode = mode;

            if (mode == Mode.Main)
            {
                Console.Title = _mainTitle;
                Console.ResetColor();
                Console.Clear();
            }
            else if (mode == Mode.Pixel)
            {

            }
        }

        private void CheckInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (KeysService.CompareWithoutChar(key, Keys.Pixel))
                SetMode(Mode.Pixel);
            else if (KeysService.CompareWithoutChar(key, Keys.Tile))
                SetMode(Mode.Tile);
            else if (KeysService.CompareWithoutChar(key, Keys.Map))
                SetMode(Mode.Map);
            else if (KeysService.CompareWithoutChar(key, Keys.Exit))
                SetMode(Mode.Exit);

        }
    }
}
