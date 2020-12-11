using System.Collections.Generic;

namespace Exam_Cell
{
    public class Undo_backup
    {
        public static List<string> date { get; set; } = new List<string>();
        public static List<string> session { get; set; } = new List<string>();
        public static List<string> examcode { get; set; } = new List<string>();
        public static List<string> semester { get; set; } = new List<string>();
        public static List<string> branch { get; set; } = new List<string>();
    }
}
