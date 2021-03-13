using System.Collections.Generic;

namespace HW7
{
    public class Board
    {
        private int _width;
        private int _height;
        
        public int Weight
        {
            get => _width;
        }
        public int Height
        {
            get => _height;
        }

        private List<List<(int, int)>> _paths;
        private List<(int, int)> _buffer;

        enum Direction
        {
            INIT,
            RIGHT,
            DOWN
        }

        public Board(int width, int height)
        {
            _height = height;
            _width = width;
            _paths = new List<List<(int, int)>>();
            _buffer = new List<(int, int)>();
        }

        public List<int[,]> GetPaths()
        {
            if (_paths.Count == 0)
            {
                GetNumberOfPaths();
            }
            
            var result = new List<int[,]>();
            foreach (var path in _paths)
            {
                var board = new int[_width, _height];

                foreach (var point in path)
                {
                    board[point.Item1, point.Item2] = 1;
                }
                
                result.Add(board);
            }

            return result;
        }
        private int GetNumberOfPaths()
        {
            return makePath(0, 0, Direction.INIT);
        }
        
        private int makePath(int posX, int posY, Direction d)
        {
            if (posX == 0 && posY == 0)
            {
                _buffer.Clear();
                _buffer.Add((posX, posY /*, Direction.INIT*/));
            }
            else
            {
                ClearBuffer(posX, posY, d);
            }
            
            switch (d)
            {
                case Direction.DOWN:
                    posY++;
                    break;
                case Direction.RIGHT:
                    posX++;
                    break;
            }
            
            // Пограничные значения
            if (posX == _width || posY == _height)
            {
                return 0;
            }
            else if (posX == _width - 1 && posY == _height - 1)
            {
                _buffer.Add((posX, posY/*, d*/));
                
                var path = new List<(int, int)>();

                foreach (var point in _buffer)
                {
                    path.Add((point.Item1, point.Item2));
                }
                
                _paths.Add(path);

                return 1;
            }

            
            _buffer.Add((posX, posY/*, d*/));
            return makePath(posX, posY, Direction.RIGHT) + makePath(posX, posY, Direction.DOWN);
        }
        
        private void ClearBuffer(int posX, int posY, Direction d)
        {
            if (_buffer.Contains((posX, posY)))
            {
                for (int i = _buffer.Count-1; i > 0; i--)
                {
                    var lastPoint = _buffer[i];
                    if (lastPoint.Item1 == posX && lastPoint.Item2 == posY)
                    {
                        break;
                    }
                    _buffer.RemoveAt(i);
                }
            }
            if (_buffer.Contains((_width - 1, _height - 1)))
            {
                for (int i = _buffer.Count-1; i > 0; i--)
                {
                    var lastPoint = _buffer[i];
                    if (lastPoint.Item1 == posX && lastPoint.Item2 == posY)
                    {
                        break;
                    }
                    _buffer.RemoveAt(i);
                }
            }
            switch (d)
            {
                case Direction.DOWN:
                    posX++;
                    while (posY >= 0)
                    {
                        _buffer.Remove((posX, posY));
                        posY--;
                    }

                    break;
                case Direction.RIGHT:
                    posY++;
                    while (posX >= 0)
                    {
                        _buffer.Remove((posX, posY));
                        posX--;
                    }

                    break;
            }
        }
    }
}