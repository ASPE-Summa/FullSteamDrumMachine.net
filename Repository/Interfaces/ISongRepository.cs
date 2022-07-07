using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Repository.Exceptions;

namespace FullSteamDrumMachine.net.Repository.Interfaces
{
    public interface ISongRepository : IDatabaseInteraction<Song>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="songName"></param>
        /// <exception cref="DataPersistanceException"></exception>
        void createSong(string songName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="song"></param>
        /// <param name="bpmValue"></param>
        /// <exception cref="DataPersistanceException"></exception>
        void updateBpm(Song song, int bpmValue);
    }
}
