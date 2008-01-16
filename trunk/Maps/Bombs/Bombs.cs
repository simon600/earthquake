using TheEarthQuake.Maps;

namespace TheEarthQuake.Maps.Bomb
{
    /// <summary>
    /// Enumerator for bomb state
    /// </summary>
    public enum BombState
    {
        Waiting,
        Blow,
        ToRemove
    }

    /// <summary>
    /// Class representing bomb
    /// </summary>
    public class Bomb
    {
        private const int bombWaitingDelayFactor = 30; //waiting time delay
        private const int bombBlowingDelayFactor = 5;  //blowing time delay

        private int counter;        //for changing states
        private BombState _state;   //state
        private float xPos;         //positions (both discrete and real coords)
        private float yPos;
        private int iPos;
        private int jPos;
        private bool blown;
        private Players insertBy;


        /// <summary>
        /// Gets bomb state
        /// </summary>
        public BombState state
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// Gets x position
        /// </summary>
        public float XPos
        {
            get
            {
                return xPos;
            }
        }

        /// <summary>
        /// Gets y position
        /// </summary>
        public float YPos
        {
            get
            {
                return yPos;
            }
        }

        /// <summary>
        /// Gets dicrete i position
        /// </summary>
        public int IPos
        {
            get
            {
                return iPos;
            }
        }

        /// <summary>
        /// Gets discrete j position
        /// </summary>
        public int JPos
        {
            get
            {
                return jPos;
            }
        }

        /// <summary>
        /// Gets and sets blown value
        /// </summary>
        public bool Blown
        {
            get
            {
                return this.blown;
            }
            set
            {
                this.blown = value;
            }
        }
        /// <summary>
        /// Gets and sets who put bomb
        /// </summary>
        public Players InsertBy
        {
            get
            {
                return insertBy;
            }
            set
            {
                insertBy = value;
            }
        }


        /// <summary>
        /// Constructor for bomb
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public Bomb(float x, float y, int i, int j,Players P)
        {
            this.counter = bombWaitingDelayFactor;
            this.xPos = x;
            this.yPos = y;
            this.iPos = i;
            this.jPos = j;
            this._state = BombState.Waiting;
            this.blown = false;
            this.insertBy = P;
        }

        /// <summary>
        /// Returns true iff bomb is blowing
        /// </summary>
        /// <returns></returns>
        public bool IsBlown()
        {
            return this.state == BombState.Blow;
        }

        /// <summary>
        /// Changes bomb state
        /// </summary>
        public void tick()
        {
            switch (this._state)
            {
                case (BombState.Waiting):
                    --this.counter;
                    if (this.counter < 1)
                    {
                        this._state = BombState.Blow;
                        this.counter = bombBlowingDelayFactor;
                    }
                    break;
                case (BombState.Blow):
                    --this.counter;
                    if (this.counter < 1)
                    {
                        this._state = BombState.ToRemove;
                    }
                    break;
                case (BombState.ToRemove):
                    break;
                default:
                    throw new System.Exception("Illegal BombState (this._state) in Bomb.tick()");
            }
        }

        /// <summary>
        /// Bomb progress percenr
        /// </summary>
        /// <returns></returns>
        public float GetProgressFactor()
        {
            int full = 0;
            switch (this._state)
            {
                case (BombState.Waiting):
                    full = bombWaitingDelayFactor;
                    break;
                case (BombState.Blow):
                    full = bombBlowingDelayFactor;
                    break;
                case (BombState.ToRemove):
                    break;
                default:
                    throw new System.Exception("Illegal BobmbState (this._state) in Bomb.GetProgressFactor()");
            }
            return ((float)(full - this.counter)) / ((float)(full)) * 100.0f;
        }
    }

}