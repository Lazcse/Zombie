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

        private bool roundOver = true;
        private int stop = 0;

        private RectangleShape _player;
        private Vector2f _position = new Vector2f(0, 0);
        private int _updateX = 0;
        private int _updateY = 0;

        public Game(RenderWindow window)
        {
            _window = window;
            Player();
            _window.KeyPressed += OnKeyPressed;
        }
        public void Player()
        {
            _player = new RectangleShape(new Vector2f(50, 50));
            _player.Position = _position;
            _player.FillColor = new Color(0, 0, 255);

        }
        public void Update()
        {
            _position = new Vector2f(_position.X + _updateX, _position.Y + _updateY);

            if (_position.X > 800 - _player.Size.X)
            {
                _position.X = 800 - _player.Size.X;
                _updateX = 0;
            }
            else if (_position.X < 0)
            {
                _position.X = 0;
                _updateX = 0;
            }

            if (_position.Y > 600 - _player.Size.Y)
            {
                _position.Y = 600 - _player.Size.Y;
                _updateY = 0;
            }
            else if (_position.Y < 0)
            {
                _position.Y = 0;
                _updateY = 0;
            }

            _player.Position = _position;
        }
        public void Draw()
        {
            _window.Draw(_player);
        }
        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
           if (stop == 0)
            {
                if (e.Code == Keyboard.Key.W)
                {
                    _updateY = -1;
                }
                else if (e.Code == Keyboard.Key.S)
                {
                    _updateY = 1;
                }
                else if (e.Code == Keyboard.Key.A)
                {
                    _updateX = -1;
                }
                else if (e.Code == Keyboard.Key.D)
                {
                    _updateX = 1;
                }
            }
            if (e.Code == Keyboard.Key.Escape)
            {
                if (stop == 0)
                {
                    stop = 1;
                    OnEscapePressed?.Invoke();
                } else if (stop == 1) {
                    stop = 0;
                    OnEscapePressed?.Invoke();
                }
                else if (stop == 2)
                {
                    stop = 0;
                    OnEPressed?.Invoke();
                }
            }

            if (roundOver)
            {
                if (e.Code == Keyboard.Key.E)
                {
                    if (stop == 0)
                    {
                        stop = 2;
                        OnEPressed?.Invoke();
                    } else if (stop == 2)
                    {
                        stop = 0;
                        OnEPressed?.Invoke();
                    }
                }
            } else if (!roundOver)
            {
                if (e.Code == Keyboard.Key.Space)
                {
                    if (stop == 0)
                    {
                        stop = 3;
                        OnSpacePressed?.Invoke();
                    } else if (stop == 3)
                    {
                        stop = 0;
                        OnSpacePressed?.Invoke();
                    }
                }
            }
        }
    }
}
