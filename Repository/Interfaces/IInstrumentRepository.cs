using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Repository.Exceptions;
using System;
using System.Collections.Generic;

namespace FullSteamDrumMachine.net.Repository.Interfaces
{
    public interface IInstrumentRepository : IDatabaseInteraction<Instrument>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="midiNumber"></param>
        /// <returns></returns>
        /// <exception cref="DataPersistanceException"></exception>
        Instrument createInstrument(string name, int midiNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        /// <exception cref="DataRetrievalException"></exception>
        ICollection<Instrument> fetchForMeasure(Measure measure);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        /// <exception cref="DataRetrievalException"></exception>
        ICollection<Instrument> fetchReuseOptionCollection(Measure measure);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instrument"></param>
        /// <param name="measure"></param>
        /// <exception cref="DataPersistanceException"></exception>
        void addToMeasure(Instrument instrument, Measure measure);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure"></param>
        /// <param name="instrument"></param>
        /// <param name="encodedBeat"></param>
        /// <exception cref="DataPersistanceException"></exception>
        void updateBeat(Measure measure, Instrument instrument, String encodedBeat);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure"></param>
        /// <param name="instrument"></param>
        /// <exception cref="DataRemovalException"></exception>
        void removeFromMeasure(Measure measure, Instrument instrument);

    }
}
