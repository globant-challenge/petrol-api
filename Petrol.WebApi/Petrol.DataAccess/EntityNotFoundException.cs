﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Petrol.DataAccess
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected EntityNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
