public class DataHolder
{
    private int _selectedPicture;
    private int _selectedDifficulty;

    public void SetPicture(int picture)
    {
        _selectedPicture = picture;
    }

    public void SetDifficulty(int difficulty)
    {
        _selectedDifficulty = difficulty;
    }

    public int GetPicture()
        => _selectedPicture;

    public int GetDifficulty()
        => _selectedDifficulty;
}
