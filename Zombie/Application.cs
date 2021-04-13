using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Zombie
{
    class Application
    {
        private readonly RenderWindow _window;

        private bool _isUpdating = true;

        public Application()
        {
            _window = new RenderWindow(new VideoMode(800, 600), "Zombie", Styles.Titlebar | Styles.Close);


            _window.Closed += OnWindowClosed;
        }

        public void Run()
        {
            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                if (_isUpdating)
                {

                }
                _window.Clear();
                _window.Display();

            }   
        }
        private void OnWindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}
