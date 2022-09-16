namespace DTOModel
{
    using System;
    using System.Collections.Generic;

    public partial class DTO_BOOK_Bookings
    {
        public string PatientName { get; set; }
        public string PatientCode { get; set; }
        public string PatientPhone { get; set; }
        public string PatientEmailAddress { get; set; }
        public string PatientDOB { get; set; }
        public Nullable<bool> PatientGender { get; set; }
        public bool IsCreateAccount { get; set; }
    }

    public class DTO_BOOK_AvailbleDoctorTime
    {
        public int IDBranch { get; set; }
        public Nullable<int> IDDoctor { get; set; }
        public DateTime Date { get; set; }
        public List<pickTime> Times { get; set; }
    }

    public class pickTime
    {
        /// <summary>
        /// Thời gian
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Số lượng đã đặt hẹn khám thường
        /// </summary>
        public int CountRegularBook { get; set; }
        /// <summary>
        /// Số lượng đã đặt hẹn khám mổ
        /// </summary>
        public int CountSurgeryBook { get; set; }
        /// <summary>
        /// Tổng số lượng khám thường có thể đặt
        /// </summary>
        public int AvailbleRegularBook { get; set; }
        /// <summary>
        /// Tổng số lượng khám mổ có thể đặt
        /// </summary>
        public int AvailbleSurgeryBook { get; set; }
    }

}