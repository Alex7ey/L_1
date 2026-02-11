using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Infrastructure
{
    public class DIContainer
    {
        public readonly Dictionary<Type, Registration> _container = new();
        private readonly DIContainer _parent; 

        public DIContainer(DIContainer container = null)
        {
            _parent = container;
        }
       
        public void RegisterAsSingle<T>(Func<DIContainer, T> creator)
        {
            Registration registration = new(container => creator.Invoke(container));
            _container.Add(typeof(T), registration);
        }

        public T Resolve<T>()
        {
            if (_container.TryGetValue(typeof(T), out Registration registration))
                return (T)registration.CreateInstanceFrom(this);

            throw new InvalidOperationException($"Rigistartion for {typeof(T)} not exists");
        }
    }
}
