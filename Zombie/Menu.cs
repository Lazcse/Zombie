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
    class Menu
    {
        private RenderWindow _window;

        public event Action OnEscapePressed;

        private Text _text;
        private Text _text2;

        private Button _button;
        private Button _button2;

        public Menu(RenderWindow window)
        {
            _window = window;
            Buttons();
            Texts();
        }
        private void Buttons()
        {
            _button = new Button(_window, new Vector2f(150, 100), new Vector2f(500, 150));
            _button.OuterColor = Color.Transparent;
            _button.CenterColor = new Color(128, 128, 128);
            _button.ButtonPressed += ResumePressed;

            _button2 = new Button(_window, new Vector2f(150, 350), new Vector2f(500, 150));
            _button2.OuterColor = Color.Transparent;
            _button2.CenterColor = new Color(128, 128, 128);
            _button2.ButtonPressed += SavePressed;
        }
        
        private void Texts()
        {
            _text = new Text("Resume", new Font("Arial.ttf"), 50);
            _text.Position = new Vector2f(300, 150);
            _text.FillColor = new Color(0, 0, 0);

            _text2 = new Text("Save & exit", new Font("Arial.ttf"),50);
            _text2.Position = new Vector2f(275, 400);
            _text2.FillColor = new Color(0, 0, 0);
        }

        public void Draw()
        {
            _button.Draw();
            _button2.Draw();

            _window.Draw(_text);
            _window.Draw(_text2);
        }

        private void ResumePressed()
        {
            OnEscapePressed?.Invoke();
        }

        private void SavePressed()
        {

        }
    }
}
