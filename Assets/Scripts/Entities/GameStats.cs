using System.Collections.Generic;
using System.Linq;

public class GameStats
{
    private List<Resource> _resources;

    public GameStats()
    {
        _resources = new List<Resource>()
        {
            new Coin(),
            new Crystal(),
            new Stone()
        };
    }

    public Resource GetResource(ResourceType resourceType)
    {
        return _resources.Where(r => r.ResourceType == resourceType).FirstOrDefault();
    }
}