using BoxEngine.Graphics;

public class AssetsManager
{
    public static Texture spr_sheet_player;
    
    public static Texture spr_cursor;
    
    public static Texture spr_sheet_slime;

    public AssetsManager()
    {
        spr_sheet_player = new Texture(@"sprites/spr_sheet_player.png");
        spr_cursor = new Texture(@"sprites/spr_cursor.png");
        spr_sheet_slime = new Texture(@"sprites/spr_sheet_slime.png");
    }
}