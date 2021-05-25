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
        private readonly Game _game;
        private readonly Shop _shop;
        private readonly Menu _menu;
        private readonly PauseScreen _pauseScreen;

        private bool _isUpdating = true;
        public int state = 0;

        private bool pressed = false;
        private bool start = true;
        private bool login = false;
        private bool shop = false;

        private bool menu = false;
        private bool pause = false;

        public Application()
        {
            _window = new RenderWindow(new VideoMode(800, 600), "Zombie", Styles.Titlebar | Styles.Close);
            _startScreen = new StartScreen(_window);
            _login = new Login(_window);
            _game = new Game(_window);
            _shop = new Shop(_window);
            _menu = new Menu(_window);
            _pauseScreen = new PauseScreen(_window);

            _window.Closed += OnWindowClosed;

            _startScreen.OnStartButtonPressed += OnStartButtonPressed;
            _startScreen.OnStartButtonReleased += OnStartButtonReleased;

            _login.OnLogButtonPressed += OnLogButtonPressed;
            _login.OnLogButtonReleased += OnLogButtonReleased;

            _game.OnEPressed += OnEPressed;
            _game.OnSpacePressed += OnSpacePressed;
            _game.OnEscapePressed += OnEscapePressed;
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
                            _game.Update();
                            _game.Draw();
                            if (shop)
                            {
                                _shop.Draw();
                            }
                            if (pause)
                            {
                                _pauseScreen.Draw();
                            }
                            if (menu)
                            {
                                _menu.Draw();
                            }
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
                    state = 2;
                    pressed = false;
                }
            }
        }
        private void OnEPressed()
        {
            if(state == 2)
            {
                shop = !shop;
            }
        }
        private void OnSpacePressed()
        {
            if (state == 2)
            {
                pause = !pause;
            }
        }
        private void OnEscapePressed()
        {
            if (state == 2)
            {
                if (shop)
                {
                    shop = false;
                } else if (!shop)
                {
                    menu = !menu;
                }
            }
        }
    }
}
