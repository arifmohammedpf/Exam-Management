using System.Collections.Generic;

namespace Exam_Cell
{
    public class Undo_backup
    {
        public static List<string> Date { get; set; } = new List<string>();
        public static List<string> Session { get; set; } = new List<string>();
        public static List<string> Examcode { get; set; } = new List<string>();
        public static List<string> Semester { get; set; } = new List<string>();
        public static List<string> Branch { get; set; } = new List<string>();
    }
}
