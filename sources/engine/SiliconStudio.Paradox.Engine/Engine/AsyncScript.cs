// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System.Threading.Tasks;
using SiliconStudio.Core;
using SiliconStudio.Core.MicroThreading;

namespace SiliconStudio.Paradox.Engine
{
    /// <summary>
    /// A script which can be implemented as an async microthread.
    /// </summary>
    public abstract class AsyncScript : Script
    {
        [DataMemberIgnore]
        internal MicroThread MicroThread;

        /// <summary>
        /// Called once, as a microthread
        /// </summary>
        /// <returns></returns>
        public abstract Task Execute();

        protected internal override void PriorityUpdated()
        {
            base.PriorityUpdated();

            // Update micro thread priority
            if (MicroThread != null)
                MicroThread.Priority = Priority;
        }
    }
}