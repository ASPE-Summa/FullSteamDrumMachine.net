using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Service.Interfaces;
using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Service
{
    public class MusicPlayer : IMusicPlayer
    {
        MidiOut midiOutput = new MidiOut(0);
       
        public void playMeasure(int bpm, Measure measure)
        {
            throw new NotImplementedException();
        }

        public void playNote(int value)
        {
            MidiOut.DeviceInfo(0);
            MidiEvent midi = new MidiEvent(0,1,MidiCommandCode.NoteOn);
            int delta = midi.DeltaTime;
            throw new NotImplementedException();
        }

        public void playSong(Song song)
        {
            throw new NotImplementedException();
        }
    }
}
