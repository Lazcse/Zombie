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
            Button();
        }

        private Text _text;
        private Text _text1;
        private TextInput _textInput;
        private TextInput _textInput1;

        private Button _button;
        private Text _text2;

        private bool _loggedIn;

        private string _username;
        private string _password;

        public event Action OnLogButtonPressed;
        public event Action OnLogButtonReleased;

        private dbLogin _db;

        public void username()
        {
            _text = new Text("Username", new Font("Arial.ttf"), 60);
            _text.Position = new Vector2f(200, 200);
            _text.FillColor = new Color(128, 128, 128);

            _textInput = new TextInput(_window, new Vector2f(200, 275), 250f, 50f, new Font("Arial.ttf")) { FieldColor = Color.White, TextColor = Color.Black };

        }

        public void password()
        {
            _text1 = new Text("Password", new Font("Arial.ttf"), 60);
            _text1.Position = new Vector2f(200, 325);
            _text1.FillColor = new Color(128, 128, 128);

            _textInput1 = new TextInput(_window, new Vector2f(200, 400), 250f, 50f, new Font("Arial.ttf")) { FieldColor = Color.White, TextColor = Color.Black };
        }
        public void Button()
        {
            _button = new Button(_window, new Vector2f(600, 400), new Vector2f(100, 25));
            _button.OuterColor = Color.Transparent;
            _button.CenterColor = new Color(128, 128, 128);
            _button.ButtonPressed += LogButtonPressed;
            _button.ButtonReleased += LogButtonReleased;

            _text2 = new Text("Continue", new Font("Arial.ttf"), 20);
            _text2.Position = new Vector2f(605, 400);
            _text2.FillColor = new Color(0, 0, 0);
        }
        public void Draw()
        {
            _window.Draw(_text);
            _window.Draw(_text1);
            _textInput.Draw();
            _textInput1.Draw();
            _button.Draw();
            _window.Draw(_text2);
        }
        private void LogButtonPressed()
        {
            OnLogButtonPressed?.Invoke();
        }

        private void LogButtonReleased()
        {
            _username = _textInput.Text;
            _password = _textInput1.Text;
            _db = new dbLogin(_username, _password);

            if (/*_loggedIn ==*/ true)
            {
                //OnLogButtonReleased?.Invoke();
            }
            
        }

        
    }
}
