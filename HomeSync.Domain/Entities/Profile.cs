using HomeSync.Domain.Common;

namespace HomeSync.Domain.Entities
{
    public class Profile(long id, string name, string description) : Entity(id)
    {
        public string Name { get; private set; } = name;

        public string Description { get; private set; } = description;

        public List<ProfileRule> ProfileRulesList { get; private set; } = [];

        public void AddProfileRule(ProfileRule rule)
        {
            ProfileRulesList.Add(rule);
        }

        public void RemoveProfileRule(ProfileRule rule)
        {
            ProfileRulesList.Remove(rule);
        }
    }
}
