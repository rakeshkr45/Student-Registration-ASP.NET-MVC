using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentReg.Models
{
    public class StudentView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string College { get; set; }
    }
}
