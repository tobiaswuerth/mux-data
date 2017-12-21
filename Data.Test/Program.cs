using System;
using System.Collections.Generic;
using System.Linq;
using ch.wuerth.tobias.mux.Core.events;
using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.mux.Core.logging.exception;
using ch.wuerth.tobias.mux.Core.logging.information;
using ch.wuerth.tobias.mux.Data.models;
using ch.wuerth.tobias.mux.Data.models.shadowentities;
using Microsoft.EntityFrameworkCore;

namespace ch.wuerth.tobias.mux.Data.Test
{
    internal class Program : ICallback<Exception>
    {
        public Program()
        {
            using (DataContext dc = new DataContext(new DbContextOptions<DataContext>(),
                new LoggerBundle
                {
                    Exception = new ExceptionConsoleLogger(this),
                    Information = new InformationConsoleLogger(null)
                }))
            {

                List<User> a = dc.SetUsers.ToList();
                List<Track> b = dc.SetTracks.ToList();
                List<AcoustId> c = dc.SetAcoustIds.ToList();
                List<MusicBrainzRecordAcoustId> z = dc.SetMusicBrainzRecordAcoustId.ToList();
                List<AcoustIdResult> d = dc.SetAcoustIdResults.ToList();
                List<MusicBrainzRecord> e = dc.SetMusicBrainzRecords.ToList();
                List<MusicBrainzRelease> f = dc.SetReleases.ToList();
                List<MusicBrainzReleaseEvent> g = dc.SetReleaseEvents.ToList();
                List<MusicBrainzAlias> h = dc.SetAliases.ToList();
                List<MusicBrainzArea> i = dc.SetAreas.ToList();
                List<MusicBrainzArtist> j = dc.SetArtists.ToList();
                List<MusicBrainzArtistCredit> k = dc.SetArtistCredits.ToList();
                List<MusicBrainzIsoCode> l = dc.SetIsoCodes.ToList();
                List<MusicBrainzTag> m = dc.SetTags.ToList();
                List<MusicBrainzTextRepresentation> n = dc.SetTextRepresentations.ToList();
            }
        }

        public void Push(Exception arg)
        {
            Console.WriteLine($"Exception: {arg.Message}");
        }

        private static void Main(String[] args)
        {
            new Program();
        }
    }
}