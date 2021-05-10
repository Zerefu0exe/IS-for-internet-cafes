namespace Cursovaya2ISP.db
{
    class DataUser
    {
        public string SessionStart { get; }
        public string SessionEnd { get; }
        public string Date { get; }
        public string PC { get; }
        public string StaffName { get; }
        public string StaffSurname { get; }
        public string Position { get; }

        public DataUser(string SessionStart, string SessionEnd, string Date, string PC, string StaffName, string StaffSurname, string Position)
        {
            this.SessionStart = SessionStart;
            this.SessionEnd = SessionEnd;
            this.Date = Date;
            this.PC = PC;
            this.StaffName = StaffName;
            this.StaffSurname = StaffSurname;
            this.Position = Position;
        }
    }
}
