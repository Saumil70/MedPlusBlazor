using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedPlusBlazor.Models
{
    public class SearchModel
    {
        public List<Data> Result { get; set; }
        public bool Success { get; set; }
    }
    public class Data
    {
        public List<string> Heading { get; set; }
        public List<string> Description { get; set; }
    }
}
