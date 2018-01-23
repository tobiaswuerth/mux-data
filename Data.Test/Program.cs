using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.mux.Data.models;
using ch.wuerth.tobias.mux.Data.models.shadowentities;
using Microsoft.EntityFrameworkCore;

namespace ch.wuerth.tobias.mux.Data.Test
{
    internal class Program
    {
        private static readonly HashSet<Type> _types = new HashSet<Type>
        {
            typeof(Track)
            , typeof(User)
            , typeof(Track)
            , typeof(AcoustId)
            , typeof(AcoustIdResult)
            , typeof(MusicBrainzRecord)
            , typeof(MusicBrainzRelease)
            , typeof(MusicBrainzReleaseEvent)
            , typeof(MusicBrainzAlias)
            , typeof(MusicBrainzArea)
            , typeof(MusicBrainzArtist)
            , typeof(MusicBrainzArtistCredit)
            , typeof(MusicBrainzIsoCode)
            , typeof(MusicBrainzTag)
            , typeof(MusicBrainzTextRepresentation)
            , typeof(MusicBrainzRecordAcoustId)
            , typeof(MusicBrainzAliasMusicBrainzRecord)
            , typeof(MusicBrainzArtistCreditMusicBrainzRecord)
            , typeof(MusicBrainzArtistMusicBrainzAlias)
            , typeof(MusicBrainzIsoCodeMusicBrainzArea)
            , typeof(MusicBrainzReleaseEventMusicBrainzRelease)
            , typeof(MusicBrainzReleaseMusicBrainzAlias)
            , typeof(MusicBrainzReleaseMusicBrainzArtistCredit)
            , typeof(MusicBrainzReleaseMusicBrainzRecord)
            , typeof(MusicBrainzTagMusicBrainzRecord)
        };

        private Program()
        {
            using (DataContext dc = new DataContext(new DbContextOptions<DataContext>()))
            {
                LoggerBundle.Debug("Trying to load data of every model type...");

                foreach (Type t in _types)
                {
                    LoggerBundle.Trace($"Loading data for set of type '{t.Name}'...");
                    MethodInfo setMethod = dc.GetType().GetMethods().First(x => x.Name.Equals("Set"));
                    MethodInfo setMethodGeneric = setMethod.MakeGenericMethod(t);
                    Object set = setMethodGeneric.Invoke(dc, new Object[] { });
                    MethodInfo methodLoad = typeof(EntityFrameworkQueryableExtensions).GetMethods()
                        .First(x => x.Name.Equals("Load"));
                    MethodInfo methodLoadGeneric = methodLoad.MakeGenericMethod(t);
                    methodLoadGeneric.Invoke(set
                        , new[]
                        {
                            set
                        });

                    dc.SetTracks.Load();
                    LoggerBundle.Trace("Loading data done.");
                }

                LoggerBundle.Debug("Done.");
            }
        }

        private static void Main(String[] args)
        {
            try
            {
                new Program();
            }
            catch (Exception ex)
            {
                LoggerBundle.Error(ex);
            }

#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}