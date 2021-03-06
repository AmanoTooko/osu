﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Linq;
using osu.Framework.Audio.Track;
using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Beatmaps
{
    public partial class WorkingBeatmap
    {
        /// <summary>
        /// A type of <see cref="TrackVirtual"/> which provides a valid length based on the <see cref="HitObject"/>s of an <see cref="IBeatmap"/>.
        /// </summary>
        protected class VirtualBeatmapTrack : TrackVirtual
        {
            private const double excess_length = 1000;

            public VirtualBeatmapTrack(IBeatmap beatmap)
            {
                var lastObject = beatmap.HitObjects.LastOrDefault();

                switch (lastObject)
                {
                    case null:
                        Length = excess_length;
                        break;
                    case IHasEndTime endTime:
                        Length = endTime.EndTime + excess_length;
                        break;
                    default:
                        Length = lastObject.StartTime + excess_length;
                        break;
                }
            }
        }
    }
}
