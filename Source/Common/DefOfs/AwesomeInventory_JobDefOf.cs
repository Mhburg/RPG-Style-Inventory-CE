﻿// <copyright file="AwesomeInventory_JobDefOf.cs" company="Zizhen Li">
// Copyright (c) Zizhen Li. All rights reserved.
// Licensed under the GPL-3.0-only license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace AwesomeInventory.Common
{
    /// <summary>
    /// Job def provided by AwesomeInventory.
    /// </summary>
    [DefOf]
    [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Follow naming convention in RimWorld.")]
    public static class AwesomeInventory_JobDefOf
    {
#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1310 // Field names should not contain underscore
#pragma warning disable CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// Unload inventory.
        /// </summary>
        public static JobDef RPGI_Unload;

        /// <summary>
        /// Placeholder in job queue for <see cref="RPGI_Unload"/>.
        /// </summary>
        public static JobDef RPGI_Fake;

        /// <summary>
        /// 
        /// </summary>
        public static JobDef RPGI_ApparelOptions;

        /// <summary>
        /// Equip items from map.
        /// </summary>
        public static JobDef RPGI_Map_Equip;

#pragma warning restore CA2211 // Non-constant fields should not be visible
#pragma warning restore SA1310 // Field names should not contain underscore
#pragma warning restore SA1401 // Fields should be private

        static AwesomeInventory_JobDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(AwesomeInventory_JobDefOf));
        }
    }
}
