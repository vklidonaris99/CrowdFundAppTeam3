
namespace CrowdFoundAppTeam3.Domain
{
    public class Backer
    {
        public PaymentMethod PaymentMethod { get; set; }


        public int BackerId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public List<Project>? Projects { get; set; }
    }
}

