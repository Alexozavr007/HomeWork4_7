using System;

class MusicEngine {

    [Obsolete("This method is deprecated", true)]
    public void PlayMusic(string filePath) {
        Console.WriteLine("This is the old method");
    }

    [Obsolete("Not recommended to use. Use 'PlayMusic' method with 3 arguments")]
    public void PlayMusic(string filePath, int format) {
        Console.WriteLine("This is the new method");
    }

    public void PlayMusic(string filePath, int format, bool autoRepeat) {
    }
}

class Program {
    static void Main() {
        MusicEngine music = new MusicEngine();
        //music.PlayMusic(@"c:\Jackson.mp3"); // Виклик старого методу, викликає помилку компіляції

        music.PlayMusic(@"c:\Jackson.mp3", 123); // Виклик методу з попередженням

        music.PlayMusic(@"c:\Jackson.mp3", 123, true); 
    }
}
