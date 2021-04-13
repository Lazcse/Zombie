using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Zombie
{
    class Application
    {
        private readonly RenderWindow _window;
        private readonly StartScreen _startScreen;

        private bool _isUpdating = true;
        public int state = 0;



        public Application()
        {
            _window = new RenderWindow(new VideoMode(800, 600), "Zombie", Styles.Titlebar | Styles.Close);
            _startScreen = new StartScreen(_window);

            _window.Closed += OnWindowClosed;

            _startScreen.OnStartButtonPressed += OnStartButtonPressed;
            _startScreen.OnStartButtonReleased += OnStartButtonReleased;
        }

        public void Run()
        {
            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                if (_isUpdating)
                {
                    switch (state)
                    {
                        case 0:
                            _startScreen.Draw();
                            break;

                        case 1:
                            _login.Draw();
                            break;

                        case 2:

                            break;

                        case 3:

                            break;

                        case 4:

                            break;
                    }
                }
                _window.Clear();
                _window.Display();

            }   
        }
        private void OnWindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}
