namespace Assets.Scripts.Evolution.ClonalSelection
{
    public interface IClonalSelection
    {
        Team Execute(Team antibodyTeam, Team antigenTeam);
    }
}