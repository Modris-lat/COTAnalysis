using System.Collections.Generic;
using CoreLibrary.Interfaces;

namespace CoreLibrary.Services
{
    public class ServiceResult
    {
        public bool Succeeded { get; private set; }
        public int Id { get; }
        public IEntity Entity { get; private set; }
        public IEnumerable<string> Errors = new List<string>();

        public ServiceResult Set(IEnumerable<string> errors)
        {
            Errors = errors;
            return this;
        }

        public ServiceResult(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public ServiceResult(int id, bool succeeded)
        {
            Id = id;
            Succeeded = succeeded;
        }

        public ServiceResult Set(IEntity entity)
        {
            Entity = entity;
            return this;
        }
    }
}
