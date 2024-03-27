using USync.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USync.Domain.Entities
{
    public class ProfileRule(string description) : Entity()
    {
        public string Description { get; private set; } = description;
    }
}
