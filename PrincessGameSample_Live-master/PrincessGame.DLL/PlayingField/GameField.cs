using System.Collections.Generic;
using System.Linq;

namespace PrincessGame.DLL.PlayingField
{
    public class GameField
    {
        public List<Cell> Cells { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public GameField()
        {

        }
        public GameField(int height, int width)
        {
            Cells = new List<Cell>();

            Height = height;
            Width = width;

            LoadCells();
        }

        private void LoadCells()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Cells.Add(new Cell(x, y));
                }
            }
        }

        public Cell this[int x, int y] => Cells.FirstOrDefault(cell => cell.Position == (x, y));

        public Cell this[Position position] => Cells.FirstOrDefault(cell => cell.Position == position);
    }
}
