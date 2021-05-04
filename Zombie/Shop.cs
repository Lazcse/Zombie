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
    class Shop
    {
        private RenderWindow _window;
        private Text _text;
        public Shop(RenderWindow window)
        {
            _window = window;
            
        }
        public void TestS()
        {
            _text = new Text("Game", new Font("Arial.ttf"), 60);
            _text.Position = new Vector2f(200, 200);
            _text.FillColor = new Color(128, 128, 128);

        }
        public void Draw()
        {
            _window.Draw(_text);
        }
    }
}
