namespace Bilet2._2.ViewModels.TeamMemberViewModels
{
    public class TeamUpdateVM
    {
        public TeamGetVM TeamGet { get; set; }
        public TeamPostVM TeamPost { get; set; }
        public TeamUpdateVM()
        {
            TeamPost = new TeamPostVM();
        }
    }
}
