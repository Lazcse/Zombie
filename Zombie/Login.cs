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
            username();
            password();
        }

        private Text _text;
        private Text _text1;
        private TextInput _textInput;
        private TextInput _textInput1;
        public void username()
        {
            _text = new Text("Username", new Font("Arial.ttf"), 60);
            _text.Position = new Vector2f(200, 200);
            _text.FillColor = new Color(128, 128, 128);

            _textInput = new TextInput(_window, new Vector2f(20, 250), 500f, 20f, new Font("Arial.ttf")) { FieldColor = Color.Black, TextColor = Color.White };

        }

        public void password()
        {
            _text1 = new Text("Password", new Font("Arial.ttf"), 60);
            _text1.Position = new Vector2f(200, 400);
            _text1.FillColor = new Color(128, 128, 128);

            _textInput1 = new TextInput(_window, new Vector2f(20, 250), 500f, 20f, new Font("Arial.ttf")) { FieldColor = Color.Black, TextColor = Color.White };
        }
        public void Draw()
        {
            _window.Draw(_text);
            _window.Draw(_text1);
        }
    }
}
