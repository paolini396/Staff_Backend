using Staff_Backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace Staff_Backend.Models
{
    public class StaffModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DepartamentEnum Departament { get; set; }
        public bool Active { get; set; }
        public TurnEnum Turn { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime UpdateAt { get; set; } = DateTime.Now.ToLocalTime();

        public static implicit operator StaffModel(List<StaffModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
