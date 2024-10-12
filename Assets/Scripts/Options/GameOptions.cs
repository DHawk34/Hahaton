public class GameOptions
{
    public float gamma;          // Гамма
    public int refreshRate;      // Герцовка
    public bool vsync;           // Vsync

    public GameOptions(float gamma, int refreshRate, bool vsync)
    {
        this.gamma = gamma;
        this.refreshRate = refreshRate;
        this.vsync = vsync;
    }

    // Конструктор по умолчанию
    public GameOptions()
    {
        gamma = 1.0f;
        refreshRate = 60;
        vsync = false;
    }
}