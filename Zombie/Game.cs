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
    class Game
    {
        private RenderWindow _window;

        public event Action OnEPressed;
        public event Action OnEscapePressed;
        public event Action OnSpacePressed;
        public event Action GoldUp;
        public event Action Saving;

        private bool roundOver = true;
        private int stop = 0;

        private bool up = false;
        private bool down = false;
        private bool left = false;
        private bool right = false;

        private bool started = false;

        private RectangleShape _player;
        private Vector2f _position = new Vector2f(0, 0);
        private int _updateX = 0;
        private int _updateY = 0;

        private int i = 0;

        public Game(RenderWindow window)
        {
            _window = window;
            Player();
            _window.KeyPressed += OnKeyPressed;
            _window.KeyReleased += OnKeyReleased;
        }
        private void Player()
        {
            _player = new RectangleShape(new Vector2f(50, 50));
            _player.Position = _position;
            _player.FillColor = new Color(0, 0, 255);

        }
        public void GoldUpdate()
        {
            if (!roundOver)
            {
                i++;
                if (i == 100)
                {
                    i = 0;
                    GoldUp?.Invoke();
                }
            }
        }

        public void Start()
        {
            started = true;
        }

        public void Update()
        {
            _position = new Vector2f(_position.X + _updateX, _position.Y + _updateY);

            if (_position.X > 800 - _player.Size.X)
            {
                _position.X = 800 - _player.Size.X;
                _updateX = 0;
                right = false;
                left = false;
            }
            else if (_position.X < 0)
            {
                _position.X = 0;
                _updateX = 0;
                right = false;
                left = false;
            }

            if (_position.Y > 600 - _player.Size.Y)
            {
                _position.Y = 600 - _player.Size.Y;
                _updateY = 0;
                up = false;
                down = false;
            }
            else if (_position.Y < 0)
            {
                _position.Y = 0;
                _updateY = 0;
                up = false;
                down = false;
            }

            _player.Position = _position;
        }

        public void Escape()
        {
            stop = 0;
        }

        public void Save()
        {
            if(stop == 1)
            {
                Saving?.Invoke();
            }
        }

        public void Draw()
        {
            _window.Draw(_player);
        }
        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (started)
            {
                if (stop == 0)
                {
                    if (e.Code == Keyboard.Key.W)
                    {
                        if (!up)
                        {
                            _updateY += -1;
                            up = true;
                        }

                    }
                    else if (e.Code == Keyboard.Key.S)
                    {
                        if (!down)
                        {
                            _updateY += 1;
                            down = true;
                        }

                    }
                    else if (e.Code == Keyboard.Key.A)
                    {
                        if (!left)
                        {
                            _updateX += -1;
                            left = true;
                        }
                    }
                    else if (e.Code == Keyboard.Key.D)
                    {
                        if (!right)
                        {
                            _updateX += 1;
                            right = true;
                        }
                    }
                    else if (e.Code == Keyboard.Key.R)
                    {
                        roundOver = !roundOver;
                    }
                }
                if (roundOver)
                {
                    if (e.Code == Keyboard.Key.E)
                    {
                        if (stop == 0)
                        {
                            stop = 2;
                            _updateX = 0;
                            _updateY = 0;
                            up = false;
                            down = false;
                            left = false;
                            right = false;
                            OnEPressed?.Invoke();
                        }
                        else if (stop == 2)
                        {
                            stop = 0;
                            OnEPressed?.Invoke();
                        }
                    }
                    else if (e.Code == Keyboard.Key.Escape)
                    {
                        if (stop == 0)
                        {
                            stop = 1;
                            _updateX = 0;
                            _updateY = 0;
                            up = false;
                            down = false;
                            left = false;
                            right = false;
                            OnEscapePressed?.Invoke();
                        }
                        else if (stop == 1)
                        {
                            stop = 0;
                            OnEscapePressed?.Invoke();
                        }
                        else if (stop == 2)
                        {
                            stop = 0;
                            OnEPressed?.Invoke();
                        }
                    }
                }
                else if (!roundOver)
                {
                    if (e.Code == Keyboard.Key.Space)
                    {
                        if (stop == 0)
                        {
                            stop = 3;
                            _updateX = 0;
                            _updateY = 0;
                            up = false;
                            down = false;
                            left = false;
                            right = false;
                            OnSpacePressed?.Invoke();
                        }
                        else if (stop == 3)
                        {
                            stop = 0;
                            OnSpacePressed?.Invoke();
                        }
                    }
                }
            }
        }
        private void OnKeyReleased(object sender, KeyEventArgs e)
        {
            if (stop == 0)
            {
                if (e.Code == Keyboard.Key.W)
                {
                    if (up)
                    {
                        _updateY += 1;
                        up = false;
                    }

                }
                else if (e.Code == Keyboard.Key.S)
                {
                    if (down)
                    {
                        _updateY += -1;
                        down = false;
                    }
                }
                else if (e.Code == Keyboard.Key.A)
                {
                    if (left)
                    {
                        _updateX += 1;
                        left = false;
                    }
                }
                else if (e.Code == Keyboard.Key.D)
                {
                    if (right)
                    {
                        _updateX += -1;
                        right = false;
                    }
                }
            }
        }
    }
}
