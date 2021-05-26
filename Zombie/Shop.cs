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
        private Text _text2;
        private Text _text3;
        private Text _text4;
        private Text _text5;
        private Text _text6;
        private Text _text7;
        private Text _text8;
        private Text _text9;

        private Button _button;
        private Button _button2;
        private Button _button3;
        private Button _button4;
        private Button _button5;
        private Button _button6;
        private Button _button7;
        private Button _button8;
        private Button _button9;

        public Action OnButtonPressed;
        public Action OnButtonPressed2;
        public Action OnButtonPressed3;
        public Action OnButtonPressed4;
        public Action OnButtonPressed5;
        public Action OnButtonPressed6;
        public Action OnButtonPressed7;
        public Action OnButtonPressed8;
        public Action OnButtonPressed9;

        public Shop(RenderWindow window)
        {
            _window = window;
            Buttons();
            Texts();
            
        }
        
        private void Buttons()
        {
            _button = new Button(_window, new Vector2f(100, 100), new Vector2f(100, 100));
            _button.OuterColor = Color.Transparent;
            _button.CenterColor = new Color(128, 128, 128);
            _button.ButtonPressed += ButtonPressed;

            _button2 = new Button(_window, new Vector2f(410, 355), new Vector2f(100, 100));
            _button2.OuterColor = Color.Transparent;
            _button2.CenterColor = new Color(128, 128, 128);
            _button2.ButtonPressed += ButtonPressed2;

            _button3 = new Button(_window, new Vector2f(410, 355), new Vector2f(100, 100));
            _button3.OuterColor = Color.Transparent;
            _button3.CenterColor = new Color(128, 128, 128);
            _button3.ButtonPressed += ButtonPressed3;

            _button4 = new Button(_window, new Vector2f(410, 355), new Vector2f(100, 100));
            _button4.OuterColor = Color.Transparent;
            _button4.CenterColor = new Color(128, 128, 128);
            _button4.ButtonPressed += ButtonPressed4;

            _button5 = new Button(_window, new Vector2f(410, 355), new Vector2f(100, 100));
            _button5.OuterColor = Color.Transparent;
            _button5.CenterColor = new Color(128, 128, 128);
            _button5.ButtonPressed += ButtonPressed5;

            _button6 = new Button(_window, new Vector2f(410, 355), new Vector2f(100, 100));
            _button6.OuterColor = Color.Transparent;
            _button6.CenterColor = new Color(128, 128, 128);
            _button6.ButtonPressed += ButtonPressed6;

            _button7 = new Button(_window, new Vector2f(410, 355), new Vector2f(100, 100));
            _button7.OuterColor = Color.Transparent;
            _button7.CenterColor = new Color(128, 128, 128);
            _button7.ButtonPressed += ButtonPressed7;

            _button8 = new Button(_window, new Vector2f(410, 355), new Vector2f(100, 100));
            _button8.OuterColor = Color.Transparent;
            _button8.CenterColor = new Color(128, 128, 128);
            _button8.ButtonPressed += ButtonPressed8;

            _button9 = new Button(_window, new Vector2f(410, 355), new Vector2f(100, 100));
            _button9.OuterColor = Color.Transparent;
            _button9.CenterColor = new Color(128, 128, 128);
            _button9.ButtonPressed += ButtonPressed9;

        }

        private void Texts()
        {
            _text = new Text("Continue", new Font("Arial.ttf"), 20);
            _text.Position = new Vector2f(420, 355);
            _text.FillColor = new Color(0, 0, 0);

            _text2 = new Text("Continue", new Font("Arial.ttf"), 20);
            _text2.Position = new Vector2f(420, 355);
            _text2.FillColor = new Color(0, 0, 0);

            _text3 = new Text("Continue", new Font("Arial.ttf"), 20);
            _text3.Position = new Vector2f(420, 355);
            _text3.FillColor = new Color(0, 0, 0);

            _text4 = new Text("Continue", new Font("Arial.ttf"), 20);
            _text4.Position = new Vector2f(420, 355);
            _text4.FillColor = new Color(0, 0, 0);

            _text5 = new Text("Continue", new Font("Arial.ttf"), 20);
            _text5.Position = new Vector2f(420, 355);
            _text5.FillColor = new Color(0, 0, 0);

            _text6 = new Text("Continue", new Font("Arial.ttf"), 20);
            _text6.Position = new Vector2f(420, 355);
            _text6.FillColor = new Color(0, 0, 0);

            _text7 = new Text("Continue", new Font("Arial.ttf"), 20);
            _text7.Position = new Vector2f(420, 355);
            _text7.FillColor = new Color(0, 0, 0);

            _text8 = new Text("Continue", new Font("Arial.ttf"), 20);
            _text8.Position = new Vector2f(420, 355);
            _text8.FillColor = new Color(0, 0, 0);

            _text9 = new Text("Continue", new Font("Arial.ttf"), 20);
            _text9.Position = new Vector2f(420, 355);
            _text9.FillColor = new Color(0, 0, 0);

        }

        public void Button1()
        {
            _button.CenterColor = new Color(0, 128, 0);
        }
        public void Button2()
        {
            _button2.CenterColor = new Color(0, 128, 0);
        }
        public void Button3()
        {
            _button3.CenterColor = new Color(0, 128, 0);
        }
        public void Button4()
        {
            _button4.CenterColor = new Color(0, 128, 0);
        }
        public void Button5()
        {
            _button5.CenterColor = new Color(0, 128, 0);
        }
        public void Button6()
        {
            _button6.CenterColor = new Color(0, 128, 0);
        }
        public void Button7()
        {
            _button7.CenterColor = new Color(0, 128, 0);
        }
        public void Button8()
        {
            _button8.CenterColor = new Color(0, 128, 0);
        }
        public void Button9()
        {
            _button9.CenterColor = new Color(0, 128, 0);
        }

        public void Draw()
        {
            _button.Draw();
            _button2.Draw();
            _button3.Draw();
            _button4.Draw();
            _button5.Draw();
            _button6.Draw();
            _button7.Draw();
            _button8.Draw();
            _button9.Draw();

            _window.Draw(_text);
            _window.Draw(_text2);
            _window.Draw(_text3);
            _window.Draw(_text4);
            _window.Draw(_text5);
            _window.Draw(_text6);
            _window.Draw(_text7);
            _window.Draw(_text8);
            _window.Draw(_text9);

        }
        private void ButtonPressed()
        {
            OnButtonPressed?.Invoke();
        }
        private void ButtonPressed2()
        {
            OnButtonPressed2?.Invoke();
        }
        private void ButtonPressed3()
        {
            OnButtonPressed3?.Invoke();
        }
        private void ButtonPressed4()
        {
            OnButtonPressed4?.Invoke();
        }
        private void ButtonPressed5()
        {
            OnButtonPressed5?.Invoke();
        }
        private void ButtonPressed6()
        {
            OnButtonPressed6?.Invoke();
        }
        private void ButtonPressed7()
        {
            OnButtonPressed7?.Invoke();
        }
        private void ButtonPressed8()
        {
            OnButtonPressed8?.Invoke();
        }
        private void ButtonPressed9()
        {
            OnButtonPressed9?.Invoke();
        }
    }
}
