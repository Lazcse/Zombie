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
    class PauseScreen
    {
        private RenderWindow _window;
        private Text _text;

        public PauseScreen(RenderWindow window)
        {
            _window = window;
            Text();
        }
        
        private void Text()
        {
            _text = new Text("Paused", new Font("Arial.ttf"), 50);
            _text.Position = new Vector2f(300, 150);
            _text.FillColor = new Color(128, 128, 128);
        }
        public void Draw()
        {
            _window.Draw(_text);
        }
    }
}
