using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject
{
    public enum Directions
    {
        N = 1,//North
        S = 2,//South
        E = 3,//East
        W = 4//West
    }
    public interface IPosition
    {
        void StartMoving();
    }

    public class Position : IPosition
    {
        Validation validation = new Validation();
        public Position(string platoArea, string startingPosition, string moves)
        {
            this.Moves = moves;
            this.StartingPosition = startingPosition;
            this.PlateauArea = platoArea;
        }

        #region fields
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }
        public List<int> PlateauAreaList { get; set; }
        string StartingPosition { get; set; }
        string Moves { get; set; }
        string PlateauArea { get; set; }

        #endregion

        #region Methods
        private void Rotate90Left()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }
        private void Rotate90Right()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }
        private void MoveInSameDirection()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Y += 1;
                    break;
                case Directions.S:
                    this.Y -= 1;
                    break;
                case Directions.E:
                    this.X += 1;
                    break;
                case Directions.W:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }

        public void StartMoving()
        {
            if (SetParameters())

                foreach (var move in this.Moves)
                {
                    switch (move)
                    {
                        case 'M':
                            this.MoveInSameDirection();
                            break;
                        case 'L':
                            this.Rotate90Left();
                            break;
                        case 'R':
                            this.Rotate90Right();
                            break;
                        default:
                            throw new Exception($"Invalid Character {move}"); 
                    }

                    if (this.X < 0 || this.X > PlateauAreaList[0] || this.Y < 0 || this.Y > PlateauAreaList[1])
                    {
                        throw new Exception($"Oops! Position can not be beyond bounderies (0 , 0) and ({PlateauAreaList[0]} , {PlateauAreaList[1]})");
                    }
                }
            Console.WriteLine(X.ToString() + " " + Y.ToString() + " " + Direction);
        }

        private bool SetParameters()
        {
            bool result = false;
            if (!validation.Validate(ValidationType.Area, PlateauArea))
            {
                throw new Exception($"invalid platoarea position..");
            }

            else if (!validation.Validate(ValidationType.StartingPosition, StartingPosition))
            {
                throw new Exception($"invalid starting position..");
            }

            else
            {
                var sp = StartingPosition.Trim().Split(' ');

                this.X = Convert.ToInt32(sp[0]);
                this.Y = Convert.ToInt32(sp[1]);
                this.Direction = (Directions)Enum.Parse(typeof(Directions), sp[2]);
                this.PlateauAreaList = PlateauArea.Split(' ').Select(int.Parse).ToList();
                result = true;
            }
            return result;
        }

        #endregion

    }
}
