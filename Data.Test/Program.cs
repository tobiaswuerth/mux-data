using System;
using System.Collections.Generic;
using System.Linq;
using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.mux.Data.models;
using ch.wuerth.tobias.mux.Data.models.shadowentities;
using Microsoft.EntityFrameworkCore;

namespace ch.wuerth.tobias.mux.Data.Test
{
    internal class Program 
    {
        public Program()
        {
            using (DataContext dc = new DataContext(new DbContextOptions<DataContext>()))
            {
                List<User> a = dc.SetUsers.ToList();
                List<Track> b = dc.SetTracks.ToList();
                List<AcoustId> c = dc.SetAcoustIds.ToList();
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

                // shadow entities
                List<MusicBrainzRecordAcoustId> z = dc.SetMusicBrainzRecordAcoustId.ToList();
                List<MusicBrainzAliasMusicBrainzRecord> w = dc.SetMusicBrainzAliasMusicBrainzRecord.ToList();
                List<MusicBrainzArtistCreditMusicBrainzRecord> o = dc.SetMusicBrainzArtistCreditMusicBrainzRecord.ToList();
                List<MusicBrainzArtistMusicBrainzAlias> p = dc.SetMusicBrainzArtistMusicBrainzAlias.ToList();
                List<MusicBrainzIsoCodeMusicBrainzArea> q = dc.SetMusicBrainzIsoCodeMusicBrainzArea.ToList();
                List<MusicBrainzReleaseEventMusicBrainzRelease> r = dc.SetMusicBrainzReleaseEventMusicBrainzRelease.ToList();
                List<MusicBrainzReleaseMusicBrainzAlias> s = dc.SetMusicBrainzReleaseMusicBrainzAlias.ToList();
                List<MusicBrainzReleaseMusicBrainzArtistCredit> t = dc.SetMusicBrainzReleaseMusicBrainzArtistCredit.ToList();
                List<MusicBrainzReleaseMusicBrainzRecord> u = dc.SetMusicBrainzReleaseMusicBrainzRecord.ToList();
                List<MusicBrainzTagMusicBrainzRecord> v = dc.SetMusicBrainzTagMusicBrainzRecord.ToList();
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