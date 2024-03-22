using HomeSync.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSync.Domain.Entities
{
    public class Profile(long id, string name, string description, long profileRuleId) : Entity(id)
    {
        public string Name { get; private set; } = name;

        public string Description { get; private set; } = description;

        public long ProfileRuleId { get; private set; } = profileRuleId;
        [ForeignKey("ProfileRuleId")]
        public ProfileRule? ProfileRule { get; set; }

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
