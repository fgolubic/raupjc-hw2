﻿using System;
using System.Runtime.Serialization;

namespace Todo
{
    [Serializable]
    internal class DuplicateTodoItemException : Exception
    {
        private string v;
        private Guid id;

        public DuplicateTodoItemException()
        {
        }

        public DuplicateTodoItemException(string message) : base(message)
        {
        }

       

        public DuplicateTodoItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateTodoItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}