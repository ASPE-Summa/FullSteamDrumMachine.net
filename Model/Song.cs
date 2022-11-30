using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FullSteamDrumMachine.net.Model
{
    public class Song
    {
        private int songId;
        public int SongId { get { return songId; }}

        private string name;
        public string Name { get { return name; }}

        private int bpm;
        public int Bpm { get { return bpm; }}

        public Song(int songId, string name, int bpm)
        {
            this.songId = songId;
            this.name = name;
            this.bpm = bpm;
        }


        public void showMessageBox()
        {
            MessageBox.Show(name);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
