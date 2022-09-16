using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class BranchWorkingHours
    {
        public TShift T2 { get; set; }
        public TShift T3 { get; set; }
        public TShift T4 { get; set; }
        public TShift T5 { get; set; }
        public TShift T6 { get; set; }
        public TShift T7 { get; set; }
        public TShift CN { get; set; }
    }

    public class TShift
    {
        public bool Availble { get; set; }
        public Nullable<TimeSpan> MorningBegin { get; set; }
        public Nullable<TimeSpan> MorningEnd { get; set; }
        public Nullable<TimeSpan> AfternoonBegin { get; set; }
        public Nullable<TimeSpan> AfternoonEnd { get; set; }
        public Nullable<TimeSpan> EverningBegin { get; set; }
        public Nullable<TimeSpan> EverningEnd { get; set; }
    }

}


//{
//    T2:{Availble: true, MorningBegin: '08:00', MorningEnd: '12:00', AfternoonBegin:'13:00', AfternoonEnd:'19:00'},
//    T3:{Availble: true, MorningBegin: '08:00', MorningEnd: '12:00', AfternoonBegin:'13:00', AfternoonEnd:'19:00'},
//    T4:{Availble: true, MorningBegin: '08:00', MorningEnd: '12:00', AfternoonBegin:'13:00', AfternoonEnd:'19:00'},
//    T5:{Availble: true, MorningBegin: '08:00', MorningEnd: '12:00', AfternoonBegin:'13:00', AfternoonEnd:'19:00'},
//    T6:{Availble: true, MorningBegin: '08:00', MorningEnd: '12:00', AfternoonBegin:'13:00', AfternoonEnd:'19:00'},
//    T7:{Availble: true, MorningBegin: '08:00', MorningEnd: '12:00', AfternoonBegin:'13:00', AfternoonEnd:'19:00'},
//    CN:{Availble: false, MorningBegin: '08:00', MorningEnd: '12:00', AfternoonBegin:'13:00', AfternoonEnd:'19:00'},
//}