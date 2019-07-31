using System.Collections.Generic;
using System.Linq;

namespace SeatingManagement
{
    public class SeatRow
    {
        public SeatRow(int rowId)
        {
            RowId = rowId;
        }
        public int RowId { get; }
        public IList<RowSection> Sections { get; } = new List<RowSection>();
        public int TotalVacant { get => Sections.Sum(section => section.SeatVacant); }
    }
}
