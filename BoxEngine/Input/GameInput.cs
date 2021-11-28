using System.Collections.Generic;
using System.Numerics;

using OpenTK.Windowing.GraphicsLibraryFramework;

using BoxEngine.Game;
using BoxEngine.Graphics.Windowing;
using OpenTK.Windowing.Common;

namespace BoxEngine.Input
{
    public class GameInput
    {
        private static WindowFrame _context = null!;
        private static GameSandbox _gameSandbox = null!;

        private static Dictionary<string, InputAxis> _inputAxes = new Dictionary<string, InputAxis>();
        
        public GameInput(WindowFrame context, GameSandbox gameSandbox)
        {
            _context = context;
            _gameSandbox = gameSandbox;

            _inputAxes = new Dictionary<string, InputAxis>();
        }

        public static void CreateInputAxis(string axisName, Key keyA, Key keyB)
        {
            _inputAxes.Add(axisName, new InputAxis
            {
                AxisName = axisName,
                KeyA = keyA,
                KeyB = keyB
            });
        }

        public static bool IsKeyDown(Key key) => _context.IsKeyDown((Keys)key);
        public static bool IsKeyUp(Key key) => !_context.IsKeyDown((Keys)key);
        public static bool IsMouseDown(MouseButton mouseButton) => _context.IsMouseButtonDown((OpenTK.Windowing.GraphicsLibraryFramework.MouseButton)mouseButton);
        public static bool IsMouseUp(MouseButton mouseButton) => !_context.IsMouseButtonDown((OpenTK.Windowing.GraphicsLibraryFramework.MouseButton)mouseButton);
        public static void GetMousePositionToScreen(out int x, out int y)
        {
            x = (int)_context.MousePosition.X;
            y = (int)_context.MousePosition.Y;
        }
        public static void GetMousePositionToWorld(out float x, out float y)
        {
            x = (_context.MousePosition.X - _context.Size.X / 2f) / _gameSandbox.GameViewport.Width + _gameSandbox.GameViewport.X/ 2f;
            y = (_context.MousePosition.Y - _context.Size.Y / 2f) / _gameSandbox.GameViewport.Height - _gameSandbox.GameViewport.Y/ 2f;
        }

        public static float GetInputAxis(string axisName)
        {
            float result = 0f;
            InputAxis inputAxis;

            _inputAxes.TryGetValue(axisName, out inputAxis);

            if (IsKeyDown(inputAxis.KeyA))
                result -= 1f;

            if (IsKeyDown(inputAxis.KeyB))
                result += 1f;

            return result;
        }
    }

    public struct InputAxis
    {
        public string AxisName;
        public Key KeyA, KeyB;
    }
}