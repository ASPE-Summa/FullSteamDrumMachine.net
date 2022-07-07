using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Repository.Exceptions;
using System.Collections.Generic;

namespace FullSteamDrumMachine.net.Repository.Interfaces
{
    internal interface IMeasureRepository : IDatabaseInteraction<Measure>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        /// <exception cref="DataPersistanceException"></exception>
       public Measure createMeasure(Measure measure);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        /// <exception cref="DataRetrievalException"></exception>
       public ICollection<SongMeasure> fetchForSong(Song song);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure"></param>
        /// <param name="song"></param>
        /// <param name="sequence"></param>
        /// <exception cref="DataPersistanceException"></exception>
        public void addToSong(Measure measure, Song song, int sequence);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="songMeasure"></param>
        /// <exception cref="DataRemovalException"></exception>
        public void removeFromSong(SongMeasure songMeasure);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        /// <exception cref="DataRetrievalException"></exception>
        public int countUseages(Measure measure);
    }
}
