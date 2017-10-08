using Algorithms.Grid;

namespace Algorithms.CellularAutomata
{
    class AutomataCell : BaseCell
    {
        public bool IsFilled { get; set; }

        public AutomataCell(int row, int col, bool isFilled) : base(row, col)
        {
            this.IsFilled = isFilled;
        }

        public override char ToChar()
        {
            return this.IsFilled ? '*' : ' ';
        }
    }
}
