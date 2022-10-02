using System;

namespace Domain.Entities
{
    public class BaseClassifier : CoreDomain.Domain.BaseClassifier
    {
        public BaseClassifier(int id, string name, DateTime computed) : base(id, name, computed)
        {
        }
    }
}
