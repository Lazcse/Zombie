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

        private int i = 0;
        private int wait = 10;
        public int gold = 0;
        private int X = 0;

        private bool boots = false;
        private bool life = false;
        private bool damage = false;
        private bool shield = false;
        private bool damage2 = false;
        private bool life2 = false;
        private bool shield2 = false;
        private bool damage3 = false;
        private bool reach = false;

        public List<string> _inventory;
        public int balance = 0;

        private dbUpdate _dbU;
        private dbSync _dbS;

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

            _shop.OnButtonPressed += OnButtonPressed;
            _shop.OnButtonPressed2 += OnButtonPressed2;
            _shop.OnButtonPressed3 += OnButtonPressed3;
            _shop.OnButtonPressed4 += OnButtonPressed4;
            _shop.OnButtonPressed5 += OnButtonPressed5;
            _shop.OnButtonPressed6 += OnButtonPressed6;
            _shop.OnButtonPressed7 += OnButtonPressed7;
            _shop.OnButtonPressed8 += OnButtonPressed8;
            _shop.OnButtonPressed9 += OnButtonPressed9;

            _menu.OnResumePressed += OnResumePressed;
            _menu.OnSavePressed += OnSavePressed;

            _game.GoldUp += GoldUp;
            _game.Saving += Saving;
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
                            i++;
                            if (i == 1)
                            {
                                _game.Update();
                            }
                            else if (i >= wait)
                            {
                                i = 0;
                            }
                            _game.GoldUpdate();
                            _game.Start();
                            _game.Draw();
                            if (shop)
                            {
                                _shop.Draw();
                            }
                            else if (pause)
                            {
                                _pauseScreen.Draw();
                            }
                            else if (menu)
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
                if (login == true)
                {
                    pressed = true;
                }

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

                    _dbS = new dbSync(Global._username, out int balance, out List<string> _inventory);
                    gold = balance;
                    string[] array = _inventory.ToArray();
                    X = array.Length;
                    for(int y=0; y<X; y++)
                    {
                        switch (array[y])
                        {
                            case "boots":
                                wait = wait / 2;
                                boots = true;
                                _shop.Button1();
                                break;
                        }
                    }
                }
            }
        }
        private void OnEPressed()
        {
            if (state == 2)
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
                menu = !menu;
            }
        }
        private void OnResumePressed()
        {
            if (state == 2 && menu)
            {
                menu = !menu;
                _game.Escape();
            }
        }
        private void OnButtonPressed()
        {
            if (gold >= 100 && !boots && shop)
            {
                gold = gold - 100;
                boots = true;
                wait = wait / 2;
                _shop.Button1();
            }
        }
        private void OnButtonPressed2()
        {
            if (gold >= 200 && !damage && shop)
            {
                gold = gold - 200;
                damage = true;
                _shop.Button2();
            }
        }
        private void OnButtonPressed3()
        {
            if (gold >= 300 && !shield && shop)
            {
                gold = gold - 300;
                shield = true;
                _shop.Button3();
            }
        }
        private void OnButtonPressed4()
        {
            if (gold >= 400 && !damage2 && shop)
            {
                gold = gold - 400;
                damage2 = true;
                _shop.Button4();
            }
        }
        private void OnButtonPressed5()
        {
            if (gold >= 500 && !life && shop)
            {
                gold = gold - 500;
                life = true;
                _shop.Button5();
            }
        }
        private void OnButtonPressed6()
        {
            if (gold >= 600 && !shield2 && shop)
            {
                gold = gold - 600;
                shield2 = true;
                _shop.Button6();
            }
        }
        private void OnButtonPressed7()
        {
            if (gold >= 700 && !damage3 && shop)
            {
                gold = gold - 700;
                damage3 = true;
                _shop.Button7();
            }
        }
        private void OnButtonPressed8()
        {
            if (gold >= 800 && !reach && shop)
            {
                gold = gold - 800;
                reach = true;
                _shop.Button8();
            }
        }
        private void OnButtonPressed9()
        {
            if (gold >= 900 && !life2 && shop)
            {
                gold = gold - 900;
                life2 = true;
                _shop.Button9();
            }
        }

        private void OnSavePressed()
        {
            _game.Save();
        }

        private void Saving()
        {
            _inventory = new List<string>();
            if(boots)
            {
                _inventory.Add("boots");
            }
            balance = gold;
            _dbU = new dbUpdate(Global._username, balance, _inventory);
            

            _window.Close();
        }

        private void GoldUp()
        {
            gold++;
        }
    }
}

