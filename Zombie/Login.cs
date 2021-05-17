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
            Failed();
        }

        private Text _text;
        private Text _text1;
        private TextInput _textInput;
        private TextInput _textInput1;

        private Button _button;
        private Text _text2;

        private Text _text3;
        private Text _text4;

        private string _username;
        private string _password;

        public event Action OnLogButtonPressed;
        public event Action OnLogButtonReleased;

        private dbLogin _db;

        private bool _failed;

        public void username()
        {
            _text = new Text("Username", new Font("Arial.ttf"), 60);
            _text.Position = new Vector2f(250, 100);
            _text.FillColor = new Color(128, 128, 128);

            _textInput = new TextInput(_window, new Vector2f(260, 175), 250f, 50f, new Font("Arial.ttf")) { FieldColor = Color.White, TextColor = Color.Black };

        }

        public void password()
        {
            _text1 = new Text("Password", new Font("Arial.ttf"), 60);
            _text1.Position = new Vector2f(250, 225);
            _text1.FillColor = new Color(128, 128, 128);

            _textInput1 = new TextInput(_window, new Vector2f(260, 300), 250f, 50f, new Font("Arial.ttf")) { FieldColor = Color.White, TextColor = Color.Black };
        }
        public void Button()
        {
            _button = new Button(_window, new Vector2f(410, 355), new Vector2f(100, 25));
            _button.OuterColor = Color.Transparent;
            _button.CenterColor = new Color(128, 128, 128);
            _button.ButtonPressed += LogButtonPressed;
            _button.ButtonReleased += LogButtonReleased;

            _text2 = new Text("Continue", new Font("Arial.ttf"), 20);
            _text2.Position = new Vector2f(420, 355);
            _text2.FillColor = new Color(0, 0, 0);
        }
        public void Failed()
        {
            _text3 = new Text("Login failed", new Font("Arial.ttf"), 15);
            _text3.Position = new Vector2f(260, 360);
            _text3.FillColor = new Color(255, 0, 0);

            _text4 = new Text("Username or password was incorrect", new Font("Arial.ttf"), 15);
            _text4.Position = new Vector2f(260, 380);
            _text4.FillColor = new Color(255, 0, 0);
        }

        public void Draw()
        {
            _window.Draw(_text);
            _window.Draw(_text1);
            _textInput.Draw();
            _textInput1.Draw();
            _button.Draw();
            _window.Draw(_text2);
            if (_failed)
            {
                _window.Draw(_text3);
                _window.Draw(_text4);
            }
        }
        private void LogButtonPressed()
        {
            OnLogButtonPressed?.Invoke();
        }

        private void LogButtonReleased()
        {
            _username = _textInput.Text;
            _password = _textInput1.Text;
            _db = new dbLogin(_username, _password,out bool loginState);
            if (loginState)
            {
                OnLogButtonReleased?.Invoke();
            }
            else
            {
                _failed = true;
            }
            
        }

        
    }
}
