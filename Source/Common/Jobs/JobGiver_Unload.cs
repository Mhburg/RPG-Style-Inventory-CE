﻿// <copyright file="JobGiver_Unload.cs" company="Zizhen Li">
// Copyright (c) Zizhen Li. All rights reserved.
// Licensed under the GPL-3.0-only license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Linq;
using RimWorld;
using Verse;
using Verse.AI;

namespace AwesomeInventory.Common
{
    public class JobGiver_RPGIUnload : ThinkNode_JobGiver
    {
        private Thing _thing;
        public static bool JobInProgress = false;

        // TODO need to add code for thing with count
        private JobGiver_RPGIUnload(Thing t)
        {
            _thing = t;
        }

        protected override Job TryGiveJob(Pawn pawn)
        {
            if (JobInProgress)
            {
                Job fakeJob = new Job(AwesomeInventory_JobDefOf.RPGI_Fake)
                {
                    playerForced = true
                };
                return fakeJob;
            }
            Job job = HaulAIUtility.HaulToStorageJob(pawn, _thing);
            if (job == null)
            {
                Messages.Message("NoEmptyPlaceLower".Translate(),
                    new TargetInfo(pawn.PositionHeld, pawn.MapHeld), MessageTypeDefOf.NeutralEvent);
                return null;
            }
            job.def = AwesomeInventory_JobDefOf.RPGI_Unload;

            return job;
        }

        public static Job TryGiveJobStatic(Pawn pawn, Thing thing)
        {
            if (JobInProgress)
            {
                Job fakeJob = new Job(AwesomeInventory_JobDefOf.RPGI_Fake, thing)
                {
                    playerForced = true
                };
                return fakeJob;
            }
            Job job = HaulAIUtility.HaulToStorageJob(pawn, thing);
            if (job == null)
            {
                Messages.Message("NoEmptyPlaceLower".Translate(),
                    new TargetInfo(pawn.PositionHeld, pawn.MapHeld), MessageTypeDefOf.NeutralEvent);
                return null;
            }
            job.def = AwesomeInventory_JobDefOf.RPGI_Unload;
            job.playerForced = true;

            return job;
        }

        internal static void QueueJob(Pawn pawn, Job job)
        {
            if (job != null)
            {
                if (JobInProgress)
                {
                    pawn.jobs.jobQueue.EnqueueLast(job, JobTag.UnloadingOwnInventory);
                }
                else
                {
                    // TODO check constant thinknode before stop jobs
                    pawn.jobs.StopAll();
                    pawn.jobs.jobQueue.EnqueueFirst(job, JobTag.UnloadingOwnInventory);
                    JobInProgress = true;
                }
            }
        }
    }
}
