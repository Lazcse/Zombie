using System;
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
    class Login
    {
        private RenderWindow _window;
        public Login(RenderWindow window)
        {
            _window = window;
            text();
        }

        private Text _text;
        private Text _text1;

        public void text()
        {
            _text = new Text("Username", new Font("Arial.ttf"), 60);
            _text.Position = new Vector2f(200, 200);
            _text.FillColor = new Color(128, 128, 128);

            _text1 = new Text("Password", new Font("Arial.ttf"), 60);
            _text1.Position = new Vector2f(200, 400);
            _text1.FillColor = new Color(128, 128, 128);
        }
        public void Draw()
        {
            _window.Draw(_text);
            _window.Draw(_text1);
        }
    }
}
