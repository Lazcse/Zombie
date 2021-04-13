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
    class StartScreen
    {
        private RenderWindow _window;
        public StartScreen(RenderWindow window)
        {
            _window = window;
            startButton();

        }
        private Button _button;
        private Text _text;

        public event Action OnStartButtonPressed;
        public event Action OnStartButtonReleased;


        public void startButton()
        {
            _button = new Button(_window, new Vector2f(300 ,250 ), new Vector2f(200, 100));
            _button.OuterColor = Color.Transparent;
            _button.CenterColor = new Color(128, 128, 128);
            _button.ButtonPressed += buttonPressed;
            _button.ButtonReleased += buttonReleased;

            _text = new Text("Start", new Font("Arial.ttf"), 60);
            _text.Position = new Vector2f(335, 265 );
            _text.FillColor = new Color(0, 0, 0);
        }
        public void Draw()
        {
            _button.Draw();
            _window.Draw(_text);
        }
        private void buttonPressed()
        {
            OnStartButtonPressed?.Invoke();
        }

        private void buttonReleased()
        {
            OnStartButtonReleased?.Invoke();
        }
    }
}
