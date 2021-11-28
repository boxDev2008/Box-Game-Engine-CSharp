using NAudio.Wave;

namespace BoxEngine.Audio
{
    public static class GameAudioManager
    {
        private static WaveOut backgroundMusic = null!;

        public static WaveOut PlaySound(GameSound gameSound, float volume = 1f)
        {
            var waveOut = new WaveOut();
            waveOut.Init(gameSound.waveReader);
            waveOut.Volume = volume;
            waveOut.Play();
            return waveOut;
        }

        public static WaveOut SetMusic(GameSound gameSound, float volume = 1f)
        {
            backgroundMusic = new WaveOut();
            backgroundMusic.Init(gameSound.waveReader);
            backgroundMusic.Volume = volume;
            backgroundMusic.Play();
            return backgroundMusic;
        }
    }

    public class GameSound
    {
        public WaveFileReader waveReader = null!;

        public GameSound(string filePath)
        {
            waveReader = new WaveFileReader(filePath);
        }
    }
}