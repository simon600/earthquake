using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TheEarthQuake.Logic
{
    public class GameControllKeys
    {
        private Keys up;
        private Keys left;
        private Keys right;
        private Keys down;
        private Keys bomb;
        private Keys special;

        public GameControllKeys(Players player)
        {
            if (player == Players.Player1)
            {
                up = Keys.W;
                left = Keys.A;
                right = Keys.D;
                down = Keys.S;
                bomb = Keys.Z;
                special = Keys.X;
            }

            if (player == Players.Player2)
            {
                up = Keys.I;
                left = Keys.J;
                down = Keys.K;
                right = Keys.L;
                bomb = Keys.N;
                special = Keys.M;
            }
        }

        public Keys Up
        {
            get
            {
                return up;
            }

            set
            {
                up = value;
            }
        }

        public Keys Left
        {
            get
            {
                return left;
            }

            set
            {
                left = value;
            }
        }

        public Keys Right
        {
            get
            {
                return right;
            }

            set
            {
                right = value;
            }
        }

        public Keys Down
        {
            get
            {
                return down;
            }

            set
            {
                down = value;
            }
        }

        public Keys Bomb
        {
            get
            {
                return bomb;
            }

            set
            {
                bomb = value;
            }
        }

        public Keys Special
        {
            get
            {
                return special;
            }

            set
            {
                special = value;
            }
        }
    }
}
