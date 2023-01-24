namespace Bilet2._2.ViewModels.TeamMemberViewModels
{
    public class TeamPostVM
    {
        public string Name { get; set; }
        public string Prefession { get; set; }
        public string Description { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public IFormFile? formFile { get; set; }
    }
}
