using Selu383.SP25.Api.Data.Base;

namespace Selu383.SP25.Api.Entity
{
    public class Theater : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int SeatCount
        {
            get; set;
        }
    }
}
