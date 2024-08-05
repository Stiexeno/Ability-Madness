namespace AbilityMadness.Code.Infrastructure.Services.Assembler.Common
{
    public class Array2DAttachment : Array2D<Attachment>
    {
        private CellAttachment[] cells;

        public int GridSize => gridSize;
        public CellAttachment[] Cells => cells;

        public Array2DAttachment(int size)
        {
            gridSize = size;
            cells = new CellAttachment[gridSize * gridSize];

            for (var x = 0; x < gridSize * gridSize; x++)
            {
                cells[x] = new CellAttachment();
            }
        }

        protected override Cell<Attachment> GetCellByIndex(int index) => cells[index];
    }
}
