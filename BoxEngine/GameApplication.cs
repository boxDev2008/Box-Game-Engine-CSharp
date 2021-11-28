using System.Runtime.InteropServices;

using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL;

using BoxEngine.Game;
using BoxEngine.Input;
using BoxEngine.Graphics;
using BoxEngine.Graphics.Windowing;

namespace BoxEngine
{
    public class GameApplication
    {
        #region Variables
        
        public WindowFrame _context { get; private set; }
        public GameSandbox _gameSandbox { get; private set; }
        private GameRenderer gameRenderer { get; set; } = null!;
        private GameInput gameInput { get; set; } = null!;

        #endregion

        #region Application Initialization


        public GameApplication(WindowFrame context, GameSandbox gameSandbox)
        {
            _context = context;
            _gameSandbox = gameSandbox;

            _context.Load += _context_Load;
            _context.UpdateFrame += _context_UpdateFrame;
            _context.RenderFrame += _context_RenderFrame;
            _context.Resize += _context_Resize;
            _context.Closing += _context_Closing;
            _context.Closed += _context_Closed;
            _context.Run();
        }

        #endregion

        #region Context Events

        private void _context_Load()
        {
            _gameSandbox.WindowFrame = _context;

            gameRenderer = new GameRenderer();
            gameInput = new GameInput(_context, _gameSandbox);

            _gameSandbox.OnStart();
        }

        private void _context_UpdateFrame(FrameEventArgs obj)
        {
            GameTime.UpdateDeltaTime = (float)obj.Time;
            _gameSandbox.OnUpdate();
        }

        private void _context_RenderFrame(FrameEventArgs obj)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GameTime.DrawDeltaTime = (float)obj.Time;
            gameRenderer.CreateViewportTransform(_gameSandbox.GameViewport.X, _gameSandbox.GameViewport.Y, _gameSandbox.GameViewport.Width, _gameSandbox.GameViewport.Height);
            gameRenderer.OnRenderUpdate();

            _gameSandbox.OnDraw();

            _context.SwapBuffers();
        }

        private void _context_Resize(ResizeEventArgs obj)
        {
            gameRenderer.OnResize(_context.Size.X, _context.Size.Y);
            GameTime.DrawDeltaTime = 0.0f;
            _gameSandbox.OnResize();
        }

        private void _context_Closing(System.ComponentModel.CancelEventArgs obj)
        {
            _gameSandbox.OnClosing();
        }

        private void _context_Closed()
        {
            _gameSandbox.OnClosed();
        }

        #endregion

        #region Console Controller

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void SetConsoleState(bool visible)
        {
            const int SW_HIDE = 0;
            const int SW_SHOW = 5;

            var handle = GetConsoleWindow();

            if (!visible)
                ShowWindow(handle, SW_HIDE);
            else
                ShowWindow(handle, SW_SHOW);
        }

        #endregion
    }
}