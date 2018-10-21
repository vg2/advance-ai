using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Evolution
{
    public class Team
    {
        public Team(string name, List<OrigamiRobot> robots)
        {
            Name = name;
            Robots = robots;
        }

        public string Name { get; private set; }
        public List<OrigamiRobot> Robots { get; private set; }

        public void InitRobots()
        {
            throw new NotImplementedException();
        }
    }
}
