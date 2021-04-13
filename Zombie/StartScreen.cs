using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

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
            _button = new Button(_window, new Vector2f(_window.Size.X / 2 - 800 / 2, _window.Size.Y / 3 * 2 - 150), new Vector2f(800, 200));
            _button.OuterColor = Color.Transparent;
            _button.CenterColor = new Color(255, 255, 255);
            _button.ButtonPressed += buttonPressed;
            _button.ButtonReleased += buttonReleased;

            _text = new Text("Start", new Font("Arial.ttf"), 60);
            _text.Position = new Vector2f(1920 / 2 - 80, 1080 / 3 * 2 - 80);
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
