public class GameOptions
{
    public float gamma;          // Гамма
    public float brightness;      // Герцовка
    public bool vsync;           // Vsync

    public GameOptions(float gamma, float brightness, bool vsync)
    {
        this.gamma = gamma;
        this.brightness = brightness;
        this.vsync = vsync;
    }

    // Конструктор по умолчанию
    public GameOptions()
    {
        gamma = 1.0f;
        brightness = 1f;
        vsync = false;
    }
}