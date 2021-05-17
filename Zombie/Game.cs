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

        private Text _text;

        private bool roundOver = true;
        public Game(RenderWindow window)
        {
            _window = window;

        }
        public void TestG()
        {
            _text = new Text("Game", new Font("Arial.ttf"), 60);
            _text.Position = new Vector2f(200, 200);
            _text.FillColor = new Color(128, 128, 128);

        }
        public void Draw()
        {
            _window.Draw(_text);
        }
        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (!roundOver) {
                if (e.Code == Keyboard.Key.W)
                {
                    
                }
                else if (e.Code == Keyboard.Key.S)
                {
                    
                }
                else if (e.Code == Keyboard.Key.A)
                {
                    
                }
                else if (e.Code == Keyboard.Key.D)
                {
                    
                }
            } else if (roundOver)
            {
                if (e.Code == Keyboard.Key.E)
                {
                    OnEPressed?.Invoke();
                }else if (e.Code == Keyboard.Key.Escape)
                {
                    OnEscapePressed?.Invoke();
                }else if (e.Code == Keyboard.Key.Space)
                {
                    OnSpacePressed?.Invoke();
                }
            }
        }
    }
}
