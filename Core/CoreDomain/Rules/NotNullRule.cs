using CoreBussines.Rule;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDomain.Rules
{
    public class NotNullRule<T> : IBusinessRule
    {
        private readonly T value;

        public NotNullRule(T value)
        {
            this.value = value;
        }

        public string Message => "El valor " + typeof(T).Name + " no puede ser nulo";

        public bool IsBroken()
        {
            return value == null;
        }
    }
}
