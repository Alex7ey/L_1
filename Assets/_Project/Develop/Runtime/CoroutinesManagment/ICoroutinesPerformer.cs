using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime
{
    public interface ICoroutinesPerformer
    {
        public Coroutine StartPerform(IEnumerator coroutineFunction);

        public void StopPerform(Coroutine coroutine); 
    }
}
