using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Repository.Exceptions;

namespace FullSteamDrumMachine.net.Service.Interfaces
{
    public interface IMusicPlayer
    {
        //Sequencer getSequencer() throws MidiUnavailableException;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="song"></param>
        /// <exception cref="DataRetrievalException"></exception>
        public void playSong(Song song);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bpm"></param>
        /// <param name="measure"></param>
        /// <exception cref="DataRetrievalException"></exception>
        public void playMeasure(int bpm, Measure measure);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void playNote(int value);

    }
}
