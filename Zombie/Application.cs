using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SfmlUI;
using System.Xml;

namespace Zombie
{
    class Application
    {
        private readonly RenderWindow _window;
        private readonly StartScreen _startScreen;
        private readonly Login _login;

        private bool _isUpdating = true;
        public int state = 0;

        public bool pressed = false;
        public bool start = true;
        public bool login = false;

        public Application()
        {
            _window = new RenderWindow(new VideoMode(800, 600), "Zombie", Styles.Titlebar | Styles.Close);
            _startScreen = new StartScreen(_window);
            _login = new Login(_window);

            _window.Closed += OnWindowClosed;

            _startScreen.OnStartButtonPressed += OnStartButtonPressed;
            _startScreen.OnStartButtonReleased += OnStartButtonReleased;

            _login.OnLogButtonPressed += OnLogButtonPressed;
            _login.OnLogButtonReleased += OnLogButtonReleased;
        }

        public void Run()
        {
            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                if (_isUpdating)
                {
                    _window.Clear();
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
                _window.Display();

            }   
        }
        private void OnWindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }

        private void OnStartButtonPressed()
        {
            if (start == true)
            {
                state = 1;
                pressed = true;
            }

        }

        private void OnStartButtonReleased()
        {
            if (start == true)
            {
                if (pressed == true)
                {
                    pressed = false;
                    login = true;
                    start = false;
                }
            }
        }
        private void OnLogButtonPressed()
        {
            if (state == 1)
            {
                
                pressed = true;
            }

        }

        private void OnLogButtonReleased()
        {
            if (state == 1)
            {
                if (pressed == true)
                {
                 
                }
            }
        }
    }
}
