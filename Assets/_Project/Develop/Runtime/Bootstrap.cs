using Assets._Project.Develop.Runtime.Infrastructure;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime
{
    public abstract class Bootstrap : MonoBehaviour
    {
        public abstract void ProcessRegistrations(DIContainer container);

        public abstract IEnumerator Initialize();

        public abstract void Run();
    }
}
