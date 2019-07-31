namespace SeatingManagement
{
    public class RowSection
    {
        public RowSection(int sectionId, int seatCount)
        {
            SectionId = sectionId;
            SeatCount = seatCount;
            SeatVacant = seatCount;
        }
        public int SeatCount { get; }
        public int SectionId { get; set; }
        public int SeatVacant { get; set; }
    }
}
