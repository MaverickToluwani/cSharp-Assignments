using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackObject
{
    public interface IStack
    {
        /// <summary>
        /// Push: Adds an object to an array of objects
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="InvalidOperationException"></exception>
        void Push(object obj);

        /// <summary>
        /// Pop: Removes the last object placed in the array
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        object Pop();

        /// <summary>
        /// Clear: Removes all objects in array
        /// </summary>
        void Clear();

        /// <summary>
        /// DisplayArray: Displayes all elements in the array
        /// </summary>
        void DisplayArray();
    }
}
