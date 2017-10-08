using System;
using System.Linq;
using Algorithms.Grid;

namespace Algorithms.CellularAutomata
{
    class AutomataGrid : BaseGrid<AutomataCell>
    {
        public AutomataGrid(int rowCount, int colCount)
            : base(rowCount, colCount, CreateInitialCell) { }

        public int GetFilledNeighborCount(AutomataCell cell)
        {
            return this.GetNeighbors(cell)
                .Where(it => it.IsFilled)
                .Count();
        }

        public AutomataGrid SetCells(Func<Tuple<int, int>, bool> isFilled)
        {
            foreach (var cell in this.GetFlatCellArray())
                cell.IsFilled = isFilled(cell.GetPositionTuple());
            return this;
        }

        public void Advance()
        {
            var clonedGrid = this.Clone();
            foreach (var clonedCell in clonedGrid.GetFlatCellArray())
            {
                var neighborCount = clonedGrid.GetFilledNeighborCount(clonedCell);
                var isFilled = clonedCell.IsFilled
                    ? (neighborCount == 2 || neighborCount == 3)
                    : neighborCount == 3;

                var cell = this.GetCell(clonedCell.GetPositionTuple());
                cell.IsFilled = isFilled;
            }
        }

        private AutomataGrid Clone()
        {
            return new AutomataGrid(this.RowCount, this.ColCount)
                .SetCells(tuple => this.GetCell(tuple).IsFilled);
        }

        protected static AutomataCell CreateInitialCell(int row, int col)
        {
            return new AutomataCell(row, col, false);
        }
    }
}
